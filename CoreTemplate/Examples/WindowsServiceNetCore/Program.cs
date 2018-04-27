using System;

namespace WindowsServiceNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var logPath = "C:/Users/tharknes/Documents/GitHub/EnterpriseApplicationArhictetureDotNetCore/CoreTemplate/Examples/WindowsServiceNetCore/logfile.txt"; //System.IO.Path.GetTempFileName();
            var logFile = System.IO.File.Create(logPath);
            var logWriter = new System.IO.StreamWriter(logFile);
            logWriter.WriteLine("Log messages");
            logWriter.Dispose();

        }
    }
}
