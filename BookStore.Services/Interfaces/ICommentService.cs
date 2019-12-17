using System.Threading.Tasks;

namespace BookStore.Services.Interfaces
{
    public interface ICommentService
    {
        Task CreateAndGetAllCommentsAsync(string UserName, string Comment);
    }
}
