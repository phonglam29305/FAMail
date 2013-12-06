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
using System.Data.OleDb;
using System;
using System.Security.Cryptography;
using System.Text;
using Email;
using System.Data.SqlClient;
/// <summary>
/// Summary description for Common
/// </summary>
public class Common
{
    private static string convertCurrentDate()
    {
        DateTime d = DateTime.Now;
        string[] thu = { " Chủ nhật", " Thứ hai", " Thứ ba", " Thứ tư", "Thứ năm", " Thứ sáu", " Thứ bảy" };
        int i = d.DayOfWeek.GetHashCode();
        string rs = "Hôm nay: " + thu[i] + " - " + d.ToShortDateString();
        //"Hôm nay: " + thu[i] + " Ngày " + d.Day + " Tháng " + d.Month + " Năm " + d.Year + ", Hiện Giờ Là " + d.ToShortTimeString();
        return rs;
    }
    public DataTable ReadExcelContents(string fileName)
    {
        try
        {
            OleDbConnection connection = new OleDbConnection();
            connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Excel 8.0;Data Source=" + fileName); //Excel 97-2003, .xls
            string excelQuery = @"Select * FROM [Sheet1$]";
            connection.Open();
            OleDbCommand cmd = new OleDbCommand(excelQuery, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }
        catch (Exception ex)
        {
                return null;
        }
    }
  

	public int calculatorMinuteQuantityEmail(int count)
    {
        int calc = count / 1;
        return calc;
    }

    /********************************************/
    /*                      MD5
    /********************************************/
    public static string GetMd5Hash(string input)
    {
        MD5 md5Hash = MD5.Create();
        // Convert the input string to a byte array and compute the hash. 
        byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        // Create a new Stringbuilder to collect the bytes 
        // and create a string.
        StringBuilder sBuilder = new StringBuilder();

        // Loop through each byte of the hashed data  
        // and format each one as a hexadecimal string. 
        for (int i = 0; i < data.Length; i++)
        {
            sBuilder.Append(data[i].ToString("x2"));
        }

        // Return the hexadecimal string. 
        return sBuilder.ToString();
    }

    // Verify a hash against a string. 
    public static bool VerifyMd5Hash(string input, string hash)
    {
        // Hash the input. 
        string hashOfInput = GetMd5Hash(input);

        // Create a StringComparer an compare the hashes.
        StringComparer comparer = StringComparer.OrdinalIgnoreCase;

        if (0 == comparer.Compare(hashOfInput, hash))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public DataTable CreateDetailOrder()
    {

        DataTable dt = new DataTable("CreateDetailOrder");
        DataColumn No = new DataColumn("No");
        DataColumn ProductID = new DataColumn("ProductID");
        DataColumn ProductName = new DataColumn("ProductName");
        DataColumn DeliveryCode = new DataColumn("DeliveryCode");
        DataColumn UnitPrice = new DataColumn("UnitPrice");
        DataColumn Quantity = new DataColumn("Quantity");     
        DataColumn Total = new DataColumn("Total");
        //VatLieu.DataType = System.Type.GetType("System.Double");
        DataColumn Note = new DataColumn("Note");

        DataColumn[] key = { ProductID };
        dt.Columns.Add(No);
        dt.Columns.Add(ProductID);
        dt.Columns.Add(ProductName);
        dt.Columns.Add(DeliveryCode);
        dt.Columns.Add(UnitPrice);
        dt.Columns.Add(Quantity);
        dt.Columns.Add(Total);
        dt.Columns.Add(Note);
        dt.PrimaryKey = key;
        return dt;
    }
    public string NextID(string lastID, string prefixID)
    {
        int nextID = int.Parse(lastID.Remove(0, prefixID.Length)) + 1;
        int lengthNumberID = lastID.Length - prefixID.Length;
        string zeroNumber = "";
        for (int i = 1; i <= lengthNumberID; i++)
        {
            if (nextID < Math.Pow(10, i))
            {
                for (int j = 1; j <= lengthNumberID - i; j++)
                {
                    zeroNumber += "0";
                }
                return prefixID + zeroNumber + nextID.ToString();
            }
        }
        return prefixID +"-"+ nextID;
    }

    public string GetLastID(string tableName, string fieldName, string prefixID)
    {
        string lastID = "";
        string sql = "Select top 1 " + fieldName + " From " + tableName + " Order By " + fieldName + " Desc";
        DataTable tbl = this.GetDataTable(sql);
        //Lấy cột đầu tiên là mã 
        if (tbl.Rows.Count > 0)
        {
            lastID = tbl.Rows[0][fieldName].ToString();
        }
        else
        {
            lastID =  prefixID + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + "00";
        }
        return lastID;
    }
    public DataTable GetDataTable(string sql)
    {
       
        if (ConnectionData._MyConnection.State== ConnectionState.Closed)
        {
            ConnectionData.OpenMyConnection();
        }
        SqlDataAdapter adapter = new SqlDataAdapter(sql, ConnectionData._MyConnection);
        DataTable table = new DataTable();
        adapter.Fill(table);
        adapter.Dispose();
        return table;
    }

    private string[] ChuSo = new string[10] { " không", " một", " hai", " ba", " bốn", " năm", " sáu", " bẩy", " tám", " chín" };
    private string[] Tien = new string[6] { "", " nghìn", " triệu", " tỷ", " nghìn tỷ", " triệu tỷ" };
    // Hàm đọc số thành chữ
    public string DocTienBangChu(long SoTien, string strTail)
    {
        int lan, i;
        long so;
        string KetQua = "", tmp = "";
        int[] ViTri = new int[6];
        if (SoTien < 0) return "Số tiền âm !";
        if (SoTien == 0) return "Không đồng !";
        if (SoTien > 0)
        {
            so = SoTien;
        }
        else
        {
            so = -SoTien;
        }
        //Kiểm tra số quá lớn
        if (SoTien > 8999999999999999)
        {
            SoTien = 0;
            return "";
        }
        ViTri[5] = (int)(so / 1000000000000000);
        so = so - long.Parse(ViTri[5].ToString()) * 1000000000000000;
        ViTri[4] = (int)(so / 1000000000000);
        so = so - long.Parse(ViTri[4].ToString()) * +1000000000000;
        ViTri[3] = (int)(so / 1000000000);
        so = so - long.Parse(ViTri[3].ToString()) * 1000000000;
        ViTri[2] = (int)(so / 1000000);
        ViTri[1] = (int)((so % 1000000) / 1000);
        ViTri[0] = (int)(so % 1000);
        if (ViTri[5] > 0)
        {
            lan = 5;
        }
        else if (ViTri[4] > 0)
        {
            lan = 4;
        }
        else if (ViTri[3] > 0)
        {
            lan = 3;
        }
        else if (ViTri[2] > 0)
        {
            lan = 2;
        }
        else if (ViTri[1] > 0)
        {
            lan = 1;
        }
        else
        {
            lan = 0;
        }
        for (i = lan; i >= 0; i--)
        {
            tmp = DocSo3ChuSo(ViTri[i]);
            KetQua += tmp;
            if (ViTri[i] != 0) KetQua += Tien[i];
            if ((i > 0) && (!string.IsNullOrEmpty(tmp))) KetQua += ",";//&& (!string.IsNullOrEmpty(tmp))
        }
        if (KetQua.Substring(KetQua.Length - 1, 1) == ",") KetQua = KetQua.Substring(0, KetQua.Length - 1);
        KetQua = KetQua.Trim() + strTail;
        return KetQua.Substring(0, 1).ToUpper() + KetQua.Substring(1);
    }
    // Hàm đọc số có 3 chữ số
    private string DocSo3ChuSo(int baso)
        {
            int tram, chuc, donvi;
            string KetQua = "";
            tram = (int)(baso / 100);
            chuc = (int)((baso % 100) / 10);
            donvi = baso % 10;
            if ((tram == 0) && (chuc == 0) && (donvi == 0)) return "";
            if (tram != 0)
            {
                KetQua += ChuSo[tram] + " trăm";
                if ((chuc == 0) && (donvi != 0)) KetQua += " linh";
            }
            if ((chuc != 0) && (chuc != 1))
            {
                KetQua += ChuSo[chuc] + " mươi";
                if ((chuc == 0) && (donvi != 0)) KetQua = KetQua + " linh";
            }
            if (chuc == 1) KetQua += " mười";
            switch (donvi)
            {
                case 1:
                    if ((chuc != 0) && (chuc != 1))
                    {
                        KetQua += " mốt";
                    }
                    else
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
                case 5:
                    if (chuc == 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    else
                    {
                        KetQua += " lăm";
                    }
                    break;
                default:
                    if (donvi != 0)
                    {
                        KetQua += ChuSo[donvi];
                    }
                    break;
            }
            return KetQua;
        }

    public static Boolean checkRoleByRoleId(int roleId, int departmentId) {
        if (departmentId == 1)//administrator
            return true;
        RoleDetailBUS rdBus = new RoleDetailBUS();
        DataTable tblRole = rdBus.GetByDepartmentIdAndRole(roleId, departmentId);
        if (tblRole.Rows.Count > 0)
            return true;
        return false;
    }
    public static int countHasCreateMailByUserId(int userId)
    {
        MailGroupDAO mailGroupDao = new MailGroupDAO();
        return mailGroupDao.countCustomerByUserId(userId);
    }

    public static DataTable GetSendRegisterByUserId(int userId)
    {
        string sql = "";
        sql += "SELECT  sr.Id, sr.AccountId, sr.StartDate, sr.EndDate, sr.SendContentId, sr.SendType, sr.Status, sr.ErrorType, sr.MailConfigID, sr.GroupTo ";
        sql += "FROM   tblSendRegister AS sr INNER JOIN ";
        sql += "tblSendRegisterDetail AS srd ON sr.Id = srd.SendRegisterId ";
        sql += "WHERE     (sr.AccountId = @userId)";
        SqlCommand cmd = new SqlCommand(sql,
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }
    public static DataTable GetCustomerCreatedByUserId(int userId)
    {
        string sql = "";
        sql += "SELECT  mg.Id, mg.Name, mg.Description, mg.UserId, dg.GroupID, dg.CustomerID, dg.countReceivedMail, dg.LastReceivedMail ";
        sql += "FROM   tblMailGroup AS mg INNER JOIN ";
        sql += "tblDetailGroup AS dg ON mg.Id = dg.GroupID ";
        sql += "WHERE     (mg.UserId = @userId)";
        SqlCommand cmd = new SqlCommand(sql,
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public static DataTable GetUserLoginDetail(int userId)
    {
        string sql = "";
        sql += "SELECT  ul.UserId, ul.Username, ul.Password, ul.DepartmentId, ul.hasSendMail, d.ID, d.Name, d.Description, d.Role ";
        sql += "FROM   tblUserLogin AS ul INNER JOIN ";
        sql += "tblDepartment AS d ON ul.DepartmentId = d.ID ";
        sql += "WHERE     (ul.UserId = @userId) ";
        SqlCommand cmd = new SqlCommand(sql,
            ConnectionData._MyConnection);
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        DataTable table = new DataTable();
        adapter.Fill(table);
        cmd.Dispose();
        adapter.Dispose();
        return table;
    }

    public static int DeleteDataByUserId(int userId)
    {
        return 0;
    }

    enum userType : int
    {
        Admin = 0, Client = 1, subClient = 2
    }
    enum clientStatus : int
    {
        Online = 0, Expire = 1, Suppend = 2
    }
    enum registerType : int
    {
        New = 0, Extension = 1, Upgrade = 2, addFunction = 3
    }
    

}
