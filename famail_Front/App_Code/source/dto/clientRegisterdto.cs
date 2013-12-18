using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for dangkydto
/// </summary>
public class clientRegisterdto
{
    public clientRegisterdto()
    {
    }
    public int registerId { get; set; }
    public int clientId { get; set; }
    public int packageId { get; set; }
    public int limitId { get; set; }
    public int subAccontCount { get; set; }
    public double totalFee { get; set; }
    public int registerType { get; set; }
    public int packageTimeId { get; set; }
    public DateTime from { get; set; }
    public DateTime to { get; set; }
    public DateTime lastRegisterFrom { get; set; }
    public DateTime lastRegisterTo { get; set; }
    public double lastRegisterFee { get; set; }
    public double lastRegisterFeeRemain { get; set; }
    public DateTime registerTime { get; set; }
    public DateTime registerDate { get; set; }
}