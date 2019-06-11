using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// 

    public class LL
    {
        public string Name { get; set; }
        public string FName { get; set; }
        public string Identity { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string vehicletype { get; set; }
        public string state {get; set;}
        public string LLno { get; set; }

        public string dateofissue { get; set; }

    }
    public sealed partial class GetDocuments : Page
    {
        const string dbConnectionString = "Data Source=DESKTOP-NBNJR96;Initial Catalog=RTO;Integrated Security=True";
        public GetDocuments()
        {
            this.InitializeComponent();
        }

        private void GetRC_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GetRC));
        }

        private void GetDL_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GetDL));
        }

        private void GetLL_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select Customer.Customer_name,Customer.Customer_fathername,Customer.Customer_identity,Customer.Customer_address,Customer.Customer_DOB,Customer.Customer_vehicle,Customer.Customer_state,LL.Dateofissue from Customer,LL where Customer.Customer_id = LL.Customer_id and Customer.Customer_id = (select Customer_id from LL where LearnersLicence_No=" + GetLLBox.Text.Trim() + ")", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    LL inalL = new LL
                    {
                        Name = dr.GetString(0).ToString(),
                        FName = dr.GetString(1).ToString(),
                        Identity = dr.GetString(2).ToString(),
                        Address = dr.GetString(3).ToString(),
                        DOB = dr.GetString(4).ToString(),
                        vehicletype = dr.GetString(5).ToString(),
                        state = dr.GetString(6).ToString(),
                        LLno = GetLLBox.Text,
                        dateofissue = dr.GetString(7).ToString()
                    };
                    this.Frame.Navigate(typeof(GetLL), inalL);
                }
                
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            

        }
    }
}
