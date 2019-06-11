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
using Microsoft.Toolkit.Uwp.UI.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

    public class TestCustomers
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

    /*public class TestClass
    {
        public string teststring1 { get; set; }
        public string teststring2 { get; set; }
    }*/


    public sealed partial class ShowDatabase : Page
    {
        const string dbConnectionString = "Data Source=DESKTOP-NBNJR96;Initial Catalog=RTO;Integrated Security=True";
        public ShowDatabase()
        {
            this.InitializeComponent();
        }

        

        private void ADDData_Click(object sender, RoutedEventArgs e)
        {
            //string dateteststring = datetest.ToString();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                SqlCommand command = new SqlCommand("spInserttest", sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@aad", SqlDbType.VarChar).Value = TestText.Text;
                command.Parameters.Add("@string", SqlDbType.VarChar).Value = (TestText1.Text);
                command.Parameters.Add("@intval", SqlDbType.Int).Value = Int32.Parse(TestText2.Text);
                //command1.Parameters.Add("@Dob", SqlDbType.VarChar).Value = dateteststring;
                //command1.Parameters.Add("@aad", SqlDbType.VarChar).Value = TestText3.Text;
                //ommand1.Parameters.Add("@ide", SqlDbType.VarChar).Value = TestText4.Text;
                sqlConnection.Open();
                command.ExecuteNonQuery();
                //Console.WriteLine("Data added"); 
                /*SqlCommand cmd = new SqlCommand("select Customer_name,Customer_fathername,Customer_email,Customer_identity,Customer_address,Customer_DOB,Customer_mobile,Customer_aadhar,Customer_vehicle from Customer where Customer_id=(select Customer_id from LL where LearnersLicence_No=" + TestText2.Text.Trim() + ")", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TestClass @class = new TestClass
                    {
                        teststring1 = dr.GetString(0).ToString(),
                        teststring2 = dr.GetString(1).ToString()
                        // temp = true;
                    };
                    this.Frame.Navigate(typeof(Test),@class);
                }*/

                // SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                /* sqlConnection.Open();
                 SqlCommand cmd = new SqlCommand("select Customer_name,Customer_fathername,Customer_email,Customer_identity,Customer_address,Customer_DOB,Customer_mobile,Customer_aadhar,Customer_vehicle from Customer where Customer_id =(select Customer_id from LL where LearnersLicence_No=" + TestText2.Text.Trim() + ")", sqlConnection);
                 SqlDataReader dr = cmd.ExecuteReader();
                 while (dr.Read())
                 {
                     TestCustomers customer = new TestCustomers
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
                     this.Frame.Navigate(typeof(Test), customer);
                 }*/

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
        }
    }
}
