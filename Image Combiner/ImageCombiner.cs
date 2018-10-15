using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Image_Combiner
{
    /// <summary>
    /// Takes multiple folders each containing images of the same size and extension.
    /// Creates a new image that layers one randomly selected file from each folder on top of eachother.
    /// Outputs that file in a specified folder with a specified extension.
    /// </summary>
    class ImageCombiner
    {
        public string filePath;
        public string outputDirectory;
        public string inputImageExtension;
        public string outputImageExtension;
        public List<string> layerDirectories = new List<string>();

        public ImageCombiner()
        {
            filePath = @"C:\Users\Naomi\source\repos\Image Combiner\Image Combiner\bin\Debug\Creation\";
            outputDirectory = @"CreatedImage\";
            inputImageExtension = ".png";
            outputImageExtension = ".png";
            layerDirectories.Add(@"Hair\");
            layerDirectories.Add(@"Head\");
        }

        public ImageCombiner(string filepath, string outputdirectory, string inputimageextension, string outputimageextension, List<string> layerdirectories) : this()
        {
            filePath = filepath;
            outputDirectory = outputdirectory;
            inputImageExtension = inputimageextension;
            outputImageExtension = outputimageextension;
            layerDirectories = layerdirectories;
        }

        public void CreateImage(int outputFileName, Random rnd)
        {

            List<Image> Layers = new List<Image>();
            foreach (string directory in layerDirectories)
            {
                Layers.Add(SelectRandomImageFromDirectory(directory, rnd)); 
            }
                       
            Bitmap output = MergeImageLayers(Layers);

            string completeOutputPath = filePath + outputDirectory + outputFileName + outputImageExtension;
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

        private Image SelectRandomImageFromDirectory(string directory, Random rnd)
        {
            DirectoryInfo d = new DirectoryInfo(filePath + directory);
            FileInfo[] files = d.GetFiles("*"+inputImageExtension);
            string fileName = files[rnd.Next(0, files.Length)].Name;
            Image chosenImage = Image.FromFile(filePath + directory + fileName);
            return chosenImage;
        }

        private Bitmap MergeImageLayers(List<Image> layers)
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
