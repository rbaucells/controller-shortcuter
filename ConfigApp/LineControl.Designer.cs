namespace config_app
{
    partial class LineControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Label label3;
            Label label2;
            Label Shortcut_Text;
            Label Argument_Label;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineControl));
            Find_Button = new Button();
            Record_Button = new Button();
            Command_Text_Box = new RichTextBox();
            Inputs_Text_Box = new RichTextBox();
            Clear_Inputs = new Button();
            Clear_Command = new Button();
            button1 = new Button();
            Stop_Button = new Button();
            button2 = new Button();
            Arguments_Text_Box = new RichTextBox();
            button3 = new Button();
            button4 = new Button();
            label3 = new Label();
            label2 = new Label();
            Shortcut_Text = new Label();
            Argument_Label = new Label();
            SuspendLayout();
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(460, 41);
            label3.Name = "label3";
            label3.Size = new Size(105, 27);
            label3.TabIndex = 9;
            label3.Text = "Action";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(138, 45);
            label2.Name = "label2";
            label2.Size = new Size(105, 23);
            label2.TabIndex = 8;
            label2.Text = "Inputs";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Shortcut_Text
            // 
            Shortcut_Text.Font = new Font("Segoe UI", 15F);
            Shortcut_Text.Location = new Point(3, 7);
            Shortcut_Text.Name = "Shortcut_Text";
            Shortcut_Text.Size = new Size(129, 33);
            Shortcut_Text.TabIndex = 5;
            Shortcut_Text.Text = "Shortcut #";
            Shortcut_Text.TextAlign = ContentAlignment.MiddleCenter;
            Shortcut_Text.DoubleClick += NewLine;
            // 
            // Argument_Label
            // 
            Argument_Label.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Argument_Label.Font = new Font("Segoe UI", 14F);
            Argument_Label.Location = new Point(906, 40);
            Argument_Label.Name = "Argument_Label";
            Argument_Label.Size = new Size(105, 27);
            Argument_Label.TabIndex = 19;
            Argument_Label.Text = "Argument";
            Argument_Label.TextAlign = ContentAlignment.MiddleCenter;
            Argument_Label.Click += Argument_Label_Click;
            // 
            // Find_Button
            // 
            Find_Button.Anchor = AnchorStyles.Bottom;
            Find_Button.Location = new Point(557, 46);
            Find_Button.Name = "Find_Button";
            Find_Button.Size = new Size(75, 23);
            Find_Button.TabIndex = 11;
            Find_Button.Text = "Find";
            Find_Button.UseVisualStyleBackColor = true;
            Find_Button.Click += OpenCommandFile;
            // 
            // Record_Button
            // 
            Record_Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Record_Button.Location = new Point(221, 46);
            Record_Button.Name = "Record_Button";
            Record_Button.Size = new Size(75, 23);
            Record_Button.TabIndex = 10;
            Record_Button.Text = "Record";
            Record_Button.UseVisualStyleBackColor = true;
            Record_Button.Click += StartRecordingInput;
            // 
            // Command_Text_Box
            // 
            Command_Text_Box.Anchor = AnchorStyles.Top;
            Command_Text_Box.Location = new Point(400, 9);
            Command_Text_Box.Name = "Command_Text_Box";
            Command_Text_Box.Size = new Size(430, 33);
            Command_Text_Box.TabIndex = 7;
            Command_Text_Box.Text = "";
            // 
            // Inputs_Text_Box
            // 
            Inputs_Text_Box.Location = new Point(138, 9);
            Inputs_Text_Box.Name = "Inputs_Text_Box";
            Inputs_Text_Box.ReadOnly = true;
            Inputs_Text_Box.Size = new Size(256, 33);
            Inputs_Text_Box.TabIndex = 6;
            Inputs_Text_Box.Text = "";
            // 
            // Clear_Inputs
            // 
            Clear_Inputs.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Clear_Inputs.Location = new Point(302, 46);
            Clear_Inputs.Name = "Clear_Inputs";
            Clear_Inputs.Size = new Size(75, 23);
            Clear_Inputs.TabIndex = 12;
            Clear_Inputs.Text = "Clear";
            Clear_Inputs.UseVisualStyleBackColor = true;
            Clear_Inputs.Click += Clear_Inputs_Click;
            // 
            // Clear_Command
            // 
            Clear_Command.Anchor = AnchorStyles.Bottom;
            Clear_Command.Location = new Point(638, 46);
            Clear_Command.Name = "Clear_Command";
            Clear_Command.Size = new Size(75, 23);
            Clear_Command.TabIndex = 13;
            Clear_Command.Text = "Clear";
            Clear_Command.UseVisualStyleBackColor = true;
            Clear_Command.Click += Clear_Command_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(34, 46);
            button1.Name = "button1";
            button1.Size = new Size(24, 24);
            button1.TabIndex = 14;
            button1.UseVisualStyleBackColor = true;
            button1.Click += NewLine;
            // 
            // Stop_Button
            // 
            Stop_Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Stop_Button.Location = new Point(221, 46);
            Stop_Button.Name = "Stop_Button";
            Stop_Button.Size = new Size(75, 23);
            Stop_Button.TabIndex = 15;
            Stop_Button.Text = "Stop";
            Stop_Button.UseVisualStyleBackColor = true;
            Stop_Button.Visible = false;
            Stop_Button.Click += StopRecordingInput;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(64, 44);
            button2.Name = "button2";
            button2.Size = new Size(24, 24);
            button2.TabIndex = 16;
            button2.UseVisualStyleBackColor = true;
            button2.Click += DeleteLine;
            // 
            // Arguments_Text_Box
            // 
            Arguments_Text_Box.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Arguments_Text_Box.Location = new Point(836, 9);
            Arguments_Text_Box.Name = "Arguments_Text_Box";
            Arguments_Text_Box.Size = new Size(388, 33);
            Arguments_Text_Box.TabIndex = 17;
            Arguments_Text_Box.Text = "";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button3.Location = new Point(1098, 45);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 18;
            button3.Text = "Clear";
            button3.UseVisualStyleBackColor = true;
            button3.Click += Clear_Argument_Click;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button4.Location = new Point(1017, 45);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 20;
            button4.Text = "Find";
            button4.UseVisualStyleBackColor = true;
            button4.Click += OpenArgumentFile;
            // 
            // LineControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CausesValidation = false;
            Controls.Add(button4);
            Controls.Add(Argument_Label);
            Controls.Add(button3);
            Controls.Add(Arguments_Text_Box);
            Controls.Add(button2);
            Controls.Add(Stop_Button);
            Controls.Add(button1);
            Controls.Add(Clear_Command);
            Controls.Add(Clear_Inputs);
            Controls.Add(Find_Button);
            Controls.Add(label3);
            Controls.Add(Record_Button);
            Controls.Add(Shortcut_Text);
            Controls.Add(Inputs_Text_Box);
            Controls.Add(label2);
            Controls.Add(Command_Text_Box);
            Name = "LineControl";
            Size = new Size(1250, 80);
            Load += LineControl_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button Find_Button;
        private Button Record_Button;
        private RichTextBox Command_Text_Box;
        private RichTextBox Inputs_Text_Box;
        private Button Clear_Inputs;
        private Button Clear_Command;
        private Button button1;
        private Button Stop_Button;
        private Button button2;
        private RichTextBox Arguments_Text_Box;
        private Button button3;
        private Button button4;
    }
}
