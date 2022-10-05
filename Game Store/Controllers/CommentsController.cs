using Business_Logic_Layer.Interfaces;
using Business_Logic_Layer.Models;
using Data_Layer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Game_Store.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetAllCommentsAsync()
        {
            var comments = await commentService.GetAllAsync();
            return new OkObjectResult(comments);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentModel>> GetCommentByIdAsync(int id)
        {
            var comment = await commentService.GetByIdAsync(id);
            return new OkObjectResult(comment);
        }
        [HttpPost]
        public async Task<ActionResult> PostCommentAsync([FromBody] CommentModel comment)
        {
            await commentService.AddAsync(comment);
            return new OkObjectResult(comment);
        }
        [HttpPost("reply/{id}")]
        public async Task<ActionResult> ReplyCommentAsync(int id, [FromBody] CommentModel comment)
        {
            await commentService.ReplyCommentAsync(id, comment);
            return new OkObjectResult(comment);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommentAsync(int id, [FromBody] CommentModel comment)
        {
            await commentService.UpdateAsync(comment);
            return new OkResult();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteComment(int id)
        {
            await commentService.DeleteAsync(id);
            return new OkResult();
        }
    }
}
