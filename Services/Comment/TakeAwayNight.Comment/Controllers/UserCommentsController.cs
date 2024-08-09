using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeAwayNight.Comment.Dtos;
using TakeAwayNight.Comment.Services;

namespace TakeAwayNight.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public UserCommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllUserCommentList()
        {
            var values = await _commentService.GetAllUserCommentAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserCommentAsync(CreateUserCommentDto createUserCommentDto)
        {
            await _commentService.CreateUserCommentAsync(createUserCommentDto);
            return Ok("Ekleme işlemi yapıldı");
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteUserCommentAsync(int id)
        {
            await _commentService.DeleteUserCommentAsync(id);
            return Ok("Silme işlemi gerçekleştirildi");
        }

        [HttpGet("{GetUserComment}")]

        public async Task<IActionResult> GetUserComment(int id)
        {
            var values = await _commentService.GetByIdUserCommentAsync(id);
            return Ok(values);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserCommentAsync(UpdateUserCommentDto updateUserCommentDto)
        {
            await _commentService.UpdateUserCommentAsync(updateUserCommentDto);
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("{UserCommentByProductId}")]

        public async Task<IActionResult> UserCommentByProductId(string id)
        {
            var values = await _commentService.GetByProductIdUserCommentAsync(id);
            return Ok(values);

        }
    }
}
