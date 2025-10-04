using LM.Api.EntityModels;

namespace LM.Api.Services.Interfaces;

public interface IMemberService
{
    
    Task<List<Member>> GetMemberAsync();
}
