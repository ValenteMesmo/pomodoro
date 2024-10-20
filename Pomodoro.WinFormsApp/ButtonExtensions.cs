namespace Pomodoro.WinFormsApp;

public static class ButtonExtensions
{
    public static void ChangeColorToActive(this Button button)
    {
        button.BackColor = SystemColors.Highlight;
        button.ForeColor = SystemColors.HighlightText;
    }

    public static void ChangeColorToDefault(this Button button)
    {
        button.BackColor = SystemColors.Control;
        button.ForeColor = SystemColors.ControlText;
    }
}
