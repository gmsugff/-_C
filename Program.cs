using System.IO;

namespace сбор
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\SomeDir";
            
            DirectoryInfo dirInfo = new DirectoryInfo(path);
                dirInfo.Create();

            StreamWriter file = new StreamWriter(path+"//TestFile.txt");

            file.Write("О дисках:");
            file.Write("\n");


            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                file.Write("\n");
                file.Write($" Название: {drive.Name}");
                file.Write("\n");
                file.Write($" Тип: {drive.DriveType}");
                file.Write("\n ");
                if (drive.IsReady)
                {
                    file.Write("\n ");
                    file.Write($" Объем диска: {drive.TotalSize}");
                    file.Write("\n ");
                    file.Write($" Свободное пространство: {drive.TotalFreeSpace}");
                    file.Write("\n ");
                    file.Write($" Метка диска: {drive.VolumeLabel}");
                    file.Write("\n ");

                }
                file.Write("\n");
                if (Directory.Exists(drive.Name))
                {
                    file.Write("\n");
                    file.Write("Подкаталоги:");
                    file.Write("\n");

                    string[] dirs = Directory.GetDirectories(drive.Name);
                    foreach (string s in dirs)
                    {
                        file.Write("\n");
                        file.Write($"-{s}");

                    }
                    file.Write("\n");
                    file.Write("Файлы:");

                    string[] files = Directory.GetFiles(drive.Name);
                    foreach (string s in files)
                    {
                        file.Write("\n ");
                        file.Write($"-{s}");
                    }
                    file.Write("\n");

                }
            }
                file.Close();



            
        }
    }
}
