using SplashKitSDK;

namespace HSBColorExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow("HSB Color", 800, 600);

            double hue = 0.0;
            double saturation = 1.0;
            double brightness = 1.0;

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                if (SplashKit.KeyDown(KeyCode.LeftKey))
                {
                    hue -= 0.005;
                }

                if (SplashKit.KeyDown(KeyCode.RightKey))
                {
                    hue += 0.005;
                }

                if (SplashKit.KeyDown(KeyCode.DownKey))
                {
                    saturation -= 0.005;
                }

                if (SplashKit.KeyDown(KeyCode.UpKey))
                {
                    saturation += 0.005;
                }

                if (SplashKit.KeyDown(KeyCode.SKey))
                {
                    brightness -= 0.005;
                }

                if (SplashKit.KeyDown(KeyCode.WKey))
                {
                    brightness += 0.005;
                }

                hue = Math.Clamp(hue, 0.0, 1.0);
                saturation = Math.Clamp(saturation, 0.0, 1.0);
                brightness = Math.Clamp(brightness, 0.0, 1.0);

                Color selectedColor = SplashKit.HSBColor(
                    hue,
                    saturation,
                    brightness
                );

                SplashKit.ClearScreen(Color.Black);

                SplashKit.FillRectangle(
                    selectedColor,
                    250,
                    120,
                    300,
                    260
                );

                SplashKit.DrawText(
                    $"Hue: {hue:F2}",
                    Color.White,
                    40,
                    430
                );

                SplashKit.DrawText(
                    $"Saturation: {saturation:F2}",
                    Color.White,
                    40,
                    460
                );

                SplashKit.DrawText(
                    $"Brightness: {brightness:F2}",
                    Color.White,
                    40,
                    490
                );

                SplashKit.DrawText(
                    "Left/Right: Hue   Up/Down: Saturation   W/S: Brightness",
                    Color.White,
                    40,
                    530
                );

                SplashKit.RefreshScreen(60);
            }

            SplashKit.CloseAllWindows();
        }
    }
}