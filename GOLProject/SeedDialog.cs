using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GOLProject
{
  public class SeedDialog : Form
  {
    private IContainer components;
    private Button buttonOK;
    private Button buttonCancel;
    private NumericUpDown numericUpDownSeed;
    private Label label1;
    private Button button1;

    public SeedDialog()
    {
      this.InitializeComponent();
      this.numericUpDownSeed.Maximum = 2147483647M;
      this.numericUpDownSeed.Minimum = -2147483648M;
    }

    public int Seed
    {
      get => (int) this.numericUpDownSeed.Value;
      set => this.numericUpDownSeed.Value = (Decimal) value;
    }

    private void button1_Click(object sender, EventArgs e) => this.numericUpDownSeed.Value = (Decimal) new Random().Next(int.MinValue, int.MaxValue);

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
      this.numericUpDownSeed = new NumericUpDown();
      this.label1 = new Label();
      this.button1 = new Button();
      this.numericUpDownSeed.BeginInit();
      this.SuspendLayout();
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Location = new Point(81, 72);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new Size(75, 23);
      this.buttonOK.TabIndex = 1;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Location = new Point(163, 72);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(75, 23);
      this.buttonCancel.TabIndex = 2;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.numericUpDownSeed.Location = new Point(77, 19);
      this.numericUpDownSeed.Name = "numericUpDownSeed";
      this.numericUpDownSeed.Size = new Size(120, 20);
      this.numericUpDownSeed.TabIndex = 3;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(40, 23);
      this.label1.Name = "label1";
      this.label1.Size = new Size(32, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Seed";
      this.button1.Location = new Point(203, 18);
      this.button1.Name = "button1";
      this.button1.Size = new Size(75, 23);
      this.button1.TabIndex = 5;
      this.button1.Text = "Randomize";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.AcceptButton = (IButtonControl) this.buttonOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.ClientSize = new Size(318, 107);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.numericUpDownSeed);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (SeedDialog);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Seed Dialog";
      this.numericUpDownSeed.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
