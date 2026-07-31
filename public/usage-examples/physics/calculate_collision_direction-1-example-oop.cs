using SplashKitSDK;

namespace CalculateCollisionDirectionExample
{
    public class Program
    {
        public static void Main()
        {
            SplashKit.OpenWindow(
                "Calculate Collision Direction",
                800,
                600
            );

            double movingX = 250;
            double movingY = 300;

            const double fixedX = 520;
            const double fixedY = 300;
            const double radius = 70;
            const double speed = 3;

            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();

                if (SplashKit.KeyDown(KeyCode.LeftKey))
                {
                    movingX -= speed;
                }

                if (SplashKit.KeyDown(KeyCode.RightKey))
                {
                    movingX += speed;
                }

                if (SplashKit.KeyDown(KeyCode.UpKey))
                {
                    movingY -= speed;
                }

                if (SplashKit.KeyDown(KeyCode.DownKey))
                {
                    movingY += speed;
                }

                Circle movingCircle = SplashKit.CircleAt(
                    movingX,
                    movingY,
                    radius
                );

                Circle fixedCircle = SplashKit.CircleAt(
                    fixedX,
                    fixedY,
                    radius
                );

                Vector2D collisionDirection =
                    SplashKit.CalculateCollisionDirection(
                        movingCircle,
                        fixedCircle
                    );

                SplashKit.ClearScreen(Color.Black);

                SplashKit.FillCircle(Color.Blue, movingCircle);
                SplashKit.FillCircle(Color.Orange, fixedCircle);

                if (
                    collisionDirection.X != 0
                    || collisionDirection.Y != 0
                )
                {
                    double lineEndX =
                        movingX + collisionDirection.X * 120;

                    double lineEndY =
                        movingY + collisionDirection.Y * 120;

                    SplashKit.DrawLine(
                        Color.Yellow,
                        movingX,
                        movingY,
                        lineEndX,
                        lineEndY
                    );

                    SplashKit.FillCircle(
                        Color.Yellow,
                        lineEndX,
                        lineEndY,
                        7
                    );

                    SplashKit.DrawText(
                        "Collision detected",
                        Color.White,
                        20,
                        50
                    );
                }
                else
                {
                    SplashKit.DrawText(
                        "No collision",
                        Color.White,
                        20,
                        50
                    );
                }

                SplashKit.DrawText(
                    "Use the Arrow Keys to move the blue circle",
                    Color.White,
                    20,
                    20
                );

                SplashKit.RefreshScreen(60);
            }

            SplashKit.CloseAllWindows();
        }
    }
}