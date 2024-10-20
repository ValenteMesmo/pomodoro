namespace Pomodoro.WinFormsApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Pomodorobutton = new Button();
            ShortBreakButton = new Button();
            LongBreakButton = new Button();
            TimeLabel = new Label();
            SuspendLayout();
            // 
            // Pomodorobutton
            // 
            Pomodorobutton.Location = new Point(8, 9);
            Pomodorobutton.Name = "Pomodorobutton";
            Pomodorobutton.Size = new Size(196, 80);
            Pomodorobutton.TabIndex = 0;
            Pomodorobutton.Text = "Pomodoro";
            Pomodorobutton.UseVisualStyleBackColor = true;
            Pomodorobutton.Click += Pomodorobutton_Click;
            // 
            // ShortBreakButton
            // 
            ShortBreakButton.Location = new Point(210, 9);
            ShortBreakButton.Name = "ShortBreakButton";
            ShortBreakButton.Size = new Size(196, 80);
            ShortBreakButton.TabIndex = 0;
            ShortBreakButton.Text = "Short Break";
            ShortBreakButton.UseVisualStyleBackColor = true;
            ShortBreakButton.Click += ShortBreakButton_Click;
            // 
            // LongBreakButton
            // 
            LongBreakButton.Location = new Point(412, 9);
            LongBreakButton.Name = "LongBreakButton";
            LongBreakButton.Size = new Size(196, 80);
            LongBreakButton.TabIndex = 0;
            LongBreakButton.Text = "Long Break";
            LongBreakButton.UseVisualStyleBackColor = true;
            LongBreakButton.Click += LongBreakButton_Click;
            // 
            // TimeLabel
            // 
            TimeLabel.AutoSize = true;
            TimeLabel.Font = new Font("Segoe UI", 72F);
            TimeLabel.Location = new Point(142, 92);
            TimeLabel.Name = "TimeLabel";
            TimeLabel.Size = new Size(353, 159);
            TimeLabel.TabIndex = 1;
            TimeLabel.Text = "00:00";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 252);
            Controls.Add(TimeLabel);
            Controls.Add(LongBreakButton);
            Controls.Add(ShortBreakButton);
            Controls.Add(Pomodorobutton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Pomodorobutton;
        private Button ShortBreakButton;
        private Button LongBreakButton;
        private Label TimeLabel;
    }
}
