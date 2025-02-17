using OpenCvSharp;
using Turkmite;

namespace TurkmiteTests
{
    public class SimpleTurkmiteTests
    {
        [Fact]
        public void StepFromPrimaryColor()
        {
            var turkmite = new SimpleTurkmite();
            (Vec3b newColor, int deltaDir) = turkmite.GetNextStep(SimpleTurkmite.PrimaryColor);
            Assert.Equal(SimpleTurkmite.SecondaryColor, newColor);
            Assert.Equal(-1, deltaDir);
        }
    }
}