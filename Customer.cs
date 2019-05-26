using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace App1
{
    public class Customer
    {
        [Key]
        public int Customer_id { get; set; }
        public string Customer_name { get; set; }
        public string Customer_Fathername { get; set; }
        public string Customer_address { get; set; }
        public string Customer_email { get; set; }
        public int Customer_Aadhar { get; set; }
        public int Customer_mobile { get; set; }
        public string Customer_State { get; set; }
        public string Customer_RTO { get; set; }
        public string Customer_qualification { get; set; }
        public string Customer_mark { get; set; }
        public string Customer_gender { get; set; }

        public Customer()
        { }
        public Customer(string name, string Fathername, string email, string address, string state, string RTO, string gender, string mark, string qualification, int mobile, int Aadhar)
        {
            Customer_name = name;
            Customer_Fathername = Fathername;
            Customer_address = address;
            Customer_email = email;
            Customer_Aadhar = Aadhar;
            Customer_mobile = mobile;
            Customer_State = state;
            Customer_RTO = RTO;
            Customer_qualification = qualification;
            Customer_mark = mark;
            Customer_gender = gender;

        }

       
    }
}
