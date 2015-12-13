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
            this.connectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Audrius\documents\visual studio 2015\PrekybosSistema\PrekybosSistema\PrekybosSistema\sandelys.mdf; Integrated Security = True";
        }

        /**
            * Duomenu gavimas is isores. SKIRTA REGISTRACIJAI
        */
        public int tiekejoKodas { get; set; }
        public string tiekejoPavadinimas { get; set; }
        public DateTime sutartisPasirasyta { get; set; }
        public DateTime sutartiesPabaiga { get; set; }

        /**
            * Tiekejo registracija
        */
        public bool tiekejuRegistracija()
        {
            int test = 0;

                        SqlConnection sqlConnection = new SqlConnection(this.connectionString);

                        SqlCommand cmd = new SqlCommand();
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.CommandText = "INSERT Tiekejai VALUES (@tiekejoKodas, @tiekejoPavavadinimas, @sutartiesPradzia, @sutartiesPabaiga)";
                            cmd.Parameters.AddWithValue("@tiekejoKodas", this.tiekejoKodas);
                            cmd.Parameters.AddWithValue("@tiekejoPavavadinimas", this.tiekejoPavadinimas);
                            cmd.Parameters.AddWithValue("@sutartiesPradzia", this.sutartisPasirasyta);
                            cmd.Parameters.AddWithValue("@sutartiesPabaiga", this.sutartiesPabaiga);
            
                            cmd.Connection = sqlConnection;

                        sqlConnection.Open();
                        test = cmd.ExecuteNonQuery();
                        sqlConnection.Close();
            if (test.Equals(1))
                return true;
            else
                return false;
        }
        // Patikrina, ar egzistuoja tokiu kodu imone.
        public bool tiekejasEgzistuoja()
        {

            int count = 0;

            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Tiekejai WHERE tiekejo_kodas=@tiekejoKodas", sqlConnection);
            cmd.Parameters.AddWithValue("@tiekejoKodas", this.tiekejoKodas);

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
        public void tiekejuSarasas(TiekejoIsregistravimas data)
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
        public void tiekejuSarasasIsregistravimui(TiekejoIsregistravimas data)
        {
            //List<string> tiekejulist = new List<string>();
            data.label4.Text = data.listBox1.Text;


                SqlConnection sqlConnection = new SqlConnection(this.connectionString);
                SqlCommand cmd = new SqlCommand("SELECT * FROM Tiekejai WHERE tiekejo_pavadinimas=@tiekejo_pavadinimas", sqlConnection);
                cmd.Parameters.AddWithValue("@tiekejo_pavadinimas", Convert.ToString(data.listBox1.Text));

                sqlConnection.Open();
                SqlDataReader duomenys = cmd.ExecuteReader();
                sqlConnection.Close();

                while (duomenys.Read())
                {
                    data.label5.Text = duomenys["tiekejo_pavadinimas"].ToString();
                }


            //duomenys.close();





            /*SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tiekejai WHERE tiekejo_pavadinimas=@tiekejo_pavadinimas", sqlConnection);
            cmd.Parameters.AddWithValue("@tiekejo_pavadinimas", data.listBox1.Text);

            sqlConnection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string labas4 = reader["tiekejo_pavadinimas"].ToString();
                data.label4.Text = labas4;
            }
            reader.Close();
            sqlConnection.Close();*/
        }

    }
}
