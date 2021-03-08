using System.Collections.Generic;
using Paco.Entities.Models;

namespace Paco.SystemManagement
{
    public interface ISystemManager
    {
        ManagedSystem System { get; }
        Dictionary<string, string> GetSystemInformation();
        IEnumerable<string> GetPackagesUpdates(bool shouldRefresh = false);
        bool IsSystemUpdateAvailable();
        KeyValuePair<bool, string> UpdateNeedsInteraction();
        void FetchPackagesUpdates();
    }
}
