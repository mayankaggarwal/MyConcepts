using System;
using CSharpConcepts.Interfaces;
using System.IO;
using System.Text;
using System.IO.Compression;

namespace CSharpConcepts.DataAccessConcepts
{
    internal class WorkingWithStreams : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Working with Streams");
        }

        public void MainMethod()
        {
            FileStreamCreateAndUse();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            WriteFileUsingStreamWriter();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            OpenFileStreamAndDecodeBytes();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            OpenTextFileAndReadContent();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            UsingGZipStream();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            UsingBufferedStream();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            UsingMemoryStream();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");

        }

        private void FileStreamCreateAndUse()
        {
            Console.WriteLine("FileStream create file example:");
            string path = "temp.txt";
            using (FileStream stream = File.Create(path))
            {
                string myValue = "MyValue";
                byte[] data = Encoding.UTF8.GetBytes(myValue);
                stream.Write(data,0,data.Length);
            }

        }

        private void WriteFileUsingStreamWriter()
        {
            Console.WriteLine("StreamWriter create file example:");
            string path = "temp.txt";
            using (StreamWriter writer = File.CreateText(path))
            {
                string myValue = "My value";
                writer.WriteLine(myValue);
            }
        }

        private void OpenFileStreamAndDecodeBytes()
        {
            Console.WriteLine("File Stream Open Read example");
            string path = "temp.txt";
            using (FileStream reader = File.OpenRead(path))
            {
                byte[] data = new byte[reader.Length];
                for(int i=0;i<reader.Length;i++)
                {
                    data[i] = (byte)reader.ReadByte();
                }
                Console.WriteLine(Encoding.UTF8.GetString(data));
            }

        }

        private void OpenTextFileAndReadContent()
        {
            Console.WriteLine("Using Stream Reader to read data:");
            string path = "temp.txt";
            using (StreamReader reader = File.OpenText(path))
            {
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        private void UsingGZipStream()
        {
            Console.WriteLine("Compressing file using GZipStream");
            string folder = Environment.CurrentDirectory;
            string uncompressedFilePath = Path.Combine(folder, "uncompressed.txt");
            string compressedFilePath = Path.Combine(folder, "compressed.gz");
            string data = "My name is Mayank Aggarwal. I am a Software Developer and I need to learn a lot about that.";
            byte[] dataToCompress = Encoding.UTF8.GetBytes(data);
            using (FileStream writer = File.Create(uncompressedFilePath))
            {
                writer.Write(dataToCompress, 0, dataToCompress.Length);
            }
            using (FileStream compressedStream = File.Create(compressedFilePath))
            {
                using (GZipStream compressionStream = new GZipStream(compressedStream,CompressionMode.Compress))
                {
                    compressedStream.Write(dataToCompress, 0, dataToCompress.Length);
                }
            }

            FileInfo uncompressedFile = new FileInfo(uncompressedFilePath);
            FileInfo compressedFile = new FileInfo(compressedFilePath);

            Console.WriteLine("Uncompressed file size :{0}", uncompressedFile.Length);
            Console.WriteLine("Compressed file size :{0}", compressedFile.Length);
        }

        private void UsingBufferedStream()
        {
            string path = "bufferedStream.txt";
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                using (BufferedStream bufferedStream = new BufferedStream(fileStream))
                {
                    using (StreamWriter writer = new StreamWriter(bufferedStream))
                    {
                        writer.WriteLine("A line of text");
                    }
                }
            }
        }

        private void UsingMemoryStream()
        {
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Memory Stream Example");
            int count;
            byte[] byteArray;
            char[] charArray;

            UnicodeEncoding uniEncoding = new UnicodeEncoding();

            byte[] firstString = uniEncoding.GetBytes("Invalid file path character are: ");
            byte[] secondString = uniEncoding.GetBytes(Path.GetInvalidFileNameChars());

            using (MemoryStream memStream = new MemoryStream(100))
            {
                memStream.Write(firstString, 0, firstString.Length);

                count = 0;
                while(count < secondString.Length)
                {
                    memStream.WriteByte(secondString[count++]);
                }

                Console.WriteLine("Capacity = {0}, Length = {1}, Position = {2}", 
                    memStream.Capacity, 
                    memStream.Length, 
                    memStream.Position);

                memStream.Seek(0, SeekOrigin.Begin);

                byteArray = new byte[memStream.Length];
                count = memStream.Read(byteArray, 0, 20);

                while(count<memStream.Length)
                {
                    byteArray[count++] = Convert.ToByte(memStream.ReadByte());
                }

                charArray = new char[uniEncoding.GetCharCount(byteArray,0,count)];
                uniEncoding.GetDecoder().GetChars(byteArray, 0, count, charArray, 0);
                Console.WriteLine(charArray);

            }
        }
    }
}