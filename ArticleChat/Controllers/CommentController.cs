using ArticleChat.Models.Db;
using ArticleChat.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ArticleChat.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> Create(Comment comment)
        {
            var createdComment = await _commentService.CreateCommentAsync(comment);
            return CreatedAtAction(nameof(GetComment), new { id = createdComment.Id }, createdComment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Comment comment)
        {
            comment.Id = id;
            var existingComment = await _commentService.UpdateCommentAsync(comment);
            if (existingComment == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _commentService.DeleteCommentAsync(id);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetAllComments() =>
            Ok(await _commentService.GetAllCommentsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }
    }
}
