using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurryFit.Views.Forms
{

    public class MDPageMasterMenuItem
    {
        public MDPageMasterMenuItem()
        {
            TargetType = typeof(MDPageMasterMenuItem);
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public Type TargetType { get; set; }
        public string MenuIcon { get; set; }
        public bool ShowToggleSwitch { get; set; }
    }
}