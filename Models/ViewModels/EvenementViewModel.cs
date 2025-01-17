namespace ECF.Models.ViewModels
{
    public class EvenementViewModel
    {
        public int EvenementId { get; set; }
        public string EvenementName { get; set; }
        public string EvenementLieu { get; set; }
        public DateTime EvenementDate { get; set; }
        public bool IsSelected { get; set; }
    }
}
