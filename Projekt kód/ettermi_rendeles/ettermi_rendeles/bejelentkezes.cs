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

        Label lb_bej, lb_felhnev, lb_jelszo;
        TextBox tb_fh, tb_jelszo;
        Button btn_bej;


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

            lb_felhnev = new Label()
            {
                Parent = this,
                Location = new Point(5, 62),
                Font = new Font("Niagara Solid", 16f),
                Text = "Felhasználónév",
                Size = new Size(100, 30),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
            };

            lb_jelszo = new Label()
            {
                Parent = this,
                Location = new Point(5, 100),
                Font = new Font("Niagara Solid", 16f),
                Text = "Jelszó",
                Size = new Size(50, 30),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
            };



            tb_fh = new TextBox()
            {
                Parent = this,
                Location = new Point(115, 60),
                Font = new Font("Times", 12f),
                Size = new Size(100, 20),
            };

            tb_jelszo = new TextBox()
            {
                Parent = this,
                Location = new Point(57, 98),
                Font = new Font("Times", 12f),
                PasswordChar = '*',
                Size = new Size(158, 20),
            };


            btn_bej = new Button()
            {
                Parent = this,
                Location = new Point(22, 145),
                Font = new Font("Niagara Solid", 18.5f),
                Size = new Size(193, 40),
                Text = "Bejelentkezés",
            };

            btn_bej.Click += Btn_bej_Click;
            btn_bej.Paint += Btn_bej_Paint;
            this.FormClosing += Bejelentkezes_FormClosing;
        }

        private void Btn_bej_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, btn_bej.ClientRectangle,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset);
        }

        private void Bejelentkezes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Btn_bej_Click(object sender, EventArgs e)
        {

        }


    }
}

