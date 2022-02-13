using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SagligimBlog.Yonetici
{
    public partial class KategoriListeleGridView : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            gv_kategoriler.DataSource = dm.KategoriListele();
            gv_kategoriler.DataBind();//Data bind edilmeden veriler sayfada gösterilmez
        }
    }
}