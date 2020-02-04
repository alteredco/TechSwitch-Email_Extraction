using System;
using System.IO;
using System.Net;

namespace EmailExtraction
{
    internal class Program
    {
        public static void Main(string[] args)
        {

            string fullText = ReadText();
            foreach (var letter in fullText)
            {
                 Console.Write(letter);
            }
            Console.ReadLine();

        }

        private static string ReadText()
        {
            string path = @"C:\Users\WenKak\Desktop\Training\EmailExtraction\scanText.txt";
            string fullText = File.ReadAllText(path);
            return fullText;
        }
        
    }
    
}