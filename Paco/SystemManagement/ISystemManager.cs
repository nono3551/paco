using Paco.Data.Entities;
using System.Collections.Generic;

namespace Paco.SystemManagement
{
    public interface ISystemManager
    {
        ManagedSystem System { get; }
        Dictionary<string, string> GetSystemInformation();
        void FetchSystemUpdates();
        bool IsSystemUpdateAvailable();
    }
}
