using ArticleChat.Models.Db;
using ArticleChat.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController(ICommentService _commentService) : ControllerBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        [HttpPost]
        public async Task<ActionResult<Comment>> Create(Comment comment)
        {
            var createdComment = await _commentService.CreateCommentAsync(comment);
            Logger.Info($"Comment {comment.CommentText} created successfully.");
            return CreatedAtAction(nameof(GetComment), new { id = createdComment.Id }, createdComment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Comment comment)
        {
            comment.Id = id;
            var existingComment = await _commentService.UpdateCommentAsync(comment);
            if (existingComment == null) return NotFound();
            Logger.Info($"Comment {comment.CommentText} updated successfully.");
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id, Comment comment)
        {
            await _commentService.DeleteCommentAsync(id);
            Logger.Info($"Comment {comment.CommentText} deleted successfully.");
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
