using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AnimaTV.Core.Services.Data.Images
{
    public interface IImageConverter
    {
        byte[] ConvertImageToByte(Image bitmapImage);
        Image ConvertByteToImage(byte[] byteImage);
    }
}
