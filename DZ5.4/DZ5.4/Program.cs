using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DZ5._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string workDir = @"D:\A1Dir";

            Console.WriteLine(Directory.Exists(workDir)); // Проверяет, существует ли заданная директория

            string notesDir = Path.Combine(workDir, "Notes"); // "D:\A1Dir\Notes"

            Directory.CreateDirectory(notesDir); // Создаем вложенную директорию

            string noteText = "Directory_Nice";

            string notePath = Path.Combine(notesDir, "Note 1.txt");

            File.WriteAllText(notePath, noteText);

            string copyOfNotePath = Path.Combine(workDir, "Copy of Note 1.txt");
            File.Copy(notePath, copyOfNotePath);

            Console.WriteLine(File.Exists(copyOfNotePath)); // Проверяет, существует ли заданный файл

            File.Move(copyOfNotePath, Path.Combine(notesDir, "Note 2.txt"));

            // Создаем директорию "D:\A1Dir\Documents" и перемещаем в нее директорию Notes
            Directory.CreateDirectory(Path.Combine(workDir, "Documents"));
            Directory.Move(notesDir, Path.Combine(workDir, "Documents", "Notes"));

            // Перечень всех файлов и папок, вложенных в workDir
            string[] entries = Directory.GetFileSystemEntries(workDir, "*", SearchOption.AllDirectories);

            for (int i = 0; i < entries.Length; i++)
            {
                Console.WriteLine(entries[i]);
            }
            File.AppendAllLines("Nothing.txt", entries);
        }
    }
}
