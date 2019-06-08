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
    public sealed partial class Registration : Page
    {
        const string dbConnectionString = "Data Source=DESKTOP-NBNJR96;Initial Catalog=RTO;Integrated Security=True";
        public Registration()
        {
            this.InitializeComponent();

        }

        private void RCButton_Click(object sender, RoutedEventArgs e)
        {
            string Currentdate = DateTime.Now.ToString();
            /*try
            {
                SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                SqlCommand command = new SqlCommand("spinsertLL", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = UsernameTextbox.Text;
                command.Parameters.Add("@FName", SqlDbType.VarChar).Value = FathernameTextbox.Text;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = EmailTextbox.Text;
                command.Parameters.Add("@Identity", SqlDbType.VarChar).Value = IdentificationTextbox.Text;
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = addressTextbox.Text;
                command.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = PhoneTextbox.Text;
                command.Parameters.Add("@State", SqlDbType.VarChar).Value = StateTextbox.Text;
                command.Parameters.Add("@rto", SqlDbType.VarChar).Value = RtoTextbox.Text;
                command.Parameters.Add("@aadhar", SqlDbType.VarChar).Value = AadharTextBox.Text;
                command.Parameters.Add("@vehicletype", SqlDbType.VarChar).Value = VehicleCombox.SelectedItem.ToString();
                command.Parameters.Add("@currentdate", SqlDbType.VarChar).Value = Currentdate;
                sqlConnection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Data added");
                this.Frame.Navigate(typeof(FinalLL));


            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }*/
        }
    }
}
