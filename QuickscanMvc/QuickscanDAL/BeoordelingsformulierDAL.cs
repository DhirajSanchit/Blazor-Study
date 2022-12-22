using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using QuickscanInterfaces.Interface;
using QuickscanInterfaces.DTO;
using QuickscanInterfaces.DTO.Beoordelingsformulier;

namespace QuickscanDAL
{
    public class BeoordelingsformulierDAL : DatabaseConnectie, IBeoordelingsformulier
    {

        // Alle antwoorden van beoordelingsformulier updaten
        public void AntwoordenOpslaan(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            this.Connect();
            try
            {
                VeiligheidOpslaan(beoordelingsformulierDTO);
                UitstralingOpslaan(beoordelingsformulierDTO);
                EnergieVerbruikOpslaan(beoordelingsformulierDTO);
                OnderwijskundigeStaatOpslaan(beoordelingsformulierDTO);
                BouwkundigeStaatOpslaan(beoordelingsformulierDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
        }

        private void VeiligheidOpslaan(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            try
            {
                SqlCommand command = this.conn.CreateCommand();
                command.CommandText = "UPDATE Veiligheid SET Score = @Score, ExtraPunt = @ExtraPunt, Opmerking = @Opmerking WHERE AdviesId = @AdviesId";
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
                command.Parameters.AddWithValue("@Score", beoordelingsformulierDTO.VeiligheidDTO.CheckBoxScore);
                command.Parameters.AddWithValue("@ExtraPunt", beoordelingsformulierDTO.VeiligheidDTO.ExtraScore);
                command.Parameters.AddWithValue("@Opmerking", beoordelingsformulierDTO.VeiligheidDTO.Opmerking);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void UitstralingOpslaan(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            try
            {
                SqlCommand command = this.conn.CreateCommand();
                command.CommandText = "UPDATE Uitstraling SET Score = @Score, Opmerking = @Opmerking WHERE AdviesId = @AdviesId";
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
                command.Parameters.AddWithValue("@Score", beoordelingsformulierDTO.UitstralingDTO.Score);
                command.Parameters.AddWithValue("@Opmerking", beoordelingsformulierDTO.UitstralingDTO.Opmerking);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void EnergieVerbruikOpslaan(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            try
            {
                SqlCommand command = this.conn.CreateCommand();
                command.CommandText = "UPDATE EnergieVerbruik SET Elektriciteit = @Elektriciteit, Gas = @Gas, Stadsverwarming = @Stadsverwarming, EigenOpwekking = @EigenOpwekking, Opmerking = @Opmerking WHERE AdviesId = @AdviesId";
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
                command.Parameters.AddWithValue("@Elektriciteit", beoordelingsformulierDTO.EnergieVerbruikDTO.VerbruikElektriciteit);
                command.Parameters.AddWithValue("@Gas", beoordelingsformulierDTO.EnergieVerbruikDTO.VerbruikGas);
                command.Parameters.AddWithValue("@Stadsverwarming", beoordelingsformulierDTO.EnergieVerbruikDTO.VerbruikStadsverwarming);
                command.Parameters.AddWithValue("@EigenOpwekking", beoordelingsformulierDTO.EnergieVerbruikDTO.EigenOpwekking);
                command.Parameters.AddWithValue("@Opmerking", beoordelingsformulierDTO.EnergieVerbruikDTO.Beschrijving);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void OnderwijskundigeStaatOpslaan(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            try
            {
                SqlCommand command = this.conn.CreateCommand();
                command.CommandText = "UPDATE OnderwijskundigeStaat SET Aula = @Aula, Stafruimte = @Stafruimte, Bergruimte = @Bergruimte, RolstoelToegankelijkheid = @RolstoelToegankelijkheid, Opmerking = @Opmerking WHERE AdviesId = @AdviesId";
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
                command.Parameters.AddWithValue("@Aula", beoordelingsformulierDTO.OnderwijskundigeStaatDTO.Aula);
                command.Parameters.AddWithValue("@Stafruimte", beoordelingsformulierDTO.OnderwijskundigeStaatDTO.Stafruimte);
                command.Parameters.AddWithValue("@Bergruimte", beoordelingsformulierDTO.OnderwijskundigeStaatDTO.Bergruimte);
                command.Parameters.AddWithValue("@RolstoelToegankelijkheid", beoordelingsformulierDTO.OnderwijskundigeStaatDTO.Rolstoel);
                command.Parameters.AddWithValue("@Opmerking", beoordelingsformulierDTO.OnderwijskundigeStaatDTO.Beschrijving);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void RuimtebehoefteOpslaan(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            this.Connect();
            try
            {
                SqlCommand command = this.conn.CreateCommand();
                command.CommandText = "INSERT INTO Ruimtebehoefte(AdviesId, Jaar, Leerlingen) VALUES(@AdviesId, @Jaar, @Leerlingen)";
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
                command.Parameters.AddWithValue("@Jaar", beoordelingsformulierDTO.RuimtebehoefteDTO.JaarToevoegen);
                command.Parameters.AddWithValue("@Leerlingen", beoordelingsformulierDTO.RuimtebehoefteDTO.LeerlingenToevoegen);
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                this.Disconnect();
            }
        }

        private void BouwkundigeStaatOpslaan(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            SqlCommand command = this.conn.CreateCommand();
            command.CommandText = "UPDATE BouwkundigeStaat SET Dak = @Dak, Gevel = @Gevel, KozijnenDeuren = @Kozijn, Verwarming = @Verwarming, Sanitair = @Sanitair, Riolering = @Riolering, WandenPlafond = @Wanden, KostenPerJaar = @Kosten, SubsidiePerJaar = @Subsidie, BouwJaar = @Bouwjaar, RenovatieJaar = @Renovatie, ExtraPunt = @ExtraPunt, ExtraPuntKosten = @ExtraPuntKosten, Opmerking = @Opmerking WHERE AdviesId = @AdviesId";
            command.Parameters.AddWithValue("@Dak", beoordelingsformulierDTO.BouwkundigeStaatDTO.Dak);
            command.Parameters.AddWithValue("@Gevel", beoordelingsformulierDTO.BouwkundigeStaatDTO.Gevel);
            command.Parameters.AddWithValue("@Kozijn", beoordelingsformulierDTO.BouwkundigeStaatDTO.Kozijnen);
            command.Parameters.AddWithValue("@Verwarming", beoordelingsformulierDTO.BouwkundigeStaatDTO.Verwarming);
            command.Parameters.AddWithValue("@Sanitair", beoordelingsformulierDTO.BouwkundigeStaatDTO.Sanitair);
            command.Parameters.AddWithValue("@Riolering", beoordelingsformulierDTO.BouwkundigeStaatDTO.Riolering);
            command.Parameters.AddWithValue("@Wanden", beoordelingsformulierDTO.BouwkundigeStaatDTO.Wanden);
            command.Parameters.AddWithValue("@Kosten", beoordelingsformulierDTO.BouwkundigeStaatDTO.KostenPerJaar);
            command.Parameters.AddWithValue("@Subsidie", beoordelingsformulierDTO.BouwkundigeStaatDTO.SubsidiePerJaar);
            command.Parameters.AddWithValue("@Bouwjaar", beoordelingsformulierDTO.BouwkundigeStaatDTO.Bouwjaar);
            command.Parameters.AddWithValue("@Renovatie", beoordelingsformulierDTO.BouwkundigeStaatDTO.RenovatieJaar);
            command.Parameters.AddWithValue("@ExtraPunt", beoordelingsformulierDTO.BouwkundigeStaatDTO.ExtraPuntSliders);
            command.Parameters.AddWithValue("@ExtraPuntKosten", beoordelingsformulierDTO.BouwkundigeStaatDTO.ExtraPuntKosten);
            command.Parameters.AddWithValue("@Opmerking", beoordelingsformulierDTO.BouwkundigeStaatDTO.Opmerking);
            command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
            command.ExecuteNonQuery();
        }

        //Beoordelingsformulier ophalen d.m.v. gebouwId
        public int BeoordelingsformulierOphalenMetGebouwId(int id)
        {
            //beoordelingsformulier object ophalen met een gebouw id
            this.Connect();
            int adviesId = 0;
            try
            {
                string query = "SELECT Id FROM Advies WHERE GebouwId = @GebouwId";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@GebouwId", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    adviesId = Convert.ToInt32(reader["Id"]);
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
            return adviesId;
        }

        //Antwoorden ophalen methodes

        public BeoordelingsformulierDTO AntwoordenOphalen(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            try
            {
                AdviesDTO adviesDTO = this.AdviesOphalen(beoordelingsformulierDTO);
                BouwkundigeStaatDTO bouwkundigeStaatDTO = this.BouwkundigeStaatOphalen(beoordelingsformulierDTO);
                VeiligheidDTO veiligheidDTO = this.VeiligheidOphalen(beoordelingsformulierDTO);
                EnergieVerbruikDTO energieVerbruikDTO = this.EnergieVerbruikOphalen(beoordelingsformulierDTO);
                RuimtebehoefteDTO ruimtebehoefteDTO = this.RuimtebehoefteOphalen(beoordelingsformulierDTO);
                OnderwijskundigeStaatDTO onderwijskundigeStaatDTO = this.OnderwijskundigeStaatOphalen(beoordelingsformulierDTO);
                UitstralingDTO uitstralingDTO = this.UitstralingOphalen(beoordelingsformulierDTO);


                beoordelingsformulierDTO = new BeoordelingsformulierDTO()
                {
                    Id = beoordelingsformulierDTO.Id,
                    AdviesDTO = adviesDTO,
                    BouwkundigeStaatDTO = bouwkundigeStaatDTO,
                    VeiligheidDTO = veiligheidDTO,
                    EnergieVerbruikDTO = energieVerbruikDTO,
                    RuimtebehoefteDTO = ruimtebehoefteDTO,
                    OnderwijskundigeStaatDTO = onderwijskundigeStaatDTO,
                    UitstralingDTO = uitstralingDTO
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return beoordelingsformulierDTO;
        }

        private BouwkundigeStaatDTO BouwkundigeStaatOphalen(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            this.Connect();
            BouwkundigeStaatDTO bouwkundigeStaatDTO = new BouwkundigeStaatDTO();
            this.Connect();
            try
            {
                string query = "SELECT * FROM BouwkundigeStaat WHERE AdviesId = @AdviesId";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    bouwkundigeStaatDTO = new BouwkundigeStaatDTO()
                    {
                        Dak = Convert.ToInt32(reader["Dak"]),
                        Gevel = Convert.ToInt32(reader["Gevel"]),
                        Kozijnen = Convert.ToInt32(reader["KozijnenDeuren"]),
                        Verwarming = Convert.ToInt32(reader["Verwarming"]),
                        Sanitair = Convert.ToInt32(reader["Sanitair"]),
                        Riolering = Convert.ToInt32(reader["Riolering"]),
                        Wanden = Convert.ToInt32(reader["WandenPlafond"]),
                        ExtraPuntSliders = Convert.ToDouble(reader["ExtraPunt"]),
                        KostenPerJaar = Convert.ToDouble(reader["KostenPerJaar"]),
                        SubsidiePerJaar = Convert.ToDouble(reader["SubsidiePerJaar"]),
                        ExtraPuntKosten = Convert.ToDouble(reader["ExtraPuntKosten"]),
                        Bouwjaar = Convert.ToInt32(reader["BouwJaar"]),
                        RenovatieJaar = Convert.ToInt32(reader["RenovatieJaar"]),
                        Opmerking = Convert.ToString(reader["Opmerking"])
                    };
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return bouwkundigeStaatDTO;
        }

        private VeiligheidDTO VeiligheidOphalen(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            this.Connect();
            VeiligheidDTO veiligheidDTO = new VeiligheidDTO();
            this.Connect();
            try
            {
                string query = "SELECT * FROM Veiligheid WHERE AdviesId = @AdviesId";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    veiligheidDTO = new VeiligheidDTO()
                    {
                        CheckBoxScore = Convert.ToInt32(reader["Score"]),
                        ExtraScore = Convert.ToDouble(reader["ExtraPunt"]),
                        Opmerking = Convert.ToString(reader["Opmerking"])
                    };

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return veiligheidDTO;
        }

        private EnergieVerbruikDTO EnergieVerbruikOphalen(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            this.Connect();
            EnergieVerbruikDTO energieVerbruikDTO = new EnergieVerbruikDTO();
            try
            {
                string query = "SELECT * FROM EnergieVerbruik WHERE AdviesId = @AdviesId";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    energieVerbruikDTO = new EnergieVerbruikDTO()
                    {
                        VerbruikElektriciteit = Convert.ToDouble(reader["Elektriciteit"]),
                        VerbruikGas = Convert.ToDouble(reader["Gas"]),
                        VerbruikStadsverwarming = Convert.ToDouble(reader["Stadsverwarming"]),
                        EigenOpwekking = Convert.ToDouble(reader["EigenOpwekking"]),
                        Beschrijving = Convert.ToString(reader["Opmerking"])
                    };

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return energieVerbruikDTO;
        }

        private OnderwijskundigeStaatDTO OnderwijskundigeStaatOphalen(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            this.Connect();
            OnderwijskundigeStaatDTO onderwijskundigeStaatDTO = new OnderwijskundigeStaatDTO();
            try
            {

                string query = "SELECT * FROM OnderwijskundigeStaat WHERE AdviesId = @AdviesId";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    onderwijskundigeStaatDTO = new OnderwijskundigeStaatDTO()
                    {
                        
                        Aula = Convert.ToInt32(reader["Aula"]),
                        Stafruimte = Convert.ToInt32(reader["Stafruimte"]),
                        Bergruimte = Convert.ToInt32(reader["Bergruimte"]),
                        Rolstoel = Convert.ToInt32(reader["RolstoelToegankelijkheid"]),
                        Beschrijving = Convert.ToString(reader["Opmerking"])
                    };

                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return onderwijskundigeStaatDTO;
        }

        private RuimtebehoefteDTO RuimtebehoefteOphalen(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            this.Connect();
            RuimtebehoefteDTO ruimtebehoefteDTO = new RuimtebehoefteDTO()
            {
                Id = new List<int>(),
                Jaar = new List<int>(),
                Leerlingen = new List<int>()
            };

            try
            {
                string query = "SELECT * FROM Ruimtebehoefte WHERE AdviesId = @AdviesId ORDER BY Jaar";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ruimtebehoefteDTO.Id.Add(Convert.ToInt32(reader["Id"]));
                    ruimtebehoefteDTO.Jaar.Add(Convert.ToInt32(reader["Jaar"]));
                    ruimtebehoefteDTO.Leerlingen.Add(Convert.ToInt32(reader["Leerlingen"]));
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return ruimtebehoefteDTO;
        }

        private UitstralingDTO UitstralingOphalen(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            this.Connect();
            UitstralingDTO uitstralingDTO = new UitstralingDTO();
            try
            {
                string query = "SELECT * FROM Uitstraling WHERE AdviesId = @AdviesId";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    uitstralingDTO = new UitstralingDTO()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Score = Convert.ToInt32(reader["Score"]),
                        Opmerking = Convert.ToString(reader["Opmerking"])
                    };

                }

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return uitstralingDTO;
        }

        public void RuimtebehoefteVerwijderen(int id)
        {
            this.Connect();    
            try
            {
                string query = "delete from Ruimtebehoefte where Id = @Id";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
        }

        public void BeoordelingsformulierAanmaken(int gebouwId)
        {
            //eerst insert in advies
            //daarna met dat adviesId insert in de 6 categorien
            int adviesId = AdviesAanmaken(gebouwId);

            BouwkundigeStaatAanmaken(adviesId);
            EnergieVerbruikAanmaken(adviesId);
            OnderwijskundigeStaatAanmaken(adviesId);
            VeiligheidAanmaken(adviesId);
            RuimtebehoefteAanmaken(adviesId);
            UitstralingAanmaken(adviesId);
        }



        private int AdviesAanmaken(int gebouwId)
        {
            //insert is als eerst nodig voordat er antwoorden in kunnen worden gezet
            int adviesId = 0;
            this.Connect();
            try
            {
                string query = "INSERT INTO Advies (GebouwId) OUTPUT inserted.Id VALUES (@gebouwId);";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@gebouwId", gebouwId);
                adviesId = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return adviesId;
        }

        private void BouwkundigeStaatAanmaken(int adviesId)
        {
            this.Connect();
            try
            {
                string query = "INSERT INTO BouwkundigeStaat (AdviesId) VALUES (@adviesId);";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@adviesId", adviesId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
        }

        private void EnergieVerbruikAanmaken(int adviesId)
        {
            this.Connect();
            try
            {
                string query = "INSERT INTO EnergieVerbruik (AdviesId) VALUES (@adviesId);";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@adviesId", adviesId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
        }

        private void OnderwijskundigeStaatAanmaken(int adviesId)
        {
            this.Connect();
            try
            {
                string query = "INSERT INTO OnderwijskundigeStaat (AdviesId) VALUES (@adviesId);";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@adviesId", adviesId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
        }

        private void VeiligheidAanmaken(int adviesId)
        {
            this.Connect();
            try
            {
                string query = "INSERT INTO Veiligheid (AdviesId) VALUES (@adviesId);";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@adviesId", adviesId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
        }

        private void RuimtebehoefteAanmaken(int adviesId)
        {
            this.Connect();
            try
            {
                string query = "INSERT INTO Ruimtebehoefte (AdviesId) VALUES (@adviesId);";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@adviesId", adviesId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
        }

        private void UitstralingAanmaken(int adviesId)
        {
            this.Connect();
            try
            {
                string query = "INSERT INTO Uitstraling (AdviesId) VALUES (@adviesId);";
                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@adviesId", adviesId);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
        }

        public bool AdviesOpslaan(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            bool succes = false;
            this.Connect();
            try
            {
                string query = "UPDATE Advies SET [Datum] = @datum, [Status] = @status, [Score] = @score, [Opmerking] = @opmerking WHERE [Id] = @id;";
               // string query = "UPDATE Advies SET [Status] = @status, [Score] = @score, [Opmerking] = @opmerking WHERE [Id] = @id;";

                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@datum", beoordelingsformulierDTO.AdviesDTO.Datum);
                command.Parameters.AddWithValue("@status", beoordelingsformulierDTO.AdviesDTO.Status);
                command.Parameters.AddWithValue("@score", beoordelingsformulierDTO.AdviesDTO.Score);
                command.Parameters.AddWithValue("@opmerking", beoordelingsformulierDTO.AdviesDTO.Opmerking);
                command.Parameters.AddWithValue("@id", beoordelingsformulierDTO.Id);

                command.ExecuteNonQuery();
                succes = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                this.Disconnect();
            }
            return succes;
        }


        private AdviesDTO AdviesOphalen(BeoordelingsformulierDTO beoordelingsformulierDTO)
        {
            AdviesDTO advies = new AdviesDTO();
            this.Connect();
            try
            {
                string query = "SELECT * FROM Advies WHERE Id = @AdviesId";

                SqlCommand command = new SqlCommand(query, this.conn);
                command.Parameters.AddWithValue("@AdviesId", beoordelingsformulierDTO.Id);

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    advies = new AdviesDTO()
                    {
                        AdviesId = beoordelingsformulierDTO.Id,
                        Datum = Convert.ToDateTime(reader["Datum"]),
                        Status = Convert.ToBoolean(reader["Status"]),
                        GebouwId = Convert.ToInt32(reader["GebouwId"]),
                        Score = Convert.ToInt32(reader["Score"]),
                        Opmerking = reader["Opmerking"].ToString()
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
            return advies;
        }


    }
}

