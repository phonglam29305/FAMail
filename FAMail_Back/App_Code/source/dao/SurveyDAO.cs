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
/// Summary description for SurveyDAO
/// </summary>
public class SurveyDAO
{
	public SurveyDAO()
	{
		//
		// TODO: Add constructor logic here
        //public int MailConfigID { get; set; }

	}

    public void tblSurvey_insert(SurveyDTO dt)
    {
        SqlCommand cmd = new SqlCommand("INSERT INTO tblSurvey(Name, Description, MailConfigID) VALUES(@Name, @Description, @MailConfigID)", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.Parameters.Add("@MailConfigID", SqlDbType.Int).Value = dt.MailConfigID;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSurvey_Update(SurveyDTO dt)
    {
        SqlCommand cmd = new SqlCommand("UPDATE tblSurvey SET Name = @Name, Description = @Description, MailConfigID=@MailConfigID 	WHERE Id = @Id", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = dt.Id;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.Parameters.Add("@MailConfigID", SqlDbType.Int).Value = dt.MailConfigID;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSurvey_Delete(int ID)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblSurvey WHERE Id = @Id", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ID;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblSurvey", ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetAll(int MailConfigID)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSurvey WHERE MailConfigID = @MailConfigID", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@MailConfigID", SqlDbType.Int).Value = MailConfigID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable GetByID(int ID)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSurvey WHERE Id = @Id", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

}
