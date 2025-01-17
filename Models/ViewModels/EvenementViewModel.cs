using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECF.Models.ViewModels
{
    public class EvenementViewModel
    {
        public int EvenementId { get; set; }

        [Required]
        [DisplayName("Nom")]
        [StringLength(50, ErrorMessage = "Le nom de l'évènement est trop long")]
        public string EvenementName { get; set; }

        [Required]
        [DisplayName("Lieu")]
        [StringLength(50, ErrorMessage = "Le nom du lieu l'évènement est trop long")]
        public string EvenementLieu { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime EvenementDate { get; set; }
        public bool IsSelected { get; set; }
    }
}
