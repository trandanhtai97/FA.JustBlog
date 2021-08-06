using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public interface ICommentServices : IBaseService<Comment>
    {
        Task<int> AddCommentAsync(int postId , string commentName , string commentEmail , string commentTitle , string commentBody)
    }
}
