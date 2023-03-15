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
using YoutubeExplode;

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
        public void LaunchCommandLineApp()
        {
     
            // Use ProcessStartInfo class
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.FileName = "yt-dlp.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
          //  startInfo.RedirectStandardOutput = true;
            //startInfo.Verb = "runas";
            startInfo.Arguments = " https://youtu.be/UggslfShToQ?list=RDUggslfShToQ&t=118 -f mp4 -P E:\\MyVideo  ";

            
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "yt-dlp.exe",
                    Arguments = "https://youtu.be/UggslfShToQ?list=RDUggslfShToQ&t=118 -f mp4 -P E:\\MyVideo ",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };

          

            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                Debug.WriteLine("my_line: "+line); // +++++++++++++++++++++++++ ASDFGHJKLMNOPQRST1234567890 ++++++++++++++++++++++++++++++++++++++++++++ // 
                string[] ssize = line.Split(null); //Or myStr.Split()
                if (ssize.Length>=5) {
                    if (ssize[0].Equals("[download]") && ssize[1].Equals("100%")) {
                        Debug.WriteLine(" size " + ssize[5]);
                       // Debug.WriteLine("splitted:0 " + ssize[0] + " 1 " + ssize[1] + "  2  " + ssize[2] + "  3  " + ssize[3] + " 4 " + ssize[4] + " size " + ssize[5]); // +++++++++++++++++++++++++ ASDFGHJKLMNOPQRST1234567890 ++++++++++++++++++++++++++++++++++++++++++++ // 
                    }
                    }
                // do something with line
            }
            // GetInformationAsync("https://youtu.be/UggslfShToQ?list=RDUggslfShToQ&t=118");


            /*
            * var worker = sender as BackgroundWorker;
            for (int i = 0; i < filesCount; i++)
            {

                ParseSingleFile(); // pass filename here
                int percentage = (i + 1) * 100 / filesCount;
                worker.ReportProgress(percentage);  // use not myBGWorker but worker from sender
                
            }*/
            /*try
            {   
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (Process exeProcess = Process.Start(startInfo))
                {
                  //  string line = exeProcess.StandardOutput.ReadLine();
                  //  Debug.WriteLine("my_line: " + line);
                  //  do something with line

                    exeProcess.WaitForExit();
                }
            }
            catch
            {
                // Log error.
            }*/
        }

        public async Task GetInformationAsync(string url) {

            var youtube = new YoutubeClient();

            // You can specify either the video URL or its ID
            var videoUrl = url;
            var video = await youtube.Videos.GetAsync(videoUrl);

            var title = video.Title; // "Collections - Blender 2.80 Fundamentals"
            var author = video.Author.ChannelTitle; // "Blender"
            var duration = video.Duration; // 00:07:20
            //var size = video.Size; // 00:07:20

            Debug.WriteLine("title:" + title +" author"+author+" Duration"+ duration);
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
