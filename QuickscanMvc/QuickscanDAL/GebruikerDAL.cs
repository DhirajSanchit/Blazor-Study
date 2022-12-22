using System.Text;
using Microsoft.Data.SqlClient;
using System.Security.Cryptography;
using QuickscanInterfaces.Interface;
using QuickscanInterfaces.DTO;
namespace QuickscanDAL
{
    public class GebruikerDAL : DatabaseConnectie, IGebruiker
    {
        //  private void GemeenteNummerGeventest(GebruikerDTO gebruikerDTO)
        //{
        //  SqlConnection sqlConnect = OpenEnGeefTerugSqlConnection();
        //SqlCommand command = sqlConnect.CreateCommand()
        //command.Parameters.AddWithValue("@GemeenteNr", gebruikerDTO.Gemeentenummer);
        //}

        public bool CheckIfExists(GebruikerDTO gebruikerDTO)
        {
            this.Connect();
            bool userBestaat = true;
            try
            {
                SqlCommand check_User_Name = new("SELECT COUNT(*) FROM Gebruiker WHERE (Gebruikernaam = @Gebruikernaam)", this.conn);
                check_User_Name.Parameters.AddWithValue("Gebruikernaam", gebruikerDTO.Gebruikersnaam);

                int UserExist = (int)check_User_Name.ExecuteScalar();

                if (UserExist > 0)
                {
                    userBestaat = true;
                }
                else

                {
                    userBestaat = false;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return userBestaat;
        }

        private void GemeenteNummerGeven(GebruikerDTO gebruikerDTO)
        {
            this.Connect();
            try
            {
                SqlCommand command = this.conn.CreateCommand();
                command.CommandText = "INSERT INTO Gemeente(GemeenteNr,GebruikerID) VALUES(@GemeenteNr,@GebruikerID)";
                command.Parameters.AddWithValue("@GemeenteNr", gebruikerDTO.GemeenteNr);
                command.Parameters.AddWithValue("@GebruikerID", gebruikerDTO.GebruikerID);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public bool GebruikerRegistreren(GebruikerDTO gebruikerDTO)
        {

            int id = 0;
            bool Staat = false;
            bool userBestaat;
            this.Connect();
            try
            {
                SqlCommand sqlCommand = new("UserAdd", this.conn);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@Voornaam", gebruikerDTO.Voornaam);
                sqlCommand.Parameters.AddWithValue("@Achternaam", gebruikerDTO.Achternaam);
                sqlCommand.Parameters.AddWithValue("@Gebruikernaam", gebruikerDTO.Gebruikersnaam);
                sqlCommand.Parameters.AddWithValue("@Wachtwoord", gebruikerDTO.Wachtwoord);
                sqlCommand.Parameters.AddWithValue("@Type", gebruikerDTO.Type);
                sqlCommand.ExecuteNonQuery();

                sqlCommand = this.conn.CreateCommand();
                sqlCommand.CommandText = "SELECT ID from Gebruiker WHERE Gebruikernaam = @Gebruikernaam";
                sqlCommand.Parameters.AddWithValue("@Gebruikernaam", gebruikerDTO.Gebruikersnaam);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    gebruikerDTO.GebruikerID = Convert.ToInt32(reader["ID"]);
                }

                if (reader.HasRows)
                {
                    Staat = true;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                this.Disconnect();
            }
            if(gebruikerDTO.Type == "Gemeente")
            {
                GemeenteNummerGeven(gebruikerDTO);

            }
            return Staat;
        }

        public bool ControleerGegevens(GebruikerDTO gebruikerDTO)
        {
            bool Staat = false;
            this.Connect();
            try
            {
                SqlCommand sqlCommand = new("SELECT Gebruikernaam FROM dbo.Gebruiker WHERE Gebruikernaam = @Gebruikernaam AND Wachtwoord = @Wachtwoord", this.conn);
                sqlCommand.Parameters.AddWithValue("@Gebruikernaam", gebruikerDTO.Gebruikersnaam);
                sqlCommand.Parameters.AddWithValue("@Wachtwoord", gebruikerDTO.Wachtwoord);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    Staat = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                this.Disconnect();
            }
            return Staat;
        }

        public GebruikerDTO GetGebruiker_MetGebruikersnaam(GebruikerDTO gebruikerDTO)
        {
            GebruikerDTO returnGebruikerDTO = null;
            this.Connect();
            try
            {
                SqlCommand sqlCommandGetType = new("SELECT gb.Voornaam, gb.Achternaam, gb.Gebruikernaam, gb.Type, gb.Wachtwoord, gb.ID, gm.GemeenteNr FROM dbo.Gebruiker AS gb INNER JOIN Gemeente AS gm ON gb.ID = gm.GebruikerID WHERE Gebruikernaam = @Gebruikernaam", this.conn);
                sqlCommandGetType.Parameters.AddWithValue("@Gebruikernaam", gebruikerDTO.Gebruikersnaam);
                SqlDataReader reader = sqlCommandGetType.ExecuteReader();
                while (reader.Read())
                {
                    returnGebruikerDTO = new GebruikerDTO()
                    {
                        Voornaam = Convert.ToString(reader["Voornaam"]),
                        Achternaam = Convert.ToString(reader["Achternaam"]),
                        Gebruikersnaam = Convert.ToString(reader["Gebruikernaam"]),
                        Type = Convert.ToString(reader["Type"]),
                        Wachtwoord = Convert.ToString(reader["Wachtwoord"]),
                        GebruikerID = Convert.ToInt32(reader["ID"]),
                        GemeenteNr = Convert.ToInt32(reader["GemeenteNr"])
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return returnGebruikerDTO;
        }

        public List<string> FillProfielBox(string gebruikersnaam)
        {
            List<string> ProfielDataList = new()
            {
            GetVollenaam(gebruikersnaam),
            GetGebruikersnaam(gebruikersnaam),
            GetRol(gebruikersnaam)
            };

            //ProfielDataList.Add(GetGemeente());
            //ProfielDataList.Add(GetGemeenteNR());
            return ProfielDataList;
        }

        private string GetVollenaam(string gebruikersnaam)
        {
            GebruikerDTO profielDTO = null;
            this.Connect();
            try
            {
                SqlCommand sqlCommand = new("SELECT Voornaam, Achternaam FROM dbo.Gebruiker WHERE Gebruikernaam = @Gebruikersnaam", this.conn);
                sqlCommand.Parameters.AddWithValue("@Gebruikersnaam", gebruikersnaam);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    profielDTO = new GebruikerDTO()
                    {
                        Voornaam = Convert.ToString(reader["Voornaam"]),
                        Achternaam = Convert.ToString(reader["Achternaam"])
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            string ReturnName = profielDTO.Voornaam + " " + profielDTO.Achternaam;
            return ReturnName;
        }

        public string GetGebruikersnaam(string gebruikersnaam)
        {
            GebruikerDTO profielDTO = null;
            this.Connect();
            try
            {
                SqlCommand sqlCommand = new("SELECT Gebruikernaam FROM dbo.Gebruiker WHERE Gebruikernaam = @Gebruikersnaam", this.conn);
                sqlCommand.Parameters.AddWithValue("@Gebruikersnaam", gebruikersnaam);
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    profielDTO = new GebruikerDTO()
                    {
                        Gebruikersnaam = Convert.ToString(reader["Gebruikernaam"])
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return profielDTO.Gebruikersnaam;
        }

        public string GetRol(string gebruikersnaam)
        {
            GebruikerDTO profielDTO = null;
            this.Connect();
            try
            {
                SqlCommand sqlCommand = new("SELECT Type FROM dbo.Gebruiker WHERE Gebruikernaam = @Gebruikersnaam", this.conn);
                sqlCommand.Parameters.AddWithValue("@Gebruikersnaam", gebruikersnaam);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    profielDTO = new GebruikerDTO()
                    {
                        Type = Convert.ToString(reader["Type"])
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return profielDTO.Type;
        }


        /*private string GetGemeente(string gebruikersnaam)
        {
            SqlConnection con = OpenEnGeefTerugSqlConnection();
            SqlCommand sqlCommand = new SqlCommand("SELECT  FROM WHERE", con);
            sqlCommand.Parameters.AddWithValue("@Gebruikersnaam", gebruikersnaam);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

            }
            con.Close();
        }

        private string GetGemeenteNR(string gebruikersnaam)
        {
            SqlConnection con = OpenEnGeefTerugSqlConnection();
            SqlCommand sqlCommand = new SqlCommand("SELECT FROM dbo.Gebruiker WHERE Gebruikernaam = @Gebruikersnaam", con);
            sqlCommand.Parameters.AddWithValue("@Gebruikersnaam", gebruikersnaam);
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {

            }
            con.Close();
        }*/
    }
}
