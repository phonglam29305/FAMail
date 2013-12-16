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

public partial class webapp_page_backend_FillterCustomer : System.Web.UI.Page
{
    CustomerBUS ctBUS;
    MailGroupBUS mgBUS;
    SendRegisterBUS srBUS;
    DetailGroupBUS dsgBUS;
    DataTable customer;
    DataTable customerBySelect;
    DataTable result = null;
    string expresion = "";
    DataRow[] row = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                    InitBUS();           
                    customer = new DataTable();
                    customerBySelect = new DataTable();
                    if (getUserLogin().DepartmentId == 1)
                    {
                        customer = ctBUS.GetAll();
                    }
                    else
                    {
                        customer = ctBUS.GetAllByUser(getUserLogin().UserId);
                    }
                    customerBySelect = customer;
                    LoadCustomer();
                    createTable();
                    row = customer.Select(expresion);
                    chkAgeAll.Checked = true;
                    this.txtAge.Visible = false;

            }
            catch (Exception)
            {
              
            }
        }
    }

    private void LoadCustomer()
    {
        mgBUS = new MailGroupBUS();
        try
        {
            dlPager.MaxPages = 1000;
            dlPager.PageSize = 50;
            dlPager.DataSource = customerBySelect.DefaultView;
            dlPager.BindToControl = dtlCustomer;
            this.dtlCustomer.DataSource = dlPager.DataSourcePaged;
            this.dtlCustomer.DataBind();
            if (Session["us-login"] != null)
            {
                if (getUserLogin().DepartmentId == 1)
                {
                    this.drlSubGroup.DataSource = mgBUS.GetAllNew();
                }
                else
                {
                    this.drlSubGroup.DataSource = mgBUS.GetAllNew(getUserLogin().UserId);
                }
            }
            //this.drlSubGroup.DataSource = mgBUS.GetAllNew(getSessionId());
            this.drlSubGroup.DataTextField = "Name";
            this.drlSubGroup.DataValueField = "Id";
            this.drlSubGroup.DataBind();
        }
        catch (Exception)
        {


        }

    }
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
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
        GetExpresion();
        createTable();
        ctBUS = new CustomerBUS();
        if (getUserLogin().DepartmentId == 1)
        {
            customer = ctBUS.GetAll();
        }
        else
        {
            customer = ctBUS.GetAllByUser(getUserLogin().UserId);
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
        dtlCustomer.DataSource = result;
        dtlCustomer.DataBind();
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
        if (chkAgeAll.Checked == true)
        {
            chkAgeTo.Checked = false;

        }
        else
        {
            int age = 100;
            if (txtAge.Text != "")
            {
                bool isNum = int.TryParse(txtAge.Text, out age);
                if (isNum)
                {
                    age = int.Parse(txtAge.Text.Trim());
                    if (expresion == "")
                    {
                        expresion += "Birthday < #" + String.Format("{0:yyyy-M-d HH:mm:ss}", DateTime.Now.AddYears(-age)) + "#";
                    }
                    else
                    {
                        expresion += " and BirthDay < #" + String.Format("{0:yyyy-M-d HH:mm:ss}", DateTime.Now.AddYears(-age)) + "#";
                    }
                }
            }
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

        }

    }

    private void Visible(bool p)
    {
        pnError.Visible = p;
        pnSuccess.Visible=p;
    }
    protected void chkAgeAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAgeAll.Checked == true)
        {
            chkAgeTo.Checked = false;
            this.txtAge.Visible = false;

        }
        else
        {
            chkAgeTo.Visible = true;
        }
        
         
    }
    protected void chkAgeTo_CheckedChanged(object sender, EventArgs e)
    {
        if (chkAgeTo.Checked == true)
        {
            chkAgeAll.Checked = false;
            this.txtAge.Visible = true;
        }
        else
        {
            chkAgeAll.Visible = true;
        }
    }
}
