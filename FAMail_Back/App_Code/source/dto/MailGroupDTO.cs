﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for MailGroupDTO
/// </summary>
public class MailGroupDTO
{
	public MailGroupDTO()
	{
		
	}
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int UserId { get; set; }
    public int AssignToUserID { get; set; }
    public string CreatedBy { get; set; }
    public string AssignTo { get; set; }
}
