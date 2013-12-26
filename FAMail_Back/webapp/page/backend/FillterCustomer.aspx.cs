using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Email;
using log4net;

public partial class webapp_page_backend_FillterCustomer : System.Web.UI.Page
{
    CustomerBUS ctBUS;
    MailGroupBUS mgBUS;
    SendRegisterBUS srBUS;
    DetailGroupBUS dsgBUS;
    DataTable group = null;
    DataTable customer;
    DataTable customerBySelect;
    DataTable result = null;
    string expresion = "";
    DataRow[] row = null;
    log4net.ILog logs = log4net.LogManager.GetLogger("ErrorRollingLogFileAppender");
    UserLoginDTO userLogin = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            userLogin = getUserLogin();
            try
            {
                InitBUS();
                LoadSubGroup();
                //LoadCustomer();


            }
            catch (Exception)
            {

            }
        }
    }

    private void LoadSubGroup()
    {
        try
        {
            DataTable MailGroup = new DataTable();
            if (Session["us-login"] != null)
            {
                if (getUserLogin().DepartmentId == 1)
                {
                    MailGroup = mgBUS.GetAllNew();
                }
                if (getUserLogin().DepartmentId == 3)
                {
                    MailGroup = mgBUS.GetAllNewDepart3(getUserLogin().UserId);
                }
                if (getUserLogin().DepartmentId == 2)
                {
                    MailGroup = mgBUS.GetAllNew(getUserLogin().UserId);
                }
                if (MailGroup.Rows.Count > 0)
                {
                    createTableMail();
                    DataRow rowE = null;
                    if (getUserLogin().DepartmentId == 1)
                    {
                        rowE = group.NewRow();
                        rowE["Id"] = 0;
                        rowE["Name"] = "Tất cả";
                        group.Rows.Add(rowE);
                    }
                    foreach (DataRow rowItem in MailGroup.Rows)
                    {
                        rowE = group.NewRow();
                        rowE["Id"] = rowItem["Id"];
                        rowE["Name"] = rowItem["Name"];
                        group.Rows.Add(rowE);
                    }
                }
                this.drlSubGroup.DataSource = group;
                this.drlSubGroup.DataTextField = "Name";
                this.drlSubGroup.DataValueField = "Id";
                this.drlSubGroup.DataBind();
            }
        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Client - LoadSubGroup", ex);
        }

        // pnSearch.Visible = true;
        // btnSearch.Visible = false;
    }

    private void createTableMail()
    {
        group = new DataTable("group");
        DataColumn Id = new DataColumn("Id");
        Id.DataType = System.Type.GetType("System.Int32");
        DataColumn Name = new DataColumn("Name");
        DataColumn[] key = { Id };
        group.Columns.Add(Id);
        group.Columns.Add(Name);
        group.PrimaryKey = key;
    }

    private void LoadCustomer()
    {

        mgBUS = new MailGroupBUS();
        customer = new DataTable();
        customerBySelect = new DataTable();
        int GroupID = 0;
        GroupID = int.Parse(drlSubGroup.SelectedValue.ToString());
        if (getUserLogin().DepartmentId == 1)
        {
            //customer = ctBUS.GetAll();
            customer = ctBUS.GetAllFilterCustomer(txtName.Text.Trim(), txtAddress.Text.Trim(), GroupID);
        }
        else
        {
            customer = ctBUS.GetAllByUserAssignTo(getUserLogin().UserId, GroupID);
        }
        //customerBySelect = customer;
        try
        {
            dlPager.MaxPages = 1000;
            dlPager.PageSize = 50;
            dlPager.DataSource = customer.DefaultView;
            dlPager.BindToControl = dtlCustomer;
            this.dtlCustomer.DataSource = dlPager.DataSourcePaged;
            this.dtlCustomer.DataBind();

        }

        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Client - LoadCustomer", ex);
        }

    }
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        else Response.Redirect("~");//test confict
        return null;
    }
    private int getSessionId()
    {
        if (Session["ID"].ToString() != null || Session["ID"].ToString() != "")
        {
            return int.Parse(Session["ID"].ToString());
        }
        else
        {
            return 0;
        }
    }
    private int getSessionDepartmentId()
    {
        if (Session["DepartmentID"].ToString() != null || Session["DepartmentID"].ToString() != "")
        {
            return int.Parse(Session["DepartmentID"].ToString());
        }
        return 0;
    }
    private void InitBUS()
    {
        ctBUS = new CustomerBUS();
        mgBUS = new MailGroupBUS();
        srBUS = new SendRegisterBUS();
        dsgBUS = new DetailGroupBUS();

    }

    protected void drlGender_SelectedIndexChanged(object sender, EventArgs e)
    {

        //string gender = "";
        // gender = drlGender.SelectedValue.ToString();
        //if (expresion == "")
        //{
        //    if (gender == "*")
        //    {

        //    }
        //    else
        //    {
        //        expresion += "Gender = '" + gender + "'";
        //    }
        //}
        //else
        //{
        //    if (gender == "*")
        //    {

        //    }
        //    else
        //    {
        //        expresion += "and Gender = '" + gender + "'";

        //    }
        //}
    }

    private void createTable()
    {
        result = new DataTable("result");
        DataColumn Id = new DataColumn("Id");
        Id.DataType = System.Type.GetType("System.Int32");
        DataColumn Gender = new DataColumn("Gender");
        DataColumn Birthday = new DataColumn("Birthday");
        DataColumn Email = new DataColumn("Email");
        DataColumn Phone = new DataColumn("Phone");
        DataColumn Address = new DataColumn("Address");
        DataColumn Name = new DataColumn("Name");
        DataColumn[] key = { Id };
        result.Columns.Add(Id);
        result.Columns.Add(Gender);
        result.Columns.Add(Birthday);
        result.Columns.Add(Email);
        result.Columns.Add(Phone);
        result.Columns.Add(Address);
        result.Columns.Add(Name);
        result.PrimaryKey = key;
    }
    protected void txtAddress_TextChanged(object sender, EventArgs e)
    {


    }
    protected void btnFilter_Click(object sender, EventArgs e)
    {
        try
        {
            //  GetExpresion();
            //  createTable();
            customer = new DataTable();
            ctBUS = new CustomerBUS();
            dsgBUS = new DetailGroupBUS();
            int GroupID = 0;
            GroupID = int.Parse(drlSubGroup.SelectedValue.ToString());

            if (getUserLogin().DepartmentId == 1)
            {
                //customer = ctBUS.GetAll();
                customer = ctBUS.GetAllFilterCustomer(txtName.Text.Trim(), txtAddress.Text.Trim(), GroupID);

            }
            else
                customer = ctBUS.GetAllByUserAssignTo(getUserLogin().UserId, GroupID);
            /*
            if (getUserLogin().DepartmentId == 3)
            {
                DataTable dtCustomerID = ctBUS.GetAllCustomerDepart3(getUserLogin().UserId, GroupID);
                if (dtCustomerID.Rows.Count > 0)
                {
                    int CustomerID = int.Parse(dtCustomerID.Rows[0]["ID"].ToString());
                    for (int i = 0; i < dtCustomerID.Rows.Count; i++)
                    {
                        if (dsgBUS.GetByID(GroupID, CustomerID).Rows.Count > 0)
                        {
                            customer = ctBUS.GetCustomerByCustomerID(getUserLogin().UserId, CustomerID, GroupID);
                        }
                        else
                        {
                            customer = ctBUS.GetAllCustomerDepart3(getUserLogin().UserId, GroupID);
                        }
                    }
                }
              
               
            }
            if (getUserLogin().DepartmentId == 2)
            {
                DataTable dtCustomerID = ctBUS.GetAllByUserAssignTo(getUserLogin().UserId, GroupID);
                if (dtCustomerID.Rows.Count > 0)
                {
                    int CustomerID = int.Parse(dtCustomerID.Rows[0]["ID"].ToString());
                    for (int i = 0; i < dtCustomerID.Rows.Count; i++)
                    {
                        if (dsgBUS.GetByID(GroupID, CustomerID).Rows.Count > 0)
                        {
                            customer = ctBUS.GetCustomerByCustomerID(getUserLogin().UserId, CustomerID, GroupID);
                        }
                        else
                        {
                            customer = ctBUS.GetAllByUserAssignTo(getUserLogin().UserId, GroupID);
                        }
                        
                    }
                }
               
            }*/

            //row = customer.Select(expresion);
            //foreach (DataRow rowItem in row)
            //{
            //    DataRow rowFilter = result.NewRow();
            //    rowFilter["Id"] = rowItem["Id"];
            //    rowFilter["Name"] = rowItem["Name"];
            //    rowFilter["Gender"] = rowItem["Gender"];
            //    rowFilter["Birthday"] = rowItem["Birthday"];
            //    rowFilter["Email"] = rowItem["Email"];
            //    rowFilter["Phone"] = rowItem["Phone"];
            //    rowFilter["Address"] = rowItem["Address"];
            //    result.Rows.Add(rowFilter);
            //}

            dlPager.MaxPages = 1000;
            dlPager.PageSize = 50;
            dlPager.DataSource = customer.DefaultView;
            dlPager.BindToControl = dtlCustomer;
            this.dtlCustomer.DataSource = dlPager.DataSourcePaged;
            this.dtlCustomer.DataBind();
        }
        catch (Exception ex)
        {

            logs.Error(userLogin.Username + "-Client - btnFilter_Click", ex);
        }

    }

    private void GetExpresion()
    {
        string gender = "";
        //// gender = drlGender.SelectedValue.ToString();
        // if (expresion == "")
        // {
        //     if (gender == "*")
        //     {

        //     }
        //     else
        //     {
        //         expresion += "Gender = '" + gender + "'";

        //     }
        // }
        // else
        // {
        //     if (gender == "*")
        //     {

        //     }
        //     else
        //     {
        //         expresion += "and Gender = '" + gender + "'";

        //     }
        // }
        string addr = this.txtAddress.Text;

        if (expresion == "")
        {
            expresion += "Address like '%" + addr + "%'";
        }
        else
        {
            expresion += " and Address like '%" + addr + "%'";
        }


        string Name = this.txtName.Text;
        if (Name != "" || Name != null)
        {
            if (expresion == "")
            {
                expresion += "Name like '%" + Name + "%'";
            }
            else
            {
                expresion += "and Name like '%" + Name + "%'";
            }
        }
    }
    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)sender;
        if (chkAll != null)
        {
            for (int i = 0; i < dtlCustomer.Items.Count; i++)
            {
                DataListItem item = dtlCustomer.Items[i];
                CheckBox chk = (CheckBox)item.FindControl("chkCheck");
                chk.Checked = chkAll.Checked;
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        CustomerDTO ctDTO = new CustomerDTO();
        InitBUS();
        int count = 0;
        int err = 0;
        try
        {
            for (int i = 0; i < dtlCustomer.Items.Count; i++)
            {
                DataListItem item = dtlCustomer.Items[i];
                CheckBox chkXoa = (CheckBox)item.FindControl("chkCheck");
                HiddenField CustomerID = (HiddenField)item.FindControl("hdfId");

                if (chkXoa.Checked == true)
                {
                    try
                    {
                        ConnectionData.OpenMyConnection();
                        DetailGroupDTO dsgDTO = new DetailGroupDTO();
                        dsgDTO.GroupID = int.Parse(drlSubGroup.SelectedValue.ToString());
                        dsgDTO.CustomerID = int.Parse(CustomerID.Value.ToString());
                        dsgDTO.CountReceivedMail = 0;
                        dsgDTO.LastReceivedMail = DateTime.Now;
                        if (dsgBUS.GetByID(dsgDTO.GroupID, dsgDTO.CustomerID).Rows.Count > 0)
                        {
                            err++;
                        }
                        else
                        {
                            dsgBUS.tblDetailGroup_insert(dsgDTO);
                            count++;
                        }
                        ConnectionData.OpenMyConnection();
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                }
            }
            Visible(false);
            pnSuccess.Visible = true;
            lblSuccess.Text = "Bạn đã thêm thành công " + count + " khách hàng vào nhóm: " + drlSubGroup.SelectedItem.ToString() + " và trùng :" + err.ToString() + " khách hàng.";

        }
        catch (Exception ex)
        {
            logs.Error(userLogin.Username + "-Client - btnSave_Click", ex);
        }

    }

    private void Visible(bool p)
    {
        pnError.Visible = p;
        pnSuccess.Visible = p;
    }

}
