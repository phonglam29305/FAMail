using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using Email;

/// <summary>
/// Summary description for ProductDAO
/// </summary>
public class ProductDAO
{
    SqlCommand cmd;

	public ProductDAO()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public void tblProduct_insert(ProductDTO dt)
    {
        string sql = "INSERT INTO tblProduct(Title, AddedDate, AddedBy, LastModifyDate, LastModifyBy, Description, Excerpt, BodyContent, UnitPrice, UnitsInStock, Thumbnail, Category, Manufacture, PriorityOrder, IsDelete, Tag, Currency, Tax, Views, IsNew, Code, originalprice, DiscountPercentage, UnitPercent)" +
	                  " VALUES(@Title, @AddedDate, @AddedBy, @LastModifyDate, @LastModifyBy, @Description, @Excerpt, @BodyContent, @UnitPrice, @UnitsInStock, @Thumbnail, @Category, @Manufacture, @PriorityOrder, @IsDelete, @Tag, @Currency, @Tax, @Views, @IsNew, @Code, @originalprice, @DiscountPercentage, @UnitPercent)";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = dt.Title;
        cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = dt.AddedDate;
        cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = dt.AddedBy;
        cmd.Parameters.Add("@LastModifyDate", SqlDbType.DateTime).Value = dt.LastModifyDate;
        cmd.Parameters.Add("@LastModifyBy", SqlDbType.NVarChar).Value = dt.LastModifyBy;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.Parameters.Add("@Excerpt", SqlDbType.NVarChar).Value = dt.Excerpt;
        cmd.Parameters.Add("@BodyContent", SqlDbType.NVarChar).Value = dt.BodyContent;
        cmd.Parameters.Add("@UnitPrice", SqlDbType.NVarChar).Value = dt.UnitPrice;
        cmd.Parameters.Add("@UnitsInStock", SqlDbType.Int).Value = dt.UnitsInStock;
        cmd.Parameters.Add("@Thumbnail", SqlDbType.NVarChar).Value = dt.Thumbnail;
        cmd.Parameters.Add("@Category", SqlDbType.Int).Value = dt.Category;
        cmd.Parameters.Add("@Manufacture", SqlDbType.Int).Value = dt.Manufacture;
        cmd.Parameters.Add("@PriorityOrder", SqlDbType.Int).Value = dt.PriorityOrder;
        cmd.Parameters.Add("@IsDelete", SqlDbType.Bit).Value = dt.IsDelete;
        cmd.Parameters.Add("@Tag", SqlDbType.NVarChar).Value = dt.Tag;
        cmd.Parameters.Add("@Currency", SqlDbType.Int).Value = dt.Currency;
        cmd.Parameters.Add("@Tax", SqlDbType.Int).Value = dt.Tax;
        cmd.Parameters.Add("@Views", SqlDbType.Int).Value = dt.Views;
        cmd.Parameters.Add("@IsNew", SqlDbType.Bit).Value = dt.IsNew;
        cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = dt.Code;
        cmd.Parameters.Add("@originalprice", SqlDbType.Bit).Value = dt.originalprice;
        cmd.Parameters.Add("@DiscountPercentage", SqlDbType.Float).Value = dt.DiscountPercentage;
        cmd.Parameters.Add("@UnitPercent", SqlDbType.Bit).Value = dt.UnitPercent;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblProduct_Update(ProductDTO dt)
    {
        string sql = "UPDATE tblProduct SET "+
                    "Title = @Title, " +
	                "AddedDate = @AddedDate, "+
	                "AddedBy = @AddedBy, "+
	                "LastModifyDate = @LastModifyDate, "+
	                "LastModifyBy = @LastModifyBy, "+
	                "Description = @Description, "+
	                "Excerpt = @Excerpt, "+
	                "BodyContent = @BodyContent, "+
	                "UnitPrice = @UnitPrice, "+
	                "UnitsInStock = @UnitsInStock, "+
	                "Thumbnail = @Thumbnail, "+
	                "Category = @Category, "+
	                "Manufacture = @Manufacture, "+
	                "PriorityOrder = @PriorityOrder, "+
	                "IsDelete = @IsDelete, "+
	                "Tag = @Tag, "+
	                "Currency = @Currency, "+
	                "Tax = @Tax, "+
	                "Views = @Views, "+
	                "IsNew = @IsNew, "+
	                "Code = @Code, "+
	                "originalprice = @originalprice, "+
	                "DiscountPercentage = @DiscountPercentage, "+
	                "UnitPercent = @UnitPercent	WHERE ID = @ID" ;
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = dt.Title;
        cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = dt.AddedDate;
        cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = dt.AddedBy;
        cmd.Parameters.Add("@LastModifyDate", SqlDbType.DateTime).Value = dt.LastModifyDate;
        cmd.Parameters.Add("@LastModifyBy", SqlDbType.NVarChar).Value = dt.LastModifyBy;
        cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = dt.Description;
        cmd.Parameters.Add("@Excerpt", SqlDbType.NVarChar).Value = dt.Excerpt;
        cmd.Parameters.Add("@BodyContent", SqlDbType.NVarChar).Value = dt.BodyContent;
        cmd.Parameters.Add("@UnitPrice", SqlDbType.NVarChar).Value = dt.UnitPrice;
        cmd.Parameters.Add("@UnitsInStock", SqlDbType.Int).Value = dt.UnitsInStock;
        cmd.Parameters.Add("@Thumbnail", SqlDbType.NVarChar).Value = dt.Thumbnail;
        cmd.Parameters.Add("@Category", SqlDbType.Int).Value = dt.Category;
        cmd.Parameters.Add("@Manufacture", SqlDbType.Int).Value = dt.Manufacture;
        cmd.Parameters.Add("@PriorityOrder", SqlDbType.Int).Value = dt.PriorityOrder;
        cmd.Parameters.Add("@IsDelete", SqlDbType.Bit).Value = dt.IsDelete;
        cmd.Parameters.Add("@Tag", SqlDbType.NVarChar).Value = dt.Tag;
        cmd.Parameters.Add("@Currency", SqlDbType.Int).Value = dt.Currency;
        cmd.Parameters.Add("@Tax", SqlDbType.Int).Value = dt.Tax;
        cmd.Parameters.Add("@Views", SqlDbType.Int).Value = dt.Views;
        cmd.Parameters.Add("@IsNew", SqlDbType.Bit).Value = dt.IsNew;
        cmd.Parameters.Add("@Code", SqlDbType.NVarChar).Value = dt.Code;
        cmd.Parameters.Add("@originalprice", SqlDbType.Bit).Value = dt.originalprice;
        cmd.Parameters.Add("@DiscountPercentage", SqlDbType.Float).Value = dt.DiscountPercentage;
        cmd.Parameters.Add("@UnitPercent", SqlDbType.Bit).Value = dt.UnitPercent;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public void tblProduct_Delete(int ID)
    {
        string sql = "DELETE FROM tblProduct WHERE ID = @ID";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        cmd.ExecuteNonQuery();
        cmd.Dispose();
    }
    public DataTable GetAll()
    {
        string sql = "SELECT * FROM tblProduct";
        SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }
    public DataTable GetByID(int ID)
    {
        string sql = "SELECT * FROM tblProduct WHERE ID = @ID";
        cmd = new SqlCommand(sql, ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

}
