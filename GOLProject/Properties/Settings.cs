using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace GOLProject.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.8.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default => Settings.defaultInstance;

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Black")]
    public Color GridColor
    {
      get => (Color) this[nameof (GridColor)];
      set => this[nameof (GridColor)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Grey")]
    public Color BackgroundColor
    {
      get => (Color) this[nameof (BackgroundColor)];
      set => this[nameof (BackgroundColor)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Yellow")]
    public Color LiveCellColor
    {
      get => (Color) this[nameof (LiveCellColor)];
      set => this[nameof (LiveCellColor)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("1337")]
    public int Seed
    {
      get => (int) this[nameof (Seed)];
      set => this[nameof (Seed)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("Black")]
    public Color GridColorThick
    {
      get => (Color) this[nameof (GridColorThick)];
      set => this[nameof (GridColorThick)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("20")]
    public int TimerInterval
    {
      get => (int) this[nameof (TimerInterval)];
      set => this[nameof (TimerInterval)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("30")]
    public int UniverseWidth
    {
      get => (int) this[nameof (UniverseWidth)];
      set => this[nameof (UniverseWidth)] = (object) value;
    }

    [UserScopedSetting]
    [DebuggerNonUserCode]
    [DefaultSettingValue("30")]
    public int UniverseHeight
    {
      get => (int) this[nameof (UniverseHeight)];
      set => this[nameof (UniverseHeight)] = (object) value;
    }
  }
}
