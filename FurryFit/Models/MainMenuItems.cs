using System;
using System.Collections.Generic;
using System.Text;

namespace FurryFit.Models
{
    public class MainMenuItems
    {
        public List<MainMenuItem> mainMenuItems;
    }

    public class MainMenuItem
    {
        public string MenuIcon { get; set; }
        public string MenuItemName { get; set; }
        public bool ShowToggleSwitch { get; set; }
        public string TargetPage { get; set; }
        public Type TargetType { get; set; }
    }
}
