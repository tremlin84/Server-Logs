using System;
using System.IO;

namespace SeverLogParser
{
    sealed class ReadFile
    {       
        public int Gets { get; private set; } = 0;
        public int Posts { get; private set; } = 0;
        public ReadFile(string LogFile)
        {            
            try
            {
                foreach (var line in File.ReadAllLines(LogFile))
                {                    
                    if (line.Contains("GET")) { Gets++; }
                    if (line.Contains("POST")) { Posts++; }
                }
            }
            catch (IOException)
            {
                Console.WriteLine("File busy try again later");
            }            
        }        
    }
}
