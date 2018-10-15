using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Combiner
{
    class Program
    {
        public static string filePath = @"C:\Users\Naomi\source\repos\Image Combiner\Image Combiner\bin\Debug\Creation\";
        // These will be passed in when running, PersonId is for testing
        public static Random rnd = new Random();
        public static int PersonID = 524;

        static void Main(string[] args)        
        {
            List<Image> Layers = new List<Image>();
            // Your Layer Folders Here:
            Layers.Add(SelectRandomImageFromFile(@"Hair\"));
            Layers.Add(SelectRandomImageFromFile(@"Head\"));
            Bitmap output = MergeImageLayers(Layers);
            output.Save(filePath+@"CreatedImage\" + PersonID + ".png", ImageFormat.Png);
        }

        private static Image SelectRandomImageFromFile(string folder)
        {
            DirectoryInfo d = new DirectoryInfo(filePath+folder);
            FileInfo[] Files = d.GetFiles("*.png"); 
            string fileName = Files[rnd.Next(0,Files.Length)].Name;
            Image chosenImage = Image.FromFile(filePath+folder+fileName);
            return chosenImage;
        }

        public static Bitmap MergeImageLayers (List<Image> Layers)
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
