using System.Runtime.InteropServices;

namespace Pomodoro;

static class GrayScaleMode
{
    private static MAGCOLOREFFECT GRAY_SCALE;
    private static MAGCOLOREFFECT DEFAULT;

    static GrayScaleMode()
    {
        var redScale = 0.2126f;
        var greenScale = 0.7152f;
        var blueScale = 0.0722f;

        GRAY_SCALE = new MAGCOLOREFFECT
        {
            transform = [
                redScale,   redScale,   redScale,   0.0f,  0.0f,
                greenScale, greenScale, greenScale, 0.0f,  0.0f,
                blueScale,  blueScale,  blueScale,  0.0f,  0.0f,
                0.0f,       0.0f,       0.0f,       1.0f,  0.0f,
                0.0f,       0.0f,       0.0f,       0.0f,  1.0f
            ]
        };

        DEFAULT = new MAGCOLOREFFECT
        {
            transform = [
                1.0f, 0.0f, 0.0f, 0.0f, 0.0f,  // Red
                0.0f, 1.0f, 0.0f, 0.0f, 0.0f,  // Green
                0.0f, 0.0f, 1.0f, 0.0f, 0.0f,  // Blue
                0.0f, 0.0f, 0.0f, 1.0f, 0.0f,  // Alpha
                0.0f, 0.0f, 0.0f, 0.0f, 1.0f   // Constant
            ]
        };

    }

    const int OnAndOffDelay = 300;
    public static void On()
    {
        MagUninitialize();
        Thread.Sleep(OnAndOffDelay);
        MagInitialize();
        MagSetFullscreenColorEffect(ref GRAY_SCALE);
    }

    public static void Off()
    {
        MagUninitialize();
        Thread.Sleep(OnAndOffDelay);
        MagInitialize();
        MagSetFullscreenColorEffect(ref DEFAULT);
    }

    const string Magnification = "Magnification.dll";

    [DllImport(Magnification, ExactSpelling = true, SetLastError = true)]
    private static extern bool MagInitialize();

    [DllImport(Magnification, ExactSpelling = true, SetLastError = true)]
    private static extern bool MagUninitialize();

    [DllImport(Magnification, ExactSpelling = true, SetLastError = true)]
    private static extern bool MagSetFullscreenColorEffect(ref MAGCOLOREFFECT pEffect);

    private struct MAGCOLOREFFECT
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 25)]
        public float[] transform;
    }
}