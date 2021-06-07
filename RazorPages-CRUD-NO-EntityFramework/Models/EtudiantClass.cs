using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RazorPages_CRUD_NO_EntityFramework.Models
{
    public class EtudiantClass
    {
        [Key]
        public int id { get; set; }
        public string nom { get; set; }
        public string email { get; set; }
        public DateTime datenaissance { get; set; }
        public char sexe { get; set; }
    }
}
