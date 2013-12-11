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
    public int UserId { get; set; }
    public int UserType { get; set; }
}
