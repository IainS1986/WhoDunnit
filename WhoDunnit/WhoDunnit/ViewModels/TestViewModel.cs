using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace WhoDunnit.ViewModels
{
    class TestViewModel : INotifyPropertyChanged
    {
        private string m_text = "Test";
        public string Text
        {
            get
            {
                return m_text;
            }
            set
            {
                m_text = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Text"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TestViewModel()
        {
            Text = "Hello Cluedo Test ViewModel!!!";
        }
    }
}
