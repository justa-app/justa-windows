using System;
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
    public class StartSessionViewModel : ObservableObject
    {
        public ApiClient client { get; set; }

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


        Action<string> _textAction;

        public StartSessionViewModel()
        {
            this.client = new ApiClient();
            this._textAction = client.Update;            
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
    }
}
