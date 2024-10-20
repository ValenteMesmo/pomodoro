using NAudio.Wave;

namespace Pomodoro;

public static class Noise
{
    static WaveOutEvent waveOut;

    static Noise()
    {
        AudioFileReader audioFile = new AudioFileReader("binaural-brown-noise-40Hz.mp3");
        waveOut = new WaveOutEvent();
        waveOut.Init(audioFile);
    }

    public static void Play()
    {
        waveOut.Play();
    }

    public static void Stop()
    {
        waveOut.Stop();
    }
}