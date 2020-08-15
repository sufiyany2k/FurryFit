using Syncfusion.XForms.iOS.Cards;
using Syncfusion.ListView.XForms.iOS;
using Syncfusion.XForms.iOS.Graphics;
using Syncfusion.SfChart.XForms.iOS.Renderers;
using Syncfusion.XForms.iOS.Core;
using Syncfusion.XForms.iOS.Border;
using Syncfusion.XForms.iOS.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Syncfusion.SfSchedule.XForms.iOS;

using Syncfusion.SfBusyIndicator.XForms.iOS;

using Syncfusion.SfNavigationDrawer.XForms.iOS;

using Syncfusion.SfNumericTextBox.XForms.iOS;

using Syncfusion.SfNumericUpDown.XForms.iOS;

using Syncfusion.SfMaps.XForms.iOS;

using Syncfusion.XForms.iOS.TabView;

using Syncfusion.XForms.iOS.TextInputLayout;

using Syncfusion.XForms.iOS.TreeView;

using Syncfusion.XForms.iOS.BadgeView;
using Syncfusion.XForms.iOS.ComboBox;
using Syncfusion.XForms.Pickers.iOS;

namespace FurryFit.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            SfCardViewRenderer.Init();
            SfListViewRenderer.Init();
            SfGradientViewRenderer.Init();
            SfChartRenderer.Init();
            SfAvatarViewRenderer.Init();
            SfBorderRenderer.Init();
            SfButtonRenderer.Init();
			SfNavigationDrawerRenderer.Init();
			SfScheduleRenderer.Init();
            SfDatePickerRenderer.Init();

			SfComboBoxRenderer.Init();
			SfBusyIndicatorRenderer.Init();
			
			
			SfNavigationDrawerRenderer.Init();
			
			
			SfNumericTextBoxRenderer.Init();
			
			
			SfNumericUpDownRenderer.Init();
			
			
			SfMapsRenderer.Init();
			
			
			SfTabViewRenderer.Init();

            SfCarouselRenderer.Init();
			SfTextInputLayoutRenderer.Init();
			
			
			SfTreeViewRenderer.Init();
			
			
			SfBadgeViewRenderer.Init();

            SfCheckBoxRenderer.Init();
			SfTimePickerRenderer.Init();
			
			LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
