﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for UserLoginDTO
/// </summary>
public class UserLoginDTO
{
    public UserLoginDTO()
	{
	}
    public int UserId { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int DepartmentId { get; set; }

}
