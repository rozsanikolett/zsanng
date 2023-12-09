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
        public void fhteszt(TextBox Tb_fh)
        {
            string str = "username";
            string elvart = "username";
            Bejelentkezes.Tb_fh.Text = str;
            string aktualis = Bejelentkezes.Tb_fh.Text;
            Assert.AreEqual(elvart, aktualis);
        }

        [Test]
        public void jelszoteszt(TextBox Tb_jelszo)
        {
            string str = "12345";
            string elvart = "12345";
            Bejelentkezes.Tb_jelszo.Text = str;
            string aktualis = Bejelentkezes.Tb_jelszo.Text;
            Assert.AreEqual(elvart, Bejelentkezes.Tb_jelszo.Text);
        }

    }
}
