// See https://aka.ms/new-console-template for more information
using System;
using System.Text.RegularExpressions;

namespace regex
{ 
    class Strings 
    {
        static void Main(string[] args) 
        { 
            Console.WriteLine("Введите предложение");
            string sentence = Console.ReadLine();

            
            string prefixReplace = Regex.Replace(sentence, @"([^а-я]|^)(п)ри([а-я]+([!.?]|$))","$1$2ре$3",RegexOptions.IgnoreCase);
            string flexionReplace = Regex.Replace(prefixReplace, @"(([!.?]\s*|^)[а-я]+)ие([^а-я]|$)", "$1ее$3", RegexOptions.IgnoreCase);
            Console.WriteLine(flexionReplace);

        }

    }


}

