using CS322_PZ.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CS322_PZ
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Server=localhost;Database=cs322_projekat;Uid=root;Pwd=Password123#;";

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static List<Kategorija> GetKategorije()
        {
            var kategorije = new List<Kategorija>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "SELECT ID, Naziv FROM Kategorije";
                var command = new MySqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        kategorije.Add(new Kategorija
                        {
                            ID = reader.GetInt32("ID"),
                            Naziv = reader.GetString("Naziv")
                        });
                    }
                }
            }

            return kategorije;
        }

        public static void AddKategorija(string naziv)
        {
            if (!Regex.IsMatch(naziv, @"^[a-zA-ZčČćĆđĐšŠžŽ\s]+$"))
            {
                throw new Exception("Naziv kategorije može sadržavati samo slova!");
            }

            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var query = "INSERT INTO Kategorije (Naziv) VALUES (@Naziv)";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Naziv", naziv);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Greška prilikom dodavanja kategorije: " + ex.Message);
                }
            }
        }

        public static void UpdateKategorija(int kategorijaId, string noviNaziv)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "UPDATE Kategorije SET Naziv = @Naziv WHERE ID = @ID";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Naziv", noviNaziv);
                command.Parameters.AddWithValue("@ID", kategorijaId);

                command.ExecuteNonQuery();
            }
        }

        public static void DeleteKategorija(int kategorijaId)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var query = "DELETE FROM Kategorije WHERE ID = @ID";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", kategorijaId);

                command.ExecuteNonQuery();
            }
        }


        public static List<Transakcija> GetTransakcije()
        {
            List<Transakcija> transakcije = new List<Transakcija>();

            using (var connection = GetConnection())
            {
                connection.Open();
                var query = @"
            SELECT t.ID, t.Datum, t.Iznos, t.Opis, t.KategorijaID, k.Naziv AS KategorijaNaziv
            FROM Transakcije t
            INNER JOIN Kategorije k ON t.KategorijaID = k.ID";

                var command = new MySqlCommand(query, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        transakcije.Add(new Transakcija
                        {
                            ID = reader.GetInt32("ID"),
                            Datum = reader.GetDateTime("Datum"),
                            Iznos = reader.GetDecimal("Iznos"),
                            Opis = reader.GetString("Opis"),
                            Kategorija = new Kategorija
                            {
                                ID = reader.GetInt32("KategorijaID"),
                                Naziv = reader.GetString("KategorijaNaziv")
                            }
                        });
                    }
                }
            }

            return transakcije;
        }



        public static void AddTransakcija(Transakcija transakcija)
        {
            if (transakcija.Iznos <= 0)
            {
                throw new Exception("Iznos mora biti veći od nule!");
            }

            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var query = "INSERT INTO Transakcije (Datum, Iznos, KategorijaID, Opis) VALUES (@Datum, @Iznos, @KategorijaID, @Opis)";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Datum", transakcija.Datum);
                    command.Parameters.AddWithValue("@Iznos", transakcija.Iznos);
                    command.Parameters.AddWithValue("@KategorijaID", transakcija.Kategorija.ID);
                    command.Parameters.AddWithValue("@Opis", transakcija.Opis);
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Greška prilikom dodavanja transakcije: " + ex.Message);
                }
            }
        }

        public static void UpdateTransakcija(int id, DateTime datum, decimal iznos, string kategorijaNaziv, string opis)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var kategorijaQuery = "SELECT ID FROM Kategorije WHERE Naziv = @Naziv";
                    var kategorijaCommand = new MySqlCommand(kategorijaQuery, connection);
                    kategorijaCommand.Parameters.AddWithValue("@Naziv", kategorijaNaziv);

                    var kategorijaID = Convert.ToInt32(kategorijaCommand.ExecuteScalar());
                    if (kategorijaID == 0)
                    {
                        throw new Exception("Kategorija nije pronađena!");
                    }
                    var query = "UPDATE Transakcije SET Datum = @Datum, Iznos = @Iznos, KategorijaID = @KategorijaID, Opis = @Opis WHERE ID = @ID";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Datum", datum);
                    command.Parameters.AddWithValue("@Iznos", iznos);
                    command.Parameters.AddWithValue("@KategorijaID", kategorijaID);
                    command.Parameters.AddWithValue("@Opis", opis);
                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Greška prilikom ažuriranja transakcije: " + ex.Message);
                }
            }
        }


        public static void DeleteTransakcija(DateTime datum, decimal iznos)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var query = "DELETE FROM Transakcije WHERE Datum = @Datum AND Iznos = @Iznos";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Datum", datum);
                    command.Parameters.AddWithValue("@Iznos", iznos);

                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Greška prilikom brisanja transakcije: " + ex.Message);
                }
            }
        }





    }
}
