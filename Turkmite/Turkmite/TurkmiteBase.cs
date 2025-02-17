using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turkmite
{
    internal class TurkmiteBase
    {
        private int x = 100;
        private int y = 100;
        private int direction = 0;  // 0 up, 1 right, 2 down, 3 left
        private Vec3b white = new Vec3b(255, 255, 255);
        private Vec3b black = new Vec3b(0, 0, 0);

        readonly (int, int)[] deltaXY = [(0, -1), (1, 0), (0, 1), (-1, 0)];

        public void Step(Mat.Indexer<Vec3b> indexer)
        {
            Vec3b currentColor = indexer[y, x];
            if (currentColor == black)
            {
                indexer[y, x] = white;
                direction++;
            }
            else
            {
                indexer[y, x] = black;
                direction--;
            }

            direction = (direction + 4) % 4;
            (int dx, int dy) = deltaXY[direction];
            x += dx;
            y += dy;
            x = Math.Min(Math.Max(x, 0), 199);
            y = Math.Min(Math.Max(y, 0), 199);
        }

    }
}
