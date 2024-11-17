namespace GolrangSystemFinalExam.Core.Domains.Common
{
    public abstract class BaseDomain
    {
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifyDate { get; set; }

        public int AutorId { get; set; }
    }
}
