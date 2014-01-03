using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for tblPartSend
/// </summary>
public class PartSendDTO
{
    public PartSendDTO()
	{
	}
    public int UserId { get; set; }
    public int GroupId { get; set; }
    public string hasContentSend { get; set; }
    public bool settingFirst { get; set; }
}
