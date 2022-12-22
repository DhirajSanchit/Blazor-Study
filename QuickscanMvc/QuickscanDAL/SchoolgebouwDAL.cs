using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuickscanInterfaces.DTO;
using QuickscanInterfaces.Interface;

namespace QuickscanDAL
{
    public class SchoolgebouwDAL : DatabaseConnectie, ISchoolgebouw
    {
        public List<SchoolgebouwDTO> GetAllSchoolgebouwen()
        {
            List<SchoolgebouwDTO> schoolgebouwDTOsReturnList = new List<SchoolgebouwDTO>();
            this.Connect();
            try
            {
                SqlCommand sqlCommandGetGebouwen = new SqlCommand("SELECT * FROM Schoolgebouw", this.conn);
                SqlDataReader reader = sqlCommandGetGebouwen.ExecuteReader();
                SchoolgebouwDTO schoolgebouwDTO = null;
                while (reader.Read())
                {
                    schoolgebouwDTO = new SchoolgebouwDTO()
                    {
                        SchoolGebouwID = Convert.ToInt32(reader["ID"]),
                        GemeenteNr = Convert.ToInt32(reader["GemeenteNr"]),
                        GebouwNaam = Convert.ToString(reader["GebouwNaam"]),
                        Stad = Convert.ToString(reader["Stad"]),
                        Straatnaam = Convert.ToString(reader["Straatnaam"]),
                        Postcode = Convert.ToString(reader["Postcode"]),
                        Huisnummer = Convert.ToInt32(reader["Huisnummer"]),
                        Onderwijssoort = Convert.ToString(reader["Onderwijssoort"]),
                        Bouwjaar = Convert.ToInt32(reader["Bouwjaar"]),
                        Oppervlakte = Convert.ToInt32(reader["Oppervlakte"]),
                        AantalLeerlingen = Convert.ToInt32(reader["AantalLeerlingen"]),
                        ContactpersoonNaam = Convert.ToString(reader["Naam"]),
                        ContactpersoonFunctie = Convert.ToString(reader["Functie"]),
                        ContactpersoonTelefoonNr = Convert.ToString(reader["TelefoonNr"]),
                        ContactpersoonEmail = Convert.ToString(reader["Email"]),
                    };
                    schoolgebouwDTOsReturnList.Add(schoolgebouwDTO);
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
            return schoolgebouwDTOsReturnList;
        }

        public List<SchoolgebouwDTO> GetSchoolgebouwNameAndID()
        {
            List<SchoolgebouwDTO> schoolgebouwDTOsReturnList = new List<SchoolgebouwDTO>();
            this.Connect();
            try
            {
                SqlCommand sqlCommandGetGebouwen = new SqlCommand("SELECT ID,GebouwNaam FROM Schoolgebouw", this.conn);
                SqlDataReader reader = sqlCommandGetGebouwen.ExecuteReader();
                SchoolgebouwDTO schoolgebouwDTO = null;
                while (reader.Read())
                {
                    schoolgebouwDTO = new SchoolgebouwDTO()
                    {
                        SchoolGebouwID = Convert.ToInt32(reader["ID"]),
                        GebouwNaam = Convert.ToString(reader["GebouwNaam"])

                    };
                    schoolgebouwDTOsReturnList.Add(schoolgebouwDTO);
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
            return schoolgebouwDTOsReturnList;
        }

        public SchoolgebouwDTO GetSchoolgebouwByID(int ID)
        {                
            SchoolgebouwDTO schoolgebouwDTO = new SchoolgebouwDTO();
            this.Connect();
            try
            {
                SqlCommand sqlCommandGetGebouwen = new SqlCommand("SELECT * FROM Schoolgebouw WHERE ID = @ID", this.conn);
                sqlCommandGetGebouwen.Parameters.AddWithValue("@ID", ID);
                SqlDataReader reader = sqlCommandGetGebouwen.ExecuteReader();
                while (reader.Read())
                {
                    schoolgebouwDTO = new SchoolgebouwDTO()
                    {
                        SchoolGebouwID = Convert.ToInt32(reader["ID"]),
                        GemeenteNr = Convert.ToInt32(reader["GemeenteNr"]),
                        GebouwNaam = Convert.ToString(reader["GebouwNaam"]),
                        Stad = Convert.ToString(reader["Stad"]),
                        Straatnaam = Convert.ToString(reader["Straatnaam"]),
                        Postcode = Convert.ToString(reader["Postcode"]),
                        Huisnummer = Convert.ToInt32(reader["Huisnummer"]),
                        Onderwijssoort = Convert.ToString(reader["Onderwijssoort"]),
                        Bouwjaar = Convert.ToInt32(reader["Bouwjaar"]),
                        Oppervlakte = Convert.ToInt32(reader["Oppervlakte"]),
                        AantalLeerlingen = Convert.ToInt32(reader["AantalLeerlingen"]),
                        ContactpersoonNaam = Convert.ToString(reader["Naam"]),
                        ContactpersoonFunctie = Convert.ToString(reader["Functie"]),
                        ContactpersoonTelefoonNr = Convert.ToString(reader["TelefoonNr"]),
                        ContactpersoonEmail = Convert.ToString(reader["Email"]),
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
            return schoolgebouwDTO;
        }

        public void SchoolgebouwUpdaten(SchoolgebouwDTO schoolgebouwDTO)
        {
            this.Connect();
            try
            {
                string query = "UPDATE Schoolgebouw SET GebouwNaam = @GebouwNaam, GemeenteNr = @GemeenteNr, Straatnaam = @Straatnaam, Postcode = @Postcode, Huisnummer = @Huisnummer, Onderwijssoort = @Onderwijssoort, Bouwjaar = @Bouwjaar, Oppervlakte = @Oppervlakte, AantalLeerlingen = @Leerlingen, Naam = @Naam, Functie = @Functie, TelefoonNr = @TelefoonNr, Email = @Email WHERE ID = @Id";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@GebouwNaam", schoolgebouwDTO.GebouwNaam);
                command.Parameters.AddWithValue("@GemeenteNr", schoolgebouwDTO.GemeenteNr);
                command.Parameters.AddWithValue("@Straatnaam", schoolgebouwDTO.Straatnaam);
                command.Parameters.AddWithValue("@Postcode", schoolgebouwDTO.Postcode);
                command.Parameters.AddWithValue("@Huisnummer", schoolgebouwDTO.Huisnummer);
                command.Parameters.AddWithValue("@Onderwijssoort", schoolgebouwDTO.Onderwijssoort);
                command.Parameters.AddWithValue("@Bouwjaar", schoolgebouwDTO.Bouwjaar);
                command.Parameters.AddWithValue("@Oppervlakte", schoolgebouwDTO.Oppervlakte);
                command.Parameters.AddWithValue("@Leerlingen", schoolgebouwDTO.AantalLeerlingen);
                command.Parameters.AddWithValue("@Naam", schoolgebouwDTO.ContactpersoonNaam);
                command.Parameters.AddWithValue("@Functie", schoolgebouwDTO.ContactpersoonFunctie);
                command.Parameters.AddWithValue("@TelefoonNr", schoolgebouwDTO.ContactpersoonTelefoonNr);
                command.Parameters.AddWithValue("@Email", schoolgebouwDTO.ContactpersoonEmail);
                command.Parameters.AddWithValue("@Id", schoolgebouwDTO.SchoolGebouwID);
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
        }

        public int SchoolgebouwAanmaken(SchoolgebouwDTO schoolgebouwDTO)
        {
            this.Connect();
            int id = 0;
            try
            {
                string query = "INSERT INTO Schoolgebouw(GebouwNaam, GemeenteNr, Stad, Straatnaam, Postcode, Huisnummer, OnderwijsSoort, Bouwjaar, Oppervlakte, AantalLeerlingen, Naam, Functie, TelefoonNr, Email) OUTPUT inserted.ID VALUES(@GebouwNaam, @GemeenteNr, @Stad, @Straatnaam, @Postcode, @Huisnummer, @OnderwijsSoort, @Bouwjaar, @Oppervlakte, @Leerlingen, @Naam, @Functie, @TelefoonNr, @Email)";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@GebouwNaam", schoolgebouwDTO.GebouwNaam);
                command.Parameters.AddWithValue("@GemeenteNr", schoolgebouwDTO.GemeenteNr);
                command.Parameters.AddWithValue("@Stad", schoolgebouwDTO.Stad);
                command.Parameters.AddWithValue("@Straatnaam", schoolgebouwDTO.Straatnaam);
                command.Parameters.AddWithValue("@Postcode", schoolgebouwDTO.Postcode);
                command.Parameters.AddWithValue("@Huisnummer", schoolgebouwDTO.Huisnummer);
                command.Parameters.AddWithValue("@Onderwijssoort", schoolgebouwDTO.Onderwijssoort);
                command.Parameters.AddWithValue("@Bouwjaar", schoolgebouwDTO.Bouwjaar);
                command.Parameters.AddWithValue("@Oppervlakte", schoolgebouwDTO.Oppervlakte);
                command.Parameters.AddWithValue("@Leerlingen", schoolgebouwDTO.AantalLeerlingen);
                command.Parameters.AddWithValue("@Naam", schoolgebouwDTO.ContactpersoonNaam);
                command.Parameters.AddWithValue("@Functie", schoolgebouwDTO.ContactpersoonFunctie);
                command.Parameters.AddWithValue("@TelefoonNr", schoolgebouwDTO.ContactpersoonTelefoonNr);
                command.Parameters.AddWithValue("@Email", schoolgebouwDTO.ContactpersoonEmail);
                id = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return id;
        }

        public bool CheckOfSchoolgebouwBestaat(SchoolgebouwDTO schoolgebouwDTO)
        {
            this.Connect();
            bool bestaat = false;
            try
            {
                string query = "SELECT * FROM Schoolgebouw WHERE ID = @ID";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@ID", schoolgebouwDTO.SchoolGebouwID);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    bestaat = true;
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
            return bestaat;
        }
    }
}
