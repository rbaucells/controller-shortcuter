using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace config_app
{
    public partial class Main_Form : Form
    {
        // this is where all the things are
        readonly string localAppDataDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Controller Shortcuter");

        readonly string scriptConfigDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Controller Shortcuter", "config.txt");

        readonly string configAppLogDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Controller Shortcuter", "configapplog.txt");

        readonly string scriptsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Controller Shortcuter", "Scripts");
        readonly string shortcuterScriptDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Controller Shortcuter", "Scripts", "shortcut-er.pyw");
        readonly string closeShortcuterScriptDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Controller Shortcuter", "Scripts", "close_shortcuter.pyw");
        // all the lineInfos that were read from the file
        IList<LineInfo> lineInfos = new List<LineInfo>();
        // all the lineControls currently on the form
        IList<LineControl> lineControls = new List<LineControl>();
        public Main_Form()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            this.MaximumSize = new Size(1310, Screen.PrimaryScreen.Bounds.Height);

            if (!Path.Exists(localAppDataDir))
            {
                Directory.CreateDirectory(localAppDataDir);
            }

            if (!Path.Exists(configAppLogDir))
            {
                StreamWriter streamWriter = File.CreateText(configAppLogDir);
                streamWriter.Close();
            }

            WriteToLog("");
            WriteToLog("Hello World");
            // if the curWorkingDir doesn't exist, make it
            if (!Path.Exists(localAppDataDir))
            {
                WriteToLog("Creating Local Appdata directory at: " + localAppDataDir);
                Directory.CreateDirectory(localAppDataDir);
            }
            // read the file and save it into lineInfos
            ParseFileForInfo();

            // make the LineControls with the info in its corresponding lineInfo
            foreach (LineInfo lineInfo in lineInfos)
            {
                NewLineControl(lineInfo);
            }

            // if when we read the file there were no lineInfos, make an empty LineControl
            if (!lineInfos.Any())
            {
                NewEmptyLineControl();
            }
        }

        void NewLineControl(LineInfo lineInfo)
        {
            LineControl lineControl = new(lineInfo.inputs, lineInfo.command.Replace("\"", ""), lineControls.Count + 1, lineInfo.argument);
            ScrollControl.Controls.Add(lineControl);
            lineControls.Add(lineControl);
            lineControl.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            WriteToLog("Created new LineControl with inputs: " + lineControl.GetInputs() + "and command: " + lineControl.GetCommand() + "and argument: " + lineControl.GetArgument());
        }

        public void NewEmptyLineControl()
        {
            AllLineControlsStopRecording();

            LineControl lineControl = new(new List<string>(), "", lineControls.Count + 1, "");
            ScrollControl.Controls.Add(lineControl);
            lineControls.Add(lineControl);
            lineControl.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            WriteToLog("Created new empty LineControl");
        }

        public void NewEmptyLineControl(object sender, EventArgs e)
        {
            AllLineControlsStopRecording();

            LineControl lineControl = new(new List<string>(), "", lineControls.Count + 1, "");
            ScrollControl.Controls.Add(lineControl);
            lineControls.Add(lineControl);
            lineControl.Anchor = AnchorStyles.Left | AnchorStyles.Right;

            WriteToLog("Created new empty LineControl");
        }

        void ParseFileForInfo()
        {;
            WriteToLog("Parsing " + scriptConfigDir + " for info");
            // if the config file doesn't exist, make it
            if (!Path.Exists(scriptConfigDir))
            {
                WriteToLog("Config file doesn't exist, creating it");
                File.CreateText(scriptConfigDir).Close();
            }

            // read the file
            string[] lines = File.ReadAllLines(scriptConfigDir); // every line in the file

            // save the lineInfos based on what the file says
            foreach (string line in lines)
            {
                int startInputs = line.IndexOf("(\"") + 2;
                int endInputs = line.IndexOf("\")");

                int startCommand = line.IndexOf("{\"") + 2;
                int endCommand = line.IndexOf("\"}");

                int startArgument = line.IndexOf("[\"") + 2;
                int endArgument = line.IndexOf("\"]");

                if (endInputs > startInputs && startInputs != -1 && endInputs != -1 && endCommand > startCommand && startCommand != -1 && endCommand != -1 && endArgument > startArgument - 2 && startArgument != -1 && endArgument != -1)
                {
                    string[] inputs = line.Substring(startInputs, endInputs - startInputs).Split(",");

                    for (int i = 0; i < inputs.Length; i++)
                    {
                        inputs[i] = inputs[i].Trim();
                    }

                    string command = line.Substring(startCommand, endCommand - startCommand).Trim();

                    string argument = line.Substring(startArgument, endArgument - startArgument).Trim();

                    string lineWithout1 = line.Substring(endArgument + 2);

                    int startCommand2 = lineWithout1.IndexOf("{\"") + 2;
                    int endCommand2 = lineWithout1.IndexOf("\"}");

                    int startArgument2 = lineWithout1.IndexOf("[\"") + 2;
                    int endArgument2 = lineWithout1.IndexOf("\"]");

                    if (startArgument2 - 2 < endArgument2 && startCommand2 < endCommand2 && startArgument2 != -1 && endArgument2 != -1 && startCommand2 != -1 && endCommand2 != -1)
                    {
                        string command2 = lineWithout1.Substring(startCommand2, endCommand2 - startCommand2);
                        string argument2 = lineWithout1.Substring(startArgument2, endArgument2 - startArgument2);


                        WriteToLog("Read Line: " + line + " and extracted inputs: " + inputs + " and commands: " + command + " and " + command2 + "and arguments: " + argument + " and " + argument2);

                        lineInfos.Add(new LineInfo(inputs.ToList(), command, argument));
                        lineInfos.Add(new LineInfo(inputs.ToList(), command2, argument2));
                    }
                    else
                    {
                        WriteToLog("Read Line: " + line + " and extracted inputs: " + inputs + " and command: " + command + "and arguments: " + argument);

                        lineInfos.Add(new LineInfo(inputs.ToList(), command, argument));
                    }
                }
            }
        }


        void On_Save_Button(object sender, EventArgs e)
        {
            AllLineControlsStopRecording();

            Dictionary<string, List<LineControl>> groupedLineControls = new Dictionary<string, List<LineControl>>();

            foreach (LineControl lineControl in lineControls)
            {
                string inputs = lineControl.GetInputs();
                if (!groupedLineControls.ContainsKey(inputs))
                {
                    groupedLineControls.Add(inputs, new List<LineControl>());
                }
                groupedLineControls[inputs].Add(lineControl);
            }

            List<string> lines = new List<string>();

            foreach (var entry in groupedLineControls)
            {
                string inputs = entry.Key;
                List<LineControl> controlsWithSameInputs = entry.Value;

                string lineContent = "(\"" + inputs + "\")";

                foreach (LineControl lineControl in controlsWithSameInputs)
                {
                    lineContent += " {\"" + lineControl.GetCommand() + "\"}" + "[\"" + lineControl.GetArgument() + "\"]";
                }
                lines.Add(lineContent);
            }

            WriteToLog("Saving info to " + scriptConfigDir);
            File.WriteAllLines(scriptConfigDir, lines);
        }
        void On_Cancel_Button(object sender, EventArgs e)
        {
            WriteToLog("Cancel button pressed, closing app");
            // close the app
            AllLineControlsStopRecording();
            Application.Exit();
        }

        public void AllLineControlsStopRecording()
        {
            // tell all the LineControls to stop recording
            foreach (LineControl lineControl in lineControls)
            {
                lineControl.StopRecordingInput();
            }
        }

        public void DeleteLine(LineControl lineControl)
        {
            // remove the control from our list
            lineControls.Remove(lineControl);

            // set the remaining lineControls to be in the right shortcut number
            for (int i = 0; i < lineControls.Count; i++)
            {
                LineControl curLineControl = lineControls[i];

                curLineControl.SetNumber(i + 1);
            }

            // remove the control from the form
            ScrollControl.Controls.Remove(lineControl);

            if (!lineControls.Any())
            {
                Double_Click_New.Visible = true;
            }

            WriteToLog("Deleted lineControl with inputs: " + lineControl.GetInputs() + " and command: " + lineControl.GetCommand());
        }

        void StartRestartScript(object sender, EventArgs e)
        {
            KillShortcuter();
            Thread.Sleep(500);
            StartShortcuter();
        }

        void KillShortcuter()
        {
            ProcessStartInfo startInfo = new();
            startInfo.FileName = closeShortcuterScriptDir;
            startInfo.WorkingDirectory = scriptsDirectory;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            WriteToLog("Started: " + closeShortcuterScriptDir + " with working directory: " + scriptsDirectory);
        }
        void StartShortcuter()
        {
            ProcessStartInfo startInfo = new();
            startInfo.FileName = shortcuterScriptDir;
            startInfo.WorkingDirectory = scriptsDirectory;
            startInfo.UseShellExecute = true;
            Process.Start(startInfo);
            WriteToLog("Started: " + shortcuterScriptDir + " with working directory: " + scriptsDirectory);
        }

        public void WriteToLog(string messege)
        {
            List<string> curLines = File.ReadAllLines(configAppLogDir).ToList();

            curLines.Add(messege);

            File.WriteAllLines(configAppLogDir, curLines.ToArray());
        }

        public class LineInfo
        {
            public List<string> inputs = new List<string>();
            public string command = "";
            public string argument = "";
            public LineInfo(List<String> inputs, string command, string argument)
            {
                this.inputs = inputs;
                this.command = command;
                this.argument = argument;
            }
        }
    }
}


