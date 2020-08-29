using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Syncfusion.XForms.ComboBox;
using Xamarin.Forms;
using SelectionChangedEventArgs = Syncfusion.XForms.ComboBox.SelectionChangedEventArgs;

namespace FurryFit.Behaviors
{
    public class SfComboBoxValidationBehavior:  Behavior<SfComboBox>
    {
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(SfComboBoxValidationBehavior));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }


        protected override void OnAttachedTo(SfComboBox bindable)
        {
            bindable.Completed += Bindable_Completed;
            bindable.Unfocused += Bindable_Unfocused;
            bindable.SelectionChanged += BindableOnSelectionChanged;
            bindable.BindingContextChanged += Bindable_BindingContextChanged;
            base.OnAttachedTo(bindable);
        }

        private void Bindable_BindingContextChanged(object sender, EventArgs e)
        {
            var comboBox = sender as SfComboBox;
            BindingContext = comboBox?.BindingContext;
        }

        private void BindableOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Command == null)
                return;
            Command.Execute(null);
        }

        private void Bindable_Unfocused(object sender, FocusEventArgs e)
        {
            if (Command == null)
                return;
            Command.Execute(null);
        }

        private void Bindable_Completed(object sender, EventArgs e)
        {
            if (Command == null)
                return;
            Command.Execute(null);
        }

        protected override void OnDetachingFrom(SfComboBox bindable)
        {
            bindable.Completed -= Bindable_Completed;
            bindable.Unfocused -= Bindable_Unfocused;
            bindable.SelectionChanged -= BindableOnSelectionChanged;
            bindable.BindingContextChanged -= Bindable_BindingContextChanged;

            base.OnDetachingFrom(bindable);

        }
    }
}
