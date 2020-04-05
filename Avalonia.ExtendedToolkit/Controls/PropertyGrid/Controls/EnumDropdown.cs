﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Avalonia.Controls;

namespace Avalonia.ExtendedToolkit.Controls.PropertyGrid.Controls
{

    /// <summary>
    /// Combobox control to present enumeration classes.
    /// </summary>
    public class EnumDropdown : ComboBox
    {
        private bool _wrappedEvents;



        public PropertyItemValue PropertyValue
        {
            get { return (PropertyItemValue)GetValue(PropertyValueProperty); }
            set { SetValue(PropertyValueProperty, value); }
        }


        public static readonly StyledProperty<PropertyItemValue> PropertyValueProperty =
            AvaloniaProperty.Register<EnumDropdown, PropertyItemValue>(nameof(PropertyValue));

        public EnumDropdown()
        {
            PropertyValueProperty.Changed.AddClassHandler<EnumDropdown>((o, e) => OnPropertyValueChanged(o, e));

            this.AttachedToVisualTree += EnumDropdownLoaded;
            this.DetachedFromVisualTree += EnumDropdownUnloaded;

            this.SelectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PropertyValue.Value = e.AddedItems[0];
        }

        private void EnumDropdownUnloaded(object sender, VisualTreeAttachmentEventArgs e)
        {
            var value = PropertyValue;

            if (value != null)
                UnwrapEventHandlers(value);
        }

        private void EnumDropdownLoaded(object sender, VisualTreeAttachmentEventArgs e)
        {
            var value = PropertyValue;

            if (value != null)
                WrapEventHandlers(value);
        }

        private void OnPropertyValueChanged(EnumDropdown dropdown, AvaloniaPropertyChangedEventArgs e)
        {
            if (e.OldValue != null)
                dropdown.UnwrapEventHandlers((PropertyItemValue)e.OldValue);

            var newValue = e.NewValue as PropertyItemValue;
            if (newValue == null)
                return;

            dropdown.SelectedItem = newValue.Value;
            dropdown.Items = newValue.ParentProperty.StandardValues;
            dropdown.WrapEventHandlers(newValue);

        }

        private void WrapEventHandlers(PropertyItemValue target)
        {
            if (target == null)
                return;
            if (_wrappedEvents)
                return;

            target.PropertyChanged += ValuePropertyChanged;
            _wrappedEvents = true;
        }

        // TODO: Provide a dedicated ValueChanged event not to listen to everything (performance increase)
        void ValuePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Value")
            {
                if (SelectedItem != PropertyValue.Value)
                    SelectedItem = PropertyValue.Value;
            }
        }

        private void UnwrapEventHandlers(PropertyItemValue target)
        {
            if (target == null)
                return;
            if (!_wrappedEvents)
                return;

            target.PropertyChanged -= ValuePropertyChanged;
            _wrappedEvents = false;
        }

        


    }
}
