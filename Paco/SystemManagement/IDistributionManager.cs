using Paco.Data.Entities;
using System.Collections.Generic;

namespace Paco.SystemManagement
{
    public interface IDistributionManager
    {
        public ManagedSystem System { get; }

        Dictionary<string, string> GetSystemInformation();
        void FetchSystemUpdates();
    }
}
