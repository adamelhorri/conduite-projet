using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistributionAPI
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int user_id { get; set; }
        public string? user_name { get; set; }
        public string? user_fname { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime user_dob { get; set; }
  
        public string? user_fidelity { get; set; }
        public string? user_email { get; set; }
        public string? user_password { get; set; }
        

    }
}