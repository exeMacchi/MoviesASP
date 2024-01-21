using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Vista
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["movies"] == null)
                    Session["movies"] = MovieBBL.GetMovieList();
            }

            if (((List<Movie>) Session["movies"]).Count > 0)
            {
                gvMovies.DataSource = Session["movies"];
                gvMovies.DataBind();
            }
            else
            {
                alertEmtpy.Visible = true;
            }
        }

        /* Este evento sirve para darle estilos al input que crea <asp:CheckBox */
        protected void gvMovies_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox checkBox = (CheckBox)e.Row.FindControl("ckbxOscar");
                
                if (checkBox != null)
                {
                    checkBox.InputAttributes["class"] = "form-check-input";
                }
            }
        }

        protected void gvMovies_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvMovies.SelectedDataKey.Value.ToString();
            Response.Redirect($"Form.aspx?id={id}", false);
        }

        protected void gvMovies_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int movieIndex = Convert.ToInt32(gvMovies.DataKeys[e.RowIndex].Value);
            List<Movie> movieList = (List<Movie>)Session["movies"];

            if (movieIndex >= 0)
            {
                movieList.RemoveAll(m => m.ID == movieIndex);
            }

            if (movieList.Count > 0)
            {
                gvMovies.DataSource = Session["movies"];
                gvMovies.DataBind();
            }
            else
            {
                alertEmtpy.Visible = true;
                gvMovies.DataSource = Session["movies"];
                gvMovies.DataBind();
            }
        }
    }
}