﻿using ArticleChat.Models.Db;
using ArticleChat.Models.Interfaces;

namespace ArticleChat.Models.Services
{
    public class TagService : ITagService
    {
        private readonly List<Tag> _tags = new List<Tag>();

        public async Task<IEnumerable<Tag>> GetAllTagsAsync() => await Task.FromResult(_tags);

        public async Task<Tag> GetTagByIdAsync(int id) => await Task.FromResult(_tags.FirstOrDefault(t => t.Id == id));

        public async Task<Tag> CreateTagAsync(Tag tag)
        {
            tag.Id = _tags.Count + 1;
            _tags.Add(tag);
            return await Task.FromResult(tag);
        }

        public async Task<Tag> UpdateTagAsync(Tag tag)
        {
            var existingTag = _tags.FirstOrDefault(t => t.Id == tag.Id);
            if (existingTag != null)
            {
                existingTag.TagText = tag.TagText;
            }
            return await Task.FromResult(existingTag);
        }

        public async Task DeleteTagAsync(int id)
        {
            var tag = _tags.FirstOrDefault(t => t.Id == id);
            if (tag != null)
            {
                _tags.Remove(tag);
            }
            await Task.CompletedTask;
        }
    }
}