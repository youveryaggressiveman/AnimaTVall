using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimaTV.Core.Data.Model.Enums;

namespace AnimaTV.Core.Services.Data.Videos
{
    public interface IFileHelper
    {
        bool AddNewFile(string folderID, string fileSource);
        bool AddNewFile(VideoType type, string fileSource, string folderID);
        bool DeleteFile(string fileID, string folderID);
    }
}
