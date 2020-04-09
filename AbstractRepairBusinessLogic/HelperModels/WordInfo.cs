using RepairBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace RepairBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<RepairWorkViewModel> RepairWorks { get; set; }
    }
}