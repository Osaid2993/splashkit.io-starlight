from splashkit import *

open_window("Calculate Collision Direction", 800, 600)

moving_x = 250
moving_y = 300

fixed_x = 520
fixed_y = 300
radius = 70
speed = 3

while not quit_requested():
    process_events()

    if key_down(KeyCode.left_key):
        moving_x -= speed

    if key_down(KeyCode.right_key):
        moving_x += speed

    if key_down(KeyCode.up_key):
        moving_y -= speed

    if key_down(KeyCode.down_key):
        moving_y += speed

    moving_circle = circle_at(
        moving_x,
        moving_y,
        radius
    )

    fixed_circle = circle_at(
        fixed_x,
        fixed_y,
        radius
    )

    collision_direction = calculate_collision_direction(
        moving_circle,
        fixed_circle
    )

    clear_screen(color_black())

    fill_circle_record(color_blue(), moving_circle)
    fill_circle_record(color_orange(), fixed_circle)

    if collision_direction.x != 0 or collision_direction.y != 0:
        line_end_x = moving_x + collision_direction.x * 120
        line_end_y = moving_y + collision_direction.y * 120

        draw_line(
            color_yellow(),
            moving_x,
            moving_y,
            line_end_x,
            line_end_y
        )

        fill_circle(
            color_yellow(),
            line_end_x,
            line_end_y,
            7
        )

        draw_text_no_font_no_size(
            "Collision detected",
            color_white(),
            20,
            50
        )
    else:
        draw_text_no_font_no_size(
            "No collision",
            color_white(),
            20,
            50
        )

    draw_text_no_font_no_size(
        "Use the Arrow Keys to move the blue circle",
        color_white(),
        20,
        20
    )

    refresh_screen_with_target_fps(60)

close_all_windows()