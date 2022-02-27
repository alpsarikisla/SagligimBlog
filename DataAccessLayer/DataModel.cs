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

        public bool KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
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

        public Kategori KategoriGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                Kategori k = new Kategori();

                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                }
                return k;
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

        public bool KategoriGuncelle(Kategori k)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim = @i WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", k.Isim);
                cmd.Parameters.AddWithValue("@id", k.ID);
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

        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Makaleler(KategoriID, YazarID, Baslik, Ozet, Icerik, KapakResim, GoruntulenmeSayisi, EklemeTarihi, Durum) VALUES(@kategoriID, @yazarID, @baslik, @ozet, @icerik, @kapakResim, @goruntulenmeSayisi, @eklemeTarihi, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@yazarID", mak.Yazar_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@goruntulenmeSayisi", mak.GoruntulemeSayisi);
                cmd.Parameters.AddWithValue("@eklemeTarihi", mak.EklemeTarih);
                cmd.Parameters.AddWithValue("@durum", mak.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Makale> MakaleListele()
        {
            try
            {
                List<Makale> makaleler = new List<Makale>();
                cmd.CommandText = "SELECT M.ID,M.KategoriID,K.Isim,M.YazarID,Y.Isim+' '+Y.Soyisim,M.Baslik,M.Ozet,M.Icerik,M.KapakResim,M.GoruntulenmeSayisi,M.EklemeTarihi,M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON K.ID = M.KategoriID JOIN Yoneticiler AS Y ON Y.ID = M.YazarID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Makale m = new Makale();
                    m.ID = reader.GetInt32(0);
                    m.Kategori_ID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.Yazar_ID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.KapakResim = reader.GetString(8);
                    m.GoruntulemeSayisi = reader.GetInt32(9);
                    m.EklemeTarih = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                    makaleler.Add(m);
                }
                return makaleler;
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

        public List<Makale> MakaleListele(int katid)
        {
            try
            {
                List<Makale> makaleler = new List<Makale>();
                cmd.CommandText = "SELECT M.ID,M.KategoriID,K.Isim,M.YazarID,Y.Isim+' '+Y.Soyisim,M.Baslik,M.Ozet,M.Icerik,M.KapakResim,M.GoruntulenmeSayisi,M.EklemeTarihi,M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON K.ID = M.KategoriID JOIN Yoneticiler AS Y ON Y.ID = M.YazarID WHERE M.KategoriID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", katid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Makale m = new Makale();
                    m.ID = reader.GetInt32(0);
                    m.Kategori_ID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.Yazar_ID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.KapakResim = reader.GetString(8);
                    m.GoruntulemeSayisi = reader.GetInt32(9);
                    m.EklemeTarih = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                    makaleler.Add(m);
                }
                return makaleler;
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

        public Makale MakaleGetir(int id)
        {
            try
            {
               
                cmd.CommandText = "SELECT M.ID,M.KategoriID,K.Isim,M.YazarID,Y.Isim+' '+Y.Soyisim, M.Baslik, M.Ozet, M.Icerik, M.KapakResim, M.GoruntulenmeSayisi, M.EklemeTarihi, M.Durum FROM Makaleler AS M JOIN Kategoriler AS K ON K.ID = M.KategoriID JOIN Yoneticiler AS Y ON Y.ID = M.YazarID WHERE M.ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Makale m = new Makale();
                while (reader.Read())
                {
                    
                    m.ID = reader.GetInt32(0);
                    m.Kategori_ID = reader.GetInt32(1);
                    m.Kategori = reader.GetString(2);
                    m.Yazar_ID = reader.GetInt32(3);
                    m.Yazar = reader.GetString(4);
                    m.Baslik = reader.GetString(5);
                    m.Ozet = reader.GetString(6);
                    m.Icerik = reader.GetString(7);
                    m.KapakResim = reader.GetString(8);
                    m.GoruntulemeSayisi = reader.GetInt32(9);
                    m.EklemeTarih = reader.GetDateTime(10);
                    m.Durum = reader.GetBoolean(11);
                }
                return m;
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

        public bool MakaleGuncelle(Makale mak)
        {
            try
            {
                cmd.CommandText = "UPDATE Makaleler SET KategoriID=@kategoriID, Baslik=@baslik, Ozet=@ozet, Icerik=@icerik, KapakResim=@kapakResim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", mak.ID);
                cmd.Parameters.AddWithValue("@kategoriID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResim", mak.KapakResim);
                cmd.Parameters.AddWithValue("@durum", mak.Durum);
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

        public bool MakaleSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Makaleler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
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

        public bool MakaleDurumDegistir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Makaleler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = (bool)cmd.ExecuteScalar();
                cmd.CommandText = "UPDATE Makaleler SET Durum=@d WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("d", !durum);
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



        #endregion

        #region Uye Metotları

        public Uye UyeGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Email=@m AND Sifre=@s";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@m", mail);
                cmd.Parameters.AddWithValue("@s", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());

                if (sayi == 1)
                {
                    cmd.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Email, Sifre, UyelikTarihi, Durum FROM Uyeler WHERE Email=@m AND Sifre=@s";
                         cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@m", mail);
                    cmd.Parameters.AddWithValue("@s", sifre);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Uye u = new Uye();
                    while (reader.Read())
                    {
                        u.ID = reader.GetInt32(0);
                        u.Isim = reader.GetString(1);
                        u.Soyad = reader.GetString(2);
                        u.KullaniciAdi = reader.GetString(3);
                        u.Mail = reader.GetString(4);
                        u.Sifre = reader.GetString(5);
                        u.UyelikTarihi = reader.GetDateTime(6);
                        u.Durum = reader.GetBoolean(7);
                    }
                    return u;
                }
                else
                {
                    return null;
                }
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

        #region Yorum Metotları

        public List<Yorum> YorumListele()
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.MakaleID, M.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Makaleler AS M ON M.ID=Y.MakaleID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.MakaleID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
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

        public List<Yorum> YorumListele(int Mid)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.MakaleID, M.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Makaleler AS M ON M.ID=Y.MakaleID WHERE Y.MakaleID = @id AND Y.OnayDurum = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", Mid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.MakaleID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
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

        public List<Yorum> YorumListele(bool onay)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.UyeID, U.KullaniciAdi, Y.MakaleID, M.Baslik, Y.Icerik, Y.YorumTarihi, Y.OnayDurum FROM Yorumlar AS Y JOIN Uyeler AS U ON U.ID = Y.UyeID JOIN Makaleler AS M ON M.ID=Y.MakaleID WHERE Y.OnayDurum = @d";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@d", onay);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum y = new Yorum();
                    y.ID = reader.GetInt32(0);
                    y.UyeID = reader.GetInt32(1);
                    y.Uye = reader.GetString(2);
                    y.MakaleID = reader.GetInt32(3);
                    y.Baslik = reader.GetString(4);
                    y.Icerik = reader.GetString(5);
                    y.Tarih = reader.GetDateTime(6);
                    y.Durum = reader.GetBoolean(7);
                    yorumlar.Add(y);
                }
                return yorumlar;
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

        public bool YorumEkle(Yorum y)
        {
            try
            {
                cmd.CommandText = "INSERT INTO yorumlar(UyeID, MakaleID, Icerik, YorumTarihi, OnayDurum) VALUES(@uyeID, @makaleID,@icerik, @yorumTarihi, @onayDurum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@uyeID", y.UyeID);
                cmd.Parameters.AddWithValue("@makaleID", y.MakaleID);
                cmd.Parameters.AddWithValue("@icerik", y.Icerik);
                cmd.Parameters.AddWithValue("@yorumTarihi", y.Tarih);
                cmd.Parameters.AddWithValue("@onayDurum", y.Durum);
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

        #endregion
    }
}
