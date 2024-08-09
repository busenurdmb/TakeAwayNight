namespace TakeAwayNight.Comment.Dtos
{
    public class GetByProductIdUserCommentDto
    {
        public int UserCommentId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        //public string? ImageUrl { get; set; }
        //public string Email { get; set; }
        public string CommentDetail { get; set; }
        public string ProductId { get; set; }
        //public int Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
    }
}
