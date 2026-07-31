#include "splashkit.h"

int main()
{
    open_window("Calculate Collision Direction", 800, 600);

    double moving_x = 250;
    double moving_y = 300;

    const double fixed_x = 520;
    const double fixed_y = 300;
    const double radius = 70;
    const double speed = 3;

    while (!quit_requested())
    {
        process_events();

        if (key_down(LEFT_KEY))
        {
            moving_x -= speed;
        }

        if (key_down(RIGHT_KEY))
        {
            moving_x += speed;
        }

        if (key_down(UP_KEY))
        {
            moving_y -= speed;
        }

        if (key_down(DOWN_KEY))
        {
            moving_y += speed;
        }

        circle moving_circle = circle_at(
            moving_x,
            moving_y,
            radius
        );

        circle fixed_circle = circle_at(
            fixed_x,
            fixed_y,
            radius
        );

        vector_2d collision_direction =
            calculate_collision_direction(
                moving_circle,
                fixed_circle
            );

        clear_screen(COLOR_BLACK);

        fill_circle(COLOR_BLUE, moving_circle);
        fill_circle(COLOR_ORANGE, fixed_circle);

        if (
            collision_direction.x != 0
            || collision_direction.y != 0
        )
        {
            double line_end_x =
                moving_x + collision_direction.x * 120;

            double line_end_y =
                moving_y + collision_direction.y * 120;

            draw_line(
                COLOR_YELLOW,
                moving_x,
                moving_y,
                line_end_x,
                line_end_y
            );

            fill_circle(
                COLOR_YELLOW,
                line_end_x,
                line_end_y,
                7
            );

            draw_text(
                "Collision detected",
                COLOR_WHITE,
                20,
                50
            );
        }
        else
        {
            draw_text(
                "No collision",
                COLOR_WHITE,
                20,
                50
            );
        }

        draw_text(
            "Use the Arrow Keys to move the blue circle",
            COLOR_WHITE,
            20,
            20
        );

        refresh_screen(60);
    }

    close_all_windows();

    return 0;
}