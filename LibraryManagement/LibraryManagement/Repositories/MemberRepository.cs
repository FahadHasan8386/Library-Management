using System.ComponentModel;
using System.Data;
using Dapper;
using LM.Api.EntityModels;
using LM.Api.Repositories.Interfaces;

namespace LM.Api.Repositories;

public class MemberRepository : IMemberRepository
{
    public readonly IDbConnection _connection;

    public MemberRepository(IDbConnection connection)
    {
        _connection = connection;
    }
    public async Task<List<Member>> ExecuteGetMemberAsync()
    {
        var sql = @"Select * From Member";
        _connection.Open();
        var member = await _connection.QueryAsync<Member>(sql);
        _connection.Close();
        var response = member.ToList();
        return response;
    }

    
}
