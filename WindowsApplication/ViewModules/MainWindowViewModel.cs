﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Media.Imaging;
using WindowsApplication.API;
using WindowsApplication.AutomationHandlers;
using WindowsApplication.Helpers;
using WindowsApplication.Utilities;

namespace WindowsApplication.ViewModules
{
    public class MainWindowViewModel : ObservableObject
    {
        public ApiClient client { get; set; }
        private bool _hasOutlookFocusHandler;
        public bool HasOutlookFocusHandler
        {
            get => _hasOutlookFocusHandler;
            set
            {
                this._hasOutlookFocusHandler = value;
                OnPropertyChanged("HasOutlookFocusHandler");
            }
        }

        private int _index;
        public int Index
        {
            get => _index;
            set
            {
                this._index = value;
                OnPropertyChanged("Index");
            }
        }

        private bool _NewData;
        public bool NewData
        {
            get => _NewData;
            set
            {
                this._NewData = value;
                OnPropertyChanged("NewData");
            }
        }


        AutomationFocusChangedEventHandler? focusHandler;

        // the focus handler should be a class that is initialized and set to the last focused one
        // not a list of initialized ones
        private OutlookFocusHandler? _outlookFocusHandler;
        public OutlookFocusHandler? OutlookFocusHandler { get => _outlookFocusHandler; private set {
                _outlookFocusHandler = value;
                OnPropertyChanged("OutlookFocusHandler");
                HasOutlookFocusHandler = value != null;
            }
        }

        Action<string> _textAction;

        public MainWindowViewModel()
        {
            this.client = new ApiClient();
            this._textAction = client.Update;
            OutlookFocusHandler = null;
            this.client.PropertyChanged += Client_PropertyChanged;
            this.NewData = false;
        }

        private void Client_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "LastUpdatedResponse")
            {
                Index = 0;
                NewData = client.LastUpdatedResponse.Length != 0;
            }
        }

        public void registerFocusChangeHandler()
        {
            focusHandler = new AutomationFocusChangedEventHandler(OnFocusChange);
            Automation.AddAutomationFocusChangedEventHandler(focusHandler);
        }

        public void unregisterFocusChangeHandler()
        {
            if (focusHandler != null)
            {
                Automation.RemoveAutomationFocusChangedEventHandler(focusHandler);
                OutlookFocusHandler?.OnLostFocus();
            }
        }

        private void OnFocusChange(object src, AutomationFocusChangedEventArgs e)
        {           

            HasOutlookFocusHandler = OutlookHelper.HandleOutlookFocuse(src, ref _outlookFocusHandler, ref _textAction);            
            
        }
    }
}
