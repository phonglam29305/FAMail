using System;
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
using System.Data.SqlClient;
using Email;

/// <summary>
/// Summary description for SubGroupDAO
/// </summary>
public class SubGroupDAO
{
    SqlCommand cmd = null;
	public SubGroupDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void tblSubGroup_insert(SubGroupDTO dt)
    {
        string sql = "INSERT INTO tblSubGroup(GroupID, CustomerID, GroupName) " +
              "VALUES(@GroupID, @CustomerID, @GroupName)";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = dt.GroupID;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = dt.CustomerID;
        cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = dt.GroupName;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSubGroup_Update(SubGroupDTO dt)
    {
        string sql = "UPDATE tblSubGroup SET "+
	                "GroupID = @GroupID, "+
                    "CustomerID = @CustomerID, GroupName=@GroupName	WHERE IDSubGroup = @IDSubGroup";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@IDSubGroup", SqlDbType.Int).Value = dt.IDSubGroup;
        cmd.Parameters.Add("@GroupID", SqlDbType.Int).Value = dt.GroupID;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = dt.CustomerID;
        cmd.Parameters.Add("@GroupName", SqlDbType.NVarChar).Value = dt.GroupName;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSubGroup_Delete(int IDSubGroup)
    {
        string sql = "DELETE FROM tblSubGroup WHERE IDSubGroup = @IDSubGroup";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@IDSubGroup", SqlDbType.Int).Value = IDSubGroup;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblSubGroup", ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByID(int IDSubGroup)
    {
        string sql = "SELECT * FROM tblSubGroup WHERE IDSubGroup = @IDSubGroup";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@IDSubGroup", SqlDbType.Int).Value = IDSubGroup;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

}
