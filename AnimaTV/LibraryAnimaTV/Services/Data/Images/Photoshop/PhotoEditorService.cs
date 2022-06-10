using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimaTV.Core.Services.Data.Images.Photoshop
{
    public class PhotoEditorService : IPhotoEditorService
    {
        private readonly Image _image;

        public PhotoEditorService(Image image) =>
            _image = image;

        public Image ToChangeTheImage(int P)
        {
            var bitmapImage = new Bitmap(_image);
            var result = new Bitmap(bitmapImage.Width, bitmapImage.Height);
            var color = new Color();

            try
            {
                for (int j = 0; j < bitmapImage.Height; j++)
                {
                    for (int i = 0; i < bitmapImage.Width; i++)
                    {
                        color = bitmapImage.GetPixel(i,j);
                        int K = (color.R + color.G + color.B) / 3;

                        result.SetPixel(i,j, K <= P ? Color.Black : Color.White);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result; 
        }
    }
}
