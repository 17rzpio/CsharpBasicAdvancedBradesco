﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BancoDeDados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = Properties.Settings.Default.CST;
            try
            {
                con.Open();
                SqlCommand Cmn = new SqlCommand();
                Cmn.CommandText = "SELECT * FROM tb_clientes";
                Cmn.CommandType = CommandType.Text;
                Cmn.Connection = con;
                SqlDataReader DR;
                DR = Cmn.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(DR);
                dataGridView1.DataSource = dt;
                dataGridView1.Refresh();
                con.Close();
                MessageBox.Show("a conexao foi realizada");

            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Falha na conexao{0}", ex.Message));
            }
            
        }

        
    }
}
