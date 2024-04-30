using System;
using System.Collections.Generic;
using System.IO;

namespace MyApp
{
    public static class ResourceLoader
    {
        public static void LoadWords(string path, ref List<string> words)
        {
            Console.WriteLine(Directory.GetCurrentDirectory());
            StreamReader reader = null;
            try
            {
                reader = File.OpenText(path);
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(line);
                }
            }
            catch (FileNotFoundException)
            {
                throw new Exception("Can not find vocabulary file!");
            }
            catch (Exception)
            {
                throw new Exception("Error reading file!");
            }
            finally
            {
                reader?.Close();
            }
        }
    }
}