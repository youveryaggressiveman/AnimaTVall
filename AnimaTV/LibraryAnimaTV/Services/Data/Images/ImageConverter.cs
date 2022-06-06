using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Core.Services.Data.Images
{
    public class ImageConverter : IImageConverter
    {
        public byte[] ConvertImageToByte(Image bitmapImage)
        {
            if (bitmapImage == null)
            {
                throw new NullReferenceException(nameof(bitmapImage));
            }

            System.Drawing.ImageConverter converter = new();

            return (byte[])converter.ConvertTo(bitmapImage, typeof(byte[]));
        }

        public Image ConvertByteToImage(byte[] byteImage)
        {
            if (byteImage == null)
            {
                throw new NullReferenceException(nameof(byteImage));
            }

            using (var ms = new MemoryStream(byteImage))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
