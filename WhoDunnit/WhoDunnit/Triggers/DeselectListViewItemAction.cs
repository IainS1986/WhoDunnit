using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WhoDunnit.Triggers
{
    public class DeselectListViewItemAction : TriggerAction<ListView>
    {
        protected override void Invoke(ListView sender)
        {
            sender.SelectedItem = null;
        }
    }
}
