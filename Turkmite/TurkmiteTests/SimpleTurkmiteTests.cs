using OpenCvSharp;
using Turkmite;

namespace TurkmiteTests
{
    public class SimpleTurkmiteTests
    {
        [Fact]
        public void StepFromPrimaryColor()
        {
            var turkmite = new SimpleTurkmiteMock();
            (Vec3b newColor, int deltaDir) = turkmite.GetNextStep(SimpleTurkmite.PrimaryColor);
            Assert.Equal(SimpleTurkmite.SecondaryColor, newColor);
            Assert.Equal(-1, deltaDir);
        }

        class SimpleTurkmiteMock : SimpleTurkmite
        {
            public new (Vec3b newColor, int deltaDirection) GetNextStep(Vec3b currentColor)
                => base.GetNextStep(currentColor);
        }
    }
}
