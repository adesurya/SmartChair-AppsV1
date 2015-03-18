using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using NAudio.Wave;
using System.Windows.Input;
using VoiceRecorder.Core;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;

namespace VoiceRecorder
{
    class LoginFirstViewModel
    {
        
        public const string ViewName = "LoginFirst";
                private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"User id=hostingRecord;Password=123456;Server=ITSME\SQLEXPRESS;Database=hostingRecord");
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Error with the databsae connection");
                    
            }
            LoginFirst frm = new LoginFirst();
            string qry1 = "Select * from Login where PASS=@PASS and ID=@ID";
            SqlCommand com = new SqlCommand(qry1, con);
            com.Parameters.AddWithValue("@ID", frm.textbox1login.Text);
            //com.Parameters.AddWithValue("@PASS", frm.textbo.Text);
            LoginFirst ade = new LoginFirst();
            ade.Show();
                    SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows == true)
                {
                    MessageBox.Show("Login Successfull", "Login Information");
                }
            else 
                {
                    MessageBox.Show("Login Failed, Wrong Username and Password", "Warning Login Information");
                }
            }

        }
    }

       




