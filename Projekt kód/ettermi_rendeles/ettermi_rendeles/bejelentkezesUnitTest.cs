using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ettermi_rendeles
{
    internal class bejelentkezesUnitTest : bejelentkezes
    {
        bejelentkezes Bejelentkezes = new bejelentkezes();

        [Test]
        public void felhTeszt(TextBox Tb_fh)
        {
            string str = "username";
            string elvart = "username";
            Bejelentkezes.Tb_fh.Text = str;
            string aktualis = Bejelentkezes.Tb_fh.Text;
            Assert.AreEqual(elvart, aktualis);
        }

        [Test]
        public void jelszoTeszt(TextBox Tb_jelszo)
        {
            string str = "12345";
            string elvart = "12345";
            Bejelentkezes.Tb_jelszo.Text = str;
            string aktualis = Bejelentkezes.Tb_jelszo.Text;
            Assert.AreEqual(elvart, Bejelentkezes.Tb_jelszo.Text);
        }

        [Test]
        public void bejelLabelTeszt(Label Lb_bej)
        {
            string str = "Bejelentkezés";
            string elvart = "Bejelentkezés";
            Bejelentkezes.Lb_bej.Text = str;
            string aktualis = Bejelentkezes.Lb_bej.Text;
            Assert.AreEqual(elvart, aktualis);
        }

        [Test]
        public void felhLabelTeszt(Label Lb_felhnev)
        {
            string str = "Felhasználó";
            string elvart = "Felhasználó";
            Bejelentkezes.Lb_felhnev.Text = str;
            string aktualis = Bejelentkezes.Lb_felhnev.Text;
            Assert.AreEqual(elvart, aktualis);
        }

        [Test]
        public void jelszoLabelTeszt(Label Lb_jelszo)
        {
            string str = "Jelszó";
            string elvart = "Jelszó";
            Bejelentkezes.Lb_jelszo.Text = str;
            string aktualis = Bejelentkezes.Lb_jelszo.Text;
            Assert.AreEqual(elvart, aktualis);
        }
    }
}
