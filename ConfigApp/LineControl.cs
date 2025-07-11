using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XInput.Wrapper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static XInput.Wrapper.X;
using Point = System.Drawing.Point;

namespace config_app
{
    public partial class LineControl : UserControl
    {
        // names for getting a reference
        const string shortcutTextBoxName = "Shortcut_Text";
        const string inputsTextBoxName = "Inputs_Text_Box";
        // list of inputs pressed
        IList<string> controllerInputsList = new List<string>();
        // xbox controller
        X.Gamepad gamepad = null;
        // are we curently recording xbox input
        bool recordingInput;
        // reference to mainForm this control is on
        Main_Form mainForm;

        public LineControl(List<string> inputs, string command, int shortcutNumber, string argument)
        {
            InitializeComponent();
            SetInputs(inputs);
            SetCommand(command);
            SetNumber(shortcutNumber);
            SetArgument(argument);
        }

        public void SetNumber(int shortcutNumber)
        {
            // get the shortcutTextBox and set the number and the location to what its supposed to be
            foreach (Control control in this.Controls)
            {
                if (control.Name == shortcutTextBoxName)
                {
                    control.Text = "Shortcut " + shortcutNumber.ToString();

                    //this.Location = new Point(0, (shortcutNumber - 1) * 80 + 10);
                }
            }
        }

        public void SetInputs(List<string> inputs)
        {
            // adds to the InputsTextBox, if its empty, don't put a comma before the input word
            foreach (string input in inputs)
            {
                if (Inputs_Text_Box.Text.Length <= 0)
                    Inputs_Text_Box.Text = input;
                else
                    Inputs_Text_Box.Text = Inputs_Text_Box.Text + ", " + input;
            }
        }

        public void SetCommand(string command)
        {
            // sets the command
            Command_Text_Box.Text = command;
        }

        public void SetArgument(string argument)
        {
            Arguments_Text_Box.Text = argument;
        }

        private void LineControl_Load(object sender, EventArgs e)
        {
            // if theres a xbox controller connected, add a listener
            if (X.IsAvailable)
            {
                gamepad = X.Gamepad_1;

                gamepad.StateChanged += Gamepad_StateChanged;
            }

            // get a reference to the parentForm
            Form parentForm = this.FindForm();
            // make sure the parent form is of type Main_Form
            if (parentForm is Main_Form main_Form)
            {
                this.mainForm = main_Form;
            }
        }

