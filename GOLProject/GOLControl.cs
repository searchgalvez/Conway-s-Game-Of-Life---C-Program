using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GOLProject
{
  public class GOLControl : Control
  {
    private Universe universe = new Universe();
    private Timer timer = new Timer();
    private int runToGeneration;
    private int headsUpTransparency = 125;
    private Color gridColor;
    private Color gridColorThick;
    private Color livingCellColor;
    private bool neighborCountVisible = true;
    private bool hudVisible = true;
    private bool gridVisible = true;
    private IContainer components;

    public event UniverseEventHandler NewGeneration;

    public GOLControl()
    {
      this.InitializeComponent();
      this.DoubleBuffered = true;
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.timer.Interval = 20;
      this.timer.Enabled = false;
      this.timer.Tick += new EventHandler(this.timer_Tick);
      this.runToGeneration = -1;
    }

    public Universe Universe => this.universe;

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color GridColor
    {
      get => this.gridColor;
      set
      {
        this.gridColor = value;
        this.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color GridColorThick
    {
      get => this.gridColorThick;
      set
      {
        this.gridColorThick = value;
        this.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Color LivingCellColor
    {
      get => this.livingCellColor;
      set
      {
        this.livingCellColor = value;
        this.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool NeighborCountVisible
    {
      get => this.neighborCountVisible;
      set
      {
        this.neighborCountVisible = value;
        this.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool HUDVisible
    {
      get => this.hudVisible;
      set
      {
        this.hudVisible = value;
        this.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool GridVisible
    {
      get => this.gridVisible;
      set
      {
        this.gridVisible = value;
        this.Invalidate();
      }
    }

    public void Clear()
    {
      this.universe.Clear();
      this.Invalidate();
    }

    public int LivingCells => this.universe.LivingCells;

    public event UniverseEventHandler LivingCellsChanged;

    public event UniverseEventHandler Randomized;

    public void Randomize(int seed)
    {
      this.universe.Randomize(seed);
      if (this.Randomized == null)
        return;
      this.Randomized((object) this, new UniverseEventArgs(this.universe));
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      this.universe.NextGeneration();
      this.Refresh();
      if (this.NewGeneration != null)
        this.NewGeneration((object) this, new UniverseEventArgs(this.universe));
      if (this.runToGeneration <= -1 || this.universe.Generation < this.runToGeneration)
        return;
      this.Stop();
    }

    public void Start()
    {
      this.timer.Start();
      if (this.TimerEnabledChanged == null)
        return;
      this.TimerEnabledChanged((object) this, new TimerEventArgs(this.timer.Enabled, this.timer.Interval));
    }

    public void RunTo(int generation)
    {
      if (generation <= this.universe.Generation)
        return;
      this.runToGeneration = generation;
      this.timer.Start();
      if (this.TimerEnabledChanged == null)
        return;
      this.TimerEnabledChanged((object) this, new TimerEventArgs(this.timer.Enabled, this.timer.Interval));
    }

    public void Stop()
    {
      this.runToGeneration = -1;
      this.timer.Stop();
      if (this.TimerEnabledChanged == null)
        return;
      this.TimerEnabledChanged((object) this, new TimerEventArgs(this.timer.Enabled, this.timer.Interval));
    }

    public void Next() => this.timer_Tick((object) this.timer, EventArgs.Empty);

    public event TimerEventHandler TimerEnabledChanged;

    public int TimerInterval
    {
      get => this.timer.Interval;
      set
      {
        this.timer.Interval = value;
        if (this.TimerIntervalChanged == null)
          return;
        this.TimerIntervalChanged((object) this, new TimerEventArgs(this.timer.Enabled, this.timer.Interval));
      }
    }

    public event TimerEventHandler TimerIntervalChanged;

    public Size UniverseSize
    {
      get => this.universe.Size;
      set
      {
        this.universe.Size = value;
        if (this.UniverseSizeChanged == null)
          return;
        this.UniverseSizeChanged((object) this, new UniverseEventArgs(this.universe));
      }
    }

    public event UniverseEventHandler UniverseSizeChanged;

    protected override void OnPaint(PaintEventArgs pe)
    {
      SizeF size = (SizeF) this.universe.Size;
      SizeF sizeF = new SizeF((float) (this.Width - 1) / size.Width, (float) (this.Height - 1) / size.Height);
      PointF empty1 = PointF.Empty;
      PointF empty2 = PointF.Empty;
      RectangleF empty3 = RectangleF.Empty;
      Pen pen1 = new Pen(this.gridColor);
      Pen pen2 = new Pen(this.gridColorThick, 2f);
      Brush brush1 = (Brush) new SolidBrush(this.livingCellColor);
      Font font = new Font("Arial", sizeF.Width / 2.5f);
      StringFormat format1 = new StringFormat();
      format1.Alignment = StringAlignment.Center;
      format1.LineAlignment = StringAlignment.Center;
      for (float x = 0.0f; (double) x < (double) size.Width; ++x)
      {
        for (float y = 0.0f; (double) y < (double) size.Height; ++y)
        {
          int neighborCount = this.universe.GetNeighborCount((int) x, (int) y);
          empty3.X = x * sizeF.Width;
          empty3.Y = y * sizeF.Height;
          empty3.Size = sizeF;
          if (this.universe[(int) x, (int) y].Alive)
          {
            pe.Graphics.FillRectangle(brush1, empty3);
            if (this.NeighborCountVisible)
            {
              switch (neighborCount)
              {
                case 0:
                  continue;
                case 2:
                case 3:
                  pe.Graphics.DrawString(neighborCount.ToString(), font, Brushes.Green, empty3, format1);
                  continue;
                default:
                  pe.Graphics.DrawString(neighborCount.ToString(), font, Brushes.Red, empty3, format1);
                  continue;
              }
            }
          }
          else if (this.NeighborCountVisible)
          {
            switch (neighborCount)
            {
              case 0:
                continue;
              case 3:
                pe.Graphics.DrawString(neighborCount.ToString(), font, Brushes.Green, empty3, format1);
                continue;
              default:
                pe.Graphics.DrawString(neighborCount.ToString(), font, Brushes.Red, empty3, format1);
                continue;
            }
          }
        }
      }
      if (this.gridVisible)
      {
        for (float num = 0.0f; (double) num <= (double) size.Width; ++num)
        {
          empty1.X = num * sizeF.Width;
          empty1.Y = 0.0f;
          empty2.X = num * sizeF.Width;
          empty2.Y = (float) this.Height;
          if ((double) num % 10.0 == 0.0)
            pe.Graphics.DrawLine(pen2, empty1, empty2);
          else
            pe.Graphics.DrawLine(pen1, empty1, empty2);
        }
        for (float num = 0.0f; (double) num <= (double) size.Height; ++num)
        {
          empty1.X = 0.0f;
          empty1.Y = num * sizeF.Height;
          empty2.X = (float) this.Width;
          empty2.Y = num * sizeF.Height;
          if ((double) num % 10.0 == 0.0)
            pe.Graphics.DrawLine(pen2, empty1, empty2);
          else
            pe.Graphics.DrawLine(pen1, empty1, empty2);
        }
      }
      if (this.HUDVisible)
      {
        Brush brush2 = (Brush) new SolidBrush(Color.FromArgb(this.headsUpTransparency, this.ForeColor));
        StringFormat format2 = new StringFormat();
        format2.Alignment = StringAlignment.Near;
        format2.LineAlignment = StringAlignment.Far;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("Generations: {0}", (object) this.universe.Generation);
        stringBuilder.AppendLine();
        stringBuilder.AppendFormat("Cell Count: {0}", (object) this.universe.LivingCells);
        stringBuilder.AppendLine();
        stringBuilder.AppendFormat("Boundary Type: {0}", (object) this.universe.BoundaryType.ToString());
        stringBuilder.AppendLine();
        stringBuilder.AppendFormat("Universe Size: {0}", (object) this.universe.Size);
        stringBuilder.AppendLine();
        pe.Graphics.DrawString(stringBuilder.ToString(), this.Font, brush2, (RectangleF) this.ClientRectangle, format2);
        brush2.Dispose();
      }
      pen1.Dispose();
      pen2.Dispose();
      brush1.Dispose();
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
      if (e.Button != MouseButtons.Left)
        return;
      SizeF size = (SizeF) this.universe.Size;
      SizeF sizeF = new SizeF((float) this.Width / size.Width, (float) this.Height / size.Height);
      int x = (int) ((double) e.X / (double) sizeF.Width);
      int y = (int) ((double) e.Y / (double) sizeF.Height);
      Cell cell = this.universe[x, y];
      this.universe[x, y] = !cell.Alive ? new Cell(true) : new Cell(false);
      this.Invalidate();
      if (this.LivingCellsChanged == null)
        return;
      this.LivingCellsChanged((object) this, new UniverseEventArgs(this.universe));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent() => this.components = (IContainer) new Container();
  }
}
