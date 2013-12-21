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
/// Summary description for CustomerDAO
/// </summary>
public class CustomerDAO
{
    public CustomerDAO()
    {

    }

    public int tblCustomer_insert(CustomerDTO dt)
    {
        string sql = "INSERT INTO tblCustomer(Name, Gender, BirthDay, Email, Phone, Address, Type ,SecondPhone ,Fax ,Company ,City ,Province ,Country ,recivedEmail , countBuy,createBy,assignTo) " +
                     "VALUES(@Name, @Gender, @BirthDay, @Email, @Phone, @Address, @Type, @SecondPhone, @Fax ,@Company ,@City ,@Province ,@Country ,@recivedEmail, @countBuy,@createBy,@assignTo)  SELECT SCOPE_IDENTITY()";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = dt.Gender;
        cmd.Parameters.Add("@BirthDay", SqlDbType.DateTime).Value = dt.BirthDay;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = dt.Email;
        cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = dt.Phone;
        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dt.Address;
        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = dt.Type;
        cmd.Parameters.Add("@SecondPhone", SqlDbType.NVarChar).Value = dt.SecondPhone;
        cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dt.Fax;
        cmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = dt.Company;
        cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = dt.City;
        cmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = dt.Province;
        cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = dt.Country;
        cmd.Parameters.Add("@recivedEmail", SqlDbType.Bit).Value = true;
        cmd.Parameters.Add("@countBuy", SqlDbType.Int).Value = 0;
        cmd.Parameters.Add("@assignTo", SqlDbType.Int).Value = dt.AssignTo;
        cmd.Parameters.Add("@createBy", SqlDbType.Int).Value = dt.createBy;

        //cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = dt.UserID;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        var CustomerID = cmd.ExecuteScalar();
        cmd.Dispose();
        return int.Parse(CustomerID.ToString());
    }
    public void tblCustomer_Update(CustomerDTO dt)
    {
        string sql = "UPDATE tblCustomer SET " +
                    "Name = @Name, " +
                    "Gender = @Gender, " +
                    "BirthDay = @BirthDay, " +
                    "Email = @Email, " +
                    "Phone = @Phone, " +
                    "Address = @Address, " +
                    "SecondPhone = @SecondPhone, " +
                    "Fax = @Fax, " +
                    "Company = @Company, " +
                    "City = @City, " +
                    "Province = @Province, " +
                    "Country = @Country, " +
                    "recivedEmail = @recivedEmail, " +
                     "assignTo = @assignTo, " +
                    "Type = @Type	WHERE Id = @Id";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = dt.Id;
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = dt.Name;
        cmd.Parameters.Add("@Gender", SqlDbType.NVarChar).Value = dt.Gender;
        cmd.Parameters.Add("@BirthDay", SqlDbType.DateTime).Value = dt.BirthDay;
        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = dt.Email;
        cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = dt.Phone;
        cmd.Parameters.Add("@Address", SqlDbType.NVarChar).Value = dt.Address;
        cmd.Parameters.Add("@Type", SqlDbType.NVarChar).Value = dt.Type;
        cmd.Parameters.Add("@SecondPhone", SqlDbType.NVarChar).Value = dt.SecondPhone;
        cmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = dt.Fax;
        cmd.Parameters.Add("@Company", SqlDbType.NVarChar).Value = dt.Company;
        cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = dt.City;
        cmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = dt.Province;
        cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = dt.Country;
        cmd.Parameters.Add("@assignTo", SqlDbType.Int).Value = dt.AssignTo;
        cmd.Parameters.Add("@recivedEmail", SqlDbType.Bit).Value = true;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblCustomer_Delete(int Id)
    {
        SqlCommand cmd = new SqlCommand("DELETE FROM tblCustomer WHERE Id = @Id", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public DataTable GetAll(string Name, string phone, string email, int assignTo)
    {
        //SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblCustomer where Name =@Name recivedEmail='True'", ConnectionData._MyConnection);
        //DataTable table = new DataTable();
        //if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        //{
        //    ConnectionData._MyConnection.Open();
        //}
        //adapter.Fill(table);
        //adapter.Dispose();
        //return table;


        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "pro_search_tblCustomer";
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
        cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
        cmd.Parameters.Add("@assignTo", SqlDbType.Int).Value = assignTo;
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

        //string sql = "";
        //sql += "SELECT * FROM tblCustomer ";
        //sql += "WHERE (Name like '%" + @Name + "%') and Phone like '%" + @phone + "%' and Email like '%" + @email + "%' AND recivedEmail='True'";
        //SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        //cmd.CommandType = CommandType.Text;
        //cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
        //cmd.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
        //cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = email;
        //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //DataTable table = new DataTable();
        //if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        //{
        //    ConnectionData._MyConnection.Open();
        //}
        //adapter.Fill(table);
        //cmd.Dispose();
        //adapter.Dispose();
        //return table;
    }


    public DataTable GetAllFilterCustomer(string Name, string address, int assignTo)
    {

        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "pro_search_Filter_tblCustomer";
        cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = Name;
        cmd.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
        cmd.Parameters.Add("@assignTo", SqlDbType.Int).Value = assignTo;
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


    public DataTable GetAllByUserAssignTo(int UserID, int assignTo)
    {
        string sql = "";
        sql += "SELECT  ct.Id, ct.Name, ct.Gender, ct.BirthDay, ct.Email, ct.Phone, ct.SecondPhone, ";
        sql += "ct.Address, ct.Fax, ct.Company, ct.City, ct.Province, ct.Country, ct.Type, ct.countBuy, ct.recivedEmail, ct.createBy, ct.assignTo ";
        sql += "FROM   tblMailGroup AS mg INNER JOIN ";
        sql += "tblDetailGroup AS dg ON mg.Id = dg.GroupID ";
        sql += "INNER JOIN tblCustomer AS ct ON dg.CustomerID = ct.Id ";
        sql += "WHERE     (mg.UserId = @userId) AND ct.recivedEmail='True' and ct.AssignTo != @assignTo";

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        cmd.Parameters.Add("@assignTo", SqlDbType.Int).Value = assignTo;
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

    public DataTable GetAllByAssignToCustomer(int UserID, int assignTo)
    {
        string sql = "";
        sql += "SELECT  ct.Id, ct.Name, ct.Gender, ct.BirthDay, ct.Email, ct.Phone, ct.SecondPhone, ";
        sql += "ct.Address, ct.Fax, ct.Company, ct.City, ct.Province, ct.Country, ct.Type, ct.countBuy, ct.recivedEmail, ct.createBy, ct.assignTo ";
        sql += "FROM   tblMailGroup AS mg INNER JOIN ";
        sql += "tblDetailGroup AS dg ON mg.Id = dg.GroupID ";
        sql += "INNER JOIN tblCustomer AS ct ON dg.CustomerID = ct.Id ";
        sql += "WHERE     (mg.UserId = @userId) AND ct.recivedEmail='True' and ct.AssignTo = @assignTo";

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        cmd.Parameters.Add("@assignTo", SqlDbType.Int).Value = assignTo;
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



    public DataTable GetAllCustomerDepart3(int UserID, int assignTo)
    {
        string sql = "";
        sql += "SELECT  ct.Id, ct.Name, ct.Gender, ct.BirthDay, ct.Email, ct.Phone, ct.SecondPhone, ";
        sql += "ct.Address, ct.Fax, ct.Company, ct.City, ct.Province, ct.Country, ct.Type, ct.countBuy, ct.recivedEmail, ct.createBy, ct.assignTo ";
        sql += "FROM   tblMailGroup AS mg INNER JOIN ";
        sql += "tblDetailGroup AS dg ON mg.Id = dg.GroupID ";
        sql += "INNER JOIN tblCustomer AS ct ON dg.CustomerID = ct.Id ";
        sql += "WHERE     (mg.AssignToUserID = @userId) AND ct.recivedEmail='True' and ct.AssignTo != @assignTo";

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        cmd.Parameters.Add("@assignTo", SqlDbType.Int).Value = assignTo;
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


    public DataTable GetAllCustomerDepart3AssignTo(int UserID, int assignTo)
    {
        string sql = "";
        sql += "SELECT  ct.Id, ct.Name, ct.Gender, ct.BirthDay, ct.Email, ct.Phone, ct.SecondPhone, ";
        sql += "ct.Address, ct.Fax, ct.Company, ct.City, ct.Province, ct.Country, ct.Type, ct.countBuy, ct.recivedEmail, ct.createBy, ct.assignTo ";
        sql += "FROM   tblMailGroup AS mg INNER JOIN ";
        sql += "tblDetailGroup AS dg ON mg.Id = dg.GroupID ";
        sql += "INNER JOIN tblCustomer AS ct ON dg.CustomerID = ct.Id ";
        sql += "WHERE     (mg.AssignToUserID = @userId) AND ct.recivedEmail='True' and ct.AssignTo = @assignTo";

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        cmd.Parameters.Add("@assignTo", SqlDbType.Int).Value = assignTo;
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

    public DataTable GetAllByUser(int UserID)
    {
        string sql = "";
        sql += "SELECT  ct.Id, ct.Name, ct.Gender, ct.BirthDay, ct.Email, ct.Phone, ct.SecondPhone, ";
        sql += "ct.Address, ct.Fax, ct.Company, ct.City, ct.Province, ct.Country, ct.Type, ct.countBuy, ct.recivedEmail, ct.createBy, ct.assignTo ";
        sql += "FROM   tblMailGroup AS mg INNER JOIN ";
        sql += "tblDetailGroup AS dg ON mg.Id = dg.GroupID ";
        sql += "INNER JOIN tblCustomer AS ct ON dg.CustomerID = ct.Id ";
        sql += "WHERE     (mg.UserId = @userId) AND ct.recivedEmail='True' and ct.AssignTo = @assignTo";

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
        //cmd.Parameters.Add("@assignTo", SqlDbType.Int).Value = assignTo;
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
    public DataTable GetByID(int Id)
    {

        SqlCommand cmd = new SqlCommand("SELECT * FROM tblCustomer WHERE Id = @Id ", ConnectionData._MyConnection);
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



    public DataTable GetByGroupID(int AssignTo)
    {

        SqlCommand cmd = new SqlCommand("SELECT * FROM tblMailGroup WHERE Id = @AssignTo ", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@AssignTo", SqlDbType.Int).Value = AssignTo;
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

    public DataTable GetByID(int Id, bool statusRecive)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblCustomer WHERE Id = @Id and recivedEmail = @statusRecive ", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = Id;
        cmd.Parameters.Add("@statusRecive", SqlDbType.Bit).Value = statusRecive;
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
    public DataTable GetByCountBuy(int countBuy)
    {
        string sql = "";
        if (countBuy == 1)
        {
            sql = "SELECT * FROM tblCustomer WHERE countBuy = 1 and recivedEmail='True' ";
        }
        else if (countBuy == 2)
        {
            sql = "SELECT * FROM tblCustomer WHERE countBuy >= 2 and recivedEmail='True' ";
        }

        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
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
    public DataTable GetByEmail(string Email)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblCustomer WHERE Email = @Email", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
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


    public DataTable GetCountCustomerCreatedMail(int createdby)
    {
        string sql = "SP_GetEmailCount_ByUser";// "SELECT count(*) as numberMail FROM tblCustomer WHERE createBy = @createdby";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@createdby", SqlDbType.Int).Value = createdby;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetCountEmail(int ClientId)
    {
        string sql = @"SELECT under, isunlimit FROM tblClientRegister cr 
        inner join tblClient c on c.RegisterID = cr.RegisterID  
        inner join tblPackageLimit l on l.limitID = cr.limitID 
        WHERE c.ClientID = @ClientId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@ClientId", SqlDbType.Int).Value = ClientId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public DataTable GetClientId(int UserId)
    {
        string sql = "SELECT * FROM tblClient WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetClientIdSub(int UserId)
    {
        string sql = "SELECT * FROM tblSubClient WHERE UserId = @UserId";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@UserId", SqlDbType.Int).Value = UserId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public DataTable GetByEmail(string Email, int UserID)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblCustomer WHERE Email = @Email and createBy= @UserID", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = Email;
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
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
    public void tblCustomer_UpdateRecive(int CustomerID, bool recivedEmail)
    {
        string sql = "UPDATE tblCustomer SET " +
                    "recivedEmail = @recivedEmail	WHERE Id = @CustomerID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        cmd.Parameters.Add("@recivedEmail", SqlDbType.Bit).Value = recivedEmail;

        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }

    public void tblCustomer_UpdateCountBuy(int CustomerID)
    {
        int count = 0;
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblCustomer WHERE Id = @Id ", ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = CustomerID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        adapter.Fill(table);
        if (table.Rows.Count > 0)
        {
            if (table.Rows[0]["countBuy"].ToString() == "" || table.Rows[0]["countBuy"].ToString() == null)
            {
                count = 0;
            }
            else
            {
                count = int.Parse(table.Rows[0]["countBuy"].ToString());
            }
        }

        count++;

        string sql = "UPDATE tblCustomer SET " +
                    "countBuy = @countBuy	WHERE Id = @CustomerID";
        SqlCommand cmd2 = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd2.CommandType = CommandType.Text;
        cmd2.Parameters.Add("@CustomerID", SqlDbType.Int).Value = CustomerID;
        cmd2.Parameters.Add("@countBuy", SqlDbType.Int).Value = count;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        cmd2.ExecuteNonQuery();
        cmd2.Dispose();
    }

}
