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
            combine.CreateImage(645, rnd);
            Console.WriteLine("Done");
            Console.ReadLine();
        }
    }
}
