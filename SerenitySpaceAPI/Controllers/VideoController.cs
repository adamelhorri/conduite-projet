using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DistributionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly YourDbContext _context;

        public VideosController(YourDbContext context)
        {
            _context = context;
        }

        // GET: api/Videos
        [HttpGet]
        public ActionResult<IEnumerable<Video>> GetVideos()
        {
            return _context.Videos.ToList();
        }

        // GET: api/Videos/5
        [HttpGet("{id}")]
        public ActionResult<Video> GetVideo(int id)
        {
            var video = _context.Videos.Find(id);

            if (video == null)
            {
                return NotFound();
            }

            return video;
        }

        // POST: api/Videos
        [HttpPost]
        public ActionResult<Video> PostVideo(Video video)
        {
            _context.Videos.Add(video);
            _context.SaveChanges();

            return CreatedAtAction("GetVideo", new { id = video.video_id }, video);
        }

        // PUT: api/Videos/5
        [HttpPut("{id}")]
        public IActionResult PutVideo(int id, Video video)
        {
            if (id != video.video_id)
            {
                return BadRequest();
            }

            _context.Entry(video).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Videos/5
        [HttpDelete("{id}")]
        public IActionResult DeleteVideo(int id)
        {
            var video = _context.Videos.Find(id);
            if (video == null)
            {
                return NotFound();
            }

            _context.Videos.Remove(video);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
