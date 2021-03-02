using System.Collections.Generic;
using Paco.Entities.Models;

namespace Paco.SystemManagement
{
    public interface ISystemManager
    {
        ManagedSystem System { get; }
        Dictionary<string, string> GetSystemInformation();
        void FetchSystemUpdates();
        bool IsSystemUpdateAvailable();
        KeyValuePair<bool, string> UpdateNeedsInteraction();
    }
}
