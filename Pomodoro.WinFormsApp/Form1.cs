using System.ComponentModel;
using System.Windows.Forms;

namespace Pomodoro.WinFormsApp
{
    public partial class Form1 : Form
    {
        private readonly PomodoroApp pomodoro;

        public Form1()
        {
            InitializeComponent();
            this.pomodoro = new PomodoroApp();
        }

        protected override void OnLoad(EventArgs e)
        {
            pomodoro.OnMinuteUpdated += UpdateTrayIcon;
        }

        void UpdateTrayIcon(int minutes)
        {
            Bitmap bitmap = new Bitmap(32, 32);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.Transparent);

                using Brush circleBrush = new SolidBrush(Color.Black);
                g.FillEllipse(circleBrush, 0, 0, 32, 32);

                using Font font = new Font("Arial", 21, FontStyle.Bold, GraphicsUnit.Pixel);
                SizeF textSize = g.MeasureString(minutes.ToString(), font);
                float textX = (bitmap.Width - textSize.Width) / 2 + (minutes < 10 ? 1 : 0);
                float textY = ((bitmap.Height - textSize.Height) / 2) + 2;

                using Brush textBrush = new SolidBrush(Color.White);
                g.DrawString(minutes.ToString(), font, textBrush, textX, textY);
            }

            Icon icon2 = Icon.FromHandle(bitmap.GetHicon());

            this.Invoke(() =>
            {
                this.TimeLabel.Text = $"{pomodoro.currentMinute:00}:{pomodoro.currentSecond:00}";

                this.Icon = icon2;

                if (pomodoro.Mode == ClockMode.Break)
                {
                    Pomodorobutton.ChangeColorToDefault();
                    ShortBreakButton.ChangeColorToActive();
                    LongBreakButton.ChangeColorToDefault();
                    ShortBreakButton.Select();

                }
                else if (pomodoro.Mode == ClockMode.LongBreak)
                {
                    Pomodorobutton.ChangeColorToDefault();
                    ShortBreakButton.ChangeColorToDefault();
                    LongBreakButton.ChangeColorToActive();
                    LongBreakButton.Select();
                }
                else
                {
                    Pomodorobutton.ChangeColorToActive();
                    ShortBreakButton.ChangeColorToDefault();
                    LongBreakButton.ChangeColorToDefault();
                    Pomodorobutton.Select();
                }
            });
        }

        private void Pomodorobutton_Click(object sender, EventArgs e)
        {
            pomodoro.StartWork();
        }

        private void ShortBreakButton_Click(object sender, EventArgs e)
        {
            pomodoro.StartBreak(true);
        }

        private void LongBreakButton_Click(object sender, EventArgs e)
        {
            pomodoro.StartLongBreak();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            this.pomodoro.Dispose();
        }
    }
}
