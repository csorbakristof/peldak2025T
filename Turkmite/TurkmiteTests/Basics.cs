using Turkmite;

namespace TurkmiteTests
{
    public class Basics
    {
        [Fact]
        public void BasicTurkmiteRules()
        {
            var t = new BasicTurkmiteMock(new OpenCvSharp.Mat(200, 200, OpenCvSharp.MatType.CV_8UC3));
            Assert.Equal(t.white, t.GetStep(t.black).newColor);
        }

        class BasicTurkmiteMock : BasicTurkmite
        {
            public BasicTurkmiteMock(OpenCvSharp.Mat image) : base(image)
            {
            }
            public new (OpenCvSharp.Vec3b newColor, int turn) GetStep(OpenCvSharp.Vec3b currentColor)
            {
                return base.GetStep(currentColor);
            }
        }
    }
}