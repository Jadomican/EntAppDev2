using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using ForumAPI.Models;

namespace ForumAPI.Controllers
{
    [RoutePrefix("forum")]
    public class ForumController : ApiController
    {

        static List<Post> forum = new List<Post>() { };
        static int id = 1;

        [Route("all")]
        public IEnumerable<Post> GetAllPosts()
        {
            //Return all posts in Order of date
            return forum.OrderBy(p => p.TimeStamp).ToList();
        }

        [Route("post")]
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

        [Route("last/{numberToGet}")]
        public IHttpActionResult GetLastPosts(int numberToGet)
        {
            lock (forum)
            {
                var recents = forum.OrderByDescending(p => p.TimeStamp).Take(numberToGet);
                return Ok(recents.ToList());
            }
        }


        [HttpPost]
        [Route("")]
        public IHttpActionResult AddPost(Post post)
        {
            if (ModelState.IsValid)
            {
                //Check for existing ID
                var record = forum.SingleOrDefault(p => p.Id == post.Id);
                if (record == null)
                {
                    post.Id = id;
                    id++;           // Increase id after each add
                    post.TimeStamp = DateTime.Now;
                    forum.Add(post);
                    string uri = uri = Request.RequestUri.ToString() + "/id/" + post.Id;
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

        [HttpPut]
        [Route("")]
        public IHttpActionResult PutUpdatePost(Post post)
        {
            if (ModelState.IsValid)
            {

                var record = forum.SingleOrDefault(p => p.Id == post.Id);
                if (record == null)
                {
                    return NotFound();
                }
                else
                {
                    //record.Id = post.Id;
                    record.Message = post.Message;
                    record.Subject = post.Subject;
                    record.TimeStamp = DateTime.Now;    //Update time to now
                    return Ok(record);
                }

            }
            else
            {
                return BadRequest(ModelState);
            }

        }


        [HttpDelete]
        [Route("")]
        public IHttpActionResult DeletePost(int id)
        {
            var record = forum.SingleOrDefault(p => p.Id == id);
            if (record != null)
            {
                forum.Remove(record);
                return Ok(record);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
