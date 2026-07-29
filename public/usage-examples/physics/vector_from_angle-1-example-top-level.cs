using SplashKitSDK;
using static SplashKitSDK.SplashKit;

Window window = new("Vector From Angle", 800, 600);

double angle = 0;
const double length = 180;

while (!window.CloseRequested)
{
    ProcessEvents();

    if (KeyDown(KeyCode.LeftKey))
    {
        angle -= 2;
    }

    if (KeyDown(KeyCode.RightKey))
    {
        angle += 2;
    }

    ClearScreen(Color.Black);

    Point2D center = new()
    {
        X = window.Width / 2,
        Y = window.Height / 2
    };

    Vector2D direction = VectorFromAngle(angle, length);

    Point2D end = new()
    {
        X = center.X + direction.X,
        Y = center.Y + direction.Y
    };

    DrawLine(Color.DeepSkyBlue, center.X, center.Y, end.X, end.Y);
    FillCircle(Color.Yellow, end.X, end.Y, 10);
    FillCircle(Color.White, center.X, center.Y, 6);

    DrawText($"Angle: {angle:0}°", Color.White, 20, 20);
    DrawText("Use Left/Right Arrow Keys", Color.LightGray, 20, 50);

    RefreshScreen(60);
}