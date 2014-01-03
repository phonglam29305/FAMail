using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;

/// <summary>
/// Summary description for ICategory
/// </summary>
public interface ICategory
{
    DataTable GetByID(int ID);
}
