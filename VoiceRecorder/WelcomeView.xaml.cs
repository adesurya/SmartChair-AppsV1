using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.IO;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace VoiceRecorder
{
    /// <summary>
    /// Interaction logic for WelcomeView.xaml
    /// </summary>
    public partial class WelcomeView : UserControl
    {
        public WelcomeView()
        {
            InitializeComponent();
        }

        //private void MenuItem_RekamJejak(object sender, RoutedEventArgs e)
        //{
        //    RekamJejak student = new RekamJejak();
        //    student.ShowDialog();
        //}

        //public void Masuk()
        //{
        //    SqlConnection con = new SqlConnection(@"User id=hostingRecord;Password=123456;Server=ITSME\SQLEXPRESS;Database=hostingRecord");
        //    try
        //    {
        //        con.Open();
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Error with the databsae connection");
        //    }

        //    string qry1 = "Select * from Login where PASS=@PASS and ID=@ID";
        //    SqlCommand com = new SqlCommand(qry1, con);
        //    com.Parameters.AddWithValue("@ID", this.txbox1.Text);
        //    com.Parameters.AddWithValue("@PASS", this.txbox2.Text);
        //    SqlDataReader dr = com.ExecuteReader();
        //    if (dr.HasRows == true)
        //    {
        //        MessageBox.Show("Login Successfull", "Login Information");

        //    }

        //    else
        //    {
        //        MessageBox.Show("Login Failed, Wrong Username and Password", "Warning Login Information");
        //    }

        //}

        //public void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    WelcomeView login = new WelcomeView();

        //    SqlConnection con = new SqlConnection(@"User id=hostingRecord;Password=123456;Server=ITSME\SQLEXPRESS;Database=hostingRecord");
        //    try
        //    {
        //        con.Open();
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Error with the databsae connection");
        //    }

        //    string qry1 = "Select * from Login where PASS=@PASS and ID=@ID";
        //    SqlCommand com = new SqlCommand(qry1, con);
        //    com.Parameters.AddWithValue("@ID", login.txbox1.Text);
        //    com.Parameters.AddWithValue("@PASS", login.txbox2.Text);
        //    SqlDataReader dr = com.ExecuteReader();
        //    if (dr.HasRows == true)
        //    {
        //        MessageBox.Show("Login Successfull", "Login Information");
        //    }

        //    else
        //    {
        //        MessageBox.Show("Login Failed, Wrong Username and Password", "Warning Login Information");
        //    }
        //}
    }
}
