using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Threading;


namespace ettermi_rendeles
{
    public partial class pincer_fooldal : Form
    {
        public pincer_fooldal()
        {
            InitializeComponent();
        }

        adatbazis con = new adatbazis();
        foglalasok fogl = new foglalasok();

        public int osszeg_a1 = 0, osszeg_a2 = 0, osszeg_a3 = 0, osszeg_a4 = 0, osszeg_a5 = 0, osszeg_a6 = 0;



        private void pincer_fooldal_Load(object sender, EventArgs e)
        {
            #region beállítások

            CenterToScreen();
            Color sajat = Color.FromArgb(51, 44, 46);

            negyfo1.ForeColor = sajat;
            negyfo1.FlatAppearance.MouseOverBackColor = sajat;
            negyfo1.FlatAppearance.MouseDownBackColor = sajat;

            negyfo2.ForeColor = sajat;
            negyfo2.FlatAppearance.MouseOverBackColor = sajat;
            negyfo2.FlatAppearance.MouseDownBackColor = sajat;

            negyfo3.ForeColor = sajat;
            negyfo3.FlatAppearance.MouseOverBackColor = sajat;
            negyfo3.FlatAppearance.MouseDownBackColor = sajat;

            negyfo4.ForeColor = sajat;
            negyfo4.FlatAppearance.MouseOverBackColor = sajat;
            negyfo4.FlatAppearance.MouseDownBackColor = sajat;

            ketfo5.ForeColor = sajat;
            ketfo5.FlatAppearance.MouseOverBackColor = sajat;
            ketfo5.FlatAppearance.MouseDownBackColor = sajat;

            ketfo6.ForeColor = sajat;
            ketfo6.FlatAppearance.MouseOverBackColor = sajat;
            ketfo6.FlatAppearance.MouseDownBackColor = sajat;

            BackColor = sajat;

            fizetve_a1.Parent = this;
            fizetve_a2.Parent = this;
            fizetve_a3.Parent = this;
            fizetve_a4.Parent = this;
            fizetve_a5.Parent = this;
            fizetve_a6.Parent = this;




            torles_a1.Parent = panel_a1;
            torles_a2.Parent = panel_a2;
            torles_a3.Parent = panel_a3;
            torles_a4.Parent = panel_a4;
            torles_a5.Parent = panel_a5;
            torles_a6.Parent = panel_a6;

            panel_a1.Parent = this;
            panel_a2.Parent = this;
            panel_a3.Parent = this;
            panel_a4.Parent = this;
            panel_a5.Parent = this;
            panel_a6.Parent = this;


            alappanel1.BackColor = sajat;

            panel_a1.Hide();
            panel_a2.Hide();
            panel_a3.Hide();
            panel_a4.Hide();
            panel_a5.Hide();
            panel_a6.Hide();

            szamla_a1.MultiSelect = false;
            szamla_a2.MultiSelect = false;
            szamla_a3.MultiSelect = false;
            szamla_a4.MultiSelect = false;
            szamla_a5.MultiSelect = false;
            szamla_a6.MultiSelect = false;

            szamla_a1.AllowUserToAddRows = false;
            szamla_a2.AllowUserToAddRows = false;
            szamla_a3.AllowUserToAddRows = false;
            szamla_a4.AllowUserToAddRows = false;
            szamla_a5.AllowUserToAddRows = false;
            szamla_a6.AllowUserToAddRows = false;

            szamla_a1.ReadOnly = true;
            szamla_a2.ReadOnly = true;
            szamla_a3.ReadOnly = true;
            szamla_a4.ReadOnly = true;
            szamla_a5.ReadOnly = true;
            szamla_a6.ReadOnly = true;

            szamla_a1.AllowUserToDeleteRows = false;
            szamla_a2.AllowUserToDeleteRows = false;
            szamla_a3.AllowUserToDeleteRows = false;
            szamla_a4.AllowUserToDeleteRows = false;
            szamla_a5.AllowUserToDeleteRows = false;
            szamla_a6.AllowUserToDeleteRows = false;

            szamla_a1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            szamla_a2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            szamla_a3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            szamla_a4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            szamla_a5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            szamla_a6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            torles_a2.Click += Torles_a2_Click;
            torles_a3.Click += Torles_a3_Click;
            torles_a4.Click += Torles_a4_Click;
            torles_a5.Click += Torles_a5_Click;
            torles_a6.Click += Torles_a6_Click;

            tb_menny_a1.KeyPress += Tb_menny_a1_KeyPress;
            tb_menny_a2.KeyPress += Tb_menny_a2_KeyPress;
            tb_menny_a3.KeyPress += Tb_menny_a3_KeyPress;
            tb_menny_a4.KeyPress += Tb_menny_a4_KeyPress;
            tb_menny_a5.KeyPress += Tb_menny_a5_KeyPress;
            tb_menny_a6.KeyPress += Tb_menny_a6_KeyPress;

            foglalasok.Paint += Foglalasok_Paint;
            kijelentkezes.Paint += Kijelentkezes_Paint;

            #endregion

            this.FormClosed += Pincer_fooldal_FormClosed;

            #region asztalok combobox
            // -------------------------1-es asztal-----------------------------------

            cb_tipus_a1.DataSource = con.listat_ad("SELECT nev FROM tipus");
            cb_tipus_a1.SelectedIndex = -1;
            cb_tipus_a1.SelectedIndexChanged += Cb_tipus_a1_SelectedIndexChanged;
            cb_kat_a1.SelectedIndexChanged += Cb_kat_a1_SelectedIndexChanged;
            cb_tetel_a1.SelectedIndexChanged += Cb_tetel_a1_SelectedIndexChanged;

            //------------------------------------------------------------------------

            //--------------------------2-es asztal-----------------------------------

            cb_tipus_a2.DataSource = con.listat_ad("SELECT nev FROM tipus");
            cb_tipus_a2.SelectedIndex = -1;
            cb_tipus_a2.SelectedIndexChanged += Cb_tipus_a2_SelectedIndexChanged;
            cb_kat_a2.SelectedIndexChanged += Cb_kat_a2_SelectedIndexChanged;
            cb_tetel_a2.SelectedIndexChanged += Cb_tetel_a2_SelectedIndexChanged;

            //------------------------------------------------------------------------

            //--------------------------3-as asztal-----------------------------------

            cb_tipus_a3.DataSource = con.listat_ad("SELECT nev FROM tipus");
            cb_tipus_a3.SelectedIndex = -1;
            cb_tipus_a3.SelectedIndexChanged += Cb_tipus_a3_SelectedIndexChanged;
            cb_kat_a3.SelectedIndexChanged += Cb_kat_a3_SelectedIndexChanged;
            cb_tetel_a3.SelectedIndexChanged += Cb_tetel_a3_SelectedIndexChanged;

            //------------------------------------------------------------------------

            //--------------------------4-es asztal-----------------------------------

            cb_tipus_a4.DataSource = con.listat_ad("SELECT nev FROM tipus");
            cb_tipus_a4.SelectedIndex = -1;
            cb_tipus_a4.SelectedIndexChanged += Cb_tipus_a4_SelectedIndexChanged;
            cb_kat_a4.SelectedIndexChanged += Cb_kat_a4_SelectedIndexChanged;
            cb_tetel_a4.SelectedIndexChanged += Cb_tetel_a4_SelectedIndexChanged;

            //------------------------------------------------------------------------

            //--------------------------5-ös asztal-----------------------------------

            cb_tipus_a5.DataSource = con.listat_ad("SELECT nev FROM tipus");
            cb_tipus_a5.SelectedIndex = -1;
            cb_tipus_a5.SelectedIndexChanged += Cb_tipus_a5_SelectedIndexChanged;
            cb_kat_a5.SelectedIndexChanged += Cb_kat_a5_SelectedIndexChanged;
            cb_tetel_a5.SelectedIndexChanged += Cb_tetel_a5_SelectedIndexChanged;

            //-------------------------------------------------------------------------

            //--------------------------6-os asztal------------------------------------

            cb_tipus_a6.DataSource = con.listat_ad("SELECT nev FROM tipus");
            cb_tipus_a6.SelectedIndex = -1;
            cb_tipus_a6.SelectedIndexChanged += Cb_tipus_a6_SelectedIndexChanged;
            cb_kat_a6.SelectedIndexChanged += Cb_kat_a6_SelectedIndexChanged;
            cb_tetel_a6.SelectedIndexChanged += Cb_tetel_a6_SelectedIndexChanged;

            //-------------------------------------------------------------------------

            #endregion

        }

