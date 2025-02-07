using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turkmite
{
    public class ColorTurkmite : TurkmiteBase
    {
        public ColorTurkmite(Mat image) : base(image)
        {
        }
        public readonly Vec3b black = new Vec3b(0, 0, 0);
        public readonly Vec3b red = new Vec3b(0, 0, 255);
        public readonly Vec3b yellow = new Vec3b(0, 255, 255);

        public override int PreferredStepCount => 50000;

        protected override (Vec3b newColor, int turn) GetStep(Vec3b currentColor)
        {
            return currentColor == black ? (red, 1) : ( currentColor==red ? (yellow, -1) : (black, -1));
        }
    }
}
