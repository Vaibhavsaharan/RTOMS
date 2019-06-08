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
using System.Data.SqlClient;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Home : Page
    {
        const string connstring = "Data Source=DESKTOP-NBNJR96;Initial Catalog=RTO;Integrated Security=True";
        public Home()
        {
            this.InitializeComponent();
        }

        private void ConnCheckButton_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlconn = new SqlConnection(connstring))
            {
                sqlconn.Open();
                ConnCheck.Text = sqlconn.State.ToString();
            }
        }        
        

    }
}
