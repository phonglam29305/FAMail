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

public partial class webapp_page_backend_ManageSpamKeyword : System.Web.UI.Page
{
    SpamRuleBUS spamBUS ;
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

    private void LoadData()
    {
        spamBUS = new SpamRuleBUS();
        dlPager.MaxPages = 1000;
        dlPager.PageSize = 15;
        dlPager.DataSource = spamBUS.GetAll().DefaultView;
        dlPager.BindToControl = dtlSpam;
        this.dtlSpam.DataSource = dlPager.DataSourcePaged;
        this.dtlSpam.DataBind(); 
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            string err=  ValidateNull();
              if (err == "")
              {
                  spamBUS = new SpamRuleBUS();
                  SpamRuleDTO spamDTO = new SpamRuleDTO();
                  spamDTO.Keyword = txtKeyword.Text;
                  spamDTO.Score = float.Parse(txtScore.Text);
                  spamDTO.SameWord = txtSameWord.Text;
                  int i = 0;
                  if (spamBUS.tblSpamRule_GetByID(txtKeyword.Text).Rows.Count > 0)
                  {
                      spamBUS.tblSpamRule_Update(spamDTO);
                      i = 1;
                  }
                  else
                  {
                      spamBUS.tblSpamRule_insert(spamDTO);
                  }
                  if (i == 1)
                  {
                      pnError.Visible = false;
                      pnSuccess.Visible = true;
                      lblSuccess.Text = "Bạn đã cập nhật thành công ";
                  }
                  else
                  {
                      pnError.Visible = false;
                      pnSuccess.Visible = true;
                      lblSuccess.Text = "Bạn đã thêm thành công ";
                  }
                  LoadData();
                  txtKeyword.Text = "";
                  txtScore.Text = "";
                  txtSameWord.Text = "";
              }
              else
              {
                  pnError.Visible = true;
                  pnSuccess.Visible = false;
                  lblError.Text =err;
              }
        }
        catch (Exception)
        {

            pnError.Visible = true;
            pnSuccess.Visible = false;
            lblError.Text = "Lỗi trong quá trình nhập";
        }
     
    }
  

    private string ValidateNull()
    {
        float outF;
        string err = "";
        if (txtKeyword.Text == "")
        {
            err = "Bạn chưa nhập từ khóa spam";
            txtKeyword.Focus();
        }
        else if (txtScore.Text == "" || float.TryParse(txtScore.Text, out outF) == false || float.Parse(txtScore.Text) > 1)
        {
            txtScore.Focus();
            err = "Bạn chưa nhập điểm spam hoặc không đúng định dạng ! Điểm số phải lớn hơn 0 và bé hơn 1";
        }
      
        return err;
    }
    protected void btnEdit_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
                  string Keyword = ((ImageButton)sender).CommandArgument;
                spamBUS = new SpamRuleBUS();
                DataTable table = spamBUS.tblSpamRule_GetByID(Keyword);
                if (table.Rows.Count > 0)
                {
                    txtKeyword.Text = Keyword;
                    txtScore.Text = table.Rows[0]["Score"].ToString();
                    txtSameWord.Text = table.Rows[0]["SameWord"].ToString();
                }
        
        }
        catch (Exception)
        {

            pnError.Visible = true;
            pnSuccess.Visible = false;
            lblError.Text = "Lỗi trong quá trình sửa";
        }
        LoadData();
    }
    protected void btnDelete_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
             string Keyword = ((ImageButton)sender).CommandArgument;
            spamBUS = new SpamRuleBUS();
            spamBUS.tblSpamRule_Delete(Keyword);
            pnError.Visible = false;
            pnSuccess.Visible = true;
            lblSuccess.Text = "Bạn đã xóa thành công ";
            LoadData();
        }
        catch (Exception)
        {
            pnError.Visible = true;
            pnSuccess.Visible = false;
            lblError.Text = "Lỗi trong quá trình xóa";
           
        }
    }
}
