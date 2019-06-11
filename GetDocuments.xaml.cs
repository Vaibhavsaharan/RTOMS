using System;
using System.Data.SqlClient;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public class RC
    {
        public string RCno { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public string Address { get; set; }
        public string state { get; set; }
        public string dateofissue { get; set; }
        public string Chasis { get; set; }
        public string Typeofbody { get; set; }
        public string VehicleType { get; set; }
        public string Maker { get; set; }
        public string Mfd { get; set; }
        public int Cylinder { get; set; }
        public int CC { get; set; }

    }
    public class DL
    {
        public string Name { get; set; }
        public string FName { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string vehicletype { get; set; }
        public string state { get; set; }
        public string DLno { get; set; }
        public string dateofissue { get; set; }

    }
    public class LL
    {
        public string Name { get; set; }
        public string FName { get; set; }
        public string Identity { get; set; }
        public string Address { get; set; }
        public string DOB { get; set; }
        public string vehicletype { get; set; }
        public string state { get; set; }
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
            try
            {

                SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("SELECT dbo.Registration.Registration_number, dbo.Customer.Customer_state,dbo.Customer.Customer_name,dbo.Customer.Customer_fathername, dbo.Customer.Customer_address,dbo.Customer.Customer_vehicle, dbo.Vehicle.Vehicle_maker, dbo.Vehicle.Vehicle_typeofbody, dbo.Vehicle.Vehicle_manufacturedate, dbo.Registration.Vehicle_chasis, dbo.Vehicle.Vehicle_cc, dbo.Registration.Registration_Date from dbo.Customer INNER JOIN dbo.Registration ON dbo.Customer.Customer_id = dbo.Registration.Customer_id INNER JOIN dbo.Vehicle ON dbo.Customer.Customer_id = dbo.Vehicle.Customer_id AND dbo.Registration.Vehicle_chasis = dbo.Vehicle.Vehicle_chasis where dbo.Vehicle.Vehicle_chasis = (select Vehicle_chasis from Registration where Registration_number ='" + GetRCBox.Text.Trim() + "')", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RC inalL = new RC
                    {
                        RCno = dr.GetString(0).ToString(),
                        state = dr.GetString(1).ToString(),
                        Name = dr.GetString(2).ToString(),
                        FName = dr.GetString(3).ToString(),
                        Address = dr.GetString(4).ToString(),
                        VehicleType = dr.GetString(5).ToString(),
                        Maker = dr.GetString(6).ToString(),
                        Typeofbody = dr.GetString(7).ToString(),
                        Mfd = dr.GetString(8).ToString(),
                        Chasis = dr.GetString(9).ToString(),
                        CC = dr.GetInt32(10),
                        dateofissue = dr.GetString(11).ToString()

                    };
                    this.Frame.Navigate(typeof(GetRC), inalL);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
        }

        private void GetDL_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select Customer.Customer_name,Customer.Customer_fathername,Customer.Customer_address,Customer.Customer_DOB,Customer.Customer_vehicle,Customer.Customer_state,DL.Dateofissue from Customer,DL where Customer.Customer_id = DL.Customer_id and Customer.Customer_id = (select Customer_id from DL where DrivingLicence_No='" + GetDLBox.Text.Trim() + "')", sqlConnection);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    DL inalL = new DL
                    {
                        Name = dr.GetString(0).ToString(),
                        FName = dr.GetString(1).ToString(),
                        Address = dr.GetString(2).ToString(),
                        DOB = dr.GetString(3).ToString(),
                        vehicletype = dr.GetString(4).ToString(),
                        state = dr.GetString(5).ToString(),
                        DLno = GetDLBox.Text,
                        dateofissue = dr.GetString(6).ToString()
                    };
                    this.Frame.Navigate(typeof(GetDL), inalL);
                }

            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
            }
        }

        private void GetLL_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SqlConnection sqlConnection = new SqlConnection(dbConnectionString);
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand("select Customer.Customer_name,Customer.Customer_fathername,Customer.Customer_identity,Customer.Customer_address,Customer.Customer_DOB,Customer.Customer_vehicle,Customer.Customer_state,LL.Dateofissue from Customer,LL where Customer.Customer_id = LL.Customer_id and Customer.Customer_id = (select Customer_id from LL where LearnersLicence_No='" + GetLLBox.Text.Trim() + "')", sqlConnection);
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
