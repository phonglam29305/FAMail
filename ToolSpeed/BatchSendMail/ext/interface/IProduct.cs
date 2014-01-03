using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for IProduct
/// </summary>
public interface IProduct
{
    DataTable GetAll();
    DataTable GetByID(int ID);
}
