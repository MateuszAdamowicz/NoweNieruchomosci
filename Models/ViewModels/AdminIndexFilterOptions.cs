using System.Collections.Generic;

namespace Models.ViewModels
{
    public class AdminIndexFilterOptions
    {
        public List<SelectOption> AdTypes { get; set; }
        public List<SelectOption> ToLet { get; set; }
        public List<SelectOption> PerPage { get; set; }
        public List<SelectOption> Cities { get; set; }
    }
}