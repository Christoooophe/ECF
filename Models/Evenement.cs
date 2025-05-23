﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ECF.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Nom")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Le nom de l'évènement est trop long")]
        public string Nom { get; set; }
        [Required]
        [DisplayName("Lieu")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Le nom du lieu l'évènement est trop long")]
        public string Lieu { get; set; }
        [Required]
        [DisplayName("Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [DisplayName("Participants")]
        public List<EvenementParticipant>? Participants { get; set; } = new List<EvenementParticipant>();
    }
}
