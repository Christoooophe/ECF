using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECF.Models.ViewModels
{
    public class ParticipantViewModel
    {
        public int ParticipantId { get; set; }

        [Required]
        [DisplayName("Nom")]
        [StringLength(50, ErrorMessage = "Le nom est trop long")]
        public string ParticipantName { get; set; }

        [Required]
        [DisplayName("Prénom")]
        [StringLength(50, ErrorMessage = "Le prénnom est trop long")]
        public string ParticipantFirstName { get; set; }

        [Required]
        [DisplayName("Age")]
        [Range(16, 99, ErrorMessage = "L'age doit être compris entre 16 et 99 ans")]
        public int Age { get; set; }

        [DisplayName("Evenements")]
        public List<EvenementViewModel>? Evenements { get; set; }
    }
}
