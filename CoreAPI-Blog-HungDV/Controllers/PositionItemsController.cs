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
    public class PositionItemsController : ControllerBase
    {
        private readonly BaseRepository positionItemRepository;

        /// <summary>
        /// Initialization PositionItems Controller
        /// </summary>
        /// <param name="context"></param>

        public PositionItemsController(EntityContext context)
        {
            positionItemRepository = new PositionItemRepository(context);
        }

        /// <summary>
        /// get list PositionItem in API
        /// GET: api/PositionItems
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionItem>>> GetPositionItems()
        {
            List<PositionItem> listPositionItem = new List<PositionItem>();
            foreach (Object obj in await positionItemRepository.GetAllEntityAsync())
            {
                listPositionItem.Add(obj as PositionItem);
            }
            return listPositionItem;
        }


        /// <summary>
        /// get PositionItem in API
        /// GET: api/PositionItems/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns>PositionItem</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionItem>> GetPositionItem(int id)
        {
            return await positionItemRepository.GetEntityByIdAsync(id) as PositionItem;
        }

        /// <summary>
        /// Update API
        /// PUT: api/PositionItems/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="positionItem"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPositionItem(int id, PositionItem positionItem)
        {
            try
            {
                await positionItemRepository.UpdateEntityAsync(id, positionItem);
            }
            catch
            {

            }
            return NoContent();
        }

        /// <summary>
        /// Create new positionItem
        /// POST: api/PositionItems
        /// </summary>
        /// <param name="positionItem"></param>
        /// <returns>PositionItem</returns>
        [HttpPost]
        public async Task<ActionResult<PositionItem>> PostPositionItem(PositionItem positionItem)
        {
            return await positionItemRepository.CreateEntityAsync(positionItem) as PositionItem;
        }

        /// <summary>
        /// Delete PositionItem on API
        /// DELETE: api/PositionItems/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePositionItem(int id)
        {
            try
            {
                await positionItemRepository.DeleteEntity(id);
            }
            catch
            {

            }
            return NoContent();
        }
    }
}
