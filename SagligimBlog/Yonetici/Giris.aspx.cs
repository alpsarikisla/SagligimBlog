using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace SagligimBlog.Yonetici
{
    public partial class Giris : System.Web.UI.Page
    {
        DataModel db = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tb_mail.Text) && !string.IsNullOrEmpty(tb_sifre.Text))
            {
                string mail = tb_mail.Text;
                string sifre = tb_sifre.Text;

                DataAccessLayer.Yonetici y = db.YoneticiGiris(mail, sifre);
                if (y != null)
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lbl_mesaj.Text = "Kullanıcı Bulunamadı";
                    pnl_hata.Visible = true;
                }
            }
            else
            {
                lbl_mesaj.Text = "Mail ve Şifre Boş Bırakılamaz";
                pnl_hata.Visible = true;
            }
        }
    }
}