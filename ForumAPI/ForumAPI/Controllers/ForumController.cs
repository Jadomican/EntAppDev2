using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ForumAPI.Models;

namespace ForumAPI.Controllers
{
    public class ForumController : ApiController
    {

        static List<Post> forum = new List<Post>() { };
        static int id = 1;


        public IEnumerable<Post> GetAllPosts()
        {
            return forum;
        }


        public IHttpActionResult GetPost(int id)
        {
            var post = forum.FirstOrDefault((p) => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(post);
            }
        }

        [HttpPost]
        public IHttpActionResult AddPost(Post post)
        {
            if (ModelState.IsValid)
            {
                var record = forum.SingleOrDefault(p => p.Id == post.Id);
                if (record == null)
                {
                    post.Id = id;
                    id++;           // Increase id after each add
                    post.TimeStamp = DateTime.Now;
                    forum.Add(post);
                    string uri = Url.Link("DefaultAPI", new { name = post.Subject });
                    return Created(uri, post);
                }
                else
                {
                    return BadRequest("Post already exists");
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
