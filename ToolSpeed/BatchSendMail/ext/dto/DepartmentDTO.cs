﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for DepartmentDTO
/// </summary>
public class DepartmentDTO
{
	public DepartmentDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Role { get; set; }

}
