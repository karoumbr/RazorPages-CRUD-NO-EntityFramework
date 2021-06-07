using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using RazorPages_CRUD_NO_EntityFramework.Models;


namespace RazorPages_CRUD_NO_EntityFramework.Pages
{
    public class IndexModel : PageModel
    {
        public IEnumerable<EtudiantClass> ListeEtudiants { get; set; }
        //private readonly ILogger<IndexModel> _logger;

        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        public void OnGet()
        {
            ListeEtudiants = AfficherListeEtudiants();
        }

        public static List<EtudiantClass> AfficherListeEtudiants()
        {
            List<EtudiantClass> ListeEtud = new List<EtudiantClass>();
            string cs = "Data Source=localhost;Initial Catalog=searchdb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                using(SqlCommand cmd = new SqlCommand("select * from Etudiant", con))
                {
                    con.Open();
                    using (SqlDataReader lecteur = cmd.ExecuteReader())
                    {
                        while (lecteur.Read())
                        {
                            EtudiantClass ec = new EtudiantClass();
                            ec.id = Convert.ToInt32(lecteur["id"]);
                            ec.nom = Convert.ToString(lecteur["nom"]);
                            ec.email = Convert.ToString(lecteur["email"]);
                            ec.datenaissance = Convert.ToDateTime(lecteur["datenaissance"]);
                            ec.sexe = Convert.ToChar(lecteur["sexe"]);
                            ListeEtud.Add(ec);
                        }
                    }
                    return ListeEtud;
                }
            }
        }

        public IActionResult OnPostAsync(EtudiantClass ec)
        {
            string cs = "Data Source=localhost;Initial Catalog=searchdb;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(cs))
            {
                string req = "insert into Etudiant values ('" + ec.nom + "','" + ec.email + "','" + ec.datenaissance + "','" + ec.sexe + "')";
                using (SqlCommand cmd = new SqlCommand(req, con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return RedirectToPage("Index");
        }
       
    }
}
