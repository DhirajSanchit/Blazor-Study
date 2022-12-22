using Microsoft.Data.SqlClient;
using QuickscanInterfaces.DTO;
using QuickscanInterfaces.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickscanDAL
{
    public class SorteerDAL : DatabaseConnectie, ISorteer
    {
        public List<SchoolgebouwDTO> FilterListStad(string filterOp)
        {
            List<SchoolgebouwDTO> returnListSchoolgebouwDTO = new();
            this.Connect();

            try
            {
                SqlCommand sqlCommandSorteerList = new("SELECT * FROM dbo.Schoolgebouw WHERE Stad LIKE @FilterOp", this.conn);
                sqlCommandSorteerList.Parameters.AddWithValue("@FilterOp", "%" + filterOp + "%");
                SqlDataReader reader = sqlCommandSorteerList.ExecuteReader();
                
                while (reader.Read())
                {
                    SchoolgebouwDTO returnSchoolgebouwDTO = new()
                    {
                        SchoolGebouwID = Convert.ToInt32(reader["ID"]),
                        GemeenteNr = Convert.ToInt32(reader["GemeenteNr"]),
                        GebouwNaam = Convert.ToString(reader["GebouwNaam"]),
                        Straatnaam = Convert.ToString(reader["Straatnaam"]),
                        Postcode = Convert.ToString(reader["Postcode"]),
                        Stad = Convert.ToString(reader["Stad"]),
                        Huisnummer = Convert.ToInt32(reader["Huisnummer"]),
                        Onderwijssoort = Convert.ToString(reader["Onderwijssoort"]),
                        Bouwjaar = Convert.ToInt32(reader["Bouwjaar"]),
                        Oppervlakte = Convert.ToInt32(reader["Oppervlakte"]),
                        AantalLeerlingen = Convert.ToInt32(reader["AantalLeerlingen"]),
                        ContactpersoonNaam = Convert.ToString(reader["Naam"]),
                        ContactpersoonFunctie = Convert.ToString(reader["Functie"]),
                        ContactpersoonTelefoonNr = Convert.ToString(reader["TelefoonNr"]),
                        ContactpersoonEmail = Convert.ToString(reader["Email"])
                    };
                    returnListSchoolgebouwDTO.Add(returnSchoolgebouwDTO);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this.Disconnect();
            }
            return returnListSchoolgebouwDTO;
        }

        public List<SchoolgebouwDTO> FilterListGebouwNaam(string filterOp)
        {
            List<SchoolgebouwDTO> returnListSchoolgebouwDTO = new();
            this.Connect();

            try
            {
                SqlCommand sqlCommandSorteerList = new("SELECT * FROM dbo.Schoolgebouw WHERE GebouwNaam LIKE @FilterOp", this.conn);
                sqlCommandSorteerList.Parameters.AddWithValue("@FilterOp", "%" + filterOp + "%");
                SqlDataReader reader = sqlCommandSorteerList.ExecuteReader();
                while (reader.Read())
                {
                    SchoolgebouwDTO returnSchoolgebouwDTO = new()
                    {
                        SchoolGebouwID = Convert.ToInt32(reader["ID"]),
                        GemeenteNr = Convert.ToInt32(reader["GemeenteNr"]),
                        GebouwNaam = Convert.ToString(reader["GebouwNaam"]),
                        Straatnaam = Convert.ToString(reader["Straatnaam"]),
                        Postcode = Convert.ToString(reader["Postcode"]),
                        Stad = Convert.ToString(reader["Stad"]),
                        Huisnummer = Convert.ToInt32(reader["Huisnummer"]),
                        Onderwijssoort = Convert.ToString(reader["Onderwijssoort"]),
                        Bouwjaar = Convert.ToInt32(reader["Bouwjaar"]),
                        Oppervlakte = Convert.ToInt32(reader["Oppervlakte"]),
                        AantalLeerlingen = Convert.ToInt32(reader["AantalLeerlingen"]),
                        ContactpersoonNaam = Convert.ToString(reader["Naam"]),
                        ContactpersoonFunctie = Convert.ToString(reader["Functie"]),
                        ContactpersoonTelefoonNr = Convert.ToString(reader["TelefoonNr"]),
                        ContactpersoonEmail = Convert.ToString(reader["Email"])
                    };
                    returnListSchoolgebouwDTO.Add(returnSchoolgebouwDTO);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                this.Disconnect();
            }
            return returnListSchoolgebouwDTO;
        }

        public List<SchoolgebouwDTO> SorteerListStad()
        {
            List<SchoolgebouwDTO> returnListSchoolgebouwDTO = new();
            this.Connect();

            try
            {
                SqlCommand sqlCommandSorteerList = new("SELECT * FROM dbo.Schoolgebouw ORDER BY Stad", this.conn);
                SqlDataReader reader = sqlCommandSorteerList.ExecuteReader();
                while (reader.Read())
                {
                    SchoolgebouwDTO returnSchoolgebouwDTO = new()
                    {
                        SchoolGebouwID = Convert.ToInt32(reader["ID"]),
                        GemeenteNr = Convert.ToInt32(reader["GemeenteNr"]),
                        GebouwNaam = Convert.ToString(reader["GebouwNaam"]),
                        Straatnaam = Convert.ToString(reader["Straatnaam"]),
                        Postcode = Convert.ToString(reader["Postcode"]),
                        Stad = Convert.ToString(reader["Stad"]),
                        Huisnummer = Convert.ToInt32(reader["Huisnummer"]),
                        Onderwijssoort = Convert.ToString(reader["Onderwijssoort"]),
                        Bouwjaar = Convert.ToInt32(reader["Bouwjaar"]),
                        Oppervlakte = Convert.ToInt32(reader["Oppervlakte"]),
                        AantalLeerlingen = Convert.ToInt32(reader["AantalLeerlingen"]),
                        ContactpersoonNaam = Convert.ToString(reader["Naam"]),
                        ContactpersoonFunctie = Convert.ToString(reader["Functie"]),
                        ContactpersoonTelefoonNr = Convert.ToString(reader["TelefoonNr"]),
                        ContactpersoonEmail = Convert.ToString(reader["Email"])
                    };
                    returnListSchoolgebouwDTO.Add(returnSchoolgebouwDTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Disconnect();
            }
            return returnListSchoolgebouwDTO;
        }

        public List<SchoolgebouwDTO> SorteerListAdvies()
        {
            List<SchoolgebouwDTO> returnListSchoolgebouwDTO = new();
            this.Connect();

            try
            {
                SqlCommand sqlCommandSorteerList = new("SELECT * FROM dbo.Schoolgebouw ORDER BY Advies", this.conn);
                SqlDataReader reader = sqlCommandSorteerList.ExecuteReader();
                while (reader.Read())
                {
                    SchoolgebouwDTO returnSchoolgebouwDTO = new()
                    {
                        SchoolGebouwID = Convert.ToInt32(reader["ID"]),
                        GemeenteNr = Convert.ToInt32(reader["GemeenteNr"]),
                        GebouwNaam = Convert.ToString(reader["GebouwNaam"]),
                        Straatnaam = Convert.ToString(reader["Straatnaam"]),
                        Postcode = Convert.ToString(reader["Postcode"]),
                        Stad = Convert.ToString(reader["Stad"]),
                        Huisnummer = Convert.ToInt32(reader["Huisnummer"]),
                        Onderwijssoort = Convert.ToString(reader["Onderwijssoort"]),
                        Bouwjaar = Convert.ToInt32(reader["Bouwjaar"]),
                        Oppervlakte = Convert.ToInt32(reader["Oppervlakte"]),
                        AantalLeerlingen = Convert.ToInt32(reader["AantalLeerlingen"]),
                        ContactpersoonNaam = Convert.ToString(reader["Naam"]),
                        ContactpersoonFunctie = Convert.ToString(reader["Functie"]),
                        ContactpersoonTelefoonNr = Convert.ToString(reader["TelefoonNr"]),
                        ContactpersoonEmail = Convert.ToString(reader["Email"])
                    };
                    returnListSchoolgebouwDTO.Add(returnSchoolgebouwDTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Disconnect();
            }
            return returnListSchoolgebouwDTO;
        }

        public List<SchoolgebouwDTO> SorteerListGebouwNaam()
        {
            List<SchoolgebouwDTO> returnListSchoolgebouwDTO = new();
            this.Connect();

            try
            {
                SqlCommand sqlCommandSorteerList = new("SELECT * FROM dbo.Schoolgebouw ORDER BY GebouwNaam", this.conn);
                SqlDataReader reader = sqlCommandSorteerList.ExecuteReader();
                while (reader.Read())
                {
                    SchoolgebouwDTO returnSchoolgebouwDTO = new()
                    {
                        SchoolGebouwID = Convert.ToInt32(reader["ID"]),
                        GemeenteNr = Convert.ToInt32(reader["GemeenteNr"]),
                        GebouwNaam = Convert.ToString(reader["GebouwNaam"]),
                        Straatnaam = Convert.ToString(reader["Straatnaam"]),
                        Postcode = Convert.ToString(reader["Postcode"]),
                        Stad = Convert.ToString(reader["Stad"]),
                        Huisnummer = Convert.ToInt32(reader["Huisnummer"]),
                        Onderwijssoort = Convert.ToString(reader["Onderwijssoort"]),
                        Bouwjaar = Convert.ToInt32(reader["Bouwjaar"]),
                        Oppervlakte = Convert.ToInt32(reader["Oppervlakte"]),
                        AantalLeerlingen = Convert.ToInt32(reader["AantalLeerlingen"]),
                        ContactpersoonNaam = Convert.ToString(reader["Naam"]),
                        ContactpersoonFunctie = Convert.ToString(reader["Functie"]),
                        ContactpersoonTelefoonNr = Convert.ToString(reader["TelefoonNr"]),
                        ContactpersoonEmail = Convert.ToString(reader["Email"])
                    };
                    returnListSchoolgebouwDTO.Add(returnSchoolgebouwDTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Disconnect();
            }
            return returnListSchoolgebouwDTO;
        }

        public List<SchoolgebouwDTO> SorteerListStraatnaam()
        {
            List<SchoolgebouwDTO> returnListSchoolgebouwDTO = new();
            this.Connect();

            try
            {
                SqlCommand sqlCommandSorteerList = new("SELECT * FROM dbo.Schoolgebouw ORDER BY Straatnaam", this.conn);
                SqlDataReader reader = sqlCommandSorteerList.ExecuteReader();
                while (reader.Read())
                {
                    SchoolgebouwDTO returnSchoolgebouwDTO = new()
                    {
                        SchoolGebouwID = Convert.ToInt32(reader["ID"]),
                        GemeenteNr = Convert.ToInt32(reader["GemeenteNr"]),
                        GebouwNaam = Convert.ToString(reader["GebouwNaam"]),
                        Straatnaam = Convert.ToString(reader["Straatnaam"]),
                        Postcode = Convert.ToString(reader["Postcode"]),
                        Stad = Convert.ToString(reader["Stad"]),
                        Huisnummer = Convert.ToInt32(reader["Huisnummer"]),
                        Onderwijssoort = Convert.ToString(reader["Onderwijssoort"]),
                        Bouwjaar = Convert.ToInt32(reader["Bouwjaar"]),
                        Oppervlakte = Convert.ToInt32(reader["Oppervlakte"]),
                        AantalLeerlingen = Convert.ToInt32(reader["AantalLeerlingen"]),
                        ContactpersoonNaam = Convert.ToString(reader["Naam"]),
                        ContactpersoonFunctie = Convert.ToString(reader["Functie"]),
                        ContactpersoonTelefoonNr = Convert.ToString(reader["TelefoonNr"]),
                        ContactpersoonEmail = Convert.ToString(reader["Email"])
                    };
                    returnListSchoolgebouwDTO.Add(returnSchoolgebouwDTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Disconnect();
            }
            return returnListSchoolgebouwDTO;
        }

        public List<SchoolgebouwDTO> SorteerListPostcode()
        {
            List<SchoolgebouwDTO> returnListSchoolgebouwDTO = new();
            this.Connect();

            try
            {
                SqlCommand sqlCommandSorteerList = new("SELECT * FROM dbo.Schoolgebouw ORDER BY Postcode", this.conn);
                SqlDataReader reader = sqlCommandSorteerList.ExecuteReader();
                while (reader.Read())
                {
                    SchoolgebouwDTO returnSchoolgebouwDTO = new()
                    {
                        SchoolGebouwID = Convert.ToInt32(reader["ID"]),
                        GemeenteNr = Convert.ToInt32(reader["GemeenteNr"]),
                        GebouwNaam = Convert.ToString(reader["GebouwNaam"]),
                        Straatnaam = Convert.ToString(reader["Straatnaam"]),
                        Postcode = Convert.ToString(reader["Postcode"]),
                        Stad = Convert.ToString(reader["Stad"]),
                        Huisnummer = Convert.ToInt32(reader["Huisnummer"]),
                        Onderwijssoort = Convert.ToString(reader["Onderwijssoort"]),
                        Bouwjaar = Convert.ToInt32(reader["Bouwjaar"]),
                        Oppervlakte = Convert.ToInt32(reader["Oppervlakte"]),
                        AantalLeerlingen = Convert.ToInt32(reader["AantalLeerlingen"]),
                        ContactpersoonNaam = Convert.ToString(reader["Naam"]),
                        ContactpersoonFunctie = Convert.ToString(reader["Functie"]),
                        ContactpersoonTelefoonNr = Convert.ToString(reader["TelefoonNr"]),
                        ContactpersoonEmail = Convert.ToString(reader["Email"])
                    };
                    returnListSchoolgebouwDTO.Add(returnSchoolgebouwDTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Disconnect();
            }
            return returnListSchoolgebouwDTO;
        }

        public List<SchoolgebouwDTO> SorteerListHuisnummer()
        {
            List<SchoolgebouwDTO> returnListSchoolgebouwDTO = new();
            this.Connect();

            try
            {
                SqlCommand sqlCommandSorteerList = new("SELECT * FROM dbo.Schoolgebouw ORDER BY Huisnummer", this.conn);
                SqlDataReader reader = sqlCommandSorteerList.ExecuteReader();
                while (reader.Read())
                {
                    SchoolgebouwDTO returnSchoolgebouwDTO = new()
                    {
                        SchoolGebouwID = Convert.ToInt32(reader["ID"]),
                        GemeenteNr = Convert.ToInt32(reader["GemeenteNr"]),
                        GebouwNaam = Convert.ToString(reader["GebouwNaam"]),
                        Straatnaam = Convert.ToString(reader["Straatnaam"]),
                        Postcode = Convert.ToString(reader["Postcode"]),
                        Stad = Convert.ToString(reader["Stad"]),
                        Huisnummer = Convert.ToInt32(reader["Huisnummer"]),
                        Onderwijssoort = Convert.ToString(reader["Onderwijssoort"]),
                        Bouwjaar = Convert.ToInt32(reader["Bouwjaar"]),
                        Oppervlakte = Convert.ToInt32(reader["Oppervlakte"]),
                        AantalLeerlingen = Convert.ToInt32(reader["AantalLeerlingen"]),
                        ContactpersoonNaam = Convert.ToString(reader["Naam"]),
                        ContactpersoonFunctie = Convert.ToString(reader["Functie"]),
                        ContactpersoonTelefoonNr = Convert.ToString(reader["TelefoonNr"]),
                        ContactpersoonEmail = Convert.ToString(reader["Email"])
                    };
                    returnListSchoolgebouwDTO.Add(returnSchoolgebouwDTO);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.Disconnect();
            }
            return returnListSchoolgebouwDTO;
        }
    }
}
