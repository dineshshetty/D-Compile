using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Ionic.Zip;
using System.Diagnostics;
using System.Threading;
using System.Resources;
using System.Text.RegularExpressions;

namespace dstry1
{
    public partial class Form1 : Form
    {
        string directoryname = "", thecompletefilename = "";
        int x1 = 1;
        //String currentprogrampath = Environment.CurrentDirectory.ToString();
        public static DirectoryInfo zzz = new DirectoryInfo(Environment.CurrentDirectory);
        String currentprogrampath = zzz.FullName;
        string mainfilename = "";
        string appfilename = "", appactualfilename="";


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //currentprogrampath = Directory.GetCurrentDirectory();
            //String currentprogrampath = Environment.CurrentDirectory.ToString(); // can be used for exe
            //MessageBox.Show("currentprogrampath="+currentprogrampath);
            //Console.Write(currentprogrampath);
            DirectoryInfo zzz = new DirectoryInfo(Environment.CurrentDirectory);
            currentprogrampath = zzz.FullName;
           // MessageBox.Show("currentprogrampath=" + currentprogrampath);

            //currentprogrampath = (Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86).ToString());
            Console.Write(currentprogrampath);
            
            //backgroundWorker1.RunWorkerAsync();
            

        }


        private void browse_button_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();  //required
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
                mainfilename = textBox1.Text;
                //string path = "C:\\stagelist.txt";
                //Console.Write(Path.GetPathRoot(x));
                directoryname = Path.GetDirectoryName(mainfilename);
                Console.Write("directoryname=" + directoryname);
                currentprogrampath = directoryname;  // ----------------------------- Remove in final for SETUP - EXE=-------
            }

            else
            {
                textBox1.Text = "";
            }
        }

        private void decompile_button_Click(object sender, EventArgs e)
        {
            //Shown += new EventHandler(Form1_Shown);
            //backgroundWorker1.RunWorkerAsync();  //required

//            MessageBox.Show(mainfilename);
            thecompletefilename = Path.GetFileName(mainfilename);
            //MessageBox.Show(thecompletefilename); -- blah.cod
            String thefileextension = Path.GetExtension(mainfilename);
            //MessageBox.Show(thefileextension);
            //MessageBox.Show(Path.GetFileName(mainfilename));
            //Match match = Regex.Match(thefiletype, @"content/([A-Za-z0-9\-]+)\.aspx$", RegexOptions.IgnoreCase);

            if (thefileextension == ".apk")
            {
                MessageBox.Show("Android Decompilation");
                apkunzip();
                apkdecompile();
                apkdisplay();
            }
            else if (thefileextension == ".cod")
            {
                MessageBox.Show("Blackberry Decompilation");
                bbdecompile();
                bbdisplay();
            }
            else if (thefileextension == ".ipa")
            {
                MessageBox.Show("iOS Decompilation");
                iosunzip();
                iosdecompile();
                //iosdisplay();
            }

            
            

        }

        
        
        void apkunzip()
        {
            string ExistingZipFile = textBox1.Text;
            Console.Write(ExistingZipFile);
            string TargetDirectory = currentprogrampath + "\\unzipped\\";
            Console.Write(TargetDirectory);
            if (Directory.Exists(TargetDirectory))
            {
                Directory.Delete(currentprogrampath + "\\unzipped\\", true);
            }
            //  MessageBox.Show("TargetDirectory=" + TargetDirectory);
            using (ZipFile zip1 = ZipFile.Read(ExistingZipFile))
            {
                try
                {
                    foreach (ZipEntry a in zip1)
                    {
                        a.Extract(TargetDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                catch (FileNotFoundException E)
                {
                    //Handle the exception here
                }
            }
        }

        void apkdecompile()
        {
            //loading_pic.Visible = true;
            try
            {
                
                Process proc = new Process();
                proc.StartInfo.FileName = currentprogrampath + "\\Extras\\dex2jar\\dex2jar.bat";
                // MessageBox.Show("proc.StartInfo.FileName:" + proc.StartInfo.FileName);
                proc.StartInfo.Arguments = "\"" + currentprogrampath + "\\unzipped\\classes.dex\"";
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                DirectoryInfo currentDir = new DirectoryInfo(Environment.CurrentDirectory);
                proc.StartInfo.WorkingDirectory = currentDir.FullName;

                //backgroundWorker1.RunWorkerAsync();  //required
                proc.Start();
                
                //worker.RunWorkerAsync();   
                //Shown += new EventHandler(Form1_Shown);
                //    MessageBox.Show("Doing");

                //give Processor 5sec to close
                //  proc.WaitForExit(5000000);
                //proc.ExitCode;

                
                while (!proc.HasExited)
                {
                        
                        //Thread.Sleep(1);
                        //System.Timers.Timer MyTimer = new System.Timers.Timer();
                        //MyTimer.Elapsed += new System.Timers.ElapsedEventHandler(MyTimer_Elapsed);
                        //MyTimer.Interval = 1000;
                        //MyTimer.Enabled = true;



                    loading_pic.Visible = true;
                    MessageBox.Show("Decompiling... Please wait, as this might take some time.");
                    //backgroundWorker1.RunWorkerAsync(); //required
                   
                }
                proc.WaitForExit();
                proc.Close();
                MessageBox.Show("Decompilation Complete.");
                
            }
            catch
            {
            }

        
        }

        // void MyTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //  x1=x1+1;
        //  label1.Text = x1.ToString();
        //}

        void apkdisplay()
        {
            loading_pic.Visible = false;
            try
            {
                Process proc = new Process();
                proc.StartInfo.FileName = currentprogrampath + "\\Extras\\jdgui\\jd-gui.exe";

                // MessageBox.Show("proc.StartInfo.FileName--jdgui=" + proc.StartInfo.FileName);
                proc.StartInfo.Arguments = "\"" + currentprogrampath + "\\unzipped\\classes_dex2jar.jar\"";
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardError = true;
                DirectoryInfo currentDir = new DirectoryInfo(Environment.CurrentDirectory);
                proc.StartInfo.WorkingDirectory = currentDir.FullName;
                //   MessageBox.Show(currentDir.FullName);
                proc.Start();
                //give Processor 5sec to close
                // proc.WaitForExit(5000000);
                //proc.ExitCode;
                proc.WaitForExit();
                proc.Close();
                
            }
            catch
            {
            }

        }

        void bbdecompile()
        {
            loading_pic.Visible = true;
            try
            {
                string path = currentprogrampath+"\\doit.bat";
                string text2write = "java.exe -cp" +" "+currentprogrampath+ "\\coddec\\bin net.rim.tools.compiler.Compiler %1 > OUT 2>&1";
                MessageBox.Show(text2write);
                System.IO.StreamWriter writer = new System.IO.StreamWriter(path);
                writer.Write(text2write);
                writer.Close();
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = currentprogrampath + "\\doit.bat";
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.Arguments = thecompletefilename;
                proc.StartInfo.RedirectStandardError = false;
                proc.StartInfo.RedirectStandardOutput = false;
                proc.StartInfo.UseShellExecute = false;
                //DirectoryInfo currentDir = new DirectoryInfo(Environment.CurrentDirectory);
                proc.StartInfo.WorkingDirectory = currentprogrampath;
                //MessageBox.Show(currentDir.FullName);
                proc.Start();
                proc.WaitForExit();
                proc.Close();
                
                
            }
            catch
            {
            }


        }

        void bbdisplay()
        {
            loading_pic.Visible = false;
            try
            {
               
                Process.Start(currentprogrampath + "/decompiled");
               
            }
            catch
            {
            }

        }
        void iosunzip()
        {
            string ExistingZipFile = textBox1.Text;
            Console.Write(ExistingZipFile);
            string TargetDirectory = currentprogrampath + "\\unzipped\\";
            try
            {

                if (Directory.Exists(TargetDirectory))
                {
                    Directory.Delete(currentprogrampath + "\\unzipped\\", true);
                }
            }
            catch
            {
            }

            Console.Write(TargetDirectory);
            //  MessageBox.Show("TargetDirectory=" + TargetDirectory);
            using (ZipFile zip1 = ZipFile.Read(ExistingZipFile))
            {
                try
                {
                    foreach (ZipEntry a in zip1)
                    {
                        a.Extract(TargetDirectory, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
                catch (FileNotFoundException E)
                {
                    //Handle the exception here
                }
            }
        }
        public static string allowenglishcharacter(string str)
        { // Need to find a better way to do this. Regex maybe?
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            { //`!@#$%^&*()_+|\-=\\{}\[\]:"";'<>?,./
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == '-' || c == '$' || c == '/' || c == '\\' || c == '{' || c == '}' || c == '#' || c == '=' || c == '?' || c == '[' || c == ']' || c == '(' || c == ')' || c == ';' || c == ',' || c == '\'' || c == '"' || c == ':' || c == '&' || c == '^')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        void iosdecompile()
        {
            //loading_pic.Visible = true;
            try
            {   //currentprg=classdumpz
                MessageBox.Show(currentprogrampath);
                Process proc = new Process();
                //proc.StartInfo.FileName = "cmd.exe" +" /c tree | find /i"+" "+"\"app\""+"> test.txt";
                System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", " /c tree | find /i" + " " + "\"app\"" + "> test.txt");
                procStartInfo.WorkingDirectory = currentprogrampath + "\\unzipped";
                MessageBox.Show(procStartInfo.WorkingDirectory);
                procStartInfo.CreateNoWindow = false;
                procStartInfo.WindowStyle = ProcessWindowStyle.Normal;
                procStartInfo.UseShellExecute = false;
                System.Diagnostics.Process procz = new System.Diagnostics.Process();
                procz.StartInfo = procStartInfo;
                procz.Start();
                MessageBox.Show("Decompilation Complete.");
                procz.WaitForExit();
                procz.Close();
                string text = System.IO.File.ReadAllText(currentprogrampath + "\\unzipped\\test.txt");
                appfilename = allowenglishcharacter(text);
                MessageBox.Show(appfilename);
                //File.WriteAllText(currentprogrampath + "\\unzipped\\test.txt", "");
                //var fs = File.Open(currentprogrampath + "\\unzipped\\test.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                File.WriteAllText(currentprogrampath + "\\unzipped\\test.txt", String.Empty);
                string text2 = System.IO.File.ReadAllText(currentprogrampath + "\\unzipped\\test.txt");
                //MessageBox.Show(RemoveSpecialCharacters(text2));

                string[] appfilenameactual= Regex.Split(appfilename, @".app");
                MessageBox.Show(appfilenameactual[0]);
                appactualfilename = appfilenameactual[0];

                // ===============================
                System.Diagnostics.ProcessStartInfo procStartInfo2 = new System.Diagnostics.ProcessStartInfo(currentprogrampath + "\\class-dump-z.exe", " " +"\""+currentprogrampath + "\\unzipped\\Payload\\" + appfilename + "\\"+appactualfilename+"\"");
                MessageBox.Show("Argum"+procStartInfo2.Arguments);
                procStartInfo2.WorkingDirectory = currentprogrampath + "\\unzipped";
                MessageBox.Show(procStartInfo2.WorkingDirectory);
                procStartInfo2.CreateNoWindow = false;
                procStartInfo2.WindowStyle = ProcessWindowStyle.Normal;
                procStartInfo2.UseShellExecute = false;
                System.Diagnostics.Process procz2 = new System.Diagnostics.Process();
                procz2.StartInfo = procStartInfo2;
                procz2.Start();
                MessageBox.Show("Decompilation Complete.");
                procz2.WaitForExit();
                procz2.Close();

            }
            catch
            {
            }


        }


    }

}
