using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GOLProject
{
  public class OptionsDialog : Form
  {
    private IContainer components;
    private Button buttonOK;
    private Button buttonCancel;
    private NumericUpDown numericUpDownTimerInterval;
    private Label label1;
    private NumericUpDown numericUpDownUniverseHeight;
    private NumericUpDown numericUpDownUniverseWidth;
    private Label label3;
    private Label label2;

    public OptionsDialog() => this.InitializeComponent();

    public int TimerIntervalMilliseconds
    {
      get => (int) this.numericUpDownTimerInterval.Value;
      set => this.numericUpDownTimerInterval.Value = (Decimal) value;
    }

    public Size UniverseSize
    {
      get => new Size((int) this.numericUpDownUniverseWidth.Value, (int) this.numericUpDownUniverseHeight.Value);
      set
      {
        this.numericUpDownUniverseWidth.Value = (Decimal) value.Width;
        this.numericUpDownUniverseHeight.Value = (Decimal) value.Height;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.buttonOK = new Button();
      this.buttonCancel = new Button();
      this.numericUpDownUniverseHeight = new NumericUpDown();
      this.numericUpDownUniverseWidth = new NumericUpDown();
      this.label3 = new Label();
      this.label2 = new Label();
      this.numericUpDownTimerInterval = new NumericUpDown();
      this.label1 = new Label();
      this.numericUpDownUniverseHeight.BeginInit();
      this.numericUpDownUniverseWidth.BeginInit();
      this.numericUpDownTimerInterval.BeginInit();
      this.SuspendLayout();
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Location = new Point(100, 173);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new Size(75, 23);
      this.buttonOK.TabIndex = 1;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Location = new Point(182, 173);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(75, 23);
      this.buttonCancel.TabIndex = 2;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.numericUpDownUniverseHeight.Location = new Point(220, 88);
      this.numericUpDownUniverseHeight.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDownUniverseHeight.Minimum = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDownUniverseHeight.Name = "numericUpDownUniverseHeight";
      this.numericUpDownUniverseHeight.Size = new Size(66, 20);
      this.numericUpDownUniverseHeight.TabIndex = 4;
      this.numericUpDownUniverseHeight.Value = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDownUniverseWidth.Location = new Point(220, 62);
      this.numericUpDownUniverseWidth.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDownUniverseWidth.Minimum = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.numericUpDownUniverseWidth.Name = "numericUpDownUniverseWidth";
      this.numericUpDownUniverseWidth.Size = new Size(66, 20);
      this.numericUpDownUniverseWidth.TabIndex = 4;
      this.numericUpDownUniverseWidth.Value = new Decimal(new int[4]
      {
        5,
        0,
        0,
        0
      });
      this.label3.AutoSize = true;
      this.label3.Location = new Point(71, 90);
      this.label3.Name = "label3";
      this.label3.Size = new Size(131, 13);
      this.label3.TabIndex = 3;
      this.label3.Text = "Height of Universe in Cells";
      this.label2.AutoSize = true;
      this.label2.Location = new Point(71, 64);
      this.label2.Name = "label2";
      this.label2.Size = new Size(128, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Width of Universe in Cells";
      this.numericUpDownTimerInterval.Location = new Point(220, 35);
      this.numericUpDownTimerInterval.Maximum = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        0
      });
      this.numericUpDownTimerInterval.Minimum = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.numericUpDownTimerInterval.Name = "numericUpDownTimerInterval";
      this.numericUpDownTimerInterval.Size = new Size(66, 20);
      this.numericUpDownTimerInterval.TabIndex = 1;
      this.numericUpDownTimerInterval.Value = new Decimal(new int[4]
      {
        1,
        0,
        0,
        0
      });
      this.label1.AutoSize = true;
      this.label1.Location = new Point(71, 37);
      this.label1.Name = "label1";
      this.label1.Size = new Size(143, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "Timer Interval in MIlliseconds";
      this.AcceptButton = (IButtonControl) this.buttonOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.ClientSize = new Size(356, 208);
      this.Controls.Add((Control) this.numericUpDownUniverseHeight);
      this.Controls.Add((Control) this.numericUpDownUniverseWidth);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.label3);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.label2);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.numericUpDownTimerInterval);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (OptionsDialog);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Options Dialog";
      this.numericUpDownUniverseHeight.EndInit();
      this.numericUpDownUniverseWidth.EndInit();
      this.numericUpDownTimerInterval.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