        void OpenCommandFile(object sender, EventArgs e)
        {
            // makes a pop up to select a file
            mainForm.AllLineControlsStopRecording();

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Program Files (*.bat; *.exe; *.py; *.pyw; *.cmd; *.jar)|*.bat; *.exe; *.py; *.pyw; *.cmd; *.jar|All files (*.*)|*.*";
                fileDialog.Title = "Select a file to run";

                DialogResult result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Command_Text_Box.Text = fileDialog.FileName;
                }
            }
        }

        void OpenArgumentFile(object sender, EventArgs e)
        {
            // makes a pop up to select a file
            mainForm.AllLineControlsStopRecording();

            using (OpenFileDialog fileDialog = new OpenFileDialog())
            {
                fileDialog.Filter = "Program Files (*.bat; *.exe; *.py; *.pyw; *.cmd; *.jar; *.txt; *.ini *.xex; *.json)|*.bat; *.exe; *.py; *.pyw; *.cmd; *.jar; *.txt; *.ini *.xex; *.json|All files (*.*)|*.*";
                fileDialog.Title = "Select a file to pass as an argument";

                DialogResult result = fileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Arguments_Text_Box.Text = fileDialog.FileName;
                }
            }
        }

        private void Clear_Inputs_Click(object sender, EventArgs e)
        {
            // removes all the inputs from the text box
            mainForm.AllLineControlsStopRecording();
            Inputs_Text_Box.Text = "";
        }
        private void Clear_Command_Click(object sender, EventArgs e)
        {
            // removes the command from the text box
            mainForm.AllLineControlsStopRecording();
            Command_Text_Box.Text = "";
        }

        private void Clear_Argument_Click(object sender, EventArgs e)
        {
            // removes the argument from the text box
            mainForm.AllLineControlsStopRecording();
            Arguments_Text_Box.Text = "";
        }

        void NewLine(object sender, EventArgs e)
        {
            mainForm.NewEmptyLineControl();
        }
        void DeleteLine(object sender, EventArgs e)
        {
            mainForm.DeleteLine(this);
        }
        void StartRecordingInput(object sender, EventArgs e)
        {
            mainForm.WriteToLog("Started collecting Input");
            // stops all other lineControls from recording
            mainForm.AllLineControlsStopRecording();
            // reset the controllerInputsList
            controllerInputsList = new List<string>();
            // start listening for events
            X.StartPolling(gamepad);

            recordingInput = true;
            // hides the record button, shows the stop button
            Record_Button.Visible = false;
            Stop_Button.Visible = true;
        }

        public void StopRecordingInput(object sender, EventArgs e)
        {
            // might get called even if not recording (ex.mainForm.AllLineControlsStopRecording();)
            if (!recordingInput)
                return;
            // stop receiving input
            X.StopPolling();
            // put the newest text up
            UpdateControllerText();

            recordingInput = false;
            // hide the stop button, show the record button again
            Record_Button.Visible = true;
            Stop_Button.Visible = false;

            mainForm.WriteToLog("Stopped collecting input, got inputs: " + controllerInputsList);
        }

        public void StopRecordingInput()
        {
            // might get called even if not recording (ex.mainForm.AllLineControlsStopRecording();)
            if (!recordingInput)
                return;
            // stop receiving input
            X.StopPolling();
            // put the newest text up
            UpdateControllerText();

            recordingInput = false;
            // hide the stop button, show the record button again
            Record_Button.Visible = true;
            Stop_Button.Visible = false;

            mainForm.WriteToLog("Stopped collecting input, got inputs: " + controllerInputsList);
        }
        void Gamepad_StateChanged(object sender, EventArgs e)
        {
            // dont do it if we arent recording
            if (!recordingInput)
                return;
            // check what got pressed
            if (gamepad.A_down && !controllerInputsList.Contains("a"))
            {
                controllerInputsList.Add("a");
            }
            else if (gamepad.B_down && !controllerInputsList.Contains("b"))
            {
                controllerInputsList.Add("b");
            }
            else if (gamepad.X_down && !controllerInputsList.Contains("x"))
            {
                controllerInputsList.Add("x");
            }
            else if (gamepad.Y_down && !controllerInputsList.Contains("y"))
            {
                controllerInputsList.Add("y");
            }
            else if (gamepad.Start_down && !controllerInputsList.Contains("start"))
            {
                controllerInputsList.Add("start");
            }
            else if (gamepad.Back_down && !controllerInputsList.Contains("back"))
            {
                controllerInputsList.Add("back");
            }
            else if (gamepad.LStick_down && !controllerInputsList.Contains("leftstick"))
            {
                controllerInputsList.Add("leftstick");
            }
            else if (gamepad.RStick_down && !controllerInputsList.Contains("rightstick"))
            {
                controllerInputsList.Add("rightstick");
            }
            else if (gamepad.Dpad_Up_down && !controllerInputsList.Contains("up"))
            {
                controllerInputsList.Add("up");
            }
            else if (gamepad.Dpad_Down_down && !controllerInputsList.Contains("down"))
            {
                controllerInputsList.Add("down");
            }
            else if (gamepad.Dpad_Left_down && !controllerInputsList.Contains("left"))
            {
                controllerInputsList.Add("left");
            }
            else if (gamepad.Dpad_Right_down && !controllerInputsList.Contains("right"))
            {
                controllerInputsList.Add("right");
            }
            else if (gamepad.LBumper_down && !controllerInputsList.Contains("leftshoulder"))
            {
                controllerInputsList.Add("leftshoulder");
            }
            else if (gamepad.RBumper_down && !controllerInputsList.Contains("rightshoulder"))
            {
                controllerInputsList.Add("rightshoulder");
            }

            UpdateControllerText();
        }

        void UpdateControllerText()
        {
            string textBox = "";

            foreach (string input in controllerInputsList)
            {
                if (textBox == "")
                    textBox = input;
                else
                    textBox += ", " + input;
            }

            foreach (Control control in this.Controls)
            {
                if (control.Name == inputsTextBoxName)
                {
                    control.Text = textBox;
                }
            }
        }
        public string GetInputs()
        {
            return Inputs_Text_Box.Text.Trim();
        }

        public string GetCommand()
        {
            return Command_Text_Box.Text;
        }

        public string GetArgument()
        {
            return Arguments_Text_Box.Text;
        }

        private void Argument_Label_Click(object sender, EventArgs e)
        {

        }
    }
}
