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
    public sealed partial class GetDL : Page
    {
        public GetDL()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)

        {

            DL s = (DL)e.Parameter;

            namebox.Text = s.Name;
            fathernamebox.Text = s.FName;
            statebox.Text = s.state + " State Motor Driving Licence";
            addressbox.Text = s.Address;
            dlnobox.Text = s.DLno;
            vehiclebox.Text = s.vehicletype;
            dobbox.Text = s.DOB;
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
