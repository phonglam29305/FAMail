﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for SurveyDTO
/// </summary>
public class SurveyDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int MailConfigID { get; set; }

	public SurveyDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
