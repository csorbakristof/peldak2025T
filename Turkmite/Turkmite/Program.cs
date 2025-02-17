using OpenCvSharp;

namespace Turkmite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mat img = new Mat(200, 200, MatType.CV_8UC3, new Scalar(0, 0, 0));
            var indexer = img.GetGenericIndexer<Vec3b>();
            var turkmite = new SimpleTurkmite();

            for (int i = 0; i < 13000; i++)
            {
                turkmite.Step(indexer);
            }

            Cv2.ImShow("TurkMite", img);
            Cv2.WaitKey();
        }
    }
}
