using AnimaTV.Core.Data.Model.Enums;
using AnimaTV.Persistance.Services.Data.Videos;
using System;
using System.IO;
using System.Linq;

namespace AnimaTV.Core.Services.Data.Videos
{
    public class FileHelper : IFileHelper
    {
        private const string DIR_NAME = @"E:\AnimaTVSource\";

        private readonly DirectoryInfo _directory;

        public FileHelper()
        {
            if (!Directory.Exists(DIR_NAME))
            {
                Directory.CreateDirectory(DIR_NAME);
            }

            _directory = new DirectoryInfo(DIR_NAME);
        }

        public bool AddNewFile(string folderID, string fileSource)
        {
            var target = _directory.GetDirectories().FirstOrDefault(d => d.Name == folderID);

            if (target != null)
            {

                //TODO: Реализовать согласно подключенной библиотеке
                var file = new FileInfo(fileSource);
                if (file.Exists)
                {
                    file.CopyTo(target.FullName);

                    return true;
                }

                return false;
            }

            return false;
        }

        public bool AddNewFile(VideoType type, string fileSource, string folderID)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFile(string fileID, string folderID)
        {
            var target = _directory.GetDirectories().FirstOrDefault(d => d.Name == folderID);

            var file = target?.GetFiles().FirstOrDefault(f => f.Name == fileID);

            if (file == null)
            {
                return false;
            }

            File.Delete(file.FullName);

            return true;
        }
    }
}
