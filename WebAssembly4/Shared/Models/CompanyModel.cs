namespace TaskEvidence.Models
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int State { get; set; } // 1 active, 2 removed
    }
}
