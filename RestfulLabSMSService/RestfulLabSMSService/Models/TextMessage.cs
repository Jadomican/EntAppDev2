using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RestfulLabSMSService.Models
{
    public class TextMessage
    {

        [Required]
        public String SourceNumber { get; set; }

        [Required]
        public String DestinationNumber { get; set; }

        [MinLength(1)]
        [MaxLength(140)]
        public String Content { get; set; }


    }
}