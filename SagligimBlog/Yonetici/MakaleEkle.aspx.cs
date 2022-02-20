using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.IO;

namespace SagligimBlog.Yonetici
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataSource = dm.KategoriListele();
                ddl_kategoriler.DataBind();
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            bool resimformat = false;
            Makale mak = new Makale();
            mak.Baslik = tb_isim.Text;
            mak.Ozet = tb_ozet.Text;
            mak.Icerik = tb_icerik.Text;
            mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            mak.Durum = cb_yayinla.Checked;
            DataAccessLayer.Yonetici y = (DataAccessLayer.Yonetici)Session["yonetici"];
            mak.EklemeTarih = DateTime.Now;
            mak.Yazar_ID = y.ID;

            if (fu_resim.HasFile)//Resim Seçilmiş ise
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;//.jpg,.png
                if (uzanti == ".jpg" || uzanti == ".png")
                {
                    string resimadi = Guid.NewGuid() + uzanti;
                    fu_resim.SaveAs(Server.MapPath("~/MakaleResimleri/" + resimadi));
                    mak.KapakResim = resimadi;
                    resimformat = true;
                }
            }
            else
            {
                mak.KapakResim = "none.png";
            }
            if (resimformat)
            {
                if (dm.MakaleEkle(mak))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Hatasız Kul OLmaz!!!";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya Uzantısı jpg veya png olmalıdır";
            }
        }
    }
}