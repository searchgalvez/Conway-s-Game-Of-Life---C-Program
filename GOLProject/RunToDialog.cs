// Decompiled with JetBrains decompiler
// Type: GOLNET001.RunToDialog
// Assembly: GOLNET001, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: E76B15F6-1E09-484F-8596-AD5A8957CA7D
// Assembly location: C:\Users\Sergio\Desktop\GOLDEMO003\GOLDEMO003.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GOLProject
{
  public class RunToDialog : Form
  {
    private IContainer components;
    private Button buttonOK;
    private Button buttonCancel;
    private NumericUpDown numericUpDownRunToGeneration;
    private Label label1;

    public RunToDialog()
    {
      this.InitializeComponent();
      this.numericUpDownRunToGeneration.Maximum = 2147483647M;
    }

    public int RunToGeneration
    {
      get => (int) this.numericUpDownRunToGeneration.Value;
      set => this.numericUpDownRunToGeneration.Value = (Decimal) value;
    }

    public int CurrentGeneration
    {
      set => this.numericUpDownRunToGeneration.Minimum = (Decimal) value;
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
      this.numericUpDownRunToGeneration = new NumericUpDown();
      this.label1 = new Label();
      this.numericUpDownRunToGeneration.BeginInit();
      this.SuspendLayout();
      this.buttonOK.DialogResult = DialogResult.OK;
      this.buttonOK.Location = new Point(47, 56);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new Size(75, 23);
      this.buttonOK.TabIndex = 1;
      this.buttonOK.Text = "OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Location = new Point(129, 56);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(75, 23);
      this.buttonCancel.TabIndex = 2;
      this.buttonCancel.Text = "Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.numericUpDownRunToGeneration.Location = new Point(114, 14);
      this.numericUpDownRunToGeneration.Name = "numericUpDownRunToGeneration";
      this.numericUpDownRunToGeneration.Size = new Size(120, 20);
      this.numericUpDownRunToGeneration.TabIndex = 3;
      this.label1.AutoSize = true;
      this.label1.Location = new Point(16, 16);
      this.label1.Name = "label1";
      this.label1.Size = new Size(92, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Run to generation";
      this.AcceptButton = (IButtonControl) this.buttonOK;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.ClientSize = new Size(250, 93);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.numericUpDownRunToGeneration);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (RunToDialog);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Run To Dialog";
      this.numericUpDownRunToGeneration.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
