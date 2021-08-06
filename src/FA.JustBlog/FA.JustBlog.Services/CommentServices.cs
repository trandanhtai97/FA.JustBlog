using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System;

namespace FA.JustBlog.Services
{
    public class CommentServices : BaseServices<Comment>, ICommentServices
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public async Task<int> AddCommentAsync(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment()
            {
                Id = Guid.NewGuid(),
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentTime = DateTime.Now
            };
            _unitOfWork.CommentRepository.Add(comment);
        }
    }
}
