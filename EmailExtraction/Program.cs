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
            Regex rxSoftwire = new Regex(@"\w*?\.?\w*@softwire.com\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rxGoogle = new Regex(@"\w*?\.?\w*@gmail.com\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rxHotmail = new Regex(@"\w*?\.?\w*@hotmail.co[^\s]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rxOutlook = new Regex(@"\w*?\.?\w*@outlook.com\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rxTechSwitch = new Regex(@"\w*?\.?\w*@techswitch.co[^\s]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rxYahoo = new Regex(@"\w*?\.?\w*@yahoo.co[^\s]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rxKiwi = new Regex(@"\w*?\.?\w*@kiwimail.co[^\s]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rxSwi = new Regex(@"\w*?\.?\w*@swi.re\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rxMy = new Regex(@"\w*?\.?\w*@my-email.net", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rxAol = new Regex(@"\w*?\.?\w*@aol.com\s", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Regex rxFB = new Regex(@"\w*?\.?\w*@facebook.co[^\s]+", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            

            if (ReadText(out string fullText))
            {
                // int anyDomainCount = CountInstance(rxAnyDomain, fullText);
                // int softWireCount = CountInstance(rxSoftwire, fullText);
                // int googleCount = CountInstance(rxGoogle, fullText);
                Dictionary<Group, int> emailDict = new Dictionary<Group, int>();
                
                AddToDictionary(rxAnyDomain, fullText, 1, emailDict);
                AddToDictionary(rxSoftwire, fullText, 2,emailDict);
                AddToDictionary(rxGoogle, fullText,3,emailDict);
                AddToDictionary(rxHotmail, fullText, 4, emailDict);
                AddToDictionary(rxOutlook, fullText, 5, emailDict);
                AddToDictionary(rxTechSwitch, fullText, 6, emailDict);
                AddToDictionary(rxYahoo, fullText, 7, emailDict);
                AddToDictionary(rxKiwi, fullText, 8, emailDict);
                AddToDictionary(rxSwi, fullText, 9, emailDict);
                AddToDictionary(rxMy, fullText, 10, emailDict);
                AddToDictionary(rxAol, fullText, 11, emailDict);
                AddToDictionary(rxFB, fullText, 12, emailDict);
                
                
                SortDictionary(emailDict);
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

        private static int CountInstance(Regex rx, string fullText)
        {
            MatchCollection matches = rx.Matches(fullText);
        
            Console.WriteLine($"{matches.Count} matches found in text \n");
            return matches.Count;
        }

        private static Dictionary<Group, int> AddToDictionary(Regex rx, string fullText, int index, Dictionary<Group,int> dict)
        {
            MatchCollection matches = rx.Matches(fullText);

            foreach (Match letter in matches)
            {
                Group domain = letter.Groups[0];
                dict.Add(domain, index);
            }

            return dict;

        }

        private static void SortDictionary(Dictionary<Group,int> dict)
        {
            foreach (KeyValuePair<Group, int> index in dict.OrderBy(key => key.Value))
            {
                Console.WriteLine("Domain: {0}, group:{1}", index.Key, index.Value) ;
            }
        }
        
    }
    
}