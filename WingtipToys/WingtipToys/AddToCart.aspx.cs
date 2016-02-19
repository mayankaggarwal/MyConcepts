using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Logic;

namespace WingtipToys
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["productId"];
            int productId;
            if(!String.IsNullOrEmpty(rawId) && int.TryParse(rawId,out productId))
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                }
            }
            else
            {
                Debug.Fail("Error : we should never get to AddToCart.aspx without a ProductId.");
                throw new Exception("Error : It is illegal to load AddToCart.aspx without setting a product Id.");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}