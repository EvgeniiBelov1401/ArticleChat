﻿using ArticleChat.Models.Db;
using ArticleChat.Models.Interfaces;

namespace ArticleChat.Models.Services
{
    public class CommentService : ICommentService
    {
        private readonly List<Comment> _comments = new List<Comment>(); 

        public async Task<IEnumerable<Comment>> GetAllCommentsAsync() => await Task.FromResult(_comments);

        public async Task<Comment> GetCommentByIdAsync(int id) => await Task.FromResult(_comments.FirstOrDefault(c => c.Id == id));

        public async Task<Comment> CreateCommentAsync(Comment comment)
        {
            comment.Id = _comments.Count + 1; 
            return await Task.FromResult(comment);
        }

        public async Task<Comment> UpdateCommentAsync(Comment comment)
        {
            var existingComment = _comments.FirstOrDefault(c => c.Id == comment.Id);
            if (existingComment != null)
            {
                existingComment.CommentText = comment.CommentText;
            }
            return await Task.FromResult(existingComment);
        }

        public async Task DeleteCommentAsync(int id)
        {
            var comment = _comments.FirstOrDefault(c => c.Id == id);
            if (comment != null)
            {
                _comments.Remove(comment);
            }
            await Task.CompletedTask;
        }
    }
}
