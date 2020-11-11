using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace DjTaba.Utility
{
	public static class ResizeImage
	{
        public static Image GetReducedImage(int width, int height, Stream resourceImage)
        {
            try
            {
                Image image = Image.FromStream(resourceImage);
                Image thumb = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
                return thumb;
            }
            catch (Exception)
            {
                return null;
            }
        }


    }
}
