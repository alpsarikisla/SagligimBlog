using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace SagligimBlog.Yonetici
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            //pnl_basarili.Visible = false;
            //pnl_basarisiz.Visible = false;
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Kategori k = new Kategori();
                k.Isim = tb_isim.Text;

                if (dm.KategoriEkle(k))
                {
                    pnl_basarili.Visible = true;
                    pnl_basarisiz.Visible = false;
                    tb_isim.Text = "";
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Kategori eklenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_basarili.Visible = false;
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Kategori adı boş bırakılamaz";
            }
        }
    }
}