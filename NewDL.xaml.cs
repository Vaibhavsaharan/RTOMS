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
    public class InsertDL
    {
        public string DLno { get; set; }
    }
    public sealed partial class NewDL : Page
    {
        const string dbConnectionString = "Data Source=DESKTOP-NBNJR96;Initial Catalog=RTO;Integrated Security=True";
        public NewDL()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)

        {

            Customers s = (Customers)e.Parameter;

            namebox.Text = s.Name;
            fathername.Text = s.FName;
            emailbox.Text = s.Email;
            addressbox.Text = s.Address;
            aadharbox.Text = s.aadhar;
            mobilebox.Text = s.Mobile;
            identificationbox.Text = s.Identity;
            vehiclebox.Text = s.vehicletype;
            dobbox.Text = s.DOB;
        }

        private void DLButton_Click(object sender, RoutedEventArgs e)
        {

            string Currentdate = DateTime.Now.ToString();
            try
            {

                SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                SqlCommand command = new SqlCommand("spInsertDL", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@currentdate", SqlDbType.VarChar).Value = Currentdate;
                command.Parameters.Add("@aadhar", SqlDbType.VarChar).Value = aadharbox.Text;
                command.Parameters.Add("@vehicletype", SqlDbType.VarChar).Value = vehiclebox.Text;

                
                sqlConnection.Open();
                command.ExecuteNonQuery();

                SqlCommand cmd = new SqlCommand("select DrivingLicence_No from DL where Customer_id =(select Customer_id from Customer where Customer_aadhar='" + aadharbox.Text + "')", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    InsertDL custo = new InsertDL
                    {
                        DLno = dr.GetString(0).ToString()
                    };
                    this.Frame.Navigate(typeof(FinalDL), custo);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
        }
    }
}
