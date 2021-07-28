using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;

namespace FA.JustBlog.Services
{
    public class TagServices : BaseServices<Tag> , ITagServices
    {
        public TagServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
