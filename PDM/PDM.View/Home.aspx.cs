using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDM.BusinessLayer;
using PDM.DataObjects;

namespace PDM.View
{
    public partial class Home : System.Web.UI.Page
    {
        public static bool userLogged = false;
        protected void page_Init(object sender, EventArgs e)
        {
            if (Session["email"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                carregaInformativo();
            }
        }
        public void carregaInformativo()
        {
            string email = Session["email"].ToString();
            Usuario u = new Usuario();
            UsuarioBL ubl = new UsuarioBL();
            u = ubl.buscaUsuarioAtivo(email);
            ProjetoBL pbl = new ProjetoBL();
            TarefaBL tbl = new TarefaBL();
            int totaProj = 0, totalTask = 0;
            double projPend = 0, projConc = 0, TaskPend = 0, taskConc = 0;
            try
            {
                totaProj = pbl.contaProjetosEmpresa(u.idEmpresa, "");
                projPend = (pbl.contaProjetosEmpresa(u.idEmpresa, "AND status <> 2 AND status <> 3") * 100) / totaProj;
                projConc = (pbl.contaProjetosEmpresa(u.idEmpresa, "AND status <> 0 AND status <> 1") * 100) / totaProj;
                totalTask = tbl.contaTarefasEmpresa(u.idEmpresa, "");
                TaskPend = (tbl.contaTarefasEmpresa(u.idEmpresa, "AND status <> 2 AND status <> 3") * 100) / totalTask;
                taskConc = (tbl.contaTarefasEmpresa(u.idEmpresa, "AND status <> 0 AND status <> 1") * 100) / totalTask;

                lblQntProj.Text = totaProj.ToString();
                lblProjPendente.Text = projPend.ToString();
                lblProjFim.Text = projConc.ToString();
                lblTotalTarefas.Text = totalTask.ToString();
                lblTarefaTotal.Text = TaskPend.ToString();
                lblTarefaExec.Text = taskConc.ToString();
            }
            catch (Exception ex)
            {
                lblQntProj.Text = "0";
                lblProjPendente.Text = "0";
                lblProjFim.Text = "0";
                lblTotalTarefas.Text = "0";
                lblTarefaTotal.Text = "0";
                lblTarefaExec.Text = "0";
            }
        }
    }
}