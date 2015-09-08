using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PDM.View
{
    public partial class EditaProjeto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            literal1.Text = literal1.Text + addContent();
        }
        public string addContent()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<h3>Corpo do documento</h3>");
            sb.AppendLine("<p>Aqui fica o conteúdo da página. Podemos inserir várias tags HTML, como listas:</p>");
            sb.AppendLine("<ul>");
            sb.AppendLine("<li><input type='text' runat='server' /></li>");
            sb.AppendLine("<li><asp:Button ID='btn1' runat='server' /></li>");
            sb.AppendLine("</ul>");
            return sb.ToString();
        }
    }
}