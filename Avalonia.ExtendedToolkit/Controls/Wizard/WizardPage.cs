﻿using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using System;

namespace Avalonia.ExtendedToolkit.Controls
{
    public class WizardPage : ContentControl, IWizardPage
    {
        public bool IsBackButtonVisible
        {
            get { return (bool)GetValue(IsBackButtonVisibleProperty); }
            set { SetValue(IsBackButtonVisibleProperty, value); }
        }

        public static readonly AvaloniaProperty IsBackButtonVisibleProperty =
            AvaloniaProperty.Register<WizardPage, bool>(nameof(IsBackButtonVisible),inherits: true);

        public bool? CanCancel
        {
            get { return (bool?)GetValue(CanCancelProperty); }
            set { SetValue(CanCancelProperty, value); }
        }

        public static readonly AvaloniaProperty CanCancelProperty =
            AvaloniaProperty.Register<WizardPage, bool?>(nameof(CanCancel), inherits: true);

        public bool IsCancelButtonVisibe
        {
            get { return (bool)GetValue(IsCancelButtonVisibeProperty); }
            set { SetValue(IsCancelButtonVisibeProperty, value); }
        }

        public static readonly AvaloniaProperty IsCancelButtonVisibeProperty =
            AvaloniaProperty.Register<WizardPage, bool>(nameof(IsCancelButtonVisibe));

        public bool? CanFinish
        {
            get { return (bool?)GetValue(CanFinishProperty); }
            set { SetValue(CanFinishProperty, value); }
        }

        public static readonly AvaloniaProperty CanFinishProperty =
            AvaloniaProperty.Register<WizardPage, bool?>(nameof(CanFinish), inherits: true);

        public bool? CanHelp
        {
            get { return (bool?)GetValue(CanHelpProperty); }
            set { SetValue(CanHelpProperty, value); }
        }

        public static readonly AvaloniaProperty CanHelpProperty =
            AvaloniaProperty.Register<WizardPage, bool?>(nameof(CanHelp));

        public bool? CanSelectNextPage
        {
            get { return (bool?)GetValue(CanSelectNextPageProperty); }
            set { SetValue(CanSelectNextPageProperty, value); }
        }

        public static readonly AvaloniaProperty CanSelectNextPageProperty =
            AvaloniaProperty.Register<WizardPage, bool?>(nameof(CanSelectNextPage));

        public bool? CanSelectPreviousPage
        {
            get { return (bool?)GetValue(CanSelectPreviousPageProperty); }
            set { SetValue(CanSelectPreviousPageProperty, value); }
        }

        public static readonly AvaloniaProperty CanSelectPreviousPageProperty =
            AvaloniaProperty.Register<WizardPage, bool?>(nameof(CanSelectPreviousPage));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public static readonly AvaloniaProperty DescriptionProperty =
            AvaloniaProperty.Register<WizardPage, string>(nameof(Description));

        public Brush ExteriorPanelBackground
        {
            get { return (Brush)GetValue(ExteriorPanelBackgroundProperty); }
            set { SetValue(ExteriorPanelBackgroundProperty, value); }
        }

        public static readonly AvaloniaProperty ExteriorPanelBackgroundProperty =
            AvaloniaProperty.Register<WizardPage, Brush>(nameof(ExteriorPanelBackground));

        public object ExteriorPanelContent
        {
            get { return (object)GetValue(ExteriorPanelContentProperty); }
            set { SetValue(ExteriorPanelContentProperty, value); }
        }

        public static readonly AvaloniaProperty ExteriorPanelContentProperty =
            AvaloniaProperty.Register<WizardPage, object>(nameof(ExteriorPanelContent));

        public bool IsFinishButtonVisible
        {
            get { return (bool)GetValue(IsFinishButtonVisibleProperty); }
            set { SetValue(IsFinishButtonVisibleProperty, value); }
        }

        public static readonly AvaloniaProperty IsFinishButtonVisibleProperty =
            AvaloniaProperty.Register<WizardPage, bool>(nameof(IsFinishButtonVisible));

        public Brush HeaderBackground
        {
            get { return (Brush)GetValue(HeaderBackgroundProperty); }
            set { SetValue(HeaderBackgroundProperty, value); }
        }

        public static readonly AvaloniaProperty HeaderBackgroundProperty =
            AvaloniaProperty.Register<WizardPage, Brush>(nameof(HeaderBackground));

