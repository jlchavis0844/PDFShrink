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
    public partial class Form1 : Form
    {
        private string cwd = "";
        private List<string> pdfs = new List<string>();

        private void listAllPrinters()
        {
            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                this.listBox1.Items.Add(item.ToString());
            }
            string defaultPrinter = new PrinterSettings().PrinterName;
            tbConsole.AppendText("Default printer is " + defaultPrinter + "\n");
            this.listBox1.SelectedIndex = this.listBox1.FindString(defaultPrinter);
        }

        public static class myPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);

        }

        public Form1()
        {
            InitializeComponent();
            listAllPrinters();
            btnFlatten.Hide();
            btnCont.Hide();
        }

        private void btnDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.SelectedPath = "T:\\New Plan Document Roll Out\\Plan Document roll out\\School Districts";
            if(fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cwd = fbd.SelectedPath;
                lblDirectory.Text = cwd;
            }
            if(cwd != null && cwd != "")
            {
                btnFlatten.Show();
            }
            tbConsole.AppendText("CWD: " + cwd + "\n");
        }

        private void GetPDFfiles(string target)
        {
            pdfs = new List<string>();

            string[] files = System.IO.Directory.GetFiles(target);

            foreach(string file in files)
            {
                if(file.Substring(file.Length - 4) == ".pdf")
                {
                    pdfs.Add(file);
                    Console.WriteLine(file);
                }
            }
        }

        private void Flatten(List<string> pdfs)
        {
            foreach(string pdf in pdfs){
                string outFile = pdf.Replace(".pdf", "-flat.pdf");
                using (var existingFileStream = new FileStream(pdf, FileMode.Open))
                {
                    using (var newFileStream = new FileStream(outFile, FileMode.Create))
                    {
                        var pdfReader = new PdfReader(existingFileStream);
                        var stamper = new PdfStamper(pdfReader, newFileStream);

                        var form = stamper.AcroFields;

                        stamper.FormFlattening = true;
                        stamper.SetFullCompression();
                        //form.GenerateAppearances = true;
                        stamper.Close();
                        pdfReader.RemoveUnusedObjects();
                        pdfReader.Close();
                    }
                }
            }
        }

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

        private void btnFlatten_Click(object sender, EventArgs e)
        {
            btnFlatten.Hide();
            btnCont.Show();
            List<string> files = new List<string>();
            string newFile = "";
            GetPDFfiles(cwd);
            string newPath = Path.GetDirectoryName(pdfs.First()) + "\\small_files";

            if (cbMakeDir.Checked)
            {
                Console.WriteLine(newPath);
                System.IO.Directory.CreateDirectory(newPath);
                tbConsole.AppendText("Made dir: " + newPath + "\n");
            }

            if (cbCopyFiles.Checked)
            {
                foreach (string file in pdfs)
                {
                    newFile = newPath + "\\" + Path.GetFileName(file);
                    files.Add(newFile);
                    System.IO.File.Copy(file, newFile, true);
                }

                pdfs = files;
            }
            PrintAndPop();
            lblMsg.Text = "Done Flattening Docs";
        }

        private void btnCont_Click(object sender, EventArgs e)
        {
            CloseProcesses();

            foreach (string pdf in pdfs)
            {
                SendToPrinter(pdf);
            }

            btnFlatten.Hide();
            btnCont.Hide();
            lblDirectory.Text = "Please select another directory!";
            tbConsole.AppendText("All files have been processed!\n");
            tbConsole.AppendText("Closing reader\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pname = this.listBox1.SelectedItem.ToString();
            myPrinters.SetDefaultPrinter(pname);
        }

        private void CloseProcesses()
        {
            Process[] processes = Process.GetProcessesByName("AcroRd32");
            for (int i = 0; i < processes.Length; i++)
            {
                Console.WriteLine(processes[i].ProcessName);
                processes[i].CloseMainWindow();
            }
        }

        private void btnCloseReaders_Click(object sender, EventArgs e)
        {
            CloseProcesses();
        }
    }
}
