using LM.Api.EntityModels;

namespace LM.Api.Repositories.Interfaces;

public interface IMemberRepository
{
    Task<List<Member>> ExecuteGetMemberAsync();
}
