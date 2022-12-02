using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorXMauiDemo.Service
{
    public interface IFileManager
    {
        void SaveAs(string message, string filename);
    }

    public class FileManager : IFileManager
    {
        // Note that this path will be transformed on windows on C/user/*username*/appdata/local/package/*app_uid*_suffix/localappdata... 
        private static readonly string _mainFolder = Environment.GetEnvironmentVariable("LocalAppData") + @"\BlazorXMaui";

        private void EnsureDirectoryExists(string folderName)
        {
            if (folderName != null && !Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);
        }

        public void SaveAs(string message, string filename)
        {
            EnsureDirectoryExists(_mainFolder);

            StreamWriter writer = new StreamWriter($@"{_mainFolder}\{filename}.txt");
            writer.Write(message);
            writer.Close();
        }
    }
}
