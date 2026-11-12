using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
    }
}
