using LM.Api.EntityModels;
using LM.Api.Repositories.Interfaces;
using LM.Api.Services.Interfaces;

namespace LM.Api.Services;
public class MemberService : IMemberService
{
    public readonly IMemberRepository _MemberRepository;

    public MemberService (IMemberRepository memberRepository)
    {
        _MemberRepository = memberRepository ;
    }
    public async Task<List<Member>> GetMemberAsync()
    {
        var request = await _MemberRepository.ExecuteGetMemberAsync();
        return request;
    }
}
