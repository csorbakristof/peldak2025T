using OpenCvSharp;

namespace Turkmite
{
    public class SimpleTurkmite : TurkmiteBase
    {
        private readonly Vec3b white = new Vec3b(255, 255, 255);
        private readonly Vec3b black = new Vec3b(0, 0, 0);

        public override (Vec3b newColor, int deltaDirection) GetNextStep(Vec3b currentColor) 
            => currentColor == black ? (white, 1) : (black, -1);
    }
}
