using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turkmite
{
    internal abstract class TurkmiteBase
    {
        protected int x = 100;
        protected int y = 100;
        protected int direction = 0;  // 0 up, 1 right, 2 down, 3 left

        readonly (int, int)[] deltaXY = [(0, -1), (1, 0), (0, 1), (-1, 0)];

        public void Step(Mat.Indexer<Vec3b> indexer)
        {
            (var newColor, int deltaDirection) = GetNextStep(indexer[y, x]);
            indexer[y, x] = newColor;
            direction = (direction + deltaDirection + 4) % 4;
            (int dx, int dy) = deltaXY[direction];
            x += dx;
            y += dy;
            x = Math.Min(Math.Max(x, 0), 199);
            y = Math.Min(Math.Max(y, 0), 199);
        }

        public abstract (Vec3b newColor, int deltaDirection) GetNextStep(Vec3b currentColor);
    }
}
