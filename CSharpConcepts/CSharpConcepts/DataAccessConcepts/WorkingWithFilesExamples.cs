using System;
using CSharpConcepts.Interfaces;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;

namespace CSharpConcepts.DataAccessConcepts
{
    internal class WorkingWithFilesExamples : IMainMethod
    {
        public void SummaryMethod()
        {
            Console.WriteLine("Working with files examples");
        }

        public void MainMethod()
        {
            DriveInformationExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            DirectoryCreationAndDeletionExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            DirectoryWithAccessControl();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            BuildingDirectoryTreeExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
            FilesCreationAndDeletionExample();
            Console.WriteLine("\n-------------------------------------------------------------------------\n");
        }

        private void DriveInformationExample()
        {
            DriveInfo[] drivesInfo = DriveInfo.GetDrives();
            foreach(var driveInfo in drivesInfo)
            {
                Console.WriteLine("Drive {0}", driveInfo.Name);
                Console.WriteLine(" File type: {0}", driveInfo.DriveType);

                if(driveInfo.IsReady == true)
                {
                    Console.WriteLine(" Volume Label: {0}", driveInfo.VolumeLabel);
                    Console.WriteLine(" File system: {0}", driveInfo.DriveFormat);

                    Console.WriteLine(" Available space to current user:{0,15}", driveInfo.AvailableFreeSpace);
                    Console.WriteLine(" Total available space:{0,15}", driveInfo.TotalFreeSpace);
                    Console.WriteLine(" Total size of drive:{0,15}", driveInfo.TotalSize);
                }
            }
        }

        private void DirectoryCreationAndDeletionExample()
        {
            Console.WriteLine("Fetching path of current executing assembly:");
            string path = Environment.CurrentDirectory;
            string path2 = Directory.GetCurrentDirectory();

            string baseDirectoryPath = String.Concat(path, "\\Directory");
            string baseDirectoryInfoPath = String.Concat(path2, "\\DirectoryInfo");

            Console.WriteLine("Creating directories:");
            var directory = Directory.CreateDirectory(baseDirectoryPath);
            var directoryInfo = new DirectoryInfo(baseDirectoryInfoPath);
            directoryInfo.Create();


            if (directory.Exists)
                Console.WriteLine("Created directory with path :{0}", baseDirectoryPath);
            else
                Console.WriteLine("Failed to create directory path :{0}", baseDirectoryPath);

            if (directoryInfo.Exists)
                Console.WriteLine("Created directory with path :{0}", baseDirectoryInfoPath);
            else
                Console.WriteLine("Failed to create directory info path :{0}", baseDirectoryInfoPath);


            Console.WriteLine("Deleting directories:");
            if (Directory.Exists(baseDirectoryPath))
                Directory.Delete(baseDirectoryPath);

            var directoryInfoDelete = new DirectoryInfo(baseDirectoryInfoPath);
            if (directoryInfoDelete.Exists)
                directoryInfoDelete.Delete();

            if (!Directory.Exists(baseDirectoryPath))
                Console.WriteLine("Directory deleted with path :{0}", baseDirectoryPath);
            else
                Console.WriteLine("Failed to delete directory path :{0}", baseDirectoryPath);

            if (!Directory.Exists(baseDirectoryInfoPath))
                Console.WriteLine("Directory deleted with path :{0}", baseDirectoryInfoPath);
            else
                Console.WriteLine("Failed to delete directory info path :{0}", baseDirectoryInfoPath);

        }

        private void DirectoryWithAccessControl()
        {
            Console.WriteLine("Example of Directory Security");
            string path = Environment.CurrentDirectory;
            string directoryPath = String.Concat(path, "\\Directory");
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            directory.Create();
            Console.WriteLine("Setting directory security to everyone, filerights to read and execute and accesscontrol to allow");
            DirectorySecurity directorySecurity = directory.GetAccessControl();
            directorySecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.ReadAndExecute, AccessControlType.Allow));
            directory.SetAccessControl(directorySecurity);

            if (Directory.Exists(directoryPath))
                Directory.Delete(directoryPath);

        }

        private void BuildingDirectoryTreeExample()
        {
            Console.WriteLine("Building directory tree example: ");
            Console.WriteLine("If directory tree is large use Enumerate driectories instead of GetDirectories");
            DirectoryInfo directoryInfo = new DirectoryInfo("G:\\OldData");
            ListDirectories(directoryInfo, "*", 3, 1);
        }

        private void ListDirectories(DirectoryInfo directoryInfo, string searchPattern, int maxLevel, int currentLevel)
        {
            if (currentLevel > maxLevel)
                return;
            string indent = new string('-', currentLevel);
            try
            {
                DirectoryInfo[] lDirectoryInfo = directoryInfo.GetDirectories(searchPattern);
                foreach(DirectoryInfo subDirectory in lDirectoryInfo)
                {
                    Console.WriteLine(indent + subDirectory.Name);
                    ListDirectories(subDirectory, searchPattern, maxLevel, currentLevel + 1);
                }
            }
            catch(UnauthorizedAccessException)
            {
                Console.WriteLine(indent + "Cann't access directory :{0}", directoryInfo.Name);
                return;
            }
            catch(DirectoryNotFoundException)
            {
                Console.WriteLine(indent + "Cann't find :{0}", directoryInfo.Name);
                return;
            }
        }

        private void FilesCreationAndDeletionExample()
        {
            Console.WriteLine("Creating and Deleting files examples");
            try
            {
                string file = "temp.txt";
                if (!File.Exists(file))
                {
                    File.Create(file);
                    Console.WriteLine("File Created with name :{0}", file);
                }
                else
                {
                    Console.WriteLine("Cannot create file as it already exists");
                }

                if (File.Exists(file))
                {
                    
                    File.Delete(file);
                    Console.WriteLine("File deleted from path :{0}", file);
                }
                else
                {
                    Console.WriteLine("Cannot delete file as it does not exists");
                }

                FileInfo fileInfo = new FileInfo(file);
                if (!fileInfo.Exists)
                {
                    fileInfo.Create();
                    Console.WriteLine("File Created with name :{0}", file);
                }
                else
                {
                    Console.WriteLine("Cannot create file as it already exists");
                }

                if (File.Exists(file))
                {
                    fileInfo.Delete();
                    Console.WriteLine("File deleted from path :{0}", file);
                }
                else
                {
                    Console.WriteLine("Cannot delete file as it does not exists");
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Exception");
            }
        }
    }
}