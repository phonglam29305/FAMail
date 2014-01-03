using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for SpamRuleDTO
/// </summary>
public class SpamRuleDTO
{
	public SpamRuleDTO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string Keyword { get; set; }
    public float Score { get; set; }
    public string SameWord { get; set; }
}
