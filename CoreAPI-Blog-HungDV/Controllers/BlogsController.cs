using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoreAPI_Blog_HungDV.Dal;
using CoreAPI_Blog_HungDV.Models;
using CoreAPI_Blog_HungDV.Repository;

namespace CoreAPI_Blog_HungDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BaseRepository blogRepository;

        /// <summary>
        /// Initialization Blog Controller
        /// </summary>
        /// <param name="context"></param>
        public BlogsController(EntityContext context)
        {
            blogRepository = new BlogRepository(context);
        }

        /// <summary>
        /// Get list Blogs in API
        /// GET: api/Blogs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            //return await _context.Blogs.ToListAsync();
            List<Blog> listBlog = new List<Blog>();
            foreach(Object obj in await blogRepository.GetAllEntityAsync())
            {
                listBlog.Add(obj as Blog);
            }
            return listBlog;
        }

        /// <summary>
        /// get Blog in API
        /// GET: api/Blogs/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Blog</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            return await blogRepository.GetEntityByIdAsync(id) as Blog;
        }

        /// <summary>
        /// Update API
        /// PUT: api/Blogs/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Blog"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            try
            {
                await blogRepository.UpdateEntityAsync(id, blog);
            }
            catch
            {
                
            }
            return NoContent();
        }

        /// <summary>
        /// Create new Blog
        /// POST: api/Blogs
        /// </summary>
        /// <param name="blog"></param>
        /// <returns>Blog</returns>
        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            return await blogRepository.CreateEntityAsync(blog) as Blog;
        }

        /// <summary>
        /// Delete Blog on API
        /// DELETE: api/Blogs/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            try
            {
                await blogRepository.DeleteEntity(id);
            }
            catch
            {

            }
            return NoContent();
        }
    }
}
