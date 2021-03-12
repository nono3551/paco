namespace Paco.Entities.FreeBsd
{
    public class PackageOption
    {
        private OptionSetStatus _status;
        public string Name { get; set; }
        public string Description { get; set; }

        public OptionSetStatus Status
        {
            get => _status;
            set => _status = value;
        }
    }
}