using NinjaLaptops.Data;
using NinjaLaptops.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NinjaLaptops.WebClient.Controls
{
    public partial class ProductView : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.DetailsViewLaptop.DataSource = DataSource;
            this.DataBind();
        }

        public IEnumerable<Product> DataSource { get; set; }

    }
}