-- INSTALLATION--
If you don't have the .net sdk, install it https://www.python.org/downloads/
If you don't have python, install it https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.17-windows-x64-installer
run setup.py to install all the libraries needed


shortcut-er.pyw is the main script. it is responsible for turning your controller inputs into an action.
An action can be anything and everything: A script, an executable, a shortcut. 
It can be configured either directly via the config.txt located in the localAppData folder or with the config app provided with this package.
The scripts do need certain libraries to work along with python (3.13). 
If you have any issues, feel free to send me your log files located in the localAppData folder for my program and how to replicate it.
If you are having issues closing any of the scripts or the config app, let me know and just use task manager to end the task.

Internally the main script works with an event driven system, when you press a button on your controller it records it in an array[] of 1 and 0 and checks the config.txt data to see if we are ready to do a shortcut.
if we are, it will launch the executable with whatever arguments passed to it. The example format for the config.txt is shown below

	("right, x, y") "C:\Program Files\Controller Shortcuter\Scripts\Other Scripts\controller_remapper.pyw" "argument"
		^				^								   ^
		|				|								   |
	These are the inputs		This is the command						These are the arguments

There is not set limit for the amount of shortcuts, but the config app might not go that far down.

Included are also some extra scripts:
	controller_remapper.pyw is yet another python script which lets you move the mouse with your controller.
		- Right stick is responsible for scrolling up and down
		- Left stick moves the mouse cursor
		- A is to left click
		- X is to right click
		- B presses the escape key

	close_remapper.pyw can be called to close the controller_remapper.pyw

	emulator.pyw script is used to simulate keyboard actions. When you call it, pass an argument of what to do. Example Arguments:
		- "(windows, g)" - This will simulate you pressing the windows key and g at the same time for ~0.75 seconds. This will open windows game bar
		- "mouse(100:100)" - This will move the mouse to position 100 on x and 100 on y
		- "delay(3)" - This will put a delay of 3 seconds
		- "scrollx(20)" - This will scroll to the right by 20 (units undefined)
		- "scrolly(-100)" - This will scroll down by 100 (units undefined)

Here is the table of what key and button is called
	- Controller - For shortcut-er.pyw
		- A button - "a"
		- B button - "b"
		- X button - "x"
		- Y button - "y"
		- Left Bumper - "leftshoulder"
		- Right Bumper - "rightshoulder"
		- 3 lines button (idk) - "start"
		- 2 intersecting boxes (idk) - "back"
		- Left Stick Press - "leftstick"
		- Right Stick Press - "rightstick"
		- Dpad directions - "up","down","left","right"
	- Keyboard - For emulator.pyw
		- letters are what you think they are - "a", "f", "i" - Not case sensitive - always lowercase
		- space key - "space"
		- control key - "ctrl"
		- escape key - "esc"
		- alt key - "alt"
		- shift key - "shift"
		- right shift key - "rshift"
		- tab key - "tab"
		- CAPS LOCK - "capslock"
		- windows key - "command" or "windows"
		- delete key - "delete"
		- backspace key - "backspace"
		- enter key - "enter"
		- insert key - "insert"
		- home key - "home"
		- end key - "end"
		- page up key - "pageup"
		- page down key - "pagedown"
		- left arrow key - "left"
		- right arrow key - "right"
		- up arrow key - "up"
		- down arrow key - "down"
		- F1 key - "f1"
		- F2 key - "f2"
		- F3 key - "f3"
		- F4 key - "f4"
		- F5 key - "f5"
		- F6 key - "f6"
		- F7 key - "f7"
		- F8 key - "f8"
		- F9 key - "f9"
		- F10 key - "f10"
		- F11 key - "f11"
		- F12 key - "f12"

Config app was written in C# in Windows Forms. Installer was made with Wix.