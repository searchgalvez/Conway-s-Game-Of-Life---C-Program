// Decompiled with JetBrains decompiler
using GOLProject.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace GOLProject
{
  public class Form1 : Form
  {
    private int seed;
    private IContainer components;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem newToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem contentsToolStripMenuItem;
    private ToolStripMenuItem indexToolStripMenuItem;
    private ToolStripMenuItem searchToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStrip toolStrip1;
    private StatusStrip statusStrip1;
    private ToolStripButton newToolStripButton;
    private ToolStripButton openToolStripButton;
    private ToolStripButton saveToolStripButton;
    private ToolStripSeparator toolStripSeparator6;
    private GOLControl golControl1;
    private ToolStripMenuItem universeToolStripMenuItem;
    private ToolStripMenuItem runToolStripMenuItem;
    private ToolStripMenuItem startToolStripMenuItem;
    private ToolStripMenuItem pauseToolStripMenuItem;
    private ToolStripMenuItem nextToolStripMenuItem;
    private ToolStripStatusLabel toolStripStatusLabelGenerations;
    private ToolStripStatusLabel toolStripStatusLabelInterval;
    private ToolStripStatusLabel toolStripStatusLabelAlive;
    private ToolStripMenuItem importToolStripMenuItem;
    private ToolStripStatusLabel toolStripStatusLabelSeed;
    private ToolStripButton startToolStripButton;
    private ToolStripButton pauseToolStripButton;
    private ToolStripButton nextToolStripButton;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripMenuItem toToolStripMenuItem;
    private ToolStripMenuItem optionsToolStripMenuItem1;
    private ToolStripMenuItem colorToolStripMenuItem;
    private ToolStripMenuItem cellColorToolStripMenuItem;
    private ToolStripMenuItem gridColorToolStripMenuItem;
    private ToolStripMenuItem gridX10ColorToolStripMenuItem;
    private ToolStripMenuItem viewToolStripMenuItem;
    private ToolStripMenuItem hUDToolStripMenuItem;
    private ToolStripMenuItem neighborCountToolStripMenuItem;
    private ToolStripMenuItem gridToolStripMenuItem;
    private ContextMenuStrip contextMenuStripGOL;
    private ToolStripMenuItem colorToolStripMenuItem1;
    private ToolStripMenuItem backColorToolStripMenuItem;
    private ToolStripMenuItem cellColorToolStripMenuItem1;
    private ToolStripMenuItem gridColorToolStripMenuItem1;
    private ToolStripMenuItem gridX10ColorToolStripMenuItem1;
    private ToolStripMenuItem viewToolStripMenuItem1;
    private ToolStripMenuItem hUDToolStripMenuItem1;
    private ToolStripMenuItem neighborCountToolStripMenuItem1;
    private ToolStripMenuItem gridToolStripMenuItem1;
    private ToolStripSeparator toolStripSeparator8;
    private ToolStripMenuItem toroidalToolStripMenuItem;
    private ToolStripMenuItem finiteToolStripMenuItem;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem toolStripMenuItem2;
    private ToolStripMenuItem toolStripMenuItem3;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripMenuItem optionsToolStripMenuItem2;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripMenuItem resetToolStripMenuItem;
    private ToolStripMenuItem reloadToolStripMenuItem;

    public Form1()
    {
      this.InitializeComponent();
      this.seed = Settings.Default.Seed;
      this.golControl1.GridColor = Settings.Default.GridColor;
      this.golControl1.GridColorThick = Settings.Default.GridColorThick;
      this.golControl1.BackColor = Settings.Default.BackgroundColor;
      this.golControl1.LivingCellColor = Settings.Default.LiveCellColor;
      this.golControl1.UniverseSize = new Size(Settings.Default.UniverseWidth, Settings.Default.UniverseHeight);
      this.golControl1.TimerInterval = Settings.Default.TimerInterval;
      this.golControl1.NeighborCountVisible = true;
      this.golControl1.HUDVisible = true;
      this.toolStripStatusLabelInterval.Text = string.Format("Interval: {0}", (object) this.golControl1.TimerInterval);
      this.toolStripStatusLabelSeed.Text = string.Format("Seed: {0}", (object) this.seed);
    }

    private void runToolStripMenuItems_Click(object sender, EventArgs e)
    {
      if (sender.Equals((object) this.startToolStripMenuItem) || sender.Equals((object) this.startToolStripButton))
      {
        this.golControl1.Start();
        this.startToolStripMenuItem.Enabled = false;
        this.startToolStripButton.Enabled = false;
        this.pauseToolStripMenuItem.Enabled = true;
        this.pauseToolStripButton.Enabled = true;
        this.nextToolStripMenuItem.Enabled = false;
        this.nextToolStripButton.Enabled = false;
      }
      else if (sender.Equals((object) this.pauseToolStripMenuItem) || sender.Equals((object) this.pauseToolStripButton))
      {
        this.golControl1.Stop();
        this.startToolStripMenuItem.Enabled = true;
        this.startToolStripButton.Enabled = true;
        this.pauseToolStripMenuItem.Enabled = false;
        this.pauseToolStripButton.Enabled = false;
        this.nextToolStripMenuItem.Enabled = true;
        this.nextToolStripButton.Enabled = true;
      }
      else if (sender.Equals((object) this.nextToolStripMenuItem) || sender.Equals((object) this.nextToolStripButton))
      {
        this.golControl1.Next();
      }
      else
      {
        if (!sender.Equals((object) this.toToolStripMenuItem))
          return;
        RunToDialog runToDialog = new RunToDialog();
        runToDialog.CurrentGeneration = this.golControl1.Universe.Generation;
        runToDialog.RunToGeneration = this.golControl1.Universe.Generation + 1;
        if (DialogResult.OK != runToDialog.ShowDialog())
          return;
        this.golControl1.RunTo(runToDialog.RunToGeneration);
      }
    }

    private void randomizeFromSeedToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SeedDialog seedDialog = new SeedDialog();
      seedDialog.Seed = this.seed;
      if (DialogResult.OK != seedDialog.ShowDialog())
        return;
      this.seed = seedDialog.Seed;
      this.toolStripStatusLabelSeed.Text = string.Format("Seed: {0}", (object) this.seed);
      this.golControl1.Randomize(this.seed);
      this.golControl1.Invalidate();
    }

    private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.golControl1.Randomize(this.seed);
      this.golControl1.Invalidate();
    }

    private void randomizeFromTimeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.seed = new Random().Next();
      this.toolStripStatusLabelSeed.Text = string.Format("Seed: {0}", (object) this.seed);
      this.golControl1.Randomize(this.seed);
      this.golControl1.Invalidate();
    }

    private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OptionsDialog optionsDialog = new OptionsDialog();
      optionsDialog.TimerIntervalMilliseconds = this.golControl1.TimerInterval;
      optionsDialog.UniverseSize = this.golControl1.UniverseSize;
      if (DialogResult.OK != optionsDialog.ShowDialog())
        return;
      this.golControl1.TimerInterval = optionsDialog.TimerIntervalMilliseconds;
      if (optionsDialog.UniverseSize != this.golControl1.UniverseSize)
        this.golControl1.UniverseSize = optionsDialog.UniverseSize;
      this.golControl1.Invalidate();
    }

    private void golControl1_NewGeneration(object sender, UniverseEventArgs e)
    {
      this.toolStripStatusLabelGenerations.Text = string.Format("Generation: {0}", (object) e.Generation);
      this.toolStripStatusLabelAlive.Text = string.Format("Alive: {0}", (object) e.LivingCells);
    }

    private void golControl1_LivingCellsChanged(object sender, UniverseEventArgs e) => this.toolStripStatusLabelAlive.Text = string.Format("Alive: {0}", (object) e.LivingCells);

    private void golControl1_Randomized(object sender, UniverseEventArgs e)
    {
      this.toolStripStatusLabelGenerations.Text = string.Format("Generation: {0}", (object) e.Generation);
      this.toolStripStatusLabelAlive.Text = string.Format("Alive: {0}", (object) e.LivingCells);
    }

    private void golControl1_TimerIntervalChanged(object sender, TimerEventArgs e) => this.toolStripStatusLabelInterval.Text = string.Format("Interval: {0}", (object) e.Interval);

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "All Files|*.*|Cells|*.cells";
      openFileDialog.FilterIndex = 2;
      if (DialogResult.OK != openFileDialog.ShowDialog())
        return;
      StreamReader streamReader = new StreamReader(openFileDialog.FileName);
      int width = 0;
      int height = 0;
      while (!streamReader.EndOfStream)
      {
        string str = streamReader.ReadLine();
        if (str[0] != '!')
        {
          ++height;
          if (str.Length > width)
            width = str.Length;
        }
      }
      this.golControl1.Universe.Size = new Size(width, height);
      streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
      int y = 0;
      while (!streamReader.EndOfStream)
      {
        string str = streamReader.ReadLine();
        if (str[0] != '!')
        {
          for (int index = 0; index < str.Length; ++index)
            this.golControl1.Universe[index, y] = str[index] == 'O' ? new Cell(true) : new Cell(false);
          ++y;
        }
      }
      streamReader.Close();
      this.golControl1.Invalidate();
    }

    private void importToolStripMenuItem_Click(object sender, EventArgs e)
    {
      OpenFileDialog openFileDialog = new OpenFileDialog();
      openFileDialog.Filter = "All Files|*.*|Cells|*.cells";
      openFileDialog.FilterIndex = 2;
      if (DialogResult.OK != openFileDialog.ShowDialog())
        return;
      StreamReader streamReader = new StreamReader(openFileDialog.FileName);
      int num1 = 0;
      int num2 = 0;
      while (!streamReader.EndOfStream)
      {
        string str = streamReader.ReadLine();
        if (str[0] != '!')
        {
          ++num2;
          if (str.Length > num1)
            num1 = str.Length;
        }
      }
      int num3 = this.golControl1.Universe.Size.Width / 2 - num1 / 2;
      int num4 = this.golControl1.Universe.Size.Height / 2 - num2 / 2;
      streamReader.BaseStream.Seek(0L, SeekOrigin.Begin);
      int y = num4;
      while (!streamReader.EndOfStream)
      {
        string str = streamReader.ReadLine();
        if (str[0] != '!')
        {
          for (int index = 0; index < str.Length; ++index)
            this.golControl1.Universe[index + num3, y] = str[index] == 'O' ? new Cell(true) : new Cell(false);
          ++y;
        }
      }
      streamReader.Close();
      this.golControl1.Invalidate();
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.Filter = "All Files|*.*|Cells|*.cells";
      saveFileDialog.FilterIndex = 2;
      saveFileDialog.DefaultExt = "cells";
      if (DialogResult.OK != saveFileDialog.ShowDialog())
        return;
      StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
      streamWriter.WriteLine(string.Format("!{0} {1}", (object) DateTime.Now.ToShortDateString(), (object) DateTime.Now.ToShortTimeString()));
      for (int y = 0; y < this.golControl1.Universe.Size.Height; ++y)
      {
        StringBuilder stringBuilder = new StringBuilder();
        for (int x = 0; x < this.golControl1.Universe.Size.Width; ++x)
          stringBuilder.Append(this.golControl1.Universe[x, y].Alive ? 'O' : '.');
        streamWriter.WriteLine(stringBuilder.ToString());
      }
      streamWriter.Close();
    }

    private void clearToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.golControl1.Stop();
      this.startToolStripMenuItem.Enabled = true;
      this.startToolStripButton.Enabled = true;
      this.pauseToolStripMenuItem.Enabled = false;
      this.pauseToolStripButton.Enabled = false;
      this.nextToolStripMenuItem.Enabled = true;
      this.nextToolStripButton.Enabled = true;
      this.golControl1.Clear();
      this.toolStripStatusLabelGenerations.Text = string.Format("Generation: {0}", (object) this.golControl1.Universe.Generation);
      this.toolStripStatusLabelAlive.Text = string.Format("Alive: {0}", (object) this.golControl1.Universe.LivingCells);
      this.golControl1.Invalidate();
    }

    private void colorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ColorDialog colorDialog = new ColorDialog();
      colorDialog.Color = this.golControl1.BackColor;
      if (DialogResult.OK != colorDialog.ShowDialog())
        return;
      this.golControl1.BackColor = colorDialog.Color;
    }

    private void cellColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ColorDialog colorDialog = new ColorDialog();
      colorDialog.Color = this.golControl1.LivingCellColor;
      if (DialogResult.OK != colorDialog.ShowDialog())
        return;
      this.golControl1.LivingCellColor = colorDialog.Color;
    }

    private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ColorDialog colorDialog = new ColorDialog();
      colorDialog.Color = this.golControl1.GridColor;
      if (DialogResult.OK != colorDialog.ShowDialog())
        return;
      this.golControl1.GridColor = colorDialog.Color;
    }

    private void gridX10ColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ColorDialog colorDialog = new ColorDialog();
      colorDialog.Color = this.golControl1.GridColorThick;
      if (DialogResult.OK != colorDialog.ShowDialog())
        return;
      this.golControl1.GridColorThick = colorDialog.Color;
    }

    private void viewToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
    {
      this.hUDToolStripMenuItem.Checked = this.golControl1.HUDVisible;
      this.neighborCountToolStripMenuItem.Checked = this.golControl1.NeighborCountVisible;
      this.gridToolStripMenuItem.Checked = this.golControl1.GridVisible;
      this.toroidalToolStripMenuItem.Checked = this.golControl1.Universe.BoundaryType == BoundaryType.Toroidal;
      this.finiteToolStripMenuItem.Checked = this.golControl1.Universe.BoundaryType == BoundaryType.Finite;
    }

    private void hUDToolStripMenuItem_Click(object sender, EventArgs e) => this.golControl1.HUDVisible = !this.golControl1.HUDVisible;

    private void neighborCountToolStripMenuItem_Click(object sender, EventArgs e) => this.golControl1.NeighborCountVisible = !this.golControl1.NeighborCountVisible;

    private void gridToolStripMenuItem_Click(object sender, EventArgs e) => this.golControl1.GridVisible = !this.golControl1.GridVisible;

    private void viewToolStripMenuItem1_DropDownOpening(object sender, EventArgs e)
    {
      this.hUDToolStripMenuItem1.Checked = this.golControl1.HUDVisible;
      this.neighborCountToolStripMenuItem1.Checked = this.golControl1.NeighborCountVisible;
      this.gridToolStripMenuItem1.Checked = this.golControl1.GridVisible;
    }

    private void toroidalToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.golControl1.Universe.BoundaryType = BoundaryType.Toroidal;
      this.golControl1.Invalidate();
    }

    private void finiteToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.golControl1.Universe.BoundaryType = BoundaryType.Finite;
      this.golControl1.Invalidate();
    }

    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      Settings.Default.GridColor = this.golControl1.GridColor;
      Settings.Default.GridColorThick = this.golControl1.GridColorThick;
      Settings.Default.BackgroundColor = this.golControl1.BackColor;
      Settings.Default.LiveCellColor = this.golControl1.LivingCellColor;
      Settings.Default.Seed = this.seed;
      Settings.Default.TimerInterval = this.golControl1.TimerInterval;
      Settings.Default.UniverseWidth = this.golControl1.UniverseSize.Width;
      Settings.Default.UniverseHeight = this.golControl1.UniverseSize.Height;
      Settings.Default.Save();
    }

    private void resetToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Settings.Default.Reset();
      this.seed = Settings.Default.Seed;
      this.golControl1.GridColor = Settings.Default.GridColor;
      this.golControl1.GridColorThick = Settings.Default.GridColorThick;
      this.golControl1.BackColor = Settings.Default.BackgroundColor;
      this.golControl1.LivingCellColor = Settings.Default.LiveCellColor;
      this.golControl1.UniverseSize = new Size(Settings.Default.UniverseWidth, Settings.Default.UniverseHeight);
      this.golControl1.TimerInterval = Settings.Default.TimerInterval;
      this.toolStripStatusLabelInterval.Text = string.Format("Interval: {0}", (object) this.golControl1.TimerInterval);
      this.toolStripStatusLabelSeed.Text = string.Format("Seed: {0}", (object) this.seed);
    }

    private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Settings.Default.Reload();
      this.seed = Settings.Default.Seed;
      this.golControl1.GridColor = Settings.Default.GridColor;
      this.golControl1.GridColorThick = Settings.Default.GridColorThick;
      this.golControl1.BackColor = Settings.Default.BackgroundColor;
      this.golControl1.LivingCellColor = Settings.Default.LiveCellColor;
      this.golControl1.UniverseSize = new Size(Settings.Default.UniverseWidth, Settings.Default.UniverseHeight);
      this.golControl1.TimerInterval = Settings.Default.TimerInterval;
      this.toolStripStatusLabelInterval.Text = string.Format("Interval: {0}", (object) this.golControl1.TimerInterval);
      this.toolStripStatusLabelSeed.Text = string.Format("Seed: {0}", (object) this.seed);
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) => this.Close();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Form1));
      this.menuStrip1 = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.newToolStripMenuItem = new ToolStripMenuItem();
      this.openToolStripMenuItem = new ToolStripMenuItem();
      this.importToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator = new ToolStripSeparator();
      this.saveToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.viewToolStripMenuItem = new ToolStripMenuItem();
      this.hUDToolStripMenuItem = new ToolStripMenuItem();
      this.neighborCountToolStripMenuItem = new ToolStripMenuItem();
      this.gridToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator8 = new ToolStripSeparator();
      this.toroidalToolStripMenuItem = new ToolStripMenuItem();
      this.finiteToolStripMenuItem = new ToolStripMenuItem();
      this.runToolStripMenuItem = new ToolStripMenuItem();
      this.startToolStripMenuItem = new ToolStripMenuItem();
      this.pauseToolStripMenuItem = new ToolStripMenuItem();
      this.nextToolStripMenuItem = new ToolStripMenuItem();
      this.toToolStripMenuItem = new ToolStripMenuItem();
      this.universeToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem1 = new ToolStripMenuItem();
      this.toolStripMenuItem2 = new ToolStripMenuItem();
      this.toolStripMenuItem3 = new ToolStripMenuItem();
      this.optionsToolStripMenuItem1 = new ToolStripMenuItem();
      this.colorToolStripMenuItem = new ToolStripMenuItem();
      this.cellColorToolStripMenuItem = new ToolStripMenuItem();
      this.gridColorToolStripMenuItem = new ToolStripMenuItem();
      this.gridX10ColorToolStripMenuItem = new ToolStripMenuItem();
      this.helpToolStripMenuItem = new ToolStripMenuItem();
      this.contentsToolStripMenuItem = new ToolStripMenuItem();
      this.indexToolStripMenuItem = new ToolStripMenuItem();
      this.searchToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.aboutToolStripMenuItem = new ToolStripMenuItem();
      this.toolStrip1 = new ToolStrip();
      this.newToolStripButton = new ToolStripButton();
      this.openToolStripButton = new ToolStripButton();
      this.saveToolStripButton = new ToolStripButton();
      this.toolStripSeparator6 = new ToolStripSeparator();
      this.startToolStripButton = new ToolStripButton();
      this.pauseToolStripButton = new ToolStripButton();
      this.nextToolStripButton = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.statusStrip1 = new StatusStrip();
      this.toolStripStatusLabelGenerations = new ToolStripStatusLabel();
      this.toolStripStatusLabelInterval = new ToolStripStatusLabel();
      this.toolStripStatusLabelAlive = new ToolStripStatusLabel();
      this.toolStripStatusLabelSeed = new ToolStripStatusLabel();
      this.contextMenuStripGOL = new ContextMenuStrip(this.components);
      this.colorToolStripMenuItem1 = new ToolStripMenuItem();
      this.backColorToolStripMenuItem = new ToolStripMenuItem();
      this.cellColorToolStripMenuItem1 = new ToolStripMenuItem();
      this.gridColorToolStripMenuItem1 = new ToolStripMenuItem();
      this.gridX10ColorToolStripMenuItem1 = new ToolStripMenuItem();
      this.viewToolStripMenuItem1 = new ToolStripMenuItem();
      this.hUDToolStripMenuItem1 = new ToolStripMenuItem();
      this.neighborCountToolStripMenuItem1 = new ToolStripMenuItem();
      this.gridToolStripMenuItem1 = new ToolStripMenuItem();
      this.golControl1 = new GOLControl();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.optionsToolStripMenuItem2 = new ToolStripMenuItem();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.resetToolStripMenuItem = new ToolStripMenuItem();
      this.reloadToolStripMenuItem = new ToolStripMenuItem();
      this.menuStrip1.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.contextMenuStripGOL.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip1.Items.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.viewToolStripMenuItem,
        (ToolStripItem) this.runToolStripMenuItem,
        (ToolStripItem) this.universeToolStripMenuItem,
        (ToolStripItem) this.optionsToolStripMenuItem1,
        (ToolStripItem) this.helpToolStripMenuItem
      });
      this.menuStrip1.Location = new Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new Size(637, 24);
      this.menuStrip1.TabIndex = 0;
      this.menuStrip1.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.newToolStripMenuItem,
        (ToolStripItem) this.openToolStripMenuItem,
        (ToolStripItem) this.importToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator,
        (ToolStripItem) this.saveToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(37, 20);
      this.fileToolStripMenuItem.Text = "&File";
      this.newToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("newToolStripMenuItem.Image");
      this.newToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = Keys.N | Keys.Control;
      this.newToolStripMenuItem.Size = new Size(180, 22);
      this.newToolStripMenuItem.Text = "&New";
      this.newToolStripMenuItem.Click += new EventHandler(this.clearToolStripMenuItem_Click);
      this.openToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("openToolStripMenuItem.Image");
      this.openToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = Keys.O | Keys.Control;
      this.openToolStripMenuItem.Size = new Size(146, 22);
      this.openToolStripMenuItem.Text = "&Open";
      this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
      this.importToolStripMenuItem.Name = "importToolStripMenuItem";
      this.importToolStripMenuItem.Size = new Size(146, 22);
      this.importToolStripMenuItem.Text = "&Import";
      this.importToolStripMenuItem.Click += new EventHandler(this.importToolStripMenuItem_Click);
      this.toolStripSeparator.Name = "toolStripSeparator";
      this.toolStripSeparator.Size = new Size(143, 6);
      this.saveToolStripMenuItem.Image = (Image) componentResourceManager.GetObject("saveToolStripMenuItem.Image");
      this.saveToolStripMenuItem.ImageTransparentColor = Color.Magenta;
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = Keys.S | Keys.Control;
      this.saveToolStripMenuItem.Size = new Size(146, 22);
      this.saveToolStripMenuItem.Text = "&Save";
      this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(143, 6);
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new Size(180, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
      this.viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[6]
      {
        (ToolStripItem) this.hUDToolStripMenuItem,
        (ToolStripItem) this.neighborCountToolStripMenuItem,
        (ToolStripItem) this.gridToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator8,
        (ToolStripItem) this.toroidalToolStripMenuItem,
        (ToolStripItem) this.finiteToolStripMenuItem
      });
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new Size(44, 20);
      this.viewToolStripMenuItem.Text = "&View";
      this.viewToolStripMenuItem.DropDownOpening += new EventHandler(this.viewToolStripMenuItem_DropDownOpening);
      this.hUDToolStripMenuItem.Name = "hUDToolStripMenuItem";
      this.hUDToolStripMenuItem.Size = new Size(160, 22);
      this.hUDToolStripMenuItem.Text = "&HUD";
      this.hUDToolStripMenuItem.Click += new EventHandler(this.hUDToolStripMenuItem_Click);
      this.neighborCountToolStripMenuItem.Name = "neighborCountToolStripMenuItem";
      this.neighborCountToolStripMenuItem.Size = new Size(160, 22);
      this.neighborCountToolStripMenuItem.Text = "&Neighbor Count";
      this.neighborCountToolStripMenuItem.Click += new EventHandler(this.neighborCountToolStripMenuItem_Click);
      this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
      this.gridToolStripMenuItem.Size = new Size(160, 22);
      this.gridToolStripMenuItem.Text = "&Grid";
      this.gridToolStripMenuItem.Click += new EventHandler(this.gridToolStripMenuItem_Click);
      this.toolStripSeparator8.Name = "toolStripSeparator8";
      this.toolStripSeparator8.Size = new Size(157, 6);
      this.toroidalToolStripMenuItem.Name = "toroidalToolStripMenuItem";
      this.toroidalToolStripMenuItem.Size = new Size(160, 22);
      this.toroidalToolStripMenuItem.Text = "&Toroidal";
      this.toroidalToolStripMenuItem.Click += new EventHandler(this.toroidalToolStripMenuItem_Click);
      this.finiteToolStripMenuItem.Name = "finiteToolStripMenuItem";
      this.finiteToolStripMenuItem.Size = new Size(160, 22);
      this.finiteToolStripMenuItem.Text = "&Finite";
      this.finiteToolStripMenuItem.Click += new EventHandler(this.finiteToolStripMenuItem_Click);
      this.runToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.startToolStripMenuItem,
        (ToolStripItem) this.pauseToolStripMenuItem,
        (ToolStripItem) this.nextToolStripMenuItem,
        (ToolStripItem) this.toToolStripMenuItem
      });
      this.runToolStripMenuItem.Name = "runToolStripMenuItem";
      this.runToolStripMenuItem.Size = new Size(40, 20);
      this.runToolStripMenuItem.Text = "&Run";
      this.startToolStripMenuItem.Name = "startToolStripMenuItem";
      this.startToolStripMenuItem.ShortcutKeys = Keys.F5;
      this.startToolStripMenuItem.Size = new Size(124, 22);
      this.startToolStripMenuItem.Text = "&Start";
      this.startToolStripMenuItem.Click += new EventHandler(this.runToolStripMenuItems_Click);
      this.pauseToolStripMenuItem.Enabled = false;
      this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
      this.pauseToolStripMenuItem.ShortcutKeys = Keys.F6;
      this.pauseToolStripMenuItem.Size = new Size(124, 22);
      this.pauseToolStripMenuItem.Text = "&Pause";
      this.pauseToolStripMenuItem.Click += new EventHandler(this.runToolStripMenuItems_Click);
      this.nextToolStripMenuItem.Name = "nextToolStripMenuItem";
      this.nextToolStripMenuItem.ShortcutKeys = Keys.F7;
      this.nextToolStripMenuItem.Size = new Size(124, 22);
      this.nextToolStripMenuItem.Text = "&Next";
      this.nextToolStripMenuItem.Click += new EventHandler(this.runToolStripMenuItems_Click);
      this.toToolStripMenuItem.Name = "toToolStripMenuItem";
      this.toToolStripMenuItem.Size = new Size(124, 22);
      this.toToolStripMenuItem.Text = "&To";
      this.toToolStripMenuItem.Click += new EventHandler(this.runToolStripMenuItems_Click);
      this.universeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.toolStripMenuItem1,
        (ToolStripItem) this.toolStripMenuItem2,
        (ToolStripItem) this.toolStripMenuItem3
      });
      this.universeToolStripMenuItem.Name = "universeToolStripMenuItem";
      this.universeToolStripMenuItem.Size = new Size(78, 20);
      this.universeToolStripMenuItem.Text = "R&andomize";
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(173, 22);
      this.toolStripMenuItem1.Text = "From &Seed";
      this.toolStripMenuItem1.Click += new EventHandler(this.randomizeFromSeedToolStripMenuItem_Click);
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new Size(173, 22);
      this.toolStripMenuItem2.Text = "From &Current Seed";
      this.toolStripMenuItem2.Click += new EventHandler(this.fromCurrentSeedToolStripMenuItem_Click);
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new Size(173, 22);
      this.toolStripMenuItem3.Text = "From &Time";
      this.toolStripMenuItem3.Click += new EventHandler(this.randomizeFromTimeToolStripMenuItem_Click);
      this.optionsToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.colorToolStripMenuItem,
        (ToolStripItem) this.cellColorToolStripMenuItem,
        (ToolStripItem) this.gridColorToolStripMenuItem,
        (ToolStripItem) this.gridX10ColorToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.optionsToolStripMenuItem2,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.resetToolStripMenuItem,
        (ToolStripItem) this.reloadToolStripMenuItem
      });
      this.optionsToolStripMenuItem1.Name = "optionsToolStripMenuItem1";
      this.optionsToolStripMenuItem1.Size = new Size(61, 20);
      this.optionsToolStripMenuItem1.Text = "&Settings";
      this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
      this.colorToolStripMenuItem.Size = new Size(180, 22);
      this.colorToolStripMenuItem.Text = "&Back Color";
      this.colorToolStripMenuItem.Click += new EventHandler(this.colorToolStripMenuItem_Click);
      this.cellColorToolStripMenuItem.Name = "cellColorToolStripMenuItem";
      this.cellColorToolStripMenuItem.Size = new Size(180, 22);
      this.cellColorToolStripMenuItem.Text = "&Cell Color";
      this.cellColorToolStripMenuItem.Click += new EventHandler(this.cellColorToolStripMenuItem_Click);
      this.gridColorToolStripMenuItem.Name = "gridColorToolStripMenuItem";
      this.gridColorToolStripMenuItem.Size = new Size(180, 22);
      this.gridColorToolStripMenuItem.Text = "&Grid Color";
      this.gridColorToolStripMenuItem.Click += new EventHandler(this.gridColorToolStripMenuItem_Click);
      this.gridX10ColorToolStripMenuItem.Name = "gridX10ColorToolStripMenuItem";
      this.gridX10ColorToolStripMenuItem.Size = new Size(180, 22);
      this.gridX10ColorToolStripMenuItem.Text = "G&rid x10 Color";
      this.gridX10ColorToolStripMenuItem.Click += new EventHandler(this.gridX10ColorToolStripMenuItem_Click);
      this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.contentsToolStripMenuItem,
        (ToolStripItem) this.indexToolStripMenuItem,
        (ToolStripItem) this.searchToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.aboutToolStripMenuItem
      });
      this.helpToolStripMenuItem.Enabled = false;
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new Size(44, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
      this.contentsToolStripMenuItem.Size = new Size(122, 22);
      this.contentsToolStripMenuItem.Text = "&Contents";
      this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
      this.indexToolStripMenuItem.Size = new Size(122, 22);
      this.indexToolStripMenuItem.Text = "&Index";
      this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
      this.searchToolStripMenuItem.Size = new Size(122, 22);
      this.searchToolStripMenuItem.Text = "&Search";
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      this.toolStripSeparator5.Size = new Size(119, 6);
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new Size(122, 22);
      this.aboutToolStripMenuItem.Text = "&About...";
      this.toolStrip1.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.newToolStripButton,
        (ToolStripItem) this.openToolStripButton,
        (ToolStripItem) this.saveToolStripButton,
        (ToolStripItem) this.toolStripSeparator6,
        (ToolStripItem) this.startToolStripButton,
        (ToolStripItem) this.pauseToolStripButton,
        (ToolStripItem) this.nextToolStripButton,
        (ToolStripItem) this.toolStripSeparator2
      });
      this.toolStrip1.Location = new Point(0, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(637, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      this.newToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.newToolStripButton.Image = (Image) componentResourceManager.GetObject("newToolStripButton.Image");
      this.newToolStripButton.ImageTransparentColor = Color.Magenta;
      this.newToolStripButton.Name = "newToolStripButton";
      this.newToolStripButton.Size = new Size(23, 22);
      this.newToolStripButton.Text = "&New";
      this.newToolStripButton.Click += new EventHandler(this.clearToolStripMenuItem_Click);
      this.openToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.openToolStripButton.Image = (Image) componentResourceManager.GetObject("openToolStripButton.Image");
      this.openToolStripButton.ImageTransparentColor = Color.Magenta;
      this.openToolStripButton.Name = "openToolStripButton";
      this.openToolStripButton.Size = new Size(23, 22);
      this.openToolStripButton.Text = "&Open";
      this.openToolStripButton.Click += new EventHandler(this.openToolStripMenuItem_Click);
      this.saveToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.saveToolStripButton.Image = (Image) componentResourceManager.GetObject("saveToolStripButton.Image");
      this.saveToolStripButton.ImageTransparentColor = Color.Magenta;
      this.saveToolStripButton.Name = "saveToolStripButton";
      this.saveToolStripButton.Size = new Size(23, 22);
      this.saveToolStripButton.Text = "&Save";
      this.saveToolStripButton.Click += new EventHandler(this.saveToolStripMenuItem_Click);
      this.toolStripSeparator6.Name = "toolStripSeparator6";
      this.toolStripSeparator6.Size = new Size(6, 25);
      this.startToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.startToolStripButton.Image = (Image) Resources.arrow_run_16xLG;
      this.startToolStripButton.ImageTransparentColor = Color.Magenta;
      this.startToolStripButton.Name = "startToolStripButton";
      this.startToolStripButton.Size = new Size(23, 22);
      this.startToolStripButton.Text = "&Start";
      this.startToolStripButton.Click += new EventHandler(this.runToolStripMenuItems_Click);
      this.pauseToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.pauseToolStripButton.Enabled = false;
      this.pauseToolStripButton.Image = (Image) Resources.Symbols_Pause_16xLG;
      this.pauseToolStripButton.ImageTransparentColor = Color.Magenta;
      this.pauseToolStripButton.Name = "pauseToolStripButton";
      this.pauseToolStripButton.Size = new Size(23, 22);
      this.pauseToolStripButton.Text = "&Pause";
      this.pauseToolStripButton.Click += new EventHandler(this.runToolStripMenuItems_Click);
      this.nextToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.nextToolStripButton.Image = (Image) Resources.arrow_Next_16xLG_color;
      this.nextToolStripButton.ImageTransparentColor = Color.Magenta;
      this.nextToolStripButton.Name = "nextToolStripButton";
      this.nextToolStripButton.Size = new Size(23, 22);
      this.nextToolStripButton.Text = "&Next";
      this.nextToolStripButton.Click += new EventHandler(this.runToolStripMenuItems_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.statusStrip1.Items.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.toolStripStatusLabelGenerations,
        (ToolStripItem) this.toolStripStatusLabelInterval,
        (ToolStripItem) this.toolStripStatusLabelAlive,
        (ToolStripItem) this.toolStripStatusLabelSeed
      });
      this.statusStrip1.Location = new Point(0, 567);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(637, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      this.toolStripStatusLabelGenerations.Name = "toolStripStatusLabelGenerations";
      this.toolStripStatusLabelGenerations.Size = new Size(82, 17);
      this.toolStripStatusLabelGenerations.Text = "Generations: 0";
      this.toolStripStatusLabelInterval.Name = "toolStripStatusLabelInterval";
      this.toolStripStatusLabelInterval.Size = new Size(58, 17);
      this.toolStripStatusLabelInterval.Text = "Interval: 0";
      this.toolStripStatusLabelAlive.Name = "toolStripStatusLabelAlive";
      this.toolStripStatusLabelAlive.Size = new Size(45, 17);
      this.toolStripStatusLabelAlive.Text = "Alive: 0";
      this.toolStripStatusLabelSeed.Name = "toolStripStatusLabelSeed";
      this.toolStripStatusLabelSeed.Size = new Size(118, 17);
      this.toolStripStatusLabelSeed.Text = "toolStripStatusLabel1";
      this.contextMenuStripGOL.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.colorToolStripMenuItem1,
        (ToolStripItem) this.viewToolStripMenuItem1
      });
      this.contextMenuStripGOL.Name = "contextMenuStripGOL";
      this.contextMenuStripGOL.Size = new Size(104, 48);
      this.colorToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[4]
      {
        (ToolStripItem) this.backColorToolStripMenuItem,
        (ToolStripItem) this.cellColorToolStripMenuItem1,
        (ToolStripItem) this.gridColorToolStripMenuItem1,
        (ToolStripItem) this.gridX10ColorToolStripMenuItem1
      });
      this.colorToolStripMenuItem1.Name = "colorToolStripMenuItem1";
      this.colorToolStripMenuItem1.Size = new Size(103, 22);
      this.colorToolStripMenuItem1.Text = "Color";
      this.backColorToolStripMenuItem.Name = "backColorToolStripMenuItem";
      this.backColorToolStripMenuItem.Size = new Size(148, 22);
      this.backColorToolStripMenuItem.Text = "Back Color";
      this.backColorToolStripMenuItem.Click += new EventHandler(this.colorToolStripMenuItem_Click);
      this.cellColorToolStripMenuItem1.Name = "cellColorToolStripMenuItem1";
      this.cellColorToolStripMenuItem1.Size = new Size(148, 22);
      this.cellColorToolStripMenuItem1.Text = "Cell Color";
      this.cellColorToolStripMenuItem1.Click += new EventHandler(this.cellColorToolStripMenuItem_Click);
      this.gridColorToolStripMenuItem1.Name = "gridColorToolStripMenuItem1";
      this.gridColorToolStripMenuItem1.Size = new Size(148, 22);
      this.gridColorToolStripMenuItem1.Text = "Grid Color";
      this.gridColorToolStripMenuItem1.Click += new EventHandler(this.gridColorToolStripMenuItem_Click);
      this.gridX10ColorToolStripMenuItem1.Name = "gridX10ColorToolStripMenuItem1";
      this.gridX10ColorToolStripMenuItem1.Size = new Size(148, 22);
      this.gridX10ColorToolStripMenuItem1.Text = "Grid x10 Color";
      this.gridX10ColorToolStripMenuItem1.Click += new EventHandler(this.gridX10ColorToolStripMenuItem_Click);
      this.viewToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.hUDToolStripMenuItem1,
        (ToolStripItem) this.neighborCountToolStripMenuItem1,
        (ToolStripItem) this.gridToolStripMenuItem1
      });
      this.viewToolStripMenuItem1.Name = "viewToolStripMenuItem1";
      this.viewToolStripMenuItem1.Size = new Size(103, 22);
      this.viewToolStripMenuItem1.Text = "View";
      this.viewToolStripMenuItem1.DropDownOpening += new EventHandler(this.viewToolStripMenuItem1_DropDownOpening);
      this.hUDToolStripMenuItem1.Name = "hUDToolStripMenuItem1";
      this.hUDToolStripMenuItem1.Size = new Size(160, 22);
      this.hUDToolStripMenuItem1.Text = "HUD";
      this.hUDToolStripMenuItem1.Click += new EventHandler(this.hUDToolStripMenuItem_Click);
      this.neighborCountToolStripMenuItem1.Name = "neighborCountToolStripMenuItem1";
      this.neighborCountToolStripMenuItem1.Size = new Size(160, 22);
      this.neighborCountToolStripMenuItem1.Text = "Neighbor Count";
      this.neighborCountToolStripMenuItem1.Click += new EventHandler(this.neighborCountToolStripMenuItem_Click);
      this.gridToolStripMenuItem1.Name = "gridToolStripMenuItem1";
      this.gridToolStripMenuItem1.Size = new Size(160, 22);
      this.gridToolStripMenuItem1.Text = "Grid";
      this.gridToolStripMenuItem1.Click += new EventHandler(this.gridToolStripMenuItem_Click);
      this.golControl1.ContextMenuStrip = this.contextMenuStripGOL;
      this.golControl1.Dock = DockStyle.Fill;
      this.golControl1.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.golControl1.ForeColor = Color.Red;
      this.golControl1.Location = new Point(0, 49);
      this.golControl1.Name = "golControl1";
      this.golControl1.Size = new Size(637, 518);
      this.golControl1.TabIndex = 3;
      this.golControl1.Text = "golControl1";
      this.golControl1.TimerInterval = 20;
      this.golControl1.UniverseSize = new Size(30, 30);
      this.golControl1.NewGeneration += new UniverseEventHandler(this.golControl1_NewGeneration);
      this.golControl1.LivingCellsChanged += new UniverseEventHandler(this.golControl1_LivingCellsChanged);
      this.golControl1.Randomized += new UniverseEventHandler(this.golControl1_Randomized);
      this.golControl1.TimerIntervalChanged += new TimerEventHandler(this.golControl1_TimerIntervalChanged);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(177, 6);
      this.optionsToolStripMenuItem2.Name = "optionsToolStripMenuItem2";
      this.optionsToolStripMenuItem2.Size = new Size(180, 22);
      this.optionsToolStripMenuItem2.Text = "&Options";
      this.optionsToolStripMenuItem2.Click += new EventHandler(this.optionsToolStripMenuItem_Click);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(177, 6);
      this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
      this.resetToolStripMenuItem.Size = new Size(180, 22);
      this.resetToolStripMenuItem.Text = "&Reset";
      this.resetToolStripMenuItem.Click += new EventHandler(this.resetToolStripMenuItem_Click);
      this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
      this.reloadToolStripMenuItem.Size = new Size(180, 22);
      this.reloadToolStripMenuItem.Text = "Re&load";
      this.reloadToolStripMenuItem.Click += new EventHandler(this.reloadToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(637, 589);
      this.Controls.Add((Control) this.golControl1);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = nameof (Form1);
      this.Text = "Game of Life";
      this.FormClosed += new FormClosedEventHandler(this.Form1_FormClosed);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.contextMenuStripGOL.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
