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
            string dirMain = "C:\\Users\\besed\\Каталог"; // строковая переменная, которая содержит путь до файла
            string comprFile = "C:\\Users\\besed\\archive.gz";

            if (!Directory.Exists(dirMain)) // проверяем существует ли каталог
            {
                throw new Exception("The directory does not exist");
            }
            string[] files = Directory.GetFiles(dirMain);
          
            
            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            var task = new Task(() => 
            {
                using FileStream targetStream = File.Create(comprFile);
                using GZipStream compressionStream = new GZipStream(targetStream, CompressionMode.Compress);
                foreach (string file in files)
                {
                    if (token.IsCancellationRequested) // 
                        return;
                    using FileStream sourceStream = new FileStream(file, FileMode.Open);
                    sourceStream.CopyTo(compressionStream);
                    Console.WriteLine(file);
                    Thread.Sleep(2000);
                }
            }, token);
            task.Start();
            //task.Wait();
            
            var uiTask = new Task(() =>
            {
                Console.WriteLine("Press ESC to stop");
                do
                {
                    while (!Console.KeyAvailable)
                    {
                        if (token.IsCancellationRequested) // 
                            return;
                    }
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            }, token);
            uiTask.Start();

            Task.WaitAny(task,uiTask);
            cancelTokenSource.Cancel();
            task.Wait();

        }

    }
}

