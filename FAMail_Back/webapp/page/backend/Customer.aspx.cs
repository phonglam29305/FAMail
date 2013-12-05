﻿using System;
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

public partial class webapp_page_backend_Customer : System.Web.UI.Page
{
    CustomerBUS ctBUS;
    MailGroupBUS mgBUS;
    SendRegisterBUS srBUS;
    DetailGroupBUS dtgBUS;
    DataTable customer;
    DataTable group = null;
    DataTable customerBySelect;
    DataTable result = null;
    string expresion = "";
    DataRow[] row = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InitBUS();
            customer = new DataTable();
            customerBySelect = new DataTable();
            customer = ctBUS.GetAll();
            customerBySelect = customer;
            createTable();
            row = customer.Select(expresion);
            LoadCustomer();
            DataTable MailGroup = new DataTable();
            if (Session["us-login"] != null)
            {
                if (getUserLogin().DepartmentId == 1)
                {
                    MailGroup = mgBUS.GetAllNew();
                }
                else
                {
                    MailGroup = mgBUS.GetAllNew(getUserLogin().UserId);
                }
                if (MailGroup.Rows.Count > 0)
                {
                    createTableMail();
                    DataRow rowE = group.NewRow();
                    rowE["Id"] = 0;
                    rowE["Name"] = "Tất cả";
                    group.Rows.Add(rowE);
                    foreach (DataRow rowItem in MailGroup.Rows)
                    {
                        rowE = group.NewRow();
                        rowE["Id"] = rowItem["Id"];
                        rowE["Name"] = rowItem["Name"];
                        group.Rows.Add(rowE);
                    }
                }

                this.drlNhomMail.DataSource = group;
                this.drlNhomMail.DataTextField = "Name";
                this.drlNhomMail.DataValueField = "Id";
                this.drlNhomMail.DataBind();
            }
        }
        pnSearch.Visible = true;
        btnSearch.Visible = false;
    }

    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }

    protected void btnFilter_Click(object sender, EventArgs e)
    {
        GetExpresion();
        createTable();
        createTableCustomer();
        InitBUS();        
        int GroupID = 0;
        GroupID= int.Parse(drlNhomMail.SelectedValue.ToString());
        if (GroupID == 0)
        {
            customer = ctBUS.GetAll();
        }
        else
        {
            if (dtgBUS.GetByID(GroupID).Rows.Count > 0)
            {
                foreach (DataRow rowItem in dtgBUS.GetByID(GroupID).Rows)
                {
                    if (ctBUS.GetByID(int.Parse(rowItem["CustomerID"].ToString())).Rows.Count > 0)
                    {
                        DataRow rowFilter = customer.NewRow();
                        rowFilter["Id"] = ctBUS.GetByID(int.Parse(rowItem["CustomerID"].ToString())).Rows[0]["Id"];
                        rowFilter["Name"] = ctBUS.GetByID(int.Parse(rowItem["CustomerID"].ToString())).Rows[0]["Name"];
                        rowFilter["Gender"] = ctBUS.GetByID(int.Parse(rowItem["CustomerID"].ToString())).Rows[0]["Gender"];
                        rowFilter["Birthday"] = ctBUS.GetByID(int.Parse(rowItem["CustomerID"].ToString())).Rows[0]["Birthday"];
                        rowFilter["Email"] = ctBUS.GetByID(int.Parse(rowItem["CustomerID"].ToString())).Rows[0]["Email"];
                        rowFilter["Phone"] = ctBUS.GetByID(int.Parse(rowItem["CustomerID"].ToString())).Rows[0]["Phone"];
                        rowFilter["Address"] = ctBUS.GetByID(int.Parse(rowItem["CustomerID"].ToString())).Rows[0]["Address"];
                        customer.Rows.Add(rowFilter);
                    }
                }
            }
        }
        row = customer.Select(expresion);
        foreach (DataRow rowItem in row)
        {
            DataRow rowFilter = result.NewRow();
            rowFilter["Id"] = rowItem["Id"];
            rowFilter["Name"] = rowItem["Name"];
            rowFilter["Gender"] = rowItem["Gender"];
            rowFilter["Birthday"] = rowItem["Birthday"];
            rowFilter["Email"] = rowItem["Email"];
            rowFilter["Phone"] = rowItem["Phone"];
            rowFilter["Address"] = rowItem["Address"];
            result.Rows.Add(rowFilter);
        }
        dlPager.MaxPages = 1000;
        dlPager.PageSize = 50;
        dlPager.DataSource = result.DefaultView;
        dlPager.BindToControl = dtlCustomer;
        this.dtlCustomer.DataSource = dlPager.DataSourcePaged;
        this.dtlCustomer.DataBind(); 
        //dtlCustomer.DataSource = result;
        //dtlCustomer.DataBind();
    }
    private void GetExpresion()
    {
        
        string Email = this.txtEmail.Text;

        if (expresion == "")
        {
            expresion += "Email like '%" + Email + "%'";
        }
        else
        {
            expresion += " and Email like '%" + Email + "%'";
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
        string Phone = this.txtPhone.Text;
        if (Name != "" || Name != null)
        {
            if (expresion == "")
            {
                expresion += "Phone like '%" + Phone + "%'";
            }
            else
            {
                expresion += "and Phone like '%" + Phone + "%'";
            }
        }
        
       
    }
    private void LoadCustomer()
    {
        ctBUS = new CustomerBUS();
        try
        {
            dlPager.MaxPages = 1000;
            dlPager.PageSize = 50;
            dlPager.DataSource =  ctBUS.GetAll().DefaultView;
            dlPager.BindToControl = dtlCustomer;
            this.dtlCustomer.DataSource = dlPager.DataSourcePaged;
            this.dtlCustomer.DataBind(); 
        }
        catch (Exception) 
        {       
            
        }
       
    }

    private void InitBUS()
    {
        ctBUS = new CustomerBUS();
        mgBUS = new MailGroupBUS();
        srBUS = new SendRegisterBUS();
        dtgBUS = new DetailGroupBUS();
    }
    protected void lbtExecute_Click(object sender, EventArgs e)
    {
        try
        {
            DataListItem footer = (DataListItem)dtlCustomer.Controls[dtlCustomer.Controls.Count - 1];
            DropDownList drlType = (DropDownList)footer.FindControl("drlType");
            Label lblMessage = (Label)footer.FindControl("lblMessage");
            InitBUS();
            if (drlType.SelectedValue == "1")
            {
                int countDelete = 0;
                int countNoDelete = 0;
                for (int i = 0; i < dtlCustomer.Items.Count; i++)
                {
                    DataListItem item = dtlCustomer.Items[i];
                    HiddenField id = (HiddenField)item.FindControl("hdfId");
                    HiddenField Groupid = (HiddenField)item.FindControl("GroupID");
                    CheckBox chkXoa = (CheckBox)item.FindControl("chkCheck");
                    if (chkXoa.Checked == true)
                    {
                        ConnectionData.OpenMyConnection();
                        if (srBUS.GetByGroupID(int.Parse(Groupid.Value.ToString()), 0) > 0)
                        {
                            countNoDelete++;
                        }
                        else
                        {
                            ctBUS.tblCustomer_Delete(int.Parse(id.Value.ToString()));
                            countDelete++;
                        }
                        
                        ConnectionData.OpenMyConnection();
                       
                    }
                }
                LoadCustomer();
                pnSuccess.Visible = true;
                lblMessage.Text = countDelete.ToString();
                lblSuccess.Text = "Bạn xóa thành công: " + countDelete.ToString() + " Khách hàng \n<br> Không thành công :" + countNoDelete.ToString() + " khách hàng vì đang trong trạng thái chờ gửi!"; 

            }
            else
            {


            }

        }
        catch (Exception ex)
        {
            pnError.Visible = true;
            lblError.Text = ex.Message;
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
    private void createTableCustomer()
    {
        customer = new DataTable("customer");
        DataColumn Id = new DataColumn("Id");
        Id.DataType = System.Type.GetType("System.Int32");
        DataColumn Gender = new DataColumn("Gender");

        DataColumn Birthday = new DataColumn("Birthday");

        DataColumn Email = new DataColumn("Email");
        DataColumn Phone = new DataColumn("Phone");
        DataColumn Address = new DataColumn("Address");
        DataColumn Name = new DataColumn("Name");
        DataColumn[] key = { Id };
        customer.Columns.Add(Id);
        customer.Columns.Add(Gender);
        customer.Columns.Add(Birthday);
        customer.Columns.Add(Email);
        customer.Columns.Add(Phone);
        customer.Columns.Add(Address);
        customer.Columns.Add(Name);
        customer.PrimaryKey = key;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pnSearch.Visible = true;
        btnSearch.Visible = false;
        LoadCustomer();
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            ctBUS = new CustomerBUS();
            dtgBUS = new DetailGroupBUS();
            int CustomerID= int.Parse(((ImageButton)sender).CommandArgument.ToString());
            ConnectionData.OpenMyConnection();
            ctBUS.tblCustomer_Delete(CustomerID);
            dtgBUS.tblDetailGroup_DeleteByCustomerID(CustomerID);
            pnError.Visible = false;
            pnSuccess.Visible = true;
            lblSuccess.Text = "Xóa thành công một khách hàng ID: "+ CustomerID.ToString();
            ConnectionData.CloseMyConnection();
            LoadCustomer();
        }
        catch (Exception ex)
        {
            pnSuccess.Visible = false;
            pnError.Visible = true;
            lblError.Text = ex.Message;
        }
    }
}