using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Yonetici Metotları

        public Yonetici YoneticiGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE EMail=@m AND Sifre = @s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT ID,YoneticiTurID,Isim,Soyisim,EMail,Sifre,Durum FROM Yoneticiler WHERE EMail=@m AND Sifre = @s";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = null;
                    while (reader.Read())
                    {
                        y = new Yonetici();
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTurID = reader.GetInt32(1);
                        y.Isim = reader.GetString(2);
                        y.SoyIsim = reader.GetString(3);
                        y.Mail = reader.GetString(4);
                        y.Sifre = reader.GetString(5);
                        y.Durum = reader.GetBoolean(6);
                    }
                    return y;
                }
                else
                {
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori k)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim) VALUES(@i)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", k.Isim);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();

                cmd.CommandText = "SELECT ID, Isim FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}
