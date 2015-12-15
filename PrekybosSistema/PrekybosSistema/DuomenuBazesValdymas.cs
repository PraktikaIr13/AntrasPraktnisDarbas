using System;
using System.Data.SqlClient;

namespace PrekybosSistema
{
    class DuomenuBazesValdymas
    {
        private string connectionString;

        public DuomenuBazesValdymas()
        {
            // Prisijungiame prie duomenu bazes
            this.connectionString = Properties.Settings.Default.SandelysConnectionString;
        }

        /**
            * Duomenu gavimas is isores. SKIRTA REGISTRACIJAI
        */
        public int TiekejoKodas { get; set; }
        public string TiekejoPavadinimas { get; set; }
        public DateTime SutartisPasirasyta { get; set; }
        public DateTime SutartiesPabaiga { get; set; }
        public string ProduktoPavadinimas { get; set; }

        /**
            * Tiekejo registracija
            ****
            Tikrina tik pagal mones koda, reikia prideti ir pagal pavadinima arba palikti tiesiog pagal 
            imones koda kadangi jis negali kartotis
            ****
        */
        public bool TiekejuRegistracija()
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);

            if (TiekejasEgzistuoja())
            {
                return false;
            }
            else
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT Tiekejai VALUES (@tiekejoKodas, @tiekejoPavavadinimas, @sutartiesPradzia, @sutartiesPabaiga)";
                cmd.Parameters.AddWithValue("@tiekejoKodas", this.TiekejoKodas);
                cmd.Parameters.AddWithValue("@tiekejoPavavadinimas", this.TiekejoPavadinimas);
                cmd.Parameters.AddWithValue("@sutartiesPradzia", this.SutartisPasirasyta);
                cmd.Parameters.AddWithValue("@sutartiesPabaiga", this.SutartiesPabaiga);

                cmd.Connection = sqlConnection;
                int rowsAffected = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                if (rowsAffected.Equals(1))
                {
                    return true;
                }
                return false;
            }
        }

        public bool ProduktuRegistracija()
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);

            if (ProduktasEgzistuoja())
            {
                return false;
            }
            else
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT TiekejuProduktai VALUES (@ProduktoPavadinimas)";
                cmd.Parameters.AddWithValue("@ProduktoPavadinimas", this.ProduktoPavadinimas);

                cmd.Connection = sqlConnection;
                int rowsAffected = cmd.ExecuteNonQuery();
                sqlConnection.Close();

                if (rowsAffected.Equals(1))
                {
                    return true;
                }
                return false;
            }
        }

        public bool ProduktasEgzistuoja()
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            sqlConnection.Open();

            SqlCommand cmd = new SqlCommand("SELECT ID FROM TiekejuProduktai WHERE PAVADINIMAS = @Pavadinimas", sqlConnection);
            cmd.Parameters.AddWithValue("@Pavadinimas", this.ProduktoPavadinimas);
            int id = Convert.ToInt32(cmd.ExecuteScalar());
            sqlConnection.Close();
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Patikrina, ar egzistuoja tokiu kodu imone.
        public bool TiekejasEgzistuoja()
        {

            int count = 0;

            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Tiekejai WHERE tiekejo_kodas=@tiekejoKodas", sqlConnection);
            cmd.Parameters.AddWithValue("@tiekejoKodas", this.TiekejoKodas);

            sqlConnection.Open();
            count = (int)cmd.ExecuteScalar();
            sqlConnection.Close();

            if (count >= 1)
                return true;
            else
                return false;
        }

        /**
            * Perduodame Listbox`ui sarasa tiekeju
        */
        public void TiekejuSarasas(TiekejoIsregistravimas data)
        {
            //List<string> tiekejulist = new List<string>();

            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tiekejai", sqlConnection);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();


            while (reader.Read())
            {
                data.listBox1.Items.Add(reader["tiekejo_pavadinimas"].ToString());
            }
            reader.Close();
            sqlConnection.Close();
        }

        /**
            * TIEKEJU ISREGISTRAVIMAS, suteikiame informacija apie tiekeja
        */
        public void TiekejuSarasasIsregistravimui(TiekejoIsregistravimas data)
        {
            data.label4.Text = data.listBox1.Text;

            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tiekejai WHERE tiekejo_pavadinimas LIKE @tiekejo_pavadinimas", sqlConnection);
            cmd.Parameters.Add("@tiekejo_pavadinimas", System.Data.SqlDbType.Text).Value = data.listBox1.Text.ToString();

            sqlConnection.Open();
            SqlDataReader duomenys = cmd.ExecuteReader();
           
            while (duomenys.Read())
            {
                data.label5.Text = duomenys["tiekejo_pavadinimas"].ToString();
                data.label6.Text = duomenys["sutartis_pasirasyta"].ToString();
                data.label7.Text = duomenys["sutartis_pasibaigia"].ToString();
            }

            sqlConnection.Close();
        }

        public void IsregistruotiTiekeja(TiekejoIsregistravimas data)
        {
            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            SqlCommand cmd = new SqlCommand("DELETE FROM Tiekejai WHERE tiekejo_pavadinimas LIKE @tiekejo_pavadinimas", sqlConnection);
            cmd.Parameters.Add("@tiekejo_pavadinimas", System.Data.SqlDbType.Text).Value = data.label5.Text.ToString();

            sqlConnection.Open();
            cmd.ExecuteNonQuery();

            sqlConnection.Close();
        }

    }
}
