using ArticleChat.Models.Db;
using ArticleChat.Models.Interfaces;
using Azure;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController(ITagService _tagService) : ControllerBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        public async Task<ActionResult<Tag>> Create(Tag tag)
        {
            var createdTag = await _tagService.CreateTagAsync(tag);
            Logger.Info($"Tag {tag.TagText} created successfully.");
            return CreatedAtAction(nameof(GetTag), new { id = createdTag.Id }, createdTag);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Tag tag)
        {
            tag.Id = id;
            var existingTag = await _tagService.UpdateTagAsync(tag);
            if (existingTag == null) return NotFound();
            Logger.Info($"Tag {tag.TagText} updated successfully.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, Tag tag)
        {
            await _tagService.DeleteTagAsync(id);
            Logger.Info($"Tag {tag.TagText} deleted successfully.");
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetAllTags() =>
            Ok(await _tagService.GetAllTagsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(int id)
        {
            var tag = await _tagService.GetTagByIdAsync(id);
            if (tag == null) return NotFound();
            return Ok(tag);
        }
    }
}
