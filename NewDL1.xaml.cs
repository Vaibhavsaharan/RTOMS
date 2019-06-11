using System;
using System.Collections.Generic;
using System.Data;
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

    public class Customers
    {
        public string Name { get; set; }
        public string FName { get; set; }
        public string Email { get; set; }
        public string Identity { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string Mobile { get; set; }
        public string aadhar { get; set; }
        public string vehicletype { get; set; }

    }

    public sealed partial class NewDL1 : Page
    {
        const string dbConnectionString = "Data Source=DESKTOP-NBNJR96;Initial Catalog=RTO;Integrated Security=True";
        public NewDL1()
        {
            this.InitializeComponent();
        }

        private void PassportSignInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select Customer_name,Customer_fathername,Customer_email,Customer_identity,Customer_address,Customer_DOB,Customer_mobile,Customer_aadhar,Customer_vehicle from Customer where Customer_id =(select Customer_id from LL where LearnersLicence_No=" + LLTextBox.Text.Trim() + ")", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Customers customer = new Customers
                    {
                        Name = dr.GetString(0).ToString(),
                        FName = dr.GetString(1).ToString(),
                        Email = dr.GetString(2).ToString(),
                        Identity = dr.GetString(3).ToString(),
                        Address = dr.GetString(4).ToString(),
                        DOB = dr.GetString(5).ToString(),
                        Mobile = dr.GetString(6).ToString(),
                        aadhar = dr.GetString(7).ToString(),
                        vehicletype = dr.GetString(8).ToString()
                    };
                    this.Frame.Navigate(typeof(NewDL), customer);
                }
                

                

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
            

        }
    }
}
