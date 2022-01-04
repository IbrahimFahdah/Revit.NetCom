using System.Runtime.InteropServices;

namespace Revit.interop.Contacts
{
    [ComVisible(true)]
    public interface IRevitApp
    {
        string VersionName { get; set; }
    }
}
