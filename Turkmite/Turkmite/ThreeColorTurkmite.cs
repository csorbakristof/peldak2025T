using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turkmite
{
    internal class ThreeColorTurkmite : TurkmiteBase
    {
        public static readonly Vec3b Red = new Vec3b(0, 0, 255);
        public static readonly Vec3b Blue = new Vec3b(255, 0, 0);
        public static readonly Vec3b Yellow = new Vec3b(0, 255, 255);

        public override int GetOptimalStepCount() => 100000;

        protected override (Vec3b newColor, int deltaDirection) GetNextStep(Vec3b currentColor)
        {
            if (currentColor == Red)
            {
                return (Blue, 1);
            }
            else if (currentColor == Blue)
            {
                return (Yellow, 1);
            }
            else
            {
                return (Red, -1);
            }
        }
    }
}
