﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=234238

namespace AppTest
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class gameMain : Page
    {
        public gameMain()
        {
            this.InitializeComponent();
        }

        private void DonPlayButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(donChoiceAsso));
        }

        private void RandomGame_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(gameSelect));
        }
    }
}
