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
    public class InsertReg
    {
        public string RCno { get; set; }
    }

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
            try
            {
                
                
                SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                SqlCommand command = new SqlCommand("spInsertReg", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@Name", SqlDbType.VarChar).Value = UsernameTextBox.Text;
                command.Parameters.Add("@FName", SqlDbType.VarChar).Value = FatherNameTextBox.Text;
                command.Parameters.Add("@Email", SqlDbType.VarChar).Value = EmailTextBox.Text;
                command.Parameters.Add("@Identity", SqlDbType.VarChar).Value = IdentificationTextbox.Text;
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = ApplierAddress.Text;
                command.Parameters.Add("@DOB", SqlDbType.VarChar).Value = DOBTextbox.Text;
                command.Parameters.Add("@Mobile", SqlDbType.VarChar).Value = MobileTextBox.Text;
                command.Parameters.Add("@state", SqlDbType.VarChar).Value = StateTextBox.Text;
                command.Parameters.Add("@rto", SqlDbType.VarChar).Value = RtoTextBox.Text;
                command.Parameters.Add("@aadhar", SqlDbType.VarChar).Value = AadharTextBox.Text;
                command.Parameters.Add("@vehicletype", SqlDbType.VarChar).Value = VehicleCombobox.SelectedItem.ToString();
                command.Parameters.Add("@currentdate", SqlDbType.VarChar).Value = Currentdate;
                command.Parameters.Add("@insissuedate", SqlDbType.VarChar).Value = InsDateTextBox.Text;
                command.Parameters.Add("@inspremium", SqlDbType.Int).Value = Int32.Parse(InsPremiumTextBox.Text);
                command.Parameters.Add("@insamount", SqlDbType.Int).Value = Int32.Parse(InsAmountTextBox.Text);
                command.Parameters.Add("@chasis", SqlDbType.NVarChar).Value = ChasisTextBox.Text;
                command.Parameters.Add("@typeofbody", SqlDbType.VarChar).Value = TypeBodyTextBox.Text;
                command.Parameters.Add("@maker", SqlDbType.VarChar).Value = MakerTextBox.Text;
                command.Parameters.Add("@nocyclinder", SqlDbType.Int).Value = Int32.Parse(CyclinderTextBox.Text);
                command.Parameters.Add("@hp", SqlDbType.Int).Value = Int32.Parse(HpTextBox.Text);
                command.Parameters.Add("@cc", SqlDbType.Int).Value = Int32.Parse(CCTextBox.Text);
                command.Parameters.Add("@mfd", SqlDbType.VarChar).Value = MfdTextBox.Text;

                sqlConnection.Open();
                
                command.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("select Registration_number from Registration where Vehicle_chasis ='" + ChasisTextBox.Text.Trim() + "'", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    InsertReg custo = new InsertReg
                    {
                        RCno = dr.GetString(0).ToString()
                    };
                    this.Frame.Navigate(typeof(FinalRegistration), custo);
                }
                

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                

            }
        }
    }
}