        private void Kijelentkezes_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, kijelentkezes.ClientRectangle,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset);
        }

        private void Foglalasok_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, foglalasok.ClientRectangle,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset);
        }

        private void Pincer_fooldal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void foglalasok_Click(object sender, EventArgs e)
        {
            fogl.ShowDialog();
        }

        private void kijelentkezes_Click(object sender, EventArgs e)
        {
            Hide();
            bejelentkezes login = new bejelentkezes();
            login.Show();
        }

        #region asztalok

        //-------------------6-os asztal-------------------------------------------------------------------------------------------------------------------------------------------


        private void Cb_tetel_a6_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_mertek_a6.DataSource = con.listat_ad("SELECT nev FROM mertekegyseg WHERE id = (SELECT mertek_id FROM tetelek WHERE nev = '" + cb_tetel_a6.Text + "')");
        }

        private void Cb_kat_a6_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_tetel_a6.DataSource = con.listat_ad("SELECT nev FROM tetelek WHERE kategoria_id = (SELECT id FROM kategoria WHERE kat_nev = '" + cb_kat_a6.Text + "')");
        }

        private void Cb_tipus_a6_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_kat_a6.DataSource = con.listat_ad("SELECT kat_nev FROM kategoria WHERE tipus_id = (SELECT id FROM tipus WHERE nev = '" + cb_tipus_a6.Text + "')");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------5-ös asztal-------------------------------------------------------------------------------------------------------------------------------------------

        private void Cb_tetel_a5_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_mertek_a5.DataSource = con.listat_ad("SELECT nev FROM mertekegyseg WHERE id = (SELECT mertek_id FROM tetelek WHERE nev = '" + cb_tetel_a5.Text + "')");
        }

        private void Cb_kat_a5_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_tetel_a5.DataSource = con.listat_ad("SELECT nev FROM tetelek WHERE kategoria_id = (SELECT id FROM kategoria WHERE kat_nev = '" + cb_kat_a5.Text + "')");
        }

        private void Cb_tipus_a5_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_kat_a5.DataSource = con.listat_ad("SELECT kat_nev FROM kategoria WHERE tipus_id = (SELECT id FROM tipus WHERE nev = '" + cb_tipus_a5.Text + "')");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------4-es asztal-------------------------------------------------------------------------------------------------------------------------------------------

        private void Cb_tetel_a4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_mertek_a4.DataSource = con.listat_ad("SELECT nev FROM mertekegyseg WHERE id = (SELECT mertek_id FROM tetelek WHERE nev = '" + cb_tetel_a4.Text + "')");
        }

        private void Cb_kat_a4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_tetel_a4.DataSource = con.listat_ad("SELECT nev FROM tetelek WHERE kategoria_id = (SELECT id FROM kategoria WHERE kat_nev = '" + cb_kat_a4.Text + "')");
        }

        private void Cb_tipus_a4_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_kat_a4.DataSource = con.listat_ad("SELECT kat_nev FROM kategoria WHERE tipus_id = (SELECT id FROM tipus WHERE nev = '" + cb_tipus_a4.Text + "')");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------3-as asztal--------------------------------------------------------------------------------------------------------------------------------------------

        private void Cb_tetel_a3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_mertek_a3.DataSource = con.listat_ad("SELECT nev FROM mertekegyseg WHERE id = (SELECT mertek_id FROM tetelek WHERE nev = '" + cb_tetel_a3.Text + "')");
        }

        private void Cb_kat_a3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_tetel_a3.DataSource = con.listat_ad("SELECT nev FROM tetelek WHERE kategoria_id = (SELECT id FROM kategoria WHERE kat_nev = '" + cb_kat_a3.Text + "')");
        }

        private void Cb_tipus_a3_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_kat_a3.DataSource = con.listat_ad("SELECT kat_nev FROM kategoria WHERE tipus_id = (SELECT id FROM tipus WHERE nev = '" + cb_tipus_a3.Text + "')");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------


        //-------------------2-es asztal--------------------------------------------------------------------------------------------------------------------------------------------

        private void Cb_tetel_a2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_mertek_a2.DataSource = con.listat_ad("SELECT nev FROM mertekegyseg WHERE id = (SELECT mertek_id FROM tetelek WHERE nev = '" + cb_tetel_a2.Text + "')");
        }

        private void Cb_kat_a2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_tetel_a2.DataSource = con.listat_ad("SELECT nev FROM tetelek WHERE kategoria_id = (SELECT id FROM kategoria WHERE kat_nev = '" + cb_kat_a2.Text + "')");
        }

        private void Cb_tipus_a2_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_kat_a2.DataSource = con.listat_ad("SELECT kat_nev FROM kategoria WHERE tipus_id = (SELECT id FROM tipus WHERE nev = '" + cb_tipus_a2.Text + "')");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------



        //-------------------1-es asztal--------------------------------------------------------------------------------------------------------------------------------------------

        private void Cb_tetel_a1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_mertek_a1.DataSource = con.listat_ad("SELECT nev FROM mertekegyseg WHERE id = (SELECT mertek_id FROM tetelek WHERE nev = '" + cb_tetel_a1.Text + "')");
        }

        private void Cb_kat_a1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_tetel_a1.DataSource = con.listat_ad("SELECT nev FROM tetelek WHERE kategoria_id = (SELECT id FROM kategoria WHERE kat_nev = '" + cb_kat_a1.Text + "')");
        }

        private void Cb_tipus_a1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_kat_a1.DataSource = con.listat_ad("SELECT kat_nev FROM kategoria WHERE tipus_id = (SELECT id FROM tipus WHERE nev = '" + cb_tipus_a1.Text + "')");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        #endregion

        #region asztalgombok

        private void negyfo1_Click(object sender, EventArgs e)
        {

            fizetve_a1.Visible = true;
            fizetve_a2.Visible = false;
            fizetve_a3.Visible = false;
            fizetve_a4.Visible = false;
            fizetve_a5.Visible = false;
            fizetve_a6.Visible = false;
            panel_a2.Hide();
            panel_a3.Hide();
            panel_a4.Hide();
            panel_a5.Hide();
            panel_a6.Hide();
            panel_a1.Show();

        }

        private void negyfo2_Click(object sender, EventArgs e)
        {

            panel_a1.Hide();
            panel_a3.Hide();
            panel_a4.Hide();
            panel_a5.Hide();
            panel_a6.Hide();
            panel_a2.Show();
            fizetve_a1.Visible = false;
            fizetve_a2.Visible = true;
            fizetve_a3.Visible = false;
            fizetve_a4.Visible = false;
            fizetve_a5.Visible = false;
            fizetve_a6.Visible = false;
        }

        private void negyfo3_Click(object sender, EventArgs e)
        {

            panel_a1.Hide();
            panel_a2.Hide();
            panel_a4.Hide();
            panel_a5.Hide();
            panel_a6.Hide();
            panel_a3.Show();
            fizetve_a1.Visible = false;
            fizetve_a2.Visible = false;
            fizetve_a3.Visible = true;
            fizetve_a4.Visible = false;
            fizetve_a5.Visible = false;
            fizetve_a6.Visible = false;
        }

        private void negyfo4_Click(object sender, EventArgs e)
        {

            panel_a1.Hide();
            panel_a2.Hide();
            panel_a3.Hide();
            panel_a5.Hide();
            panel_a6.Hide();
            panel_a4.Show();
            fizetve_a1.Visible = false;
            fizetve_a2.Visible = false;
            fizetve_a3.Visible = false;
            fizetve_a4.Visible = true;
            fizetve_a5.Visible = false;
            fizetve_a6.Visible = false;
        }

        private void ketfo5_Click(object sender, EventArgs e)
        {

            panel_a1.Hide();
            panel_a2.Hide();
            panel_a3.Hide();
            panel_a4.Hide();
            panel_a6.Hide();
            panel_a5.Show();
            fizetve_a1.Visible = false;
            fizetve_a2.Visible = false;
            fizetve_a3.Visible = false;
            fizetve_a4.Visible = false;
            fizetve_a5.Visible = true;
            fizetve_a6.Visible = false;

        }

        private void ketfo6_Click(object sender, EventArgs e)
        {

            panel_a1.Hide();
            panel_a2.Hide();
            panel_a3.Hide();
            panel_a4.Hide();
            panel_a5.Hide();
            panel_a6.Show();
            fizetve_a1.Visible = false;
            fizetve_a2.Visible = false;
            fizetve_a3.Visible = false;
            fizetve_a4.Visible = false;
            fizetve_a5.Visible = false;
            fizetve_a6.Visible = true;
        }
        #endregion

    }
}
