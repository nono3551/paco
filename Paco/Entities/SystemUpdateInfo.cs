namespace Paco.Entities
{
    public class SystemUpdateInfo
    {
        public bool CanUpdate { get; set; }
        public bool HasUpdate { get; set; }
        public string Description { get; set; }
        public string CurrentVersion { get; set; }
        public string NewVersion { get; set; }
    }
}