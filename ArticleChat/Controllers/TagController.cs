using ArticleChat.Models.Db;
using ArticleChat.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleChat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpPost]
        public async Task<ActionResult<Tag>> Create(Tag tag)
        {
            var createdTag = await _tagService.CreateTagAsync(tag);
            return CreatedAtAction(nameof(GetTag), new { id = createdTag.Id }, createdTag);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Tag tag)
        {
            tag.Id = id;
            var existingTag = await _tagService.UpdateTagAsync(tag);
            if (existingTag == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _tagService.DeleteTagAsync(id);
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
