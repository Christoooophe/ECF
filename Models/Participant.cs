using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ECF.Models
{
    public class Participant
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Nom")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Le nom est trop long")]
        public string Nom { get; set; }
        [Required]
        [DisplayName("Prénom")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Le prénnom est trop long")]
        public string Prenom { get; set; }
        [Required]
        [DisplayName("Age")]
        [Range(16, 99, ErrorMessage = "L'age doit être compris entre 16 et 99 ans")]
        public int Age { get; set; }
        [DisplayName("Evenements")]
        public List<EvenementParticipant>? Evenements { get; set; } = new List<EvenementParticipant>();
    }
}
