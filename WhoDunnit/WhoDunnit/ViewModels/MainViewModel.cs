﻿using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace WhoDunnit.ViewModels
{
    class MainViewModel : AppViewModel
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
                RaisePropertyChanged("Text");
            }
        }

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            Text = "Hello Cluedo Test ViewModel!!!";
        }

        public void OnNewGameStart()
        {
            Console.WriteLine("Start New Game Flow");
        }
    }
}
