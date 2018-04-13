using BlogSystem.Data.Models;
using BlogSystem.DTO;
using System.Collections.Generic;

namespace BlogSystem.Services.Data.Contracts
{
    public interface ICommentsService
    {
        IEnumerable<CommentDto> GetByPostId(int id);

        void Publish(CommentDto dto);

        void Delete(int id);
    }
}