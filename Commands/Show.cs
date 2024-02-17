using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;

namespace RevitPlugin
{
    [Transaction(TransactionMode.Manual)]
    public class Show : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            try
            {
                DockablePaneId id = new DockablePaneId(new Guid("D6BD208A-C251-42B8-967A-3C9453EFB3EE"));
                DockablePane dockableWindow = commandData.Application.GetDockablePane(id);
                dockableWindow.Show();
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Info Message", ex.Message);
            }

            return Result.Succeeded;
        }
    }
}