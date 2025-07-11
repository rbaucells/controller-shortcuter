namespace config_app
{
    partial class Main_Form
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Form));
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            Save_Button = new Button();
            Cancel_Button = new Button();
            Double_Click_New = new Label();
            button3 = new Button();
            ScrollControl = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            // 
            // button2
            // 
            button2.Location = new Point(0, 0);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 1;
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 0;
            // 
            // Save_Button
            // 
            Save_Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Save_Button.Location = new Point(1126, 455);
            Save_Button.Name = "Save_Button";
            Save_Button.Size = new Size(75, 23);
            Save_Button.TabIndex = 3;
            Save_Button.Text = "Save";
            Save_Button.UseVisualStyleBackColor = true;
            Save_Button.Click += On_Save_Button;
            // 
            // Cancel_Button
            // 
            Cancel_Button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Cancel_Button.Location = new Point(1207, 455);
            Cancel_Button.Name = "Cancel_Button";
            Cancel_Button.Size = new Size(75, 23);
            Cancel_Button.TabIndex = 4;
            Cancel_Button.Text = "Cancel";
            Cancel_Button.UseVisualStyleBackColor = true;
            Cancel_Button.Click += On_Cancel_Button;
            // 
            // Double_Click_New
            // 
            Double_Click_New.Anchor = AnchorStyles.Bottom;
            Double_Click_New.AutoSize = true;
            Double_Click_New.Font = new Font("Segoe UI", 20F);
            Double_Click_New.Location = new Point(379, 452);
            Double_Click_New.Name = "Double_Click_New";
            Double_Click_New.Size = new Size(557, 37);
            Double_Click_New.TabIndex = 5;
            Double_Click_New.Text = "Double-Click to Create a New Empty Shortcut";
            Double_Click_New.DoubleClick += NewEmptyLineControl;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button3.Location = new Point(12, 455);
            button3.Name = "button3";
            button3.Size = new Size(118, 23);
            button3.TabIndex = 6;
            button3.Text = "Start/Restart Script";
            button3.UseVisualStyleBackColor = true;
            button3.Click += StartRestartScript;
            // 
            // ScrollControl
            // 
            ScrollControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ScrollControl.AutoScroll = true;
            ScrollControl.Location = new Point(12, 12);
            ScrollControl.Name = "ScrollControl";
            ScrollControl.Size = new Size(1270, 437);
            ScrollControl.TabIndex = 7;
            ScrollControl.DoubleClick += NewEmptyLineControl;
            // 
            // Main_Form
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CausesValidation = false;
            ClientSize = new Size(1294, 490);
            Controls.Add(ScrollControl);
            Controls.Add(button3);
            Controls.Add(Double_Click_New);
            Controls.Add(Cancel_Button);
            Controls.Add(Save_Button);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(1310, 529);
            MinimumSize = new Size(1310, 150);
            Name = "Main_Form";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Main_Form";
            Load += Main_Form_Load;
            DoubleClick += NewEmptyLineControl;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Button Save_Button;
        private Button Cancel_Button;
        private Label Double_Click_New;
        private Button button3;
        private FlowLayoutPanel ScrollControl;
    }
}