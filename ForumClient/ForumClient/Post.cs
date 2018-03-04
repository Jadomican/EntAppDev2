using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumClient
{
    public class Post
    {
        public String Subject { get; set; }
        public String Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Id { get; set; }
    }
}
