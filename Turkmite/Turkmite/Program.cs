using OpenCvSharp;
using System;

namespace Turkmite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat img = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            //var turkmite = new BasicTurkmite(img);
            var turkmite = new ColorTurkmite(img);
            for (int i = 0; i < 50000; i++)
            {
                turkmite.Step();
            }
            Cv2.ImShow("TurkMite", img);
            Cv2.WaitKey();

        }
    }
}