        public Image HeaderImage
        {
            get { return (Image)GetValue(HeaderImageProperty); }
            set { SetValue(HeaderImageProperty, value); }
        }

        public static readonly AvaloniaProperty HeaderImageProperty =
            AvaloniaProperty.Register<WizardPage, Image>(nameof(HeaderImage));

        public bool IsHelpButtonVisible
        {
            get { return (bool)GetValue(IsHelpButtonVisibleProperty); }
            set { SetValue(IsHelpButtonVisibleProperty, value); }
        }

        public static readonly AvaloniaProperty IsHelpButtonVisibleProperty =
            AvaloniaProperty.Register<WizardPage, bool>(nameof(IsHelpButtonVisible));

        public bool IsNextButtonVisible
        {
            get { return (bool)GetValue(IsNextButtonVisibleProperty); }
            set { SetValue(IsNextButtonVisibleProperty, value); }
        }

        public static readonly AvaloniaProperty IsNextButtonVisibleProperty =
            AvaloniaProperty.Register<WizardPage, bool>(nameof(IsNextButtonVisible));

        public WizardPage NextPage
        {
            get { return (WizardPage)GetValue(NextPageProperty); }
            set { SetValue(NextPageProperty, value); }
        }

        public static readonly AvaloniaProperty NextPageProperty =
            AvaloniaProperty.Register<WizardPage, WizardPage>(nameof(NextPage));

        public WizardPageType PageType
        {
            get { return (WizardPageType)GetValue(PageTypeProperty); }
            set { SetValue(PageTypeProperty, value); }
        }

        public static readonly AvaloniaProperty PageTypeProperty =
            AvaloniaProperty.Register<WizardPage, WizardPageType>(nameof(PageType));

        public WizardPage PreviousPage
        {
            get { return (WizardPage)GetValue(PreviousPageProperty); }
            set { SetValue(PreviousPageProperty, value); }
        }

        public static readonly AvaloniaProperty PreviousPageProperty =
            AvaloniaProperty.Register<WizardPage, WizardPage>(nameof(PreviousPage));

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly AvaloniaProperty TitleProperty =
            AvaloniaProperty.Register<WizardPage, string>(nameof(Title));

        public WizardPage()
        {
            this.Initialized += WizardPage_Initialized;
            this.DataContextChanged += WizardPage_DataContextChanged;
        }

        private void WizardPage_DataContextChanged(object sender, EventArgs e)
        {
            if (this.DataContext is IWizardPageVM)
            {
                IWizardPageVM wizardPageVM = this.DataContext as IWizardPageVM;
                Title = wizardPageVM.Title;
                Description = wizardPageVM.Description;
                PageType = wizardPageVM.PageType;
            }
        }

        private void WizardPage_Initialized(object sender, EventArgs e)
        {
            if (this.IsVisible)
            {
                base.RaiseEvent(new RoutedEventArgs(EnterEvent, this));
            }
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if ((e.Property.Name == nameof(CanSelectNextPage)) || (e.Property.Name == nameof(CanHelp)) || (e.Property.Name == nameof(CanFinish))
        || (e.Property.Name == nameof(CanCancel)) || (e.Property.Name == nameof(CanSelectPreviousPage)))
            {
                //CommandManager.InvalidateRequerySuggested();
            }
        }

        public static RoutedEvent<RoutedEventArgs> EnterEvent =
            RoutedEvent.Register<WizardPage, RoutedEventArgs>(nameof(EnterEvent), RoutingStrategies.Bubble);

        public event EventHandler Enter
        {
            add
            {
                AddHandler(EnterEvent, value);
            }
            remove
            {
                RemoveHandler(EnterEvent, value);
            }
        }

        public static RoutedEvent<RoutedEventArgs> LeaveEvent =
            RoutedEvent.Register<WizardPage, RoutedEventArgs>(nameof(LeaveEvent), RoutingStrategies.Bubble);

        public event EventHandler Leave
        {
            add
            {
                AddHandler(LeaveEvent, value);
            }
            remove
            {
                RemoveHandler(LeaveEvent, value);
            }
        }

        protected override void OnPointerEnter(PointerEventArgs e)
        {
            base.OnPointerEnter(e);
        }

        protected override void OnPointerLeave(PointerEventArgs e)
        {
            base.OnPointerLeave(e);
        }
    }
}