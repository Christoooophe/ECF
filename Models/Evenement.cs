namespace ECF.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Lieu { get; set; }
        public DateTime Date { get; set; }
        public List<EvenementParticipant>? Participants { get; set; } = new List<EvenementParticipant>();
    }
}
