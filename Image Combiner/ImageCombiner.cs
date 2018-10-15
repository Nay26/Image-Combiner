using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Combiner
{
    class ImageCombiner
    {

        public string filePath = @"C:\Users\Naomi\source\repos\Image Combiner\Image Combiner\bin\Debug\Creation\";        

        public void CreateImage(int outputFileName, Random rnd)
        {
            List<Image> Layers = new List<Image>();

            // Your Layer Folders Here:
            Layers.Add(SelectRandomImageFromFile(@"Hair\", rnd));
            Layers.Add(SelectRandomImageFromFile(@"Head\", rnd));

            Bitmap output = MergeImageLayers(Layers);
            output.Save(filePath + @"CreatedImage\" + outputFileName + ".png", ImageFormat.Png);
        }

        private Image SelectRandomImageFromFile(string folder, Random rnd)
        {
            DirectoryInfo d = new DirectoryInfo(filePath + folder);
            FileInfo[] Files = d.GetFiles("*.png");
            string fileName = Files[rnd.Next(0, Files.Length)].Name;
            Image chosenImage = Image.FromFile(filePath + folder + fileName);
            return chosenImage;
        }

        private Bitmap MergeImageLayers(List<Image> Layers)
        {
            int outputImageWidth = Layers[0].Width;
            int outputImageHeight = Layers[0].Height;
            Bitmap outputImage = new Bitmap(outputImageWidth, outputImageHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics graphics = Graphics.FromImage(outputImage))
            {
                for (int i = 0; i < Layers.Count; i++)
                {
                    graphics.DrawImage(Layers[i], new Rectangle(new Point(), Layers[i].Size),
                    new Rectangle(new Point(), Layers[i].Size), GraphicsUnit.Pixel);
                }
            }
            return outputImage;
        }
    }
}
