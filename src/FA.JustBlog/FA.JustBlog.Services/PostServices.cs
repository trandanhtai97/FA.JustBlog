using FA.JustBlog.Data.Infrastructure;
using FA.JustBlog.Models.Common;
using FA.JustBlog.Services.BaseServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services
{
    public class PostServices : BaseServices<Post>, IPostServices
    {
        public PostServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
