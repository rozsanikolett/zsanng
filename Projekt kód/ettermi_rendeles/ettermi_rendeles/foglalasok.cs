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
    public partial class foglalasok : Form
    {
        adatbazis con = new adatbazis();
        private void foglalasok_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            Color sajat = Color.FromArgb(51, 44, 46);


            

            

            negyfo1_fogl.ForeColor = sajat;
            negyfo1_fogl.FlatAppearance.MouseOverBackColor = sajat;
            negyfo1_fogl.FlatAppearance.MouseDownBackColor = sajat;

            negyfo2_fogl.ForeColor = sajat;
            negyfo2_fogl.FlatAppearance.MouseOverBackColor = sajat;
            negyfo2_fogl.FlatAppearance.MouseDownBackColor = sajat;

            negyfo3_fogl.ForeColor = sajat;
            negyfo3_fogl.FlatAppearance.MouseOverBackColor = sajat;
            negyfo3_fogl.FlatAppearance.MouseDownBackColor = sajat;

            negyfo4_fogl.ForeColor = sajat;
            negyfo4_fogl.FlatAppearance.MouseOverBackColor = sajat;
            negyfo4_fogl.FlatAppearance.MouseDownBackColor = sajat;

            ketfo5_fogl.ForeColor = sajat;
            ketfo5_fogl.FlatAppearance.MouseOverBackColor = sajat;
            ketfo5_fogl.FlatAppearance.MouseDownBackColor = sajat;

            ketfo6_fogl.ForeColor = sajat;
            ketfo6_fogl.FlatAppearance.MouseOverBackColor = sajat;
            ketfo6_fogl.FlatAppearance.MouseDownBackColor = sajat;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;



            dg_foglalasok.DataSource = con.tablazatot_ad("SELECT id, asztal_id, nev, datum, kezdo_ido, vege_ido FROM foglalas").Tables[0];
            dg_foglalasok.Columns["id"].HeaderText = "Foglalás ID";
            dg_foglalasok.Columns["asztal_id"].HeaderText = "Asztal ID";
            dg_foglalasok.Columns["nev"].HeaderText = "Név";
            dg_foglalasok.Columns["datum"].HeaderText = "Dátum";
            dg_foglalasok.Columns["kezdo_ido"].HeaderText = "Kezdő időpont";
            dg_foglalasok.Columns["vege_ido"].HeaderText = "Vége időpont";
            dg_foglalasok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg_foglalasok.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg_foglalasok.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_foglalasok.Refresh();

            sorselect();

            cb_asztal_fogl.DropDownStyle = ComboBoxStyle.DropDownList;
            cb_asztal_fogl.DataSource = con.listat_ad("SELECT id FROM asztalok");
        }

        private void bt_jovahagy_Click(object sender, EventArgs e)
        {
            string kezdido;
            string vegeido;

            string datum;

            datum = naptar_fogl.SelectionStart.Date.ToShortDateString();

            string[] D = datum.Split('.');
            datum = D[0].Trim() + "-" + D[1].Trim() + "-" + D[2].Trim();
            kezdido = "" + cb_ora.Text + ":" + cb_perc.Text;
            vegeido = "" + cb_oraig.Text + ":" + cb_percig.Text;



            if (Convert.ToInt32(cb_ora.Text + cb_perc.Text) >= Convert.ToInt32(cb_oraig.Text + cb_percig.Text))
            {
                MessageBox.Show("A kezdő időpont nem lehet később mint a foglalás vége!");
            }
            else if (naptar_fogl.SelectionStart >= naptar_fogl.TodayDate)
            {
                // ütközés...
                string sql = "SELECT id " +
                           "FROM foglalas " +
                           "WHERE asztal_id = '" + cb_asztal_fogl.Text + "' AND datum = '" + datum + "' AND " +
                           "NOT('" + vegeido + "' < kezdo_ido OR vege_ido < '" + kezdido + "')";
                var ell = con.rekord(sql);
                if (ell == null)
                {
                    con.feltolt("INSERT INTO foglalas (asztal_id, nev, datum, kezdo_ido,vege_ido) VALUES ('" + cb_asztal_fogl.Text + "', '" + tb_nev_fogl.Text + "', '" + datum + "','" + kezdido + "','" + vegeido + "');");
                    MessageBox.Show("Sikeres foglalás!");
                    dg_frissit();
                }
                else
                {
                    MessageBox.Show("Ütközés!");
                }
            }
            else
            {
                MessageBox.Show("Visszamenőleg nem lehet foglalást felvenni!");
            }

            sorselect();
        }

        private void dg_frissit()
        {

            dg_foglalasok.DataSource = con.tablazatot_ad("SELECT id, asztal_id, nev, datum, kezdo_ido, vege_ido FROM foglalas").Tables[0];
            dg_foglalasok.Columns["id"].HeaderText = "Foglalás ID";
            dg_foglalasok.Columns["asztal_id"].HeaderText = "Asztal ID";
            dg_foglalasok.Columns["nev"].HeaderText = "Név";
            dg_foglalasok.Columns["datum"].HeaderText = "Dátum";
            dg_foglalasok.Columns["kezdo_ido"].HeaderText = "Kezdő időpont";
            dg_foglalasok.Columns["vege_ido"].HeaderText = "Vége időpont";
            dg_foglalasok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg_foglalasok.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dg_foglalasok.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dg_foglalasok.Refresh();
        }

        private void bt_torles_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_foglalasok.SelectedRows.Count != 0)
                {
                    string id = dg_foglalasok.Rows[0].Cells[0].Value.ToString();
                    con.torles("DELETE FROM foglalas WHERE id = " + id + "");

                    int rowIndex_a1 = dg_foglalasok.CurrentCell.RowIndex;
                    dg_foglalasok.Rows.RemoveAt(rowIndex_a1);
                    dg_foglalasok.ClearSelection();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Az asztalhoz rendelés tartozik. Mielőtt törölné a foglalást, ürítse ki a rendeléseket!");
            }
        }

        private void negyfo1_fogl_Click(object sender, EventArgs e)
        {
            string kijeloltnap = naptar_fogl.SelectionStart.Date.ToShortDateString();
            dg_foglalasok.ClearSelection();
            dg_foglalasok.DataSource = con.tablazatot_ad("SELECT id, asztal_id,nev,datum,kezdo_ido,vege_ido FROM foglalas WHERE asztal_id = 1").Tables[0];
            sorselect();
        }

        private void negyfo2_fogl_Click(object sender, EventArgs e)
        {
            string kijeloltnap = naptar_fogl.SelectionStart.Date.ToShortDateString();
            dg_foglalasok.ClearSelection();
            dg_foglalasok.DataSource = con.tablazatot_ad("SELECT id, asztal_id, nev, datum, kezdo_ido, vege_ido FROM foglalas WHERE asztal_id = 2").Tables[0];
            sorselect();
        }

        private void negyfo3_fogl_Click(object sender, EventArgs e)
        {
            string kijeloltnap = naptar_fogl.SelectionStart.Date.ToShortDateString();
            dg_foglalasok.ClearSelection();
            dg_foglalasok.DataSource = con.tablazatot_ad("SELECT id, asztal_id, nev, datum, kezdo_ido, vege_ido FROM foglalas WHERE asztal_id = 3").Tables[0];
            sorselect();
        }

        private void negyfo4_fogl_Click(object sender, EventArgs e)
        {
            string kijeloltnap = naptar_fogl.SelectionStart.Date.ToShortDateString();
            dg_foglalasok.ClearSelection();
            dg_foglalasok.DataSource = con.tablazatot_ad("SELECT id, asztal_id, nev, datum, kezdo_ido, vege_ido FROM foglalas WHERE asztal_id = 4").Tables[0];
            sorselect();
        }

        private void ketfo5_fogl_Click(object sender, EventArgs e)
        {
            string kijeloltnap = naptar_fogl.SelectionStart.Date.ToShortDateString();
            dg_foglalasok.ClearSelection();
            dg_foglalasok.DataSource = con.tablazatot_ad("SELECT id, asztal_id, nev, datum, kezdo_ido, vege_ido FROM foglalas WHERE asztal_id = 5").Tables[0];
            sorselect();
        }

        private void ketfo6_fogl_Click(object sender, EventArgs e)
        {
            string kijeloltnap = naptar_fogl.SelectionStart.Date.ToShortDateString();
            dg_foglalasok.ClearSelection();
            dg_foglalasok.DataSource = con.tablazatot_ad("SELECT id, asztal_id, nev, datum, kezdo_ido, vege_ido FROM foglalas WHERE asztal_id = 6").Tables[0];
            sorselect();
        }

        private void fogl_osszes_Click(object sender, EventArgs e)
        {

            dg_frissit();
        }

        private void sorselect()
        {
            try { dg_foglalasok.Rows[0].Selected = false; }
            catch { }
        }

        private void fogl_osszes_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, fogl_osszes.ClientRectangle,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset);
        }

        private void bt_torles_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, bt_torles.ClientRectangle,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset);
        }

        private void bt_jovahagy_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, bt_jovahagy.ClientRectangle,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 2, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 4, ButtonBorderStyle.Outset);
        }
    }

    


    
}
