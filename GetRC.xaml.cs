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
    public sealed partial class GetRC : Page
    {
        public GetRC()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)

        {

            RC s = (RC)e.Parameter;

            namebox.Text = s.Name;
            fathernamebox.Text = s.FName;
            statebox.Text = s.state + " State Vehicle Registration Certificate";
            addressbox.Text = s.Address;
            rcnobox.Text = s.RCno;
            makerbox.Text = s.Maker;
            vehicletypebox.Text = s.VehicleType;
            mfdbox.Text = s.Mfd;
            typebodybox.Text = s.Typeofbody;
            chasisbox.Text = s.Chasis;
            ccbox.Text = s.CC.ToString();
            issuedatebox.Text = s.dateofissue;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GetDocuments));
        }

        private void DownLoadButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
