import sys
import logging
import pynput
import time
import os

log_dir = os.path.join(os.environ["LOCALAPPDATA"], "Controller Shortcuter")
os.makedirs(log_dir, exist_ok=True)
log_file = os.path.join(log_dir, "kbmEmulator.txt")

logging.basicConfig(
    filename=log_file,
    filemode='a',
    format='%(asctime)s %(levelname)s: %(message)s',
    level=logging.INFO
)
logger = logging.getLogger(__name__)

KeyboardKey = pynput.keyboard.Key
KeyboardController = pynput.keyboard.Controller

MouseButton = pynput.mouse.Button
MouseController = pynput.mouse.Controller

keyboard = KeyboardController()
mouse = MouseController()

def main():
    args = sys.argv
    logger.info("Incoming args: " + str(args))

    if args.count == 0:
        logger.error("No args provided, leaving")
        return

    for argument in args:
        if argument is not None and argument.find("keyboard_emulator.pyw") == -1:
            argument : str
            keys = [word.lower().lstrip() for word in argument.split(",")]
            DoAction(keys)

    
def DoAction(keys : list):
    for key in keys:
        key: str
        if len(key) == 1:
            logger.info("Pressing key: " + key)
            if (keyboard.pressed(key)):
                keyboard.release(key)
                keyboard.press(key)
            else:
                keyboard.press(key)      
            continue
        elif "delay(" in key:
            delay = float(key.removeprefix("delay(").removesuffix(")").lstrip())
            logger.info("Delaying execution for: " + str(delay))
            time.sleep(delay)
            continue
        elif "scrollx(" in key:
            scrollxAmount = int(key.removeprefix("scrollx(").removesuffix(")").lstrip())
            logger.info("Scroll along x axis amount: " + scrollxAmount)
            mouse.scroll(scrollxAmount, 0)
            continue
        elif "scrolly(" in key:
            scrollyAmount = int(key.removeprefix("scrolly(").removesuffix(")").lstrip())
            logger.info("Scroll along y axis amount: " + str(scrollyAmount))
            mouse.scroll(0, scrollyAmount)
            continue
        elif "mouse(" in key:
            mousePosition = key.removeprefix("mouse(").removesuffix(")").split(":")
            x = int(mousePosition[0].lstrip())
            y = int(mousePosition[1].lstrip())
            logger.info("Move mouse position to: " + str(mousePosition))
            mouse.position = (x, y)
            continue
        match key:
            case "space":
                if keyboard.pressed(KeyboardKey.space):
                    keyboard.release(KeyboardKey.space)
                keyboard.press(KeyboardKey.space)
            case "ctrl":
                if keyboard.pressed(KeyboardKey.ctrl):
                    keyboard.release(KeyboardKey.ctrl)
                keyboard.press(KeyboardKey.ctrl)
            case "esc":
                if keyboard.pressed(KeyboardKey.esc):
                    keyboard.release(KeyboardKey.esc)
                keyboard.press(KeyboardKey.esc)
            case "alt":
                if keyboard.pressed(KeyboardKey.alt):
                    keyboard.release(KeyboardKey.alt)
                keyboard.press(KeyboardKey.alt)
            case "shift":
                if keyboard.pressed(KeyboardKey.shift):
                    keyboard.release(KeyboardKey.shift)
                keyboard.press(KeyboardKey.shift)
            case "rshift":
                if keyboard.pressed(KeyboardKey.shift_r):
                    keyboard.release(KeyboardKey.shift_r)
                keyboard.press(KeyboardKey.shift_r)
            case "tab":
                if keyboard.pressed(KeyboardKey.tab):
                    keyboard.release(KeyboardKey.tab)
                keyboard.press(KeyboardKey.tab)
            case "capslock":
                if keyboard.pressed(KeyboardKey.caps_lock):
                    keyboard.release(KeyboardKey.caps_lock)
                keyboard.press(KeyboardKey.caps_lock)
            case "command" | "windows" | "window":
                if keyboard.pressed(KeyboardKey.cmd):
                    keyboard.release(KeyboardKey.cmd)
                keyboard.press(KeyboardKey.cmd)
            case "delete":
                if keyboard.pressed(KeyboardKey.delete):
                    keyboard.release(KeyboardKey.delete)
                keyboard.press(KeyboardKey.delete)
            case "backspace":
                if keyboard.pressed(KeyboardKey.backspace):
                    keyboard.release(KeyboardKey.backspace)
                keyboard.press(KeyboardKey.backspace)
            case "enter":
                if keyboard.pressed(KeyboardKey.enter):
                    keyboard.release(KeyboardKey.enter)
                keyboard.press(KeyboardKey.enter)
            case "insert":
                if keyboard.pressed(KeyboardKey.insert):
                    keyboard.release(KeyboardKey.insert)
                keyboard.press(KeyboardKey.insert)
            case "home":
                if keyboard.pressed(KeyboardKey.home):
                    keyboard.release(KeyboardKey.home)
                keyboard.press(KeyboardKey.home)
            case "end":
                if keyboard.pressed(KeyboardKey.end):
                    keyboard.release(KeyboardKey.end)
                keyboard.press(KeyboardKey.end)
            case "pageup":
                if keyboard.pressed(KeyboardKey.page_up):
                    keyboard.release(KeyboardKey.page_up)
                keyboard.press(KeyboardKey.page_up)
            case "pagedown":
                if keyboard.pressed(KeyboardKey.page_down):
                    keyboard.release(KeyboardKey.page_down)
                keyboard.press(KeyboardKey.page_down)
            case "left":
                if keyboard.pressed(KeyboardKey.left):
                    keyboard.release(KeyboardKey.left)
                keyboard.press(KeyboardKey.left)
            case "right":
                if keyboard.pressed(KeyboardKey.right):
                    keyboard.release(KeyboardKey.right)
                keyboard.press(KeyboardKey.right)
            case "up":
                if keyboard.pressed(KeyboardKey.up):
                    keyboard.release(KeyboardKey.up)
                keyboard.press(KeyboardKey.up)
            case "down":
                if keyboard.pressed(KeyboardKey.down):
                    keyboard.release(KeyboardKey.down)
                keyboard.press(KeyboardKey.down)
            case "f1":
                if keyboard.pressed(KeyboardKey.f1):
                    keyboard.release(KeyboardKey.f1)
                keyboard.press(KeyboardKey.f1)
            case "f2":
                if keyboard.pressed(KeyboardKey.f2):
                    keyboard.release(KeyboardKey.f2)
                keyboard.press(KeyboardKey.f2)
            case "f3":
                if keyboard.pressed(KeyboardKey.f3):
                    keyboard.release(KeyboardKey.f3)
                keyboard.press(KeyboardKey.f3)
            case "f4":
                if keyboard.pressed(KeyboardKey.f4):
                    keyboard.release(KeyboardKey.f4)
                keyboard.press(KeyboardKey.f4)
            case "f5":
                if keyboard.pressed(KeyboardKey.f5):
                    keyboard.release(KeyboardKey.f5)
                keyboard.press(KeyboardKey.f5)
            case "f6":
                if keyboard.pressed(KeyboardKey.f6):
                    keyboard.release(KeyboardKey.f6)
                keyboard.press(KeyboardKey.f6)
            case "f7":
                if keyboard.pressed(KeyboardKey.f7):
                    keyboard.release(KeyboardKey.f7)
                keyboard.press(KeyboardKey.f7)
            case "f8":
                if keyboard.pressed(KeyboardKey.f8):
                    keyboard.release(KeyboardKey.f8)
                keyboard.press(KeyboardKey.f8)
            case "f9":
                if keyboard.pressed(KeyboardKey.f9):
                    keyboard.release(KeyboardKey.f9)
                keyboard.press(KeyboardKey.f9)
            case "f10":
                if keyboard.pressed(KeyboardKey.f10):
                    keyboard.release(KeyboardKey.f10)
                keyboard.press(KeyboardKey.f10)
            case "f11":
                if keyboard.pressed(KeyboardKey.f11):
                    keyboard.release(KeyboardKey.f11)
                keyboard.press(KeyboardKey.f11)
            case "f12":
                if keyboard.pressed(KeyboardKey.f12):
                    keyboard.release(KeyboardKey.f12)
                keyboard.press(KeyboardKey.f12)
            case "rightclick":
                if mouse.pressed(MouseButton.right):
                    mouse.release(MouseButton.right)
                mouse.press(MouseButton.right)
            case "leftclick":
                if mouse.pressed(MouseButton.left):
                    mouse.release(MouseButton.left)
                mouse.press(MouseButton.left)
            case "middleclick":
                if mouse.pressed(MouseButton.middle):
                    mouse.release(MouseButton.middle)
                mouse.press(MouseButton.middle)
        
        logger.info("Special key: " + key + " was pressed")

    time.sleep(0.75)

    for key in keys:
        key : str
        if len(key) == 1:
            logger.info("Releasing key: " + key)
            keyboard.release(key)
        elif ("delay(" in key or "scrollx(" in key or "scrolly(" in key or "mouse(" in key):
            continue
        match key:
            case "space":
                keyboard.release(KeyboardKey.space)
            case "ctrl":
                keyboard.release(KeyboardKey.ctrl)
            case "esc":
                keyboard.release(KeyboardKey.esc)
            case "alt":
                keyboard.release(KeyboardKey.alt)
            case "shift":
                keyboard.release(KeyboardKey.shift)
            case "rshift":
                keyboard.release(KeyboardKey.shift_r)
            case "tab":
                keyboard.release(KeyboardKey.tab)
            case "capslock":
                keyboard.release(KeyboardKey.caps_lock)
            case "command" | "windows" | "window":
                keyboard.release(KeyboardKey.cmd)
            case "delete":
                keyboard.release(KeyboardKey.delete)
            case "backspace":
                keyboard.release(KeyboardKey.backspace)
            case "enter":
                keyboard.release(KeyboardKey.enter)
            case "insert":
                keyboard.release(KeyboardKey.insert)
            case "home":
                keyboard.release(KeyboardKey.home)
            case "end":
                keyboard.release(KeyboardKey.end)
            case "pageup":
                keyboard.release(KeyboardKey.page_up)
            case "pagedown":
                keyboard.release(KeyboardKey.page_down)
            case "left":
                keyboard.release(KeyboardKey.left)
            case "right":
                keyboard.release(KeyboardKey.right)
            case "up":
                keyboard.release(KeyboardKey.up)
            case "down":
                keyboard.release(KeyboardKey.down)
            case "f1":
                keyboard.release(KeyboardKey.f1)
            case "f2":
                keyboard.release(KeyboardKey.f2)
            case "f3":
                keyboard.release(KeyboardKey.f3)
            case "f4":
                keyboard.release(KeyboardKey.f4)
            case "f5":
                keyboard.release(KeyboardKey.f5)
            case "f6":
                keyboard.release(KeyboardKey.f6)
            case "f7":
                keyboard.release(KeyboardKey.f7)
            case "f8":
                keyboard.release(KeyboardKey.f8)
            case "f9":
                keyboard.release(KeyboardKey.f9)
            case "f10":
                keyboard.release(KeyboardKey.f10)
            case "f11":
                keyboard.release(KeyboardKey.f11)
            case "f12":
                keyboard.release(KeyboardKey.f12)
            case "rightclick":
                mouse.release(MouseButton.right)
            case "leftclick":
                mouse.release(MouseButton.left)
            case "middleclick":
                mouse.release(MouseButton.middle)
        logger.info("Special key: " + key + " was Released")

main()