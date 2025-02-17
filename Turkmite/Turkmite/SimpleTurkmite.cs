using OpenCvSharp;

namespace Turkmite
{
    public class SimpleTurkmite : TurkmiteBase
    {
        public static readonly Vec3b PrimaryColor = new Vec3b(0, 0, 255);
        public static readonly Vec3b SecondaryColor = new Vec3b(0, 0, 0);

        public override (Vec3b newColor, int deltaDirection) GetNextStep(Vec3b currentColor) 
            => currentColor == SecondaryColor ? (PrimaryColor, 1) : (SecondaryColor, -1);
    }
}
