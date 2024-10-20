namespace Pomodoro;

public class PomodoroApp : IDisposable
{
    private Task loopTask;
    private const int WORK_DURATION = 25 * 60;
    private const int SHORT_BREAK_DURATION = 5 * 60;
    private const int LONG_BREAK_DURATION = 15 * 60;
    private int totalDurationInSeconds = 0;
    public int currentMinute { get; private set; }
    public int currentSecond { get; private set; }
    public ClockMode Mode { get; private set; } = ClockMode.Pomodoro;

    public Action<int> OnMinuteUpdated = _ => { };
    public const int BREAKS_UNTIL_LONGBREAK = 4;
    public int breaksUntilLongBreak = BREAKS_UNTIL_LONGBREAK;

    public PomodoroApp()
    {
        StartWork();
        loopTask = Task.Run(Loop);
    }

    int previousMinute = 0;
    private async Task Loop()
    {
        while (true)
        {
            await Task.Delay(1000);

            currentMinute = totalDurationInSeconds / 60;
            currentSecond = totalDurationInSeconds % 60;

            if (currentMinute == 0)
                OnMinuteUpdated(currentSecond);
            else
                OnMinuteUpdated(currentMinute);

            previousMinute = currentMinute;

            if (Mode == ClockMode.Pomodoro)
            {
                totalDurationInSeconds--;

                if (totalDurationInSeconds <= 0)
                    StartBreak();
            }
            else
            {
                totalDurationInSeconds--;

                if (totalDurationInSeconds <= 0)
                    StartWork();
            }
        }
    }

    public void StartWork()
    {
        Mode = ClockMode.Pomodoro;
        totalDurationInSeconds = WORK_DURATION;
        previousMinute = totalDurationInSeconds / 60;
        OnMinuteUpdated(previousMinute);
        Noise.Stop();
        GrayScaleMode.Off();
    }

    public void StartLongBreak()
    {
        breaksUntilLongBreak = BREAKS_UNTIL_LONGBREAK;

        Mode = ClockMode.LongBreak;
        totalDurationInSeconds = LONG_BREAK_DURATION;

        previousMinute = totalDurationInSeconds / 60;
        OnMinuteUpdated(previousMinute);
        GrayScaleMode.On();
        Noise.Play();
    }

    public void StartBreak(bool uiTriggered = false)
    {
        if (!uiTriggered)
            breaksUntilLongBreak--;

        if (breaksUntilLongBreak == 0 && !uiTriggered)
        {
            StartLongBreak();
            return;
        }

        Mode = ClockMode.Break;
        totalDurationInSeconds = SHORT_BREAK_DURATION;

        previousMinute = totalDurationInSeconds / 60;
        OnMinuteUpdated(previousMinute);
        GrayScaleMode.On();
        Noise.Play();
    }

    public void Dispose()
    {
        OnMinuteUpdated = _ => { };
    }
}

public enum ClockMode
{
    Pomodoro,
    Break,
    LongBreak
}