using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace User_Registration
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=DESKTOP-04PDE12;Initial Catalog=\"Baza Restoran\";Integrated Security=True";
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertKorisnik1", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Set parameter values
                        command.Parameters.AddWithValue("@id_korisnika", txtIDKorisnika.Text);
                        command.Parameters.AddWithValue("@korisnicko_ime", txtKorisnickoIme.Text);
                        
                        command.Parameters.AddWithValue("@lozinka", txtLozinka.Text);
                        command.Parameters.AddWithValue("@ime", txtImeKorisnika.Text);
                        command.Parameters.AddWithValue("@prezime", txtPrezimeKorisnika.Text);
                        command.Parameters.AddWithValue("@telefon", txtTelefon.Text);
                        command.Parameters.AddWithValue("@email", txtEmail.Text);
                        command.Parameters.AddWithValue("@adresa", txtAdresa.Text);
                        
                        command.Parameters.AddWithValue("@datum_rodjenja", dateTimePicker.Value);
                        command.Parameters.AddWithValue("@zemlja", txtDrzava.Text);
                        command.Parameters.AddWithValue("@grad", txtGrad.Text);

                        command.ExecuteNonQuery();
                }
            }
        }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}