using SplashKitSDK;
using static SplashKitSDK.SplashKit;

OpenWindow("Calculate Collision Direction", 800, 600);

double movingX = 250;
double movingY = 300;
const double fixedX = 520;
const double fixedY = 300;
const double radius = 70;
const double speed = 3;

while (!QuitRequested())
{
    ProcessEvents();

    if (KeyDown(KeyCode.LeftKey))
    {
        movingX -= speed;
    }

    if (KeyDown(KeyCode.RightKey))
    {
        movingX += speed;
    }

    if (KeyDown(KeyCode.UpKey))
    {
        movingY -= speed;
    }

    if (KeyDown(KeyCode.DownKey))
    {
        movingY += speed;
    }

    Circle movingCircle = CircleAt(movingX, movingY, radius);
    Circle fixedCircle = CircleAt(fixedX, fixedY, radius);

    Vector2D collisionDirection = CalculateCollisionDirection(
        movingCircle,
        fixedCircle
    );

    ClearScreen(ColorBlack());

    FillCircle(ColorBlue(), movingCircle);
    FillCircle(ColorOrange(), fixedCircle);

    if (collisionDirection.X != 0 || collisionDirection.Y != 0)
    {
        double lineEndX = movingX + collisionDirection.X * 120;
        double lineEndY = movingY + collisionDirection.Y * 120;

        DrawLine(
            ColorYellow(),
            movingX,
            movingY,
            lineEndX,
            lineEndY
        );

        FillCircle(ColorYellow(), lineEndX, lineEndY, 7);

        DrawText(
            "Collision detected",
            ColorWhite(),
            20,
            50
        );
    }
    else
    {
        DrawText(
            "No collision",
            ColorWhite(),
            20,
            50
        );
    }

    DrawText(
        "Use the Arrow Keys to move the blue circle",
        ColorWhite(),
        20,
        20
    );

    RefreshScreen(60);
}

CloseAllWindows();