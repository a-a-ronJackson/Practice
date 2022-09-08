using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;
using System.Runtime.Caching;

namespace DataProcessor
{
    internal class Program
    {
        private static MemoryCache FilesToProcess = MemoryCache.Default;
        static void Main(string[] args)
        {
            Console.WriteLine("Parsing command line options");

            var directoryToWatch = args[0];

            if (!Directory.Exists(directoryToWatch))
            {
                Console.WriteLine($"ERROR: {directoryToWatch} does not exist");
            }
            else
            {
                Console.WriteLine($"Watching directory {directoryToWatch} for changes");

                ProcessExistingFiles(directoryToWatch);

                using var inputFileWatcher = new FileSystemWatcher(directoryToWatch);

                inputFileWatcher.IncludeSubdirectories = false;
                inputFileWatcher.InternalBufferSize = 32768; //32KB
                inputFileWatcher.Filter = "*.*"; // this is the default
                inputFileWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

                inputFileWatcher.Created += FileCreated;
                inputFileWatcher.Changed += FileChanged;
                inputFileWatcher.Deleted += FileDeleted;
                inputFileWatcher.Renamed += FileRenamed;
                inputFileWatcher.Error += WatcherError;

                inputFileWatcher.EnableRaisingEvents = true;

                Console.WriteLine("Press enter to quit");
                Console.ReadLine();
              
            }
        }

        private static void FileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"* File Created: {e.Name} - type: {e.ChangeType}");

            AddToCache(e.FullPath);
        }

        private static void FileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"* File Changed: {e.Name} - type: {e.ChangeType}");

            AddToCache(e.FullPath);
        }

        private static void FileDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"* File Deleted: {e.Name} - type: {e.ChangeType}");
        }

        private static void FileRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"* File Renamed: {e.Name} - type: {e.ChangeType}");
        }

        private static void WatcherError(object sender, ErrorEventArgs e)
        {
            Console.WriteLine($"ERROR: file system watching may no longer be active: {e.GetException()}");
        }
        private static void AddToCache(string fullPath)
        {
            var item = new CacheItem(fullPath, fullPath);

            var policy = new CacheItemPolicy
            {
                RemovedCallback = ProcessFile,
                SlidingExpiration = TimeSpan.FromSeconds(2),
            };

            FilesToProcess.Add(item, policy);
        }

        private static void ProcessFile(CacheEntryRemovedArguments args)
        {
            Console.WriteLine($"Cache item removed: {args.CacheItem.Key} because {args.RemovedReason}");

            if (args.RemovedReason == CacheEntryRemovedReason.Expired)
            {
                var fileProcessor = new FileProcessor(args.CacheItem.Key);
                fileProcessor.Process();
            }
            else
            {
                Console.WriteLine($"WARNING: {args.CacheItem.Key} was removed inexpectantly and may not be processed because {args.RemovedReason}");
            }
        }

        private static void ProcessExistingFiles(string inputDirectory)
        {
            Console.WriteLine($"Checking {inputDirectory} for existing files");
            foreach (var filePath in Directory.EnumerateFiles(inputDirectory))
            {
                Console.WriteLine($"  - Found {filePath}");
                AddToCache(filePath);
            }
        }
       

    }
}
