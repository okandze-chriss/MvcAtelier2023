using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcGLAtelelier2023.Models
{
    public class Client
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdPers { get; set; }
        [Display(Name ="Sexe"), Required(ErrorMessage ="*"), MaxLength(10, ErrorMessage ="*")]
        public string Sexe { get; set; }
        [Display(Name = "Statut inscription")]
        public bool StatutInscription{ get; set; }

        [Display(Name = "Statut")]
        public bool Statut { get; set; }

    }

    public class ClientViewModel
    {
        [Key]
        public int IdPers { get; set; }

        [Display(Name = "Nom"), MaxLength(80, ErrorMessage = "Taille maximale 80"), Required(ErrorMessage = "*")]
        public string NomPers { get; set; }

        [Display(Name = "Prénom"), MaxLength(80, ErrorMessage = "Taille maximale 80"), Required(ErrorMessage = "*")]
        public string PrenomPers { get; set; }

        [Display(Name = "Adresse"), MaxLength(150, ErrorMessage = "Taille maximale 150"), Required(ErrorMessage = "*")]
        public string AdressePers { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email"), MaxLength(150, ErrorMessage = "Taille maximale 150"), Required(ErrorMessage = "*")]
        public string EmailPers { get; set; }

        //[DataType(DataType.PhoneNumber)]
        [Display(Name = "Téléphone"), MaxLength(20, ErrorMessage = "Taille maximale 20"), Required(ErrorMessage = "*")]
        public string TelPers { get; set; }

        [Display(Name = "Sexe"), Required(ErrorMessage = "*"), MaxLength(10, ErrorMessage = "*")]
        public string Sexe { get; set; }


    }


}