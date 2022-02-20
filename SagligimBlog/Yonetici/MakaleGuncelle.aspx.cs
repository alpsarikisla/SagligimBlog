using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace SagligimBlog.Yonetici
{
    public partial class MakaleGuncelle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    ddl_kategoriler.DataSource = dm.KategoriListele();
                    ddl_kategoriler.DataBind();
                    int id = Convert.ToInt32(Request.QueryString["abuzittin"]);
                    Makale m = dm.MakaleGetir(id);
                    tb_isim.Text = m.Baslik;
                    tb_ozet.Text = m.Ozet;
                    tb_icerik.Text = m.Icerik;
                    ddl_kategoriler.SelectedValue = Convert.ToString(m.Kategori_ID);
                    img_resim.ImageUrl = "../MakaleResimleri/" + m.KapakResim;
                    cb_yayinla.Checked = m.Durum;
                }
            }
            else
            {
                Response.Redirect("MakaleListele.aspx");
            }
        }

        protected void lbtn_guncelle_Click(object sender, EventArgs e)
        {
            bool uygunMu = true;
            int id = Convert.ToInt32(Request.QueryString["abuzittin"]);
            Makale m = dm.MakaleGetir(id);
            m.Baslik = tb_isim.Text;
            m.Icerik = tb_icerik.Text;
            m.Ozet = tb_ozet.Text;
            m.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedValue);
            m.Durum = cb_yayinla.Checked;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                string uzanti = fi.Extension;
                string dosyaadi = Guid.NewGuid() + uzanti;
                if (uzanti == ".png" || uzanti == ".jpg" || uzanti == ".jpeg")
                {
                    fu_resim.SaveAs(Server.MapPath("~/MakaleResimleri/" + dosyaadi));
                    m.KapakResim = dosyaadi;
                }
                else
                {
                    uygunMu = false;
                }
            }
            if (uygunMu)
            {
                if (dm.MakaleGuncelle(m))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Bir Hata Oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Dosya Uzantısı png,jpg veya jpeg olmalıdır";
            }
        }
    }
}