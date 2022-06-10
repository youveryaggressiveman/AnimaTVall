using AnimaTV.Core.Data.Model.Enums;

namespace AnimaTV.Persistance.Services.Data.Videos
{
    public interface IFileHelper
    {
        bool AddNewFile(string folderID, string fileSource);
        bool AddNewFile(VideoType type, string fileSource, string folderID);
        bool DeleteFile(string fileID, string folderID);
    }
}
