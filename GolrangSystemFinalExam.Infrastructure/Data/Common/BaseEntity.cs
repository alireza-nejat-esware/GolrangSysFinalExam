using System.ComponentModel.DataAnnotations.Schema;

namespace GolrangSystemFinalExam.Infrastructure.Data.Common
{
    public abstract class BaseEntity
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public int? AutorId { get; set; }

    }
}
