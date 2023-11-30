using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ettermi_rendeles
{
    public partial class bejelentkezes : Form
    {
        public bejelentkezes()
        {
            InitializeComponent();
        }

        Label lb_bej;

        private void Form1_Load(object sender, EventArgs e)
        {

            ClientSize = new Size(238, 210);
            CenterToScreen();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Text = "Bejelentkezés";

            lb_bej = new Label()
            {
                Parent = this,
                Location = new Point(75, 9),
                Font = new Font("Niagara Solid", 16f),
                Text = "Bejelentkezés",
                Size = new Size(124, 30),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
            };


        }
    }
}

