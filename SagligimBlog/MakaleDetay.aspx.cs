using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace SagligimBlog
{
    public partial class MakaleDetay : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["mid"]);
                Makale m = dm.MakaleGetir(id);
                ltrl_baslik.Text = m.Baslik;
                ltrl_icerik.Text = m.Icerik;
                ltrl_kategori.Text = m.Kategori;
                ltrl_yazar.Text = m.Yazar;
                img_resim.ImageUrl = "MakaleResimleri/" + m.KapakResim;
                if (Session["uye"] != null)
                {
                    pnl_girisVar.Visible = true;
                    pnl_girisyok.Visible = false;
                }
                else
                {
                    pnl_girisVar.Visible = false;
                    pnl_girisyok.Visible = true;
                }
                rp_yorumlar.DataSource = dm.YorumListele(id);
                rp_yorumlar.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void lbtn_yorumYap_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);
            Yorum y = new Yorum();
            y.MakaleID = id;
            y.UyeID = ((Uye)Session["uye"]).ID;
            y.Icerik = tb_yorum.Text;
            y.Tarih = DateTime.Now;
            y.Durum = false;

            if (dm.YorumEkle(y))
            {
                Response.Write("<script>alert('Yorum Alındı. Onay Sonrasında yayınlanacaktır')</script>");
            }
            else
            {
                Response.Write("<script>alert('BecereMedic')</script>");
            }
        }
    }
}