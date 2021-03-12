namespace Paco.Entities.FreeBsd
{
    /// <summary>
    /// https://docs.freebsd.org/en_US.ISO8859-1/books/porters-handbook/makefile-options.html
    /// </summary>
    public enum OptionsGroupType
    {
        /// <summary>
        /// OPTIONS can be grouped as radio choices, where only one choice from each group is allowed
        /// </summary>
        Single,
        /// <summary>
        /// OPTIONS can be grouped as radio choices, where none or only one choice from each group is allowed
        /// </summary>
        Radio,
        /// <summary>
        /// OPTIONS can also be grouped as “multiple-choice” lists, where at least one option must be enabled
        /// </summary>
        Multi,  
        /// <summary>
        /// OPTIONS can also be grouped as “multiple-choice” lists, where none or any option can be enabled
        /// </summary>
        Group
    }
}