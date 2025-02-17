using OpenCvSharp;
using Turkmite;

namespace TurkmiteTests
{
    public class SimpleTurkmiteTests
    {
        [Fact]
        public void StepFromBlack()
        {
            var turkmite = new SimpleTurkmite();
            (Vec3b newColor, int deltaDir) = turkmite.GetNextStep(new OpenCvSharp.Vec3b(0, 0, 0));
            Assert.Equal(new OpenCvSharp.Vec3b(255, 255, 255), newColor);
            Assert.Equal(1, deltaDir);
        }
    }
}