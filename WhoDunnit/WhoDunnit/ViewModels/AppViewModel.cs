using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using WhoDunnit.Extensions;
using Xamarin.Forms;

namespace WhoDunnit.ViewModels
{
    class AppViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            var info = property.GetMemberInfo();

            if (info == null)
                throw new NotSupportedException("Invalid property passed to RaisePropertyChanged(), " + property.ToString());

            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info.Name));
        }

        protected void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
