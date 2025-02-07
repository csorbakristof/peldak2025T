using OpenCvSharp;

namespace Turkmite
{
    public abstract class TurkmiteBase
    {
        public Mat.Indexer<Vec3b> Indexer { get; }

        private int x;
        private int y;
        private int direction;

        public TurkmiteBase(Mat image)
        {
            Indexer = image.GetGenericIndexer<Vec3b>();
            x = image.Width / 2;
            y = image.Height / 2;
            direction = 0;
        }

        public abstract int PreferredStepCount { get; }

        public void Step()
        {
            Vec3b currentColor = Indexer[y, x];

            (Vec3b newColor, int turn) = GetStep(currentColor);
            Indexer[y, x] = newColor;
            direction += turn;

            direction = (direction + 4) % 4;

            (int, int)[] dxy = [(0, -1), (1, 0), (0, 1), (-1, 0)];
            (var dx, var dy) = dxy[direction];
            x += dx;
            y += dy;
            x = Math.Min(Math.Max(x, 0), 199);
            y = Math.Min(Math.Max(y, 0), 199);
        }

        protected abstract (Vec3b newColor, int turn) GetStep(Vec3b currentColor);
    }
}
