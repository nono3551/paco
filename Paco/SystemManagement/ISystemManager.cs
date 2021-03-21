using System.Collections.Generic;
using Paco.Entities;
using Paco.Entities.FreeBsd;
using Paco.Entities.Models;
using Paco.Entities.Models.Updating;

namespace Paco.SystemManagement
{
    public interface ISystemManager
    {
        ManagedSystem System { get; }
        Dictionary<string, string> GetSystemInformation();
        List<object> GetPackagesActions();
        bool IsSystemUpdateAvailable();
        KeyValuePair<bool, string> PackagesActionsNeedsInteraction();
        void PreparePackagesActions(List<object> actions);
        void ExecuteScheduledAction(ScheduledAction scheduledAction);
        string GetScheduledActionDetails(ScheduledAction scheduledAction);
        List<PackageInformation> GetPackagesList();
    }
}
