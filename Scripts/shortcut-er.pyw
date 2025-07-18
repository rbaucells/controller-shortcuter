import pyglet
import logging
import os
import pystray
import PIL.Image
import threading
import time

class LineInfo:
    def __init__(self, tokens: list[int], command1: str, argument1 : str, command2: str, argument2 : str):
        self.tokens = tokens
        self.command1 = command1
        self.argument1 = argument1

        self.command2 = command2
        self.argument2 = argument2

        self.state = False

localAppDataPath = os.environ.get("LOCALAPPDATA")
curWorkingDir = os.getcwd()
programFilesPath = os.environ.get("ProgramFiles")
log_file = os.path.join(localAppDataPath,"Controller Shortcuter", "scriptlog.txt")

logging.basicConfig(
    filename=log_file,
    level=logging.INFO,
    format='%(asctime)s - %(levelname)s - %(message)s',
    filemode='a'
)

logger = logging.getLogger(__name__)

a = 0
b = 1
x = 2
y = 3

up = 4
down = 5
left = 6
right = 7

leftshoulder = 8
rightshoulder = 9

start = 10
back = 11

leftStick = 12
rightStick = 13

state : list[int] = [0] * 14

counter = 14

def close_script(icon):
    logger.info("Exiting application")
    if icon is not None:
        icon.stop() 
    pyglet.app.exit()
    quit()
    
def open_editor(icon):
    logger.info("Opening config file in editor")
    os.startfile(os.path.join(programFilesPath, "Controller Shortcuter", "ConfigApp", "config app.exe"))
    ...

imageDirectory = os.path.join(curWorkingDir , "Resources")
imagePath = os.path.join(imageDirectory, "icon.jpg")

if not os.path.exists(imagePath):
    os.makedirs(os.path.dirname(imageDirectory), exist_ok=True)
    logger.error(f"Image file not found at path [{imagePath}]")
    close_script(None)

image = PIL.Image.open(imagePath)

exitEvent = threading.Event()

icon = pystray.Icon("Shortcut-er", image, menu = pystray.Menu(
    pystray.MenuItem("Exit", close_script),
    pystray.MenuItem("Open Config", open_editor)
))

def run_icon():
    icon.run()

icon_thread = threading.Thread(target=run_icon)
icon_thread.daemon = True
icon_thread.start()

manager = pyglet.input.ControllerManager()

@manager.event
def on_connect(controller):
    controller : pyglet.input.Controller
    controller.open()
    
    @controller.event
    def on_button_press(controller, button_name):
        global a, b, x, y
        global leftshoulder, rightshoulder
        global start, back
        global leftStick, rightStick
        global counter
        global state

        logger.info(f"Button {button_name} pressed")

        if button_name == "a":
            state[a] = 1
        elif button_name == "b":
            state[b] = 1
        elif button_name == "x":
            state[x] = 1
        elif button_name == "y":
            state[y] = 1
        elif button_name == "leftshoulder":
            state[leftshoulder] = 1
        elif button_name == "rightshoulder":
            state[rightshoulder] = 1
        elif button_name == "start":
            state[start] = 1
        elif button_name == "back":
            state[back] = 1
        elif button_name == "leftstick":
            state[leftStick] = 1
        elif button_name == "rightstick":
            state[rightStick] = 1

        counter += 1

        process_input()

    @controller.event
    def on_button_release(controller, button_name):
        global a, b, x, y
        global leftshoulder, rightshoulder
        global start, back
        global leftStick, rightStick
        global counter
        global state

        logger.info(f"Button {button_name} released")

        if button_name == "a":
            state[a] = 0
        elif button_name == "b":
            state[b] = 0
        elif button_name == "x":
            state[x] = 0
        elif button_name == "y":
            state[y] = 0
        elif button_name == "leftshoulder":
            state[leftshoulder] = 0
        elif button_name == "rightshoulder":
            state[rightshoulder] = 0
        elif button_name == "start":
            state[start] = 0
        elif button_name == "back":
            state[back] = 0
        elif button_name == "leftstick":
            state[leftStick] = 0
        elif button_name == "rightstick":
            state[rightStick] = 0
        
        counter -= 1

    @controller.event
    def on_dpad_motion(controller, vector):
        global up, down, left, right
        global counter
        global state

        vector : tuple[float, float]

        if vector[0] > 0:
            logger.info("Right Pressed")
            state[right] = 1
            process_input()
        elif vector[0] < 0:
            logger.info("Left Pressed")
            state[left] = 1
            process_input()
        elif vector[1] > 0:
            logger.info("Up Pressed")
            state[up] = 1
            process_input()
        elif vector[1] < 0:
            logger.info("Down Pressed")
            state[down] = 1
            process_input()
        else:
            logger.info("Dpad released")
            state[up] = 0
            state[down] = 0
            state[left] = 0
            state[right] = 0

