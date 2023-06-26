using System;
using System.Collections.Generic;
using System.IO;

namespace Translator
{
    public static class TranslatorStart
    {
        public static void TranslatorRun()
        {
            Console.WriteLine("Translator");
            Console.WriteLine("___________");

            LoadTranslation loadTranslation = new LoadTranslation();
            Dictionary<string, string> translator = loadTranslation.LoadTranslatorsFromFile(@"C:\Users\GIA\Desktop\translator.txt");

            Console.WriteLine("Enter your input:");
            string input = Console.ReadLine().ToLower();

            if (translator.ContainsKey(input))
            {
                Console.WriteLine($"Translation: {translator[input]}\n");
            }
            else
            {
                Console.WriteLine("Translation not found\n");
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }

    class LoadTranslation
    {
        public Dictionary<string, string> LoadTranslatorsFromFile(string filePath)
        {
            Dictionary<string, string> translations = new Dictionary<string, string>();

            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(":");
                        if (parts.Length == 2)
                        {
                            string word = parts[0].Trim().ToLower();
                            string translation = parts[1].Trim();
                            translations[word] = translation;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }

            return translations;
        }
    }
}
