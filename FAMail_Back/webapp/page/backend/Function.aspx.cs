﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Email;

public partial class webapp_page_backend_Default : System.Web.UI.Page
{
    FunctionBUS functionBus = new FunctionBUS();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                LoadData();
            }
            catch (Exception)
            {


            }
        }
    }
    private string checkInput()
    {
        string masseng = "";

        if (txtfunctionName.Text == "")
        {
            masseng = "Vui lòng nhập tên function";
        }
        else if (txtcode.Text == "")
        {
            masseng = "Vui lòng nhập giá vào";
        }
        else if (txtdiengiai.Text == "")
        {
            masseng = "Vui lòng nhập diễn giải";
        }
        return masseng;
    }
    private UserLoginDTO getUserLogin()
    {
        if (Session["us-login"] != null)
        {
            return (UserLoginDTO)Session["us-login"];
        }
        return null;
    }
    private FunctionDTO getfunctionDTO()
    {
        FunctionDTO sign = new FunctionDTO();
        UserLoginDTO userLogin = getUserLogin();
        if (userLogin != null)
        {
            sign.functionId = userLogin.UserId;
            sign.functionName = txtfunctionName.Text;
            sign.diengiai = txtdiengiai.Text;
            sign.cost = float.Parse(txtcode.Text);

        }
        return sign;


    }
    private void LoadData()
    {
       
     
       dtfunction.DataSource=functionBus.GetAll().DefaultView;
       dtfunction.DataBind();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        //try
        //{
            string message = checkInput();
            int status = 0;
            if (message == "")
            {

                FunctionDTO funDto = getfunctionDTO();
                ConnectionData.OpenMyConnection();
                if (hdfId.Value == null || hdfId.Value == "")//them moi
                {
                    functionBus.tblFunction_insert(funDto);
                    status = 1;
                }
                else
                {
                    functionBus.tblSignature_Update(funDto);
                        status=2;
                }
                ConnectionData.CloseMyConnection();
                pnSuccess.Visible = true;
                if (status == 1)
                {
                    lblSuccess.Text = "Bạn vừa thêm thành công chức năng !";
                }
                else
                    if (status == 2)
                    {
                        lblSuccess.Text = "Bạn vừa cập nhật thành công chức năng !";
                    }
            }
            else
            {

                pnSuccess.Visible = false;
                pnError.Visible = true;
                lblError.Text = message;

            }

        //}
        //catch (Exception)
        //{

        //    pnSuccess.Visible = false;
        //    pnError.Visible = true;
        //    lblError.Text = " Đã xảy ra lỗi trong quá trình thực hiện. Vui lòng thử lại !";
        //}
        LoadData();
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        
    }
    protected void btnDelete_Click1(object sender, ImageClickEventArgs e)
    {
       
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            int functionId=int.Parse((((ImageButton)sender).CommandArgument.ToString()));
            DataTable table = functionBus.GetByUserId(functionId);
            if (table.Rows.Count > 0)
            {
               
                txtfunctionName.Text = table.Rows[0]["functionName"].ToString();
                txtdiengiai.Text = table.Rows[0]["diengiai"].ToString();
                txtcode.Text = table.Rows[0]["cost"].ToString();


            }

          
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void btnDelete_Click2(object sender, ImageClickEventArgs e)
    {
        try
        {
            int functionId = int.Parse(((ImageButton)sender).CommandArgument.ToString());
            functionBus.tblFunction_Delete(functionId);
            LoadData();
            pnError.Visible = false;
            pnSuccess.Visible = true;
            lblSuccess.Text = "Bạn vừa xóa chữ ký thành công !";
        }
        catch (Exception ex)
        {

            pnError.Visible = true;
            lblError.Text = "Không thể xóa !</br>" + ex.Message;
        }
    }
    protected void dtfunction_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnCreateNew_Click(object sender, EventArgs e)
    {
        
           
                //FunctionDTO funDto = getfunctionDTO();
                //ConnectionData.OpenMyConnection();
                //functionBus.tblSignature_Update(funDto);
                //    LoadData();
        FunctionDTO functionDto = new FunctionDTO();

        functionDto.functionName = txtfunctionName.Text;
        functionDto.cost =float.Parse( txtcode.Text);
        if (functionBus.tblFunction_GetByID(txtfunctionName.Text).Rows.Count > 0)
        {
            functionBus.tblSignature_Update(functionDto);
        }


        LoadData();
        }


    protected void txtdiengiai_TextChanged(object sender, EventArgs e)
    {

    }
}