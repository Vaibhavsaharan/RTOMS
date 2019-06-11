using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Data.SqlClient;
using System.Data;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

        public class InsertLL
        {
            public string LLno { get; set; }
        }
    public sealed partial class NewLL : Page
    {
        const string dbConnectionString = "Data Source=DESKTOP-NBNJR96;Initial Catalog=RTO;Integrated Security=True";
        
        public NewLL()
        {
            this.InitializeComponent();
        }

        private void LLButton_Click(object sender, RoutedEventArgs e)
        {
            
            string Currentdate = DateTime.Now.ToString();
            try
            {

                        SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                        SqlCommand command = new SqlCommand("spInsertLL", sqlConnection);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Name", SqlDbType.VarChar).Value = UsernameTextbox.Text;
                        command.Parameters.Add("@FName", SqlDbType.VarChar).Value = FatherNameTextbox.Text;
                        command.Parameters.Add("@Email", SqlDbType.VarChar).Value = EmailTextbox.Text;
                        command.Parameters.Add("@Identity", SqlDbType.VarChar).Value = IdentificationTextbox.Text;
                        command.Parameters.Add("@address", SqlDbType.VarChar).Value = addressTextbox.Text;
                        command.Parameters.Add("@DOB", SqlDbType.VarChar).Value = DOBTextBox.Text;
                        command.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = PhoneTextbox.Text;
                        command.Parameters.Add("@State", SqlDbType.VarChar).Value = StateTextbox.Text;
                        command.Parameters.Add("@rto", SqlDbType.VarChar).Value = RtoTextbox.Text;
                        command.Parameters.Add("@aadhar", SqlDbType.VarChar).Value = AadharTextBox.Text;
                        command.Parameters.Add("@vehicletype", SqlDbType.VarChar).Value = VehicleCombox.SelectedItem.ToString();
                        command.Parameters.Add("@currentdate", SqlDbType.VarChar).Value = Currentdate;
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        
                SqlCommand cmd = new SqlCommand("select LearnersLicence_No from LL where Customer_id =(select Customer_id from Customer where Customer_aadhar=" + AadharTextBox.Text.Trim() + ")", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    InsertLL custo = new InsertLL
                    {
                        LLno = dr.GetString(0).ToString()
                    };
                    this.Frame.Navigate(typeof(FinalLL), custo);
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
        }
       
    }
}
