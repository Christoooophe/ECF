namespace ECF.Models
{
    public class StatistiquesDatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string StatistiquesCollectionName { get; set; } = null!;
    }
}
