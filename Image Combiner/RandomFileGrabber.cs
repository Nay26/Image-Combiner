using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_Combiner
{
    /// <summary>
    /// Grabs a random file from each directory in the list and returns a list of those images
    /// </summary>
    class RandomFileGrabber
    {
        public string filePath;
        public string inputImageExtension;
        public List<string> layerDirectories = new List<string>();

        public RandomFileGrabber()
        {
            filePath = @"C:\Users\Naomi\source\repos\Image Combiner\Image Combiner\bin\Debug\Creation\";
            inputImageExtension = ".png";
            layerDirectories.Add(@"Head\");
            layerDirectories.Add(@"Hair\");
        }

        public RandomFileGrabber(string filepath, string inputimageextension, List<string> layerdirectories) : this()
        {
            filePath = filepath;
            inputImageExtension = inputimageextension;
            layerDirectories = layerdirectories;
        }

        public List<Image> SelectRandomImageFromDirectories( Random rnd)
        {
            List<Image> layers = new List<Image>();
            foreach (string directory in layerDirectories)
            {
                DirectoryInfo d = new DirectoryInfo(filePath + directory);
                FileInfo[] files = d.GetFiles("*" + inputImageExtension);
                string fileName = files[rnd.Next(0, files.Length)].Name;
                Image chosenImage = Image.FromFile(filePath + directory + fileName);               
                layers.Add(chosenImage);
            }
            return layers;
            
        }
    }
}
