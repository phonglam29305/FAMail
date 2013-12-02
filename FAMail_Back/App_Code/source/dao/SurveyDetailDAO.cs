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
/// Summary description for SurveyDetailDAO
/// </summary>
public class SurveyDetailDAO
{
	public SurveyDetailDAO()
	{		
	}


    public void tblSurveyDetail_insert(SurveyDetailDTO dt)
    {
        string sql = "INSERT INTO tblSurveyDetail VALUES (@EmailId @SurveyDate @SurveyId @Description)";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = dt.EmailId;
        cmd.Parameters.Add("@SurveyDate", SqlDbType.DateTime).Value = dt.SurveyDate;
        cmd.Parameters.Add("@SurveyId", SqlDbType.Int).Value = dt.SurveyId;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSurveyDetail_Update(SurveyDetailDTO dt)
    {
        SqlCommand cmd = new SqlCommand("UPDATE tblSurveyDetail SET SurveyDate = @SurveyDate, SurveyId = @SurveyId, Description = @Description	WHERE EmailId = @EmailId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = dt.EmailId;
        cmd.Parameters.Add("@SurveyDate", SqlDbType.DateTime).Value = dt.SurveyDate;
        cmd.Parameters.Add("@SurveyId", SqlDbType.Int).Value = dt.SurveyId;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblSurveyDetail_Delete(string EmailId)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblSurveyDetail WHERE EmailId = @EmailId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = EmailId;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblSurveyDetail", ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByID(string EmailId)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblSurveyDetail WHERE EmailId = @EmailId", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@EmailId", SqlDbType.VarChar).Value = EmailId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

}
