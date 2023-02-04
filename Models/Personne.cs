using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGLAtelelier2023.Models
{
    public class Personne
    {
        [Key]
        public int IdPers { get; set; }

        [Display(Name ="Nom"), MaxLength(80, ErrorMessage ="Taille maximale 80"), Required(ErrorMessage ="*")]
        public string NomPers { get; set; }

        [Display(Name = "Prénom"), MaxLength(80, ErrorMessage = "Taille maximale 80"), Required(ErrorMessage = "*")]
        public string PrenomPers { get; set; }

        [Display(Name = "Adresse"), MaxLength(150, ErrorMessage = "Taille maximale 150"), Required(ErrorMessage = "*")]
        public string AdressePers { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email"), MaxLength(150, ErrorMessage = "Taille maximale 150"), Required(ErrorMessage = "*")]
        public string EmailPers { get; set; }

        [DataType(DataType.PhoneNumber), RegularExpression("^([76-78]{2})([0-9]{7})$", ErrorMessage = "Le numéro doit commencer par (76|77|78) et 9 caracteres au total")]
        [Display(Name = "Téléphone"), MaxLength(20, ErrorMessage = "Taille maximale 20"), Required(ErrorMessage = "*")]
        public string TelPers { get; set; }

    }


    public class AuthLoginViewModel
    {
        [Key]
        public int IdPers { get; set; }

        [DataType(DataType.EmailAddress)]   
        [Display(Name = "Email"), MaxLength(150, ErrorMessage = "Taille maximale 150"), Required(ErrorMessage = "*")]
        public string EmailPers { get; set; }

        [DataType(DataType.PhoneNumber), RegularExpression("^([76-78]{2})([0-9]{7})$", ErrorMessage = "Le numéro doit commencer par (76|77|78) et 9 caracteres au total")]
        [Display(Name = "Téléphone"), MaxLength(20, ErrorMessage = "Taille maximale 20"), Required(ErrorMessage = "*")]
        public string TelPers { get; set; }
    } 
}