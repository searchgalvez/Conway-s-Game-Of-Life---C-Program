using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace GOLProject.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (GOLProject.Properties.Resources.resourceMan == null)
          GOLProject.Properties.Resources.resourceMan = new ResourceManager("GOLProject.Properties.Resources", typeof (GOLProject.Properties.Resources).Assembly);
        return GOLProject.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get => GOLProject.Properties.Resources.resourceCulture;
      set => GOLProject.Properties.Resources.resourceCulture = value;
    }

    internal static Bitmap arrow_Next_16xLG_color => (Bitmap)GOLProject.Properties.Resources.ResourceManager.GetObject(nameof (arrow_Next_16xLG_color), GOLProject.Properties.Resources.resourceCulture);

    internal static Bitmap arrow_run_16xLG => (Bitmap)GOLProject.Properties.Resources.ResourceManager.GetObject(nameof (arrow_run_16xLG), GOLProject.Properties.Resources.resourceCulture);

    internal static Bitmap Symbols_Pause_16xLG => (Bitmap)GOLProject.Properties.Resources.ResourceManager.GetObject(nameof (Symbols_Pause_16xLG), GOLProject.Properties.Resources.resourceCulture);
  }
} 
