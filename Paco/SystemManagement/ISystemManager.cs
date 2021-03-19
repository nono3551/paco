using System.Collections.Generic;
using Paco.Entities.FreeBsd;
using Paco.Entities.Models;
using Paco.Entities.Models.Updating;

namespace Paco.SystemManagement
{
    public interface ISystemManager
    {
        ManagedSystem System { get; }
        Dictionary<string, string> GetSystemInformation();
        IEnumerable<object> GetPackagesActions(bool shouldRefresh = false);
        bool IsSystemUpdateAvailable();
        KeyValuePair<bool, string> PackagesActionsNeedsInteraction();
        void PreparePackagesActions(IEnumerable<object> actions);
        void ExecuteScheduledAction(ScheduledAction scheduledAction);
        string GetScheduledActionDetails(ScheduledAction scheduledAction);
    }
}
