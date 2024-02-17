using Autodesk.Revit.UI;
using RevitPlugin.xamls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace RevitPlugin
{
    public class Main : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {

            RibbonPanel panel = application.CreateRibbonPanel(Tab.AddIns, "TwentyTwo Sample");

            PushButtonData buttonData = new PushButtonData("Show", "Show", Assembly.GetExecutingAssembly().Location, "RevitPlugin.Show")
            {
                LargeImage = new BitmapImage(new Uri(@"D:\myApp\RevitPlugin\res\icon_img_32x32.png")),
            };

            panel.AddItem(buttonData);

            DockablePaneProviderData data = new DockablePaneProviderData();
            YourDockablePanelClass panelClass = new YourDockablePanelClass();

            DockablePaneId panelId = new DockablePaneId(new Guid(Config.GUID));
            application.RegisterDockablePane(panelId, "Your Dockable Panel Title", panelClass);


            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }

    class YourDockablePanelClass : IDockablePaneProvider
    {
        public void SetupDockablePane(DockablePaneProviderData data)
        {
            data.FrameworkElement = new families();
            data.InitialState = new DockablePaneState();
        }
    }
}
