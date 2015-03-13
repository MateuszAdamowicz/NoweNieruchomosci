using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Models.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class AdminIndexFilterOptions
    {
        public List<SelectOption> AdTypes { get; set; }
        public List<SelectOption> ToLet { get; set; }
        public List<SelectOption> PerPage { get; set; }
        public List<SelectOption> Cities { get; set; }
    }
}