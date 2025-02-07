using ArticleChat.Models.Db;
using ArticleChat.Models.Interfaces;

namespace ArticleChat.Models.Services
{
    public class ArticleService : IArticleService
    {
        private readonly List<Article> _articles = [];
        private int _currentId = 1;

        public void Create(Article article)
        {
            article.Id = _currentId++;
            _articles.Add(article);
        }

        public void Edit(Article article)
        {
            var existingArticle = _articles.FirstOrDefault(a => a.Id == article.Id);
            if (existingArticle != null)
            {
                existingArticle.Content = article.Content;
                existingArticle.UserId = article.UserId;
                existingArticle.TagId = article.TagId;
                existingArticle.CommentId = article.CommentId;
            }
        }

        public void Delete(int id)
        {
            var article = _articles.FirstOrDefault(a => a.Id == id);
            if (article != null)
            {
                _articles.Remove(article);
            }
        }

        public IEnumerable<Article> GetAllArticles()
        {
            return _articles;
        }

        public IEnumerable<Article> GetArticlesByUserId(int userId)
        {
            return _articles.Where(a => a.UserId == userId);
        }
    }
}
