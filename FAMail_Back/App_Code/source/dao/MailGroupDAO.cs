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
using Email;
using System.Data.SqlClient;

/// <summary>
/// Summary description for MailGroupDAO
/// </summary>
public class MailGroupDAO
{
    public MailGroupDAO()
    {

    }

    public void tblMailGroup_insert(MailGroupDTO dt)
    {
        string sql = "INSERT INTO tblMailGroup(Name, Description, UserID,CreatedBy,AssignToUserID,AssignTo) " +
                      "VALUES(@Name, @Description, @UserID,@CreatedBy,@AssignToUserID,@AssignTo)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = dt.UserId;
        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar).Value = dt.CreatedBy;
        cmd.Parameters.Add("@AssignToUserID", SqlDbType.Int).Value = dt.AssignToUserID;
        cmd.Parameters.Add("@AssignTo", SqlDbType.NVarChar).Value = dt.AssignTo;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblMailGroup_Update(MailGroupDTO dt)
    {
        string sql = "UPDATE tblMailGroup SET " +
                       "Name = @Name, " +
                       "AssignToUserID = @AssignToUserID, " +
                       "AssignTo = @AssignTo, " +
                       "Description = @Description	WHERE Id = @Id";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = dt.Id;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.Parameters.Add("@AssignToUserID", SqlDbType.Int).Value = dt.AssignToUserID;
        cmd.Parameters.Add("@AssignTo", SqlDbType.NVarChar).Value = dt.AssignTo;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblMailGroup_Delete(int ID)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblMailGroup WHERE Id = @Id",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ID;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblMailGroup ",
            ConnectionData._MyConnection);
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetAll(int userId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblMailGroup  where UserID =@UserID ",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }


    public DataTable GetAllAssignTo(int userId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblMailGroup  where AssignToUserId =@UserID ",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }

    public DataTable GetByID(int Id)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblMailGroup WHERE Id = @Id",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable GetMailGroupByUserId(int userId)
    {
        SqlCommand cmd = new SqlCommand("SP_GetMailGroupByUserId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }


    public DataTable GetAllNewDepart3(int AssignTouserId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblMailGroup where AssignToUserId =@AssignTouserId",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@AssignTouserId", SqlDbType.Int).Value = AssignTouserId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }


    public DataTable GetGroupMailDepart2(int UserID)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SP_GetMailGroupByUserId";
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        cmd.Connection = ConnectionData._MyConnection;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }



    public DataTable GetAllNewDepart(int UserID)
    {
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "SP_GetSendContent";
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        cmd.Connection = ConnectionData._MyConnection;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetSubClientBySubID(int subId)
    {
        string sql = "SELECT * FROM tblSubClient WHERE subId = @subId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@subId", SqlDbType.Int).Value = subId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetSubClientByAssignUserID(int AssignUserID)
    {
        string sql = "SELECT * FROM tblSubClient WHERE UserID = @UserID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = AssignUserID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }





    public DataTable GetSubClient(int clientId)
    {
        string sql = "SELECT * FROM tblSubClient WHERE clientId = @clientId and Is_Block = 0";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetSubClientAll()
    {
        string sql = "SELECT * FROM tblSubClient where Is_Block = 0";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        //cmd.Parameters.Add("@clientId", SqlDbType.Int).Value = clientId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetAllNew()
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblMailGroup", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();

        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public int countCustomerByUserId(int userId)
    {
        string sql = "SELECT   COUNT(*) AS countCustomer ";
        sql += "FROM   tblMailGroup AS MG INNER JOIN ";
        sql += "tblDetailGroup AS DG ON MG.Id = DG.GroupID ";
        sql += " WHERE  MG.UserId = @UserId";

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = userId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        int rs = (int)cmd.ExecuteScalar();
        return rs;
    }
}
