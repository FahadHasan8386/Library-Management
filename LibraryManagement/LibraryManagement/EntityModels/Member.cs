﻿namespace LM.Api.EntityModels;
public class Member
{
    public long MemberId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string status { get; set; }

}