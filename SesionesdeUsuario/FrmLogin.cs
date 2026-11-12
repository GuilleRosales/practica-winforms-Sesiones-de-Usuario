using SesionesdeUsuario.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SesionesdeUsuario
{
    public partial class FrmLogin : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWind, int msg, IntPtr wParam, string lParam);
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            SendMessage(
                txtUsuario.Handle, 
                0x1501,
                IntPtr.Zero,
                "Digita tu Usuario CTM");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Conexion conexion = new Conexion();

            SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Usuario WHERE Usuario=@user AND Clave=@pass",
                conexion.AbrirConexion()
            );

            cmd.Parameters.AddWithValue("@user", txtUsuario.Text);
            cmd.Parameters.AddWithValue("@pass", txtContrasena.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                FrmMenu menu = new FrmMenu();

                menu.usuario = dr["NombreCompleto"].ToString();

                menu.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }

            conexion.CerrarConexion();

        }
    }
}
