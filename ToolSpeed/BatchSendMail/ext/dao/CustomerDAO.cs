﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
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
        string sql = "INSERT INTO tblCustomer(Name, Gender, BirthDay, Email, Phone, Address, Type ,SecondPhone ,Fax ,Company ,City ,Province ,Country ,recivedEmail , countBuy) " +
                     "VALUES(@Name, @Gender, @BirthDay, @Email, @Phone, @Address, @Type, @SecondPhone, @Fax ,@Company ,@City ,@Province ,@Country ,@recivedEmail, @countBuy)  SELECT SCOPE_IDENTITY()";
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
        string sql = "UPDATE tblCustomer SET "+
	                "Name = @Name, "+
	                "Gender = @Gender, "+
	                "BirthDay = @BirthDay, "+
	                "Email = @Email, "+
	                "Phone = @Phone, "+
	                "Address = @Address, "+
                    "SecondPhone = @SecondPhone, " +
                    "Fax = @Fax, " +
                    "Company = @Company, " +
                    "City = @City, " +
                    "Province = @Province, " +
                    "Country = @Country, " +
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

    public DataTable GetAllByRegisterId(int RegisterId)
    {
        SqlDataAdapter adapter = new SqlDataAdapter("SP_GetEmail2Send " + RegisterId, ConnectionData._MyConnection);
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
        string sql="";
        if (countBuy == 1)
        {
            sql = "SELECT * FROM tblCustomer WHERE countBuy = 1 and recivedEmail='true' ";
        }
        else if(countBuy==2)
        {
            sql = "SELECT * FROM tblCustomer WHERE countBuy >= 2 and recivedEmail='true' ";
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
    public void tblCustomer_UpdateRecive(int CustomerID, bool recivedEmail)
    {
        string sql = "UPDATE tblCustomer SET " +                   
                    "recivedEmail = @recivedEmail	WHERE Id = @CustomerID";
        SqlCommand cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = CustomerID;
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
                count=0;
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


    public DataTable GetBetweenById(int start, int end)
    {
        SqlCommand cmd = new SqlCommand("SELECT * FROM tblCustomer WHERE Id BETWEEN @start AND @end AND isDelete = 0",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@start", SqlDbType.Int).Value = start;
        cmd.Parameters.Add("@end", SqlDbType.Int).Value = end;
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

    public int GetLastId()
    {
        SqlCommand cmd = new SqlCommand("SELECT TOP 1 Id FROM tblCustomer ORDER BY Id DESC ",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        var CustomerID = cmd.ExecuteScalar();
        return int.Parse(CustomerID.ToString());
    }

    public int tblCustomerBackup_insert(CustomerDTO dt)
    {
        string sql = "INSERT INTO tblCustomerBackup(Id, Name, Gender, BirthDay, Email, Phone, Address, Type ,SecondPhone ,Fax ,Company ,City ,Province ,Country ,recivedEmail , countBuy) " +
                     "VALUES(@Id, @Name, @Gender, @BirthDay, @Email, @Phone, @Address, @Type, @SecondPhone, @Fax ,@Company ,@City ,@Province ,@Country ,@recivedEmail, @countBuy)";
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
        cmd.Parameters.Add("@recivedEmail", SqlDbType.Bit).Value = true;
        cmd.Parameters.Add("@countBuy", SqlDbType.Int).Value = 0;
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        return cmd.ExecuteNonQuery();
    }

    public int updateIsDelete(int status, int id)
    {
        SqlCommand cmd = new SqlCommand("UPDATE tblCustomer SET isDelete = @status WHERE Id = @Id ",
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@status", SqlDbType.Int).Value = status;
        cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        if (ConnectionData._MyConnection.State == ConnectionState.Closed)
        {
            ConnectionData._MyConnection.Open();
        }
        return cmd.ExecuteNonQuery();
    }

}
