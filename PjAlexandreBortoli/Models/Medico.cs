using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;


namespace PjAlexandreBortoli.Models
{
    public class Medico
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome requerido")]
        [Display(Name = "Nome")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "CRM requerido.")]
        [Display(Name = "CRM")]
        public string? CRM { get; set; }

        [Required(ErrorMessage = "Está liberado?")]
        [Display(Name = "Liberado")]
        public Boolean Released { get; set; }


        [ForeignKey("User")]
        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}