@manager.event
def on_disconnect(controller):
    controller : pyglet.input.Controller
    controller.close()
    logger.info("Controller Disconnected")

def parse_file_for_lines(path: str) -> list[LineInfo]:
    try:
        file = open(path)
    except FileNotFoundError:
        logger.error(f"File not found at path [{path}]")
        return
    
    lines = file.readlines()
    logger.info(f"Opened file [{path}] and found [{len(lines)}] lines")

    processedList:list[LineInfo] = []
    for line in lines:
        processed = parse_line_for_info(line)
        if processed is not None:
            processedList.append(processed)
    
    return processedList

def parse_line_for_info(line: str) -> LineInfo:
    logger.info(f"Parsing [{line}]")

    startInput = line.find('("') + 2
    endInput = line.find('")')
    tokens = [item.strip() for item in line[startInput:endInput].split(',')]

    tokenList : list[int] = [0] * len(state)

    for token in tokens:
        if token == "a":
            tokenList[a] = 1
        elif token == "b":
            tokenList[b] = 1
        elif token == "x":
            tokenList[x] = 1
        elif token == "y":
            tokenList[y] = 1
        elif token == "up":
            tokenList[up] = 1
        elif token == "down":
            tokenList[down] = 1
        elif token == "left":
            tokenList[left] = 1
        elif token == "right":
            tokenList[right] = 1
        elif token == "leftshoulder":
            tokenList[leftshoulder] = 1
        elif token == "rightshoulder":
            tokenList[rightshoulder] = 1
        elif token == "start":
            tokenList[start] = 1
        elif token == "back":
            tokenList[back] = 1
        elif token == "leftstick":
            tokenList[leftStick] = 1
        elif token == "rightstick":
            tokenList[rightStick] = 1

    startCommand1 = line.find('{"') + 2
    endCommand1 = line.find('"}')
    
    command1 = line[startCommand1:endCommand1].strip()

    startArgument1 = line.find('["') + 2
    endArgument1 = line.find('"]')

    argument1 = line[startArgument1:endArgument1].strip()

    lineWithout1 = line[endArgument1 + 2:len(line)].strip()

    startCommand2 = lineWithout1.find('{"') + 2
    endCommand2 = lineWithout1.find('"}')
    
    command2 = ""

    if (startCommand2 != -1 and endCommand2 > startCommand2 and endCommand2 != -1):
        command2 = lineWithout1[startCommand2:endCommand2].strip()

    startArgument2 = lineWithout1.find('["') + 2
    endArgument2 = lineWithout1.find('"]')

    argument2 = ""

    if (startArgument2 != -1 and endArgument2 > startArgument2 and endArgument2 != -1):
        argument2 = lineWithout1[startArgument2:endArgument2].strip()

    return LineInfo(tokenList, command1, argument1, command2, argument2)

def rumble(left, right, duration):
    global controllers
    start_time = time.time()
    controller = controllers[0]
    controller : pyglet.input.Controller
    while time.time() - start_time < duration:
        controller.rumble_play_strong(left)
        controller.rumble_play_weak(right)
        time.sleep(0.01)
    controller.rumble_stop_strong()
    controller.rumble_stop_weak()

def execute_command(command : str, argument : str):
    logger.info(f"Running command [{command}]") 
    try:
        os.startfile(filepath = command, arguments=argument)
    except FileNotFoundError:
        logger.error(f"Command [{command}] not found")
        return

def process_input():
    global lines, line, counter
    for line in lines:
        if state == line.tokens:
            threading.Thread(target=rumble, args=(1, 1, 0.15), daemon=True).start()
            if (line.command2 != ""):
                if (line.state):
                    execute_command(line.command2, line.argument2)
                    line.state = False
                else:
                    execute_command(line.command1, line.argument1)
                    line.state = True
            else:
                execute_command(line.command1, line.argument1)
            break

lines = parse_file_for_lines(os.path.join(localAppDataPath, "Controller Shortcuter", "config.txt"))

controllers = manager.get_controllers()

if (len(controllers) != 0):
    controller = controllers[0] 
    on_connect(controller)

pyglet.app.run()