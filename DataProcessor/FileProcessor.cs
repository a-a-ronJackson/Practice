using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessor
{
    internal class FileProcessor
    {
        private const string BackupDirectoryName = "backup";
        private const string InProgressDirectoryName = "processing";
        private const string CompletedDiectoryName = "complete";

        public string InputFilePath { get; }
        public FileProcessor(string filePath) => InputFilePath = filePath;
        public void Process()
        {
            Console.WriteLine($"Begin process of {InputFilePath}");

            //Check if exsits
            if (!File.Exists(InputFilePath))
            {
                Console.WriteLine($"ERROR: file {InputFilePath} does not exsit");
                return;
            }

            string rootDirectoryPath = new DirectoryInfo(InputFilePath).Parent.Parent.FullName;
            Console.WriteLine($"Root data path is {rootDirectoryPath}");

            //check if backup dir exists
            string backupDirectoryPath = Path.Combine(rootDirectoryPath, BackupDirectoryName);

            //if (!Directory.Exists(backupDirectoryPath))
            //{
            Console.WriteLine($"Attempting to create {backupDirectoryPath}");
            Directory.CreateDirectory(backupDirectoryPath);
            //}

            //Copy file to backup dir
            string inputFileName = Path.GetFileName(InputFilePath);
            string backupFilePath = Path.Combine(backupDirectoryPath, inputFileName);
            Console.WriteLine($"Copying {InputFilePath} to {backupFilePath}");
            File.Copy(InputFilePath, backupFilePath, true);

            //Move to in progress dir
            Directory.CreateDirectory(Path.Combine(rootDirectoryPath, InProgressDirectoryName));
            string inProgressFilePath = Path.Combine(rootDirectoryPath, InProgressDirectoryName, inputFileName);

            if (File.Exists(inProgressFilePath))
            {
                Console.WriteLine($"ERROR: a file with the name {inProgressFilePath} is already being processed");
                return;
            }
            Console.WriteLine($"Moving {InputFilePath} to {inProgressFilePath}");
            File.Move(InputFilePath, inProgressFilePath);

            //Determine type of file
            string extenstion = Path.GetExtension(InputFilePath);

            string completedDirectoryPath = Path.Combine(rootDirectoryPath, CompletedDiectoryName);
            Directory.CreateDirectory(completedDirectoryPath);
            Console.WriteLine($"Moving {inProgressFilePath} to {completedDirectoryPath}");

            string completedFileName = $"{Path.GetFileNameWithoutExtension(InputFilePath)}-{Guid.NewGuid()}{extenstion}";


            var completedFilePath = Path.Combine(completedDirectoryPath, completedFileName);

            switch (extenstion)
            {
                case ".txt":
                    var textProcessor = new TextFileProcessor(inProgressFilePath, completedFilePath);
                    textProcessor.Process();
                    break;
                case ".csv":
                    var csvProcessor = new CsvFileProcessor(inProgressFilePath, completedFilePath);
                    csvProcessor.Process();
                    break;
                default:
                    Console.WriteLine($"{extenstion} is an unsupported file type.");
                    break;
            }
            Console.WriteLine($"Completed processing of {inProgressFilePath}");
            Console.WriteLine($"Deleting {inProgressFilePath}");
            File.Delete(inProgressFilePath);
        }
    }
}
