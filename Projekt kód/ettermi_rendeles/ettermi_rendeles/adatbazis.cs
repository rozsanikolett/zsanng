using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient; //Mysql gyűjtemény használata
using System.Data; //dataset használata

namespace ettermi_rendeles
{
    class adatbazis
    {
		//az alábbi kapcsolatot definiáló string
		string kapcs_string = "datasource=http://185.51.188.57/phpMyAdm;database=etterem_rn;username=nohawebc_zsanng;password=ZsAnNg2023!;charset=utf8";
		// DB kapcsolat változója:
		public MySqlConnection kapcs_mysql;
        //adapter, a dataset feltöltéséhez, ezzel fogjuk a datagridview forrását átadni
        MySqlDataAdapter adapter_mysql = new MySqlDataAdapter();
		MySqlCommand cmd = new MySqlCommand();

		public bool megnyitas() //ha megtudom nyitni true, ha nem false, mielőtt bármit operálok, MEG KELL NYITNI a Mysql kapcsolatot
        {
            try
            {
                kapcs_mysql = new MySqlConnection(kapcs_string);
                kapcs_mysql.Open();
                return true;
            }
            catch 
            {

                return false; // nem sikerül az adatbázis bezárása
            }
        }

        public string[] rekord(string LKS)
        {
            bezaras();
            if (megnyitas())
            {
                MySqlCommand lekerdezes = new MySqlCommand(LKS, kapcs_mysql);
                MySqlDataReader olvaso = lekerdezes.ExecuteReader();
                if (olvaso.HasRows)
                {
                    olvaso.Read();
                    string[] sw = new string[olvaso.FieldCount];
                    for (int i = 0; i < olvaso.FieldCount; i++)
                    {
                        sw[i] = olvaso[i].ToString();
                    }
                    return sw;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool bezaras()
        {
            try
            {
                kapcs_mysql.Close();
                return true;
            }
            catch 
            {

                return false;
            }
        }

        public string szamot_ad(string LKS) //"a" kérdés válaszánál fogjuk hazsnálni
        {
            bezaras(); // ha nyitva marad a DB kapcsolat, akkor ebaszos lesz az újra megnyitása
            if (megnyitas()) //ha meg tudjuk nyitni, akkor..
            {
                //létrehozok egy parancsváltozót, aminek a paramétere a lekérdezés(stringje) és a mysql kapcsolatot reprezentáló változó
                MySqlCommand lekerdezes = new MySqlCommand(LKS, kapcs_mysql);
                /*futtatjuk a "lekerdezes" parancsfájlban rögzített sql parancsot, az ExecuteScalar-t azért akalmazzuk mert ennek a 
                 lekérdezésnek EGY SZÁM az eredménye*/              
                 
                return lekerdezes.ExecuteScalar().ToString();
            }
            return "hiba"; //ha nem sikerül a megnyitás...
        }

        public List<string> listat_ad(string LKS)
        {
            bezaras();
            List<string> kategoria = new List<string>(); // ebben küldjük vissza a listát
            if (megnyitas())
            {
                MySqlCommand lekerdezes = new MySqlCommand(LKS, kapcs_mysql);
                //az olvaso változóba fogom berakni - SORONKÉNT (REKORDONKÉNT) - a lekérdezés eredményét
                MySqlDataReader olvaso = lekerdezes.ExecuteReader();
                while (olvaso.Read())
                {
                    kategoria.Add(olvaso[0].ToString()); //indexelni kell az "olvaso"-t, az indexek a MEZŐKRE vonatkoznak, nem a rekordokra!
                }
            }
            return kategoria;            
        }


        public DataSet tablazatot_ad(string LKS)
        {
            bezaras();
            DataSet adatok = new DataSet(); // ebben küldjük vissza az adatokat
            if (megnyitas())
            {
                adapter_mysql.SelectCommand = new MySqlCommand(LKS, kapcs_mysql);
                adapter_mysql.Fill(adatok); // az adapteren keresztül feltöltjük a datasetet
            }
            return adatok;
        }
        public bool torles(string LKS)
        {
            bezaras();
            if (megnyitas())
            {
                MySqlCommand lekerdezes = new MySqlCommand(LKS, kapcs_mysql);
                lekerdezes.ExecuteNonQuery(); //DLL és DML parancsok futtatásához ezt használjuk
                return true;
            }
            return false;
        }


        public void feltolt(string LKS)
        {
            bezaras();
            if (megnyitas())
            {
                MySqlCommand feltoltes = new MySqlCommand(LKS, kapcs_mysql);
                feltoltes.ExecuteNonQuery();
            }
        }
    }
}
