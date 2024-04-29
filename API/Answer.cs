using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DistributionAPI
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configure as an identity column

        public int? answer_id { get; set; }

        [ForeignKey("User")]
        [Column("user_id")] // Specify the actual column name in your database
        public int? user_id { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Question")]
        [Column("question_id")] // Specify the actual column name in your database
        public int? question_id { get; set; }
        public virtual Question question { get; set; }

    }
}
