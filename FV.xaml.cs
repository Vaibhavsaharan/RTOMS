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
    public class Vehicle
    {
        public string Chasis { get; set; }
        public string VehicleType { get; set; }
        public string Typeofbody { get; set; }
        public string Maker { get; set; }
        public string Mfd { get; set; }
        public int Cylinder { get; set; }
        public int HP { get; set; }
        public int CC { get; set; }


    }

    public sealed partial class FV : Page
    {
        const string dbConnectionString = "Data Source=DESKTOP-NBNJR96;Initial Catalog=RTO;Integrated Security=True";
        public FV()
        {
            this.InitializeComponent();
        }

        private void PassportSignInButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select * from Vehicle where Vehicle_chasis =(select Vehicle_chasis from Registration where Registration_number ='" + LLTextBox.Text.Trim() + "')", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Vehicle customer = new Vehicle
                    {
                        Chasis = dr.GetString(0).ToString(),
                        VehicleType = dr.GetString(2).ToString(),
                        Typeofbody = dr.GetString(3).ToString(),
                        Maker = dr.GetString(4).ToString(),
                        Cylinder = dr.GetInt32(5),
                        HP = dr.GetInt32(6),
                        CC = dr.GetInt32(7),
                        Mfd = dr.GetString(8).ToString()
                    };
                    this.Frame.Navigate(typeof(FinalFV), customer);
                }




            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }

        }
    }
}
