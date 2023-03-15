using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           LaunchCommandLineApp();
         //   ConvertEBMtoMP4();
        }

        // ffmpeg -i input.webm -c copy output.mp4

        /// <summary>
        /// Launch the application with some options set.
        /// </summary>
        static void LaunchCommandLineApp()
        {
     
            // Use ProcessStartInfo class
            /*ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "yt-dlp.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.RedirectStandardOutput = true;
            //startInfo.Verb = "runas";
            startInfo.Arguments = " https://youtu.be/UggslfShToQ?list=RDUggslfShToQ&t=118 -f mp4 -P E:\\MyVideo  ";

            */
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "yt-dlp.exe",
                    Arguments = "https://youtu.be/UggslfShToQ?list=RDUggslfShToQ&t=118 -f mp4 -P E:\\MyVideo ",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = false
                }
            };

            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                Debug.WriteLine("my_line: "+line);
                // do something with line
            }

            /*
            * var worker = sender as BackgroundWorker;
            for (int i = 0; i < filesCount; i++)
            {
                ParseSingleFile(); // pass filename here
                int percentage = (i + 1) * 100 / filesCount;
                worker.ReportProgress(percentage);  // use not myBGWorker but worker from sender
                
            }*/
            try
            {   
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
              /*  using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }*/
            }
            catch
            {
                // Log error.
            }
        }

        static void ConvertEBMtoMP4()
        {
            // For the example
   

            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "ffmpeg.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = " -i myvideo.webm  output.mp4";

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }
        }
    }
}
