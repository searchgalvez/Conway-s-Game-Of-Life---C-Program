using System;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace GOLProject
{
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
  public class NumericUpDownToolStripItem : ToolStripControlHost
  {
    public event EventHandler ValueChanged;

    public NumericUpDownToolStripItem()
      : base((Control) new System.Windows.Forms.NumericUpDown())
    {
      ((System.Windows.Forms.NumericUpDown) this.Control).Maximum = Decimal.MaxValue;
      ((System.Windows.Forms.NumericUpDown) this.Control).Minimum = Decimal.MinValue;
    }

    public Control NumericUpDown => this.Control;

    public Decimal Value
    {
      get => ((System.Windows.Forms.NumericUpDown) this.Control).Value;
      set => ((System.Windows.Forms.NumericUpDown) this.Control).Value = value;
    }

    public void OnValueChanged(object sender, EventArgs e)
    {
      if (this.ValueChanged == null)
        return;
      this.ValueChanged((object) this, EventArgs.Empty);
    }

    protected override void OnSubscribeControlEvents(Control control)
    {
      base.OnSubscribeControlEvents(control);
      ((System.Windows.Forms.NumericUpDown) control).ValueChanged += new EventHandler(this.OnValueChanged);
    }

    protected override void OnUnsubscribeControlEvents(Control control)
    {
      base.OnUnsubscribeControlEvents(control);
      ((System.Windows.Forms.NumericUpDown) control).ValueChanged -= new EventHandler(this.OnValueChanged);
    }
  }
}
