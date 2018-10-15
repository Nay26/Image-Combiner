using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Combiner
{
    class Program
    {
        static void Main(string[] args)
        {
            Image firstimage = Image.FromFile(@"C:\Users\Naomi\source\repos\Image Combiner\Image Combiner\bin\Debug\Creation\Hair\hair.png");
            Image secondimage = Image.FromFile(@"C:\Users\Naomi\source\repos\Image Combiner\Image Combiner\bin\Debug\Creation\Head\head.png");
            Bitmap output = MergeTwoImages(firstimage,secondimage);
            output.Save(@"C:\Users\Naomi\source\repos\Image Combiner\Image Combiner\bin\Debug\Creation\CreatedImage\img.png", ImageFormat.Png);
        }

        public static Bitmap MergeTwoImages(Image firstImage, Image secondImage)
        {
            if (firstImage == null)
            {
                throw new ArgumentNullException("firstImage");
            }

            if (secondImage == null)
            {
                throw new ArgumentNullException("secondImage");
            }

            int outputImageWidth = firstImage.Width;

            int outputImageHeight = firstImage.Height;

            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                graphics.DrawImage(firstImage, new Rectangle(new Point(), firstImage.Size),
                    new Rectangle(new Point(), firstImage.Size), GraphicsUnit.Pixel);
                graphics.DrawImage(secondImage, new Rectangle(new Point(), secondImage.Size),
                    new Rectangle(new Point(), secondImage.Size), GraphicsUnit.Pixel);
            }

            return outputImage;
        }


    }
}
