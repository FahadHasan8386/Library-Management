using LM.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MemberController : ControllerBase
{
    public readonly IMemberService _MemberService;

    public MemberController(IMemberService memberServicr)
    {
        _MemberService = memberServicr;
    }

    [HttpGet("GetMember")]
    public async Task<IActionResult> GetMemberAsync()
    {
        var result = await _MemberService.GetMemberAsync();
        return Ok(result);
    }
    /*
    [HttpPost("AddMember")]
    public async Task<IActionResult> AddMemberAsync()
    {
        var result = await _MemberService.AddMemberAsync();
        return Ok(result);
    }

    [HttpGet("UpdateMember")]
    public async Task<IActionResult> UpdateMemberAsync()
    {
        var result = await _MemberService.UpdateMemberAsync();
        return Ok(result);
    }

    [HttpDelete("DeleteMember")]
    public async Task<IActionResult> DeleteMemberAsync()
    {
        var result = await _MemberService.DeleteMemberAsync();
        return Ok(result);
    }
    */
}
