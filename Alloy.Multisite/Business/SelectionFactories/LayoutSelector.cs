using EPiServer.Shell.ObjectEditing;
using System.Collections.Generic;
using System.Web.Hosting;

namespace Alloy.Multisite.Business.SelectionFactories
{
    public class LayoutSelector : ISelectionFactory
    {
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var layoutDirectory = new System.IO.DirectoryInfo(HostingEnvironment.MapPath("~/Views/Shared/Layouts"));

            if(!layoutDirectory.Exists)
            {
                yield return new SelectItem() { Text = "No layouts available.", Value = "" };

                yield break;
            }

            var layouts = layoutDirectory.EnumerateDirectories("*", System.IO.SearchOption.TopDirectoryOnly);
            var siteroot = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;

            foreach(var s in layouts)
            {
                yield return new SelectItem()
                {
                    Text = s.Name,
                    Value = s.FullName.Replace(siteroot, string.Empty).Replace("\\", "/").Insert(0,"~/")
                };
            }
        }
    }
}