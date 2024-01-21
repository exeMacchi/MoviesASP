using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class Form : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Styles(this);
            if (!IsPostBack)
            {
                Initialize(this);

                // Si se está modificando una película, se rellena el formulario con su
                // información
                if (Request.QueryString["id"] != null)
                {
                    Movie movie = ((List<Movie>)Session["movies"]).Find(m => m.ID == int.Parse(Request.QueryString["id"]));
                    if (movie != null)
                    {
                        txbxTitle.Text = movie.Title;
                        txbxDirector.Text = movie.Director;
                        txbxSynopsis.Text = movie.Synopsis;
                        txbxRelease.Text = movie.Release.ToString("yyyy-MM-dd");
                        switch (movie.Rating)
                        {
                            case 1: rb1.Checked = true; break;
                            case 2: rb2.Checked = true; break;
                            case 3: rb3.Checked = true; break; 
                            case 4: rb4.Checked = true; break;
                            case 5: default: rb5.Checked = true; break;
                            case 6: rb6.Checked = true; break;
                            case 7: rb7.Checked = true; break;
                            case 8: rb8.Checked = true; break;
                            case 9: rb9.Checked = true; break;
                            case 10: rb10.Checked = true; break;
                        }
                        ckbxOscar.Checked = movie.Oscar;
                    }
                }
            }
        }

        /// <summary>
        /// Agregar una nueva película o modificar una ya existente según el contexto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Submit_Click(object sender, EventArgs e)
        {
            // Modificar película: se toma referencia de la película a modificar y se
            // actualiza su información.
            if (Request.QueryString["id"] != null)
            {
                Movie movie = ((List<Movie>)Session["movies"]).Find(m => m.ID == int.Parse(Request.QueryString["id"]));
                movie.Title = txbxTitle.Text;
                movie.Director = txbxDirector.Text;
                movie.Synopsis = txbxSynopsis.Text;
                movie.Release = DateTime.Parse(txbxRelease.Text);
                movie.Rating = Session["rating"] != null ? int.Parse(Session["rating"].ToString()) : 5;
                movie.Oscar = ckbxOscar.Checked;
            }
            // Agregar película: se crea una nueva película y se agrega a la lista.
            else
            {
                int id = 0;

                // Si hay lista en sesión y esta tiene mínimo un elemento, el id de la
                // nueva película el id del último elemento más 1.
                if (Session["Movies"] != null && ((List<Movie>)Session["movies"]).Count > 0)
                {
                    List<Movie> movieList = (List<Movie>)Session["movies"];
                    id = movieList[movieList.Count - 1].ID + 1;
                }

                string title = txbxTitle.Text;
                string director = txbxDirector.Text;
                string synopsis = txbxSynopsis.Text;
                DateTime release = DateTime.Parse(txbxRelease.Text);
                int rating = Session["rating"] != null ? int.Parse(Session["rating"].ToString()) : 5;
                bool oscar = ckbxOscar.Checked; 

                Movie newMovie = new Movie(id, title, director, synopsis, release, rating, oscar);
                if (Session["movies"] != null)
                {
                   ((List<Movie>) Session["movies"]).Add(newMovie);
                }
            }
            Response.Redirect("Default.aspx");
        }

        /// <summary>
        /// Inicializar algunos controles y elementos de sesión.
        /// </summary>
        /// <param name="form"></param>
        private static void Initialize(Form form)
        {
            form.btAdd.Enabled = false;

            // Modificar película (rating)
            if (form.Request.QueryString["id"] != null)
            {
                Movie movie = ((List<Movie>)form.Session["movies"]).Find(m => m.ID == int.Parse(form.Request.QueryString["id"]));
                if (movie != null)
                {
                    form.Session["rating"] = movie.Rating;
                }
                else
                {
                    form.Session["rating"] = 5;
                }
            }
            // Agregar película (rating)
            else
            {
                form.Session["rating"] = 5;
            }
        }

        /// <summary>
        /// Establecer los estilos de los controles del formulario.
        /// </summary>
        /// <param name="form">Referencia del actual formulario</param>
        private static void Styles(Form form)
        {
            form.rb1.InputAttributes["class"] = "form-check-input me-3";
            form.rb2.InputAttributes["class"] = "form-check-input me-3";
            form.rb3.InputAttributes["class"] = "form-check-input me-3";
            form.rb4.InputAttributes["class"] = "form-check-input me-3";
            form.rb5.InputAttributes["class"] = "form-check-input me-3";
            form.rb6.InputAttributes["class"] = "form-check-input me-3";
            form.rb7.InputAttributes["class"] = "form-check-input me-3";
            form.rb8.InputAttributes["class"] = "form-check-input me-3";
            form.rb9.InputAttributes["class"] = "form-check-input me-3";
            form.rb10.InputAttributes["class"] = "form-check-input me-3";
            form.ckbxOscar.InputAttributes["class"] = "form-check-input";
        }

        /// <summary>
        /// Actualizar el rating actual en un elemento de sesión, el cual sirve cuando
        /// se cree o se actualice una película
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Session["rating"] != null)
            {
                RadioButton rb = (RadioButton) sender;
                Session["rating"] = int.Parse(rb.Text);
            }
        }

        /// <summary>
        /// Verificar si se debe activar o desactivar el botón de agregar/modificar según
        /// haya o no información en los controles requeridos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void VerifyInformation(object sender, EventArgs e)
        {
            if (txbxTitle.Text != "" && txbxDirector.Text != "" && txbxSynopsis.Text != "" && txbxRelease.Text != "")
            {
                btAdd.Enabled = true;
                btModify.Enabled = true;
            }
            else
            {
                btAdd.Enabled = false;
                btModify.Enabled = false;
            }
        }
    }
}