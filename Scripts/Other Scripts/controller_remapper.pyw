import pyglet
import pynput
import threading
import time

up = False
down = False
left = False
right = False

scroll_up = False
scroll_down = False

escape = False

left_click = False
right_click = False
cursor_speed = 3
scroll_speed = 0.2
loop_delay = 0.01

manager = pyglet.input.ControllerManager()

@manager.event
def on_connect(controller):

    controller : pyglet.input.Controller
    controller.open()
    @controller.event
    def on_stick_motion(controller, name, vector):
        global up, down, left, right
        global scroll_up, scroll_down

        x = vector[0]
        y = vector[1]

        if name == "leftstick":
            if x > 0.5:
                right = True
            elif x < -0.5:
                left = True
            else:
                right = False
                left = False
            if y > 0.5:
                down = True
            elif y < -0.5:
                up = True
            else:
                up = False
                down = False
        elif name == "rightstick":
            if y > 0.5:
                scroll_up = True
            elif y < -0.5:
                scroll_down = True
            else:
                scroll_up = False
                scroll_down = False
    @controller.event
    def on_button_press(controller, button_name):
        global left_click, escape, right_click
        if button_name == "a":
            left_click = True
            pynput.mouse.Controller().press(pynput.mouse.Button.left)
        elif button_name == "b":
            escape = True
            pynput.keyboard.Controller().press(pynput.keyboard.Key.esc)
        elif button_name == "x":
            right_click = True
            pynput.mouse.Controller().press(pynput.mouse.Button.right)

    @controller.event
    def on_button_release(controller, button_name):
        global left_click, escape, right_click
        if button_name == "a" and left_click:
            left_click = False
            pynput.mouse.Controller().release(pynput.mouse.Button.left)
        elif button_name == "b" and escape:
            escape = False
            pynput.keyboard.Controller().release(pynput.keyboard.Key.esc)
        elif button_name == "x" and right_click:
            right_click = False
            pynput.mouse.Controller().release(pynput.mouse.Button.right)

@manager.event
def on_disconnect(controller):
    global up, down, left, right
    global scroll_up, scroll_down
    global escape

    if left_click:
        pynput.mouse.Controller().release(pynput.mouse.Button.left)
    if right_click:
        pynput.mouse.Controller().release(pynput.mouse.Button.right)
    if escape:
        pynput.keyboard.Controller().release(pynput.keyboard.Key.esc)

    up = False
    down = False
    left = False
    right = False
    scroll_up = False
    scroll_down = False
    escape = False

def main_loop():
    while True:
        global up, down, left, right
        global scroll_up, scroll_down

        if up:
            pynput.mouse.Controller().move(0, cursor_speed)
        elif down:
            pynput.mouse.Controller().move(0, -cursor_speed)
        if left:
            pynput.mouse.Controller().move(-cursor_speed, 0)
        elif right:
            pynput.mouse.Controller().move(cursor_speed, 0)
        if scroll_up:
            pynput.mouse.Controller().scroll(0, scroll_speed)
        elif scroll_down:
            pynput.mouse.Controller().scroll(0, -scroll_speed)
        time.sleep(loop_delay)

controllers = manager.get_controllers()

if (len(controllers) != 0):
    controller = controllers[0] 
    on_connect(controller)

threading.Thread(target=main_loop, daemon=True).start()

pyglet.app.run()