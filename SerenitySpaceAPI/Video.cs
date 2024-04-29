using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int video_id { get; set; }
        public string? video_url { get; set; }
        public string? video_type { get; set; }

        }
    
