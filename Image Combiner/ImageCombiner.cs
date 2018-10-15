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
        public string FilePath { get; set; }
        public string OutputDirectory { get; set; }
        public string InputImageExtension { get; set; }
        public string OutputImageExtension { get; set; }
        public List<string> FolderNames = new List<string>();

        public ImageCombiner()
        {
            FilePath = @"C:\Users\Naomi\source\repos\Image Combiner\Image Combiner\bin\Debug\Creation\";
            OutputDirectory = @"CreatedImage\";
            InputImageExtension = ".png";
            OutputImageExtension = ".png";
            FolderNames.Add(@"Hair\");
            FolderNames.Add(@"Head\");
        }

        public ImageCombiner(string filepath, string outputdirectory, string inputimagedirectory, string outputimageextension, List<string> foldernames) : this()
        {
            FilePath = filepath;
            OutputDirectory = outputdirectory;
            InputImageExtension = InputImageExtension;
            OutputImageExtension = outputimageextension;
            FolderNames = foldernames;
        }

        public void CreateImage(int outputFileName, Random rnd)
        {

            List<Image> Layers = new List<Image>();
            foreach (string folder in FolderNames)
            {
                Layers.Add(SelectRandomImageFromFile(folder, rnd)); 
            }
                       
            Bitmap output = MergeImageLayers(Layers);

            string completeOutputPath = FilePath + OutputDirectory + outputFileName + OutputImageExtension;
            switch (OutputImageExtension)
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

        private Image SelectRandomImageFromFile(string folder, Random rnd)
        {
            DirectoryInfo d = new DirectoryInfo(FilePath + folder);
            FileInfo[] Files = d.GetFiles("*"+InputImageExtension);
            string fileName = Files[rnd.Next(0, Files.Length)].Name;
            Image chosenImage = Image.FromFile(FilePath + folder + fileName);
            return chosenImage;
        }

        private Bitmap MergeImageLayers(List<Image> Layers)
        {
            int outputImageWidth = Layers[0].Width;
            int outputImageHeight = Layers[0].Height;
            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                foreach(Image image in Layers)
                {
                    graphics.DrawImage(image, new Rectangle(new Point(), image.Size),
                    new Rectangle(new Point(), image.Size), GraphicsUnit.Pixel);
                }
            }
            return outputImage;
        }
    }
}
