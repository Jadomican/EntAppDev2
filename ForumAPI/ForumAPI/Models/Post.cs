using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace ForumAPI.Models
{
    public class Post
    {
        [Required]
        [MinLength(1), MaxLength(25)]
        public String Subject { get; set; }

        [Required]
        [MaxLength(100)]
        public String Message { get; set; }

        public DateTime TimeStamp { get; set; }

        public int Id { get; set; }

    }
}