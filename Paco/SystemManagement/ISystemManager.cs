using System.Collections.Generic;
using Paco.Entities;
using Paco.Entities.Models.Updating;

namespace Paco.SystemManagement
{
    public interface ISystemManager
    {
        void SetupSystem();
        Dictionary<string, string> GetSystemInformation();
        List<object> GetPackagesActions();
        void PreparePackagesActions(List<object> actions);
        void ExecuteScheduledAction(ScheduledAction scheduledAction);
        string GetScheduledActionDetails(ScheduledAction scheduledAction);
        List<PackageInformation> GetListOfPackages();
        SystemUpdateInfo GetInformationAboutSystemUpdate();
    }
}
