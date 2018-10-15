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
        static void Main(string[] args)        
        {
            int outputFileName = 534;
            Random rnd = new Random();

            ImageCombiner combine = new ImageCombiner();
            combine.CreateImage(outputFileName, rnd);
            combine.outputImageExtension = ".gif";
            combine.CreateImage(645, rnd);


            List<string> files = new List<string>();
            files.Add(@"Hair\");
            files.Add(@"Head\");
            ImageCombiner combine2 = new ImageCombiner(@"C:\Users\Naomi\source\repos\Image Combiner\Image Combiner\bin\Debug\Creation\", @"CreatedImage\", ".png", ".jpeg",files );
            combine2.CreateImage(444,rnd);
           //Test Comment
            
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
