namespace BlogProject.Business.Dtos.UserDtos;

public record TokenResponceDto
{
    public string Token { get; set; }
    public string UserName { get; set; }
    public DateTime Expires { get; set; }

}
