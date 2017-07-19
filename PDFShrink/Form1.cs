using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PDFShrink
{
    /// <summary>
    /// This is the only GUI frame
    /// </summary>
    public partial class Form1 : Form
    {
        private string cwd = "";//holds current working directory
        private List<string> pdfs = new List<string>(); // list of found pdf files
        private string originalPrinter = "";
        private string currentPrinter = "";

        /// <summary>
        /// Fetches a list of all available printer, writes the list to listbox, and
        /// highlights the current default printer
        /// </summary>
        private void listAllPrinters()
        {
            foreach (var item in PrinterSettings.InstalledPrinters)//add printers to the list box
            {
                this.listBox1.Items.Add(item.ToString());
            }

            originalPrinter = new PrinterSettings().PrinterName;//get default printer
            currentPrinter = originalPrinter;
            tbConsole.AppendText("Default printer is " + currentPrinter + "\n"); 
            this.listBox1.SelectedIndex = this.listBox1.FindString(currentPrinter);//select default printer
        }

        /// <summary>
        /// static anon (inner) class to set the default printer with
        /// </summary>
        public static class myPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);

        }

        /// <summary>
        /// Form (frame) constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();// build gui
            listAllPrinters();//load printer list
            btnFlatten.Hide();
            btnCont.Hide();
        }

        /// <summary>
        /// Listens for directory button to be clicked, uses folder dialog and sets
        /// cwd (current working directory) global, unhides flatten button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = "T:\\New Plan Document Roll Out\\Plan Document roll out\\School Districts";
            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cwd = fbd.SelectedPath;
                lblDirectory.Text = cwd;
            }

            if(cwd != null && cwd != "")//if directory is choosen, enable flatten button.
            {
                btnFlatten.Show();
            }

            tbConsole.AppendText("CWD: " + cwd + "\n");
            GetPDFfiles(cwd);

            if (pdfs.Capacity < 1)//check if pdf files were found
            {
                ResetGUI();
                lblDirectory.Text = "Last directory empty, select another";
            }
        }

        /// <summary>
        /// Load a list of pdf files from the given directory into List<string> pdfs
        /// </summary>
        /// <param name="target">Directory to load files from</param>
        /// <returns>true if pdfs were found, false otherwise</returns>
        private bool GetPDFfiles(string target)
        {
            pdfs = new List<string>();

            string[] files = Directory.GetFiles(target);

            foreach(string file in files)
            {
                //if(file.Substring(file.Length - 4) == ".pdf")
                string temp = Path.GetExtension(file).ToLower();
                if (Path.GetExtension(file).ToLower() == ".pdf")
                {
                    pdfs.Add(file);
                    Console.WriteLine(file);
                }
            }
            return pdfs.Capacity > 0;
        }

        /// <summary>
        /// No longer needed
        /// </summary>
        /// <param name="pdfs"></param>
        //private void Flatten(List<string> pdfs)
        //{
        //    foreach(string pdf in pdfs){
        //        string outFile = pdf.Replace(".pdf", "-flat.pdf");
        //        using (var existingFileStream = new FileStream(pdf, FileMode.Open))
        //        {
        //            using (var newFileStream = new FileStream(outFile, FileMode.Create))
        //            {
        //                var pdfReader = new PdfReader(existingFileStream);
        //                var stamper = new PdfStamper(pdfReader, newFileStream);

        //                var form = stamper.AcroFields;

        //                stamper.FormFlattening = true;
        //                stamper.SetFullCompression();
        //                //form.GenerateAppearances = true;
        //                stamper.Close();
        //                pdfReader.RemoveUnusedObjects();
        //                pdfReader.Close();
        //            }
        //        }
        //    }
        //}

        ///<summary>
        ///Sends the file to Adobe with the print verb. Note, function tries to close reader immediately.
        /// </summary>
        /// <param name="file">string of the full path to file to be printed</param>
        private void SendToPrinter(string file)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.Verb = "print";
            info.FileName = file;
            info.CreateNoWindow = true;
            info.WindowStyle = ProcessWindowStyle.Hidden;
            
            Process p = new Process();
            p.StartInfo = info;
            p.Start();

            p.WaitForInputIdle();
            System.Threading.Thread.Sleep(3000);
            if (false == p.CloseMainWindow())
                try
                {
                    p.Kill();
                } catch (Exception e)
                {
                    tbConsole.AppendText("Exception: " + e + "\n");
                    Console.WriteLine(e);
                }

            tbConsole.AppendText("printing " + Path.GetFileName(file) + "\n");
        }

        /// <summary>
        /// On closing the form, revert back to the original default printer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cbResetPrinter.Checked)
            {
                myPrinters.SetDefaultPrinter(originalPrinter);
            }
        }

        /// <summary>
        /// Print the first file in the pdf list, and remove it from the list
        /// </summary>
        private void PrintAndPop()
        {
            SendToPrinter(pdfs.First());
            pdfs.RemoveAt(0);

            if(pdfs.Count == 0)
            {
                btnFlatten.Hide();
                btnCont.Hide();
            }
        }

        /// <summary>
        /// return the form to its inital state
        /// </summary>
        private void ResetGUI()
        {
            btnFlatten.Hide();
            btnCont.Hide();
            lblDirectory.Text = "Please select another directory!";
            tbConsole.AppendText("All files have been processed!\n");
        }

        /// <summary>
        /// This is the button that either prints the first file and loads the continue button or 
        /// prints all the pdf files, depending on the settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFlatten_Click(object sender, EventArgs e)
        {
            btnFlatten.Hide();
            List<string> files = new List<string>();
            string newFile = "";
            string newPath = Path.GetDirectoryName(pdfs.First()) + "\\small_files";

            if (cbMakeDir.Checked) //whether to create the small_files directory
            {
                Console.WriteLine(newPath);
                Directory.CreateDirectory(newPath);
                tbConsole.AppendText("Made dir: " + newPath + "\n");
            }

            if (cbCopyFiles.Checked) //whether to copy the files to the directory
            {
                foreach (string file in pdfs)
                {
                    newFile = newPath + "\\" + Path.GetFileName(file);
                    files.Add(newFile);
                    File.Copy(file, newFile, true);
                }

                pdfs = files;//replace the old file paths with the short_files file paths
            }

            //Here we decide whether we want to print one file and wait or print all.
            //this is implemented for printing to file coverters so the user can
            //point the printer to a certain folder, the next files will default to 
            //that folder, thus allowing the user to skip file browsing.
            if (cbPrintAll.Checked)
            {
                CloseProcesses("AcroRd32");

                foreach (string pdf in pdfs)
                {
                    SendToPrinter(pdf);
                }

                ResetGUI();//back to initial state minus the text box
            }
            else // only print one using Print and Pop
            {
                PrintAndPop();
                btnCont.Hide();
            }
        }

        /// <summary>
        /// Starts the process of printing all remaining pdf files in the pdfs List
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCont_Click(object sender, EventArgs e)
        {
            CloseProcesses("AcroRd32");

            foreach (string pdf in pdfs)
            {
                SendToPrinter(pdf);
            }

            ResetGUI();
        }

        /// <summary>
        /// Changes the default printer to the one selected in printer box tbConsole.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            currentPrinter = this.listBox1.SelectedItem.ToString();
            myPrinters.SetDefaultPrinter(currentPrinter);
            tbConsole.AppendText("changed printer to, " + currentPrinter);
        }

        /// <summary>
        /// Closes all open processes with the name given names
        /// </summary>
        private void CloseProcesses(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);
            for (int i = 0; i < processes.Length; i++)
            {
                Console.WriteLine(processes[i].ProcessName);
                processes[i].CloseMainWindow();
            }
        }

        /// <summary>
        /// Closes all open Adobe Readers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseReaders_Click(object sender, EventArgs e)
        {
            CloseProcesses("AcroRd32");
        }
    }
}
