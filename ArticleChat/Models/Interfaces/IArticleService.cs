using ArticleChat.Models.Db;

namespace ArticleChat.Models.Interfaces
{
    public interface IArticleService
    {
        void Create(Article article);
        void Edit(Article article);
        void Delete(int id);
        IEnumerable<Article> GetAllArticles();
        IEnumerable<Article> GetArticlesByUserId(int userId);
    }
}
