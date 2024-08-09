using TakeAwayNight.Comment.Dtos;

namespace TakeAwayNight.Comment.Services
{
    public interface ICommentService
    {
        Task<List<ResultUserCommentDto>> GetAllUserCommentAsync();

        Task CreateUserCommentAsync(CreateUserCommentDto userCommentDto);
        Task UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto);

        Task DeleteUserCommentAsync(int id);

        Task<GetByIdUserCommentDto> GetByIdUserCommentAsync(int id);

        Task<List<ResultUserCommentDto>> GetByProductIdUserCommentAsync(string productId);
    }
}
