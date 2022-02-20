using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace SagligimBlog.Yonetici
{
    public partial class MakaleListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_makaleler.DataSource = dm.MakaleListele();
            lv_makaleler.DataBind();
        }

        protected void lv_makaleler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.MakaleSil(id);
            }
            if(e.CommandName == "durum")
            {
                dm.MakaleDurumDegistir(id);
            }
            lv_makaleler.DataSource = dm.MakaleListele();
            lv_makaleler.DataBind();
        }
    }
}