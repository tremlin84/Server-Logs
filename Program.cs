using System;
using System.IO;

namespace SeverLogParser
{
    class Program 
    {
        static void Main()
        {            
            LoopLogDiectory("C:\\inetpub\\logs\\LogFiles\\W3SVC1");
            Console.ReadLine();
        }

        //loops log directory
        private static void LoopLogDiectory(string directory)
        {
            DirectoryInfo info = new DirectoryInfo(directory);
            int Gets = 0, Posts = 0;
            
            foreach (var file in info.GetFiles()) 
            {                
                try
                {
                    foreach (var line in File.ReadAllLines(file.FullName))
                    {
                        if (line.Contains("GET")) { Gets++; }
                        if (line.Contains("POST")) { Posts++; }                                                
                    }
                    Console.WriteLine("\r\n\tGet Requests: {0}\r\n\tPost Requests: {1}", Gets, Posts);
                }
                catch (IOException)
                {
                    Console.WriteLine("File busy try again later");                    
                }
            }            
        }
    }
}
