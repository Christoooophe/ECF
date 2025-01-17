namespace ECF.Models
{
    public class Participant
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Age { get; set; }
        public List<EvenementParticipant>? Evenements { get; set; } = new List<EvenementParticipant>();
    }
}
