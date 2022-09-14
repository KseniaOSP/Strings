using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Diagnostics;

namespace archivation
{
    class Archivation
    {
        static void Main(string[] args)
        {
            string dirMain = "C:\\Users\\besed\\Каталог";

            if (!Directory.Exists(dirMain))
            {
                throw new Exception("The directory does not exist");
            }
            string[] files = Directory.GetFiles(dirMain);
            string comprFile = "C:\\Users\\besed\\archive.gz";
            
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            var task = new Task(() => 
            {
                using FileStream targetStream = File.Create(comprFile);
                using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
                foreach (string file in files)
                {
                    token.ThrowIfCancellationRequested();
                    using FileStream sourceStream = new FileStream(file, FileMode.Open);
                    sourceStream.CopyTo(compressionStream);
                    Console.WriteLine(file);
                    Thread.Sleep(2000);
                }
            }, token);
            task.Start();
            //task.Wait();
            Console.WriteLine("Press ESC to stop");
            do
            {
                while (!Console.KeyAvailable)
                {
                    if (task.IsCompleted)
                        return;
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);

            cancelTokenSource.Cancel();
            task.Wait();


        }

    }
}

