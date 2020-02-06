using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace EmailExtraction
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Regex rxAnyDomain = new Regex(@"@[^\s]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Regex rxSoftwire = new Regex(@"\w*?\.?\w*@softwire.com\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Regex rxGoogle = new Regex(@"\w*?\.?\w*@gmail.com\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Regex rxHotmail = new Regex(@"\w*?\.?\w*@hotmail.co[^\s]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Regex rxOutlook = new Regex(@"\w*?\.?\w*@outlook.com\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Regex rxTechSwitch = new Regex(@"\w*?\.?\w*@techswitch.co[^\s]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Regex rxYahoo = new Regex(@"\w*?\.?\w*@yahoo.co[^\s]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Regex rxKiwi = new Regex(@"\w*?\.?\w*@kiwimail.co[^\s]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Regex rxSwi = new Regex(@"\w*?\.?\w*@swi.re\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Regex rxMy = new Regex(@"\w*?\.?\w*@my-email.net", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Regex rxAol = new Regex(@"\w*?\.?\w*@aol.com\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Regex rxFB = new Regex(@"\w*?\.?\w*@facebook.co[^\s]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            

            if (ReadText(out string fullText))
            { 
                AddToDictionary(rxAnyDomain, fullText);
                
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

        private static Dictionary<Group, int> AddToDictionary(Regex rx, string fullText)
        {
            Dictionary<Group, int> emailDict = new Dictionary<Group, int>();
            MatchCollection matches = rx.Matches(fullText);
            
            Console.WriteLine($"{matches.Count} matches found in text \n");
            foreach (Match match in matches)
            {
                Group domains = match.Groups[0];
                for (int i = 0; i < domains.Length; i++)
                {
                    if (emailDict.ContainsKey(domains))
                    {
                        emailDict[domains]++;
                    }
                    else
                    {
                        emailDict.Add(domains, 1);
                    }
                }
            }

            foreach (KeyValuePair<Group, int> index in emailDict.OrderBy(key => key.Value))
            {
                Console.WriteLine("Domain: {0}, Count:{1}", index.Key, index.Value) ;
            }

            return emailDict;

        }
    }
    
}