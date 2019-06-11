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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FinalFV : Page
    {
        public FinalFV()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)

        {

            Vehicle s = (Vehicle)e.Parameter;

 
            fathername.Text = s.Chasis;
            emailbox.Text = s.VehicleType;
            addressbox.Text = s.Maker;
            aadharbox.Text = s.Typeofbody;
            mobilebox.Text = s.Cylinder.ToString();
            identificationbox.Text = s.HP.ToString();
            vehiclebox.Text = s.CC.ToString();
            dobbox.Text = s.Mfd;
        }

        private void DLButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Home));
        }
    }
}
