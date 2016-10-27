using System;

using System.Collections;
using System.Text;


public partial class Pages_Home : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        FillPage();
    }

    private void FillPage()
    {
        ArrayList productList = new ArrayList();

        if (!IsPostBack)
        {
            productList = ConnectionClass.GetProductByType("%");
        }
        else
        {
            productList = ConnectionClass.GetProductByType(DropDownList1.SelectedValue);
        }

        StringBuilder sb = new StringBuilder();

        foreach (Product product in productList)
        {
            sb.Append(
                string.Format(
                    @"<table class='productTable'>
            <tr>
                <th rowspan='4' width='150px'><img runat='server' src='{4}' /></th>
                <th width='50px'>Name: </td>
                <td>{0}</td>
            </tr>

            <tr>
                <th>Type: </th>
                <td>{1}</td>
            </tr>

            <tr>
                <th>Price: </th>
                <td>${2} </td>
            </tr>


            
            <tr>
                <th> Description:  </th>
                <td colspan='2'>{3}</td>
            </tr>           
            
           </table>",
                    product.Name, product.Type, product.Price, product.Description, product.Image));


            Label1.Text = sb.ToString();
        }


    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillPage();
    }


}
