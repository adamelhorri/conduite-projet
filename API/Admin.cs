using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DistributionAPI
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int admin_id { get; set; }
        public string? admin_name { get; set; }
        public string? admin_fname { get; set; }
        public string? admin_email { get; set; }
        public string? admin_password { get; set; }


    }
}