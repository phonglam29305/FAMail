using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Email;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SendContentDAO
/// </summary>
public class SignatureDAO
{
    public SignatureDAO()
	{
	}
    public void tblSignature_insert(SignatureDTO dt)
    {
        string sql = "INSERT INTO tblSignature(UserId, SignatureContent, SignatureName) " +
                     "VALUES(@UserId, @SignatureContent, @SignatureName)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.userId;
        cmd.Parameters.Add("@SignatureContent", SqlDbType.NVarChar).Value = dt.signatureContent;
        cmd.Parameters.Add("@SignatureName", SqlDbType.NVarChar).Value = dt.SignatureName;        
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSignature_Update(SignatureDTO dt)
    {
        string sql = "UPDATE tblSignature SET " +
                    "SignatureContent = @SignatureContent, "+
                    "SignatureName = @SignatureName, " +
                    "UserId = @UserId " +
                    " WHERE id = @id";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = dt.id;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = dt.userId;
        cmd.Parameters.Add("@SignatureContent", SqlDbType.NVarChar).Value = dt.signatureContent;
        cmd.Parameters.Add("@SignatureName", SqlDbType.NVarChar).Value = dt.SignatureName;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSignature_Delete(int id)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblSignature WHERE id = @id", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblSignature", 
            ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByUserId(int userId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSignature WHERE UserId = @UserId", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@userid", SqlDbType.Int).Value = userId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable GetById(int id)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSignature WHERE id = @id", 
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
}
