using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Image_Combiner
{
    /// <summary>
    /// Takes an Image List and creates a new image consisting of images layed ontop of eachother.
    /// </summary>
    class ImageCombiner
    {
        public string filePath;
        public string outputFilePath;
        public string outputImageExtension;

        public ImageCombiner()
        {
            outputFilePath = @"C: \Users\Naomi\source\repos\Image Combiner\Image Combiner\bin\Debug\Creation\CreatedImage\";
            outputImageExtension = ".png";
        }

        public ImageCombiner(string outputfilepath, string outputimageextension) : this()
        {
            outputFilePath = outputfilepath;
            outputImageExtension = outputimageextension;
        }

        public void SaveImage(Bitmap output, int outputFileName)
        {
            string completeOutputPath = outputFilePath + outputFileName + outputImageExtension;
            switch (outputImageExtension)
            {
                case (".png"):
                    output.Save(completeOutputPath, ImageFormat.Png);
                    break;
                case (".bmp"):
                    output.Save(completeOutputPath, ImageFormat.Bmp);
                    break;
                case (".jpeg"):
                    output.Save(completeOutputPath, ImageFormat.Jpeg);
                    break;
                case (".gif"):
                    output.Save(completeOutputPath, ImageFormat.Gif);
                    break;
                case (".tif"):
                    output.Save(completeOutputPath, ImageFormat.Tiff);
                    break;
                default:
                    Console.WriteLine("Error, invalid extension supplied.");
                    break;
            }         
        }

        public Bitmap MergeImageLayers(List<Image> layers)
        {
            int outputImageWidth = layers[0].Width;
            int outputImageHeight = layers[0].Height;
            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                foreach(Image image in layers)
                {
                    graphics.DrawImage(image, new Rectangle(new Point(), image.Size),
                    new Rectangle(new Point(), image.Size), GraphicsUnit.Pixel);
                }
            }
            return outputImage;
        }
    }
}
