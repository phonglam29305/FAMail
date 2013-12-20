using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PackageDTO
/// </summary>
public class PackageDTO
{
	public PackageDTO()
	{		
	}
    public int packageId { get; set; }
    public string packageName { get; set; }
    public string description { get; set; }
    public int limitId { get; set; }
    public int subAccontCount { get; set; }
    public bool isUnLimit { get; set; }
    public long emailCount { get; set; }
    public bool isActive { get; set; }
    public bool isTry { get; set; }
}