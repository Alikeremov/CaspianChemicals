namespace CaspianChemichalsWebAPI.Dtos.TokenDtos
{
    public record TokenResponseDto(string Username, string Token, DateTime ExpirdeAt);
    
}
