using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using Email;

/// <summary>
/// Summary description for SpamRuleDAO
/// </summary>
public class SpamRuleDAO
{
	public SpamRuleDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int tblSpamRule_insert(SpamRuleDTO dt)
    {
        string sql = "INSERT INTO tblSpamRule(Keyword, Score, SameWord) " +
                     "VALUES(@Keyword, @Score, @SameWord)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = dt.Keyword;
        cmd.Parameters.Add("@Score", SqlDbType.Float).Value = dt.Score;
        cmd.Parameters.Add("@SameWord", SqlDbType.NVarChar).Value = dt.SameWord;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        int row = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return row;
    }
    public int tblSpamRule_Update(SpamRuleDTO dt)
    {
        string sql = "UPDATE  tblSpamRule SET " +
                     "Score = @Score, " +
                     "SameWord = @SameWord " +
                     "WHERE  Keyword = @Keyword";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = dt.Keyword;
        cmd.Parameters.Add("@Score", SqlDbType.Float).Value = dt.Score;
        cmd.Parameters.Add("@SameWord", SqlDbType.NVarChar).Value = dt.SameWord;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        int row = cmd.ExecuteNonQuery();
        cmd.Dispose();
        return row;
    }
    public void tblSpamRule_Delete(string Keyword)
    {

        string sql = "DELETE FROM tblSpamRule WHERE Keyword = @Keyword";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection, ConnectionData._MyTransaction);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = Keyword;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable tblSpamRule_SearchByKeyword(string Keyword)
    {

        string sql = "SELECT * FROM tblSpamRule WHERE Keyword like %@Keyword";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = Keyword;
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
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblSpamRule", ConnectionData._MyConnection);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable tblSpamRule_GetByID(string Keyword)
    {

        string sql = "SELECT * FROM tblSpamRule WHERE Keyword = @Keyword";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Keyword", SqlDbType.NVarChar).Value = Keyword;
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
}
