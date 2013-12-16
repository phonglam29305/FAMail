using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PackageLimitDTO
/// </summary>
public class PackageLimitDTO
{
	public PackageLimitDTO()
	{
		
	}
    public int limitId { get; set; }
    public string namepackagelimit { get; set; }
    public bool isUnLimit { get; set; }
    public Int64 under { get; set; }
    public float cost { get; set; }
    public bool isActive { get; set; }
}