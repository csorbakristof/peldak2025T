using OpenCvSharp;

namespace Turkmite
{
    public class BasicTurkmite : TurkmiteBase
    {
        public BasicTurkmite(Mat image) : base(image)
        {
        }

        public readonly Vec3b black = new Vec3b(0, 0, 0);
        public readonly Vec3b white = new Vec3b(255, 255, 255);

        public override int PreferredStepCount => 13000;

        protected override (Vec3b newColor, int turn) GetStep(Vec3b currentColor)
        {
            return currentColor == black ? (white, 1) : (black, -1);
        }
    }
}
