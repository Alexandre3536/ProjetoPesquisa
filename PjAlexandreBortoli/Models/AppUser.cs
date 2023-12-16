using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace PjAlexandreBortoli.Models
{
    public enum Gender { Feminino, Masculino, Outros }
    public class AppUser : IdentityUser
    {
        [Required(ErrorMessage = "Nome requerido.")]
        [Display(Name = "Nome Completo")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Data de Nascimento requerido.")]
        [Display(Name = "Data de Nascimento")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Sexo/Gênero Requerido.")]
        [Display(Name = "Sexo/Gênero")]
        public Gender Gender { get; set; }

        public DateTime CreationDate { get; set; }

    }
}

