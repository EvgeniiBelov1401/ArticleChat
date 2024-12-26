using ArticleChat.Models.Db;
using ArticleChat.Models.Interfaces;
using ArticleChat.Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticleChat.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Article article)
        {
            _articleService.Create(article);
            return CreatedAtAction(nameof(GetAllArticles), new { id = article.Id }, article);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Article article)
        {
            if (id != article.Id) return BadRequest();
            _articleService.Edit(article);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _articleService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllArticles()
        {
            var articles = _articleService.GetAllArticles();
            return Ok(articles);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetArticlesByUserId(int userId)
        {
            var articles = _articleService.GetArticlesByUserId(userId);
            return Ok(articles);
        }
    }
}
