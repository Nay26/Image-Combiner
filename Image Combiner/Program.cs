﻿using System;
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
        static void Main(string[] args)        
        {
            int outputFileName = 534;
            Random rnd = new Random();
                  
            string inputFilePath = @"C:\Users\Naomi\source\repos\Image Combiner\Image Combiner\bin\Debug\Creation\";
            string outputFilePath = inputFilePath + @"CreatedImage\";
            string inputImageExtension = ".png";
            string outputImageExtension = ".png";

            List<string> layerDirectories = new List<string>();
            layerDirectories.Add(@"Hair\");
            layerDirectories.Add(@"Head\");
           
            RandomFileGrabber grabber = new RandomFileGrabber(inputFilePath, inputImageExtension, layerDirectories);
            List<Image> imageLayers = grabber.SelectRandomImageFromDirectories(rnd);
            ImageCombiner combine = new ImageCombiner(outputFilePath, outputImageExtension);
            Bitmap outputImage = combine.MergeImageLayers(imageLayers);
            combine.SaveImage(outputImage,outputFileName);
                       
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
