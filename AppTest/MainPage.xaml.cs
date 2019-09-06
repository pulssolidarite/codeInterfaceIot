using System;
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
using Windows.Devices.Gpio;
using Windows.UI.ViewManagement;
using Windows.UI.Core;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppTest
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private const int PB_PIN = 19;
        private const int A_PIN = 18;

        private GpioPin pushButton;
        private GpioPin aButton;

        private GpioPinEdge aButtonValue;

        public MainPage()
        {
            InitializeComponent();
            InitGPIO();
        }

        private void InitGPIO()
        {
            var gpio = GpioController.GetDefault();

            if (gpio == null)
            {
                GpioStatus.Text = "There is no GPIO controller on this device.";
                return;
            }
            pushButton = gpio.OpenPin(PB_PIN);
            aButton = gpio.OpenPin(A_PIN);
            aButton.SetDriveMode(GpioPinDriveMode.Input);

            if (pushButton.IsDriveModeSupported(GpioPinDriveMode.InputPullUp))
                pushButton.SetDriveMode(GpioPinDriveMode.InputPullUp);
            else
                pushButton.SetDriveMode(GpioPinDriveMode.Input);

            pushButton.DebounceTimeout = TimeSpan.FromMilliseconds(50);

            pushButton.ValueChanged += GpioAct;
            GpioStatus.Text = "GPIO pins initialized correctly.";
            

        }

        private void MainPage_Unloaded(object sender, object args)
        {
            pushButton.Dispose();
            aButton.Dispose();
        }



        private void GpioAct(GpioPin sender, GpioPinValueChangedEventArgs e)
        {

            /* if (e.Edge == GpioPinEdge.FallingEdge)
             {
                 *//*this.Frame.Navigate(typeof(SecondePage));*//*

                 GpioStatus.Text = "Button Pressed";

             }
             else
             {
                 GpioStatus.Text = "Button Released";
             }*/
            var task = Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
                {
                    if (e.Edge == GpioPinEdge.FallingEdge)
                    {

                        GpioStatus.Text = "Button Pressed";
                    }
                    else
                    {
                        GpioStatus.Text = "Button Released";
                    }

                });

        }

        private void Don_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SecondePage));
            this.Unloaded += MainPage_Unloaded;
        }

        private void Game_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(gameMain));
            this.Unloaded += MainPage_Unloaded;
        }
    }
}
