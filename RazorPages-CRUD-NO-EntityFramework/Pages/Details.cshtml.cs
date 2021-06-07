using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using RazorPages_CRUD_NO_EntityFramework.Models;


namespace RazorPages_CRUD_NO_EntityFramework.Pages
{
    public class DetailsModel : PageModel
    {
        [BindProperty]
        public EtudiantClass ListeEtudiants { get; set; }
        public void OnGet(int _id)
        {
            EtudiantClass ec = new EtudiantClass();
            string cs = "Data Source=localhost;Initial Catalog=searchdb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Etudiant where id='" + _id + "'", con))
                {
                    con.Open();
                    using (SqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        while (lecteur.Read())
                        {
                           
                            ec.id = Convert.ToInt32(lecteur["id"]);
                            ec.nom = Convert.ToString(lecteur["nom"]);
                            ec.email = Convert.ToString(lecteur["email"]);
                            ec.datenaissance = Convert.ToDateTime(lecteur["datenaissance"]);
                            ec.sexe = Convert.ToChar(lecteur["sexe"]);
                           
                        }
                    }
                    ListeEtudiants=ec;
                }
            }
        }
    }
}
