using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace EmailExtraction
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Regex rx = new Regex(@"\w*?\.?\w*@softwire.com\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (ReadText(out string fullText))
            {
                CountInstance(rx, fullText);
                Console.ReadLine();
            }

        }

        private static Boolean ReadText(out string text)
        {
            string path = @"C:\Users\WenKak\Desktop\Training\EmailExtraction\scanText.txt";
            try
            {
                text = File.ReadAllText(path);
                return true;
            }
            catch(IOException e)
            {
                Console.WriteLine("There was a problem!" + e.Message);
                text = "";
                return false;
            }
        }

        private static void CountInstance(Regex rx, string fullText)
        {
            MatchCollection matches = rx.Matches(fullText);
            
            
            Console.WriteLine($"{matches.Count} matches found in: \n {fullText}");
            foreach (Match letter in matches)
            {
                Group domain = letter.Groups[0];
                {
                    Console.Write(domain);
                }
            }
        }
        
    }
    
}