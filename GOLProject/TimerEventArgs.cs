using System;

namespace GOLProject
{
  public class TimerEventArgs : EventArgs
  {
    private bool enabled;
    private int interval;

    public bool Enabled
    {
      get => this.enabled;
      set => this.enabled = value;
    }

    public int Interval
    {
      get => this.interval;
      set => this.interval = value;
    }

    public TimerEventArgs(bool enabled, int interval)
    {
      this.enabled = enabled;
      this.interval = interval;
    }
  }
}
