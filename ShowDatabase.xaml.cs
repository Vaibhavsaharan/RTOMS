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
                SqlCommand command1 = new SqlCommand("spInserttest", sqlConnection);
                command1.CommandType = CommandType.StoredProcedure;
                //command1.Parameters.Add("@Name", SqlDbType.VarChar).Value = TestText.Text;
                //command1.Parameters.Add("@FN", SqlDbType.VarChar).Value = TestText1.Text;
                //command1.Parameters.Add("@rN", SqlDbType.Int).Value = Int32.Parse(TestText2.Text);
                //command1.Parameters.Add("@Dob", SqlDbType.VarChar).Value = dateteststring;
                command1.Parameters.Add("@aad", SqlDbType.VarChar).Value = TestText3.Text;
                command1.Parameters.Add("@ide", SqlDbType.VarChar).Value = TestText4.Text;
                sqlConnection.Open();
                command1.ExecuteNonQuery();
                Console.WriteLine("Data added");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
        }
    }
}
