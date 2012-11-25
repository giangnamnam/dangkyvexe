using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Web.Security;

public partial class Admin_Acountkhachhang : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetUsers();
        }
    }

    int pageSize = 10;
    int totalUsers;
    int totalPages;
    int currentPage = 1;
    private void GetUsers()
    {
        UsersOnlineLabel.Text = Membership.GetNumberOfUsersOnline().ToString();

        RepeaterUser.DataSource = Membership.GetAllUsers(currentPage - 1, pageSize, out totalUsers);
        totalPages = ((totalUsers - 1) / pageSize) + 1;


        // Ensure that we do not navigate past the last page of users.

        if (currentPage > totalPages)
        {
            currentPage = totalPages;
            GetUsers();
            return;
        }

        RepeaterUser.DataBind();
        CurrentPageLabel.Text = currentPage.ToString();
        TotalPagesLabel.Text = totalPages.ToString();

        if (currentPage == totalPages)
            NextButton.Visible = false;
        else
            NextButton.Visible = true;

        if (currentPage == 1)
            PreviousButton.Visible = false;
        else
            PreviousButton.Visible = true;

        if (totalUsers <= 0)
            NavigationPanel.Visible = false;
        else
            NavigationPanel.Visible = true;
    }

    public void NextButton_OnClick(object sender, EventArgs args)
    {
        currentPage = Convert.ToInt32(CurrentPageLabel.Text);
        currentPage++;
        GetUsers();
    }

    public void PreviousButton_OnClick(object sender, EventArgs args)
    {
        currentPage = Convert.ToInt32(CurrentPageLabel.Text);
        currentPage--;
        GetUsers();
    }


    protected void btXoaLienHe_Click(object sender, EventArgs e)
    {
        string stringUsername = Request.Form["username"] ?? "";
        if (stringUsername != "")
        {
            foreach (string item in stringUsername.Split(','))
            {
                Membership.DeleteUser(item);
                GetUsers();
            }
        }
    }


    protected void btTimKiem_Click(object sender, EventArgs e)
    {
        PanelTimKiem.Visible = true;
    }


    protected void btTimKiemThat_Click(object sender, EventArgs e)
    {
        if (RadioButtonUserName.Checked)
        {
            if (txtTimKiem.Text != "")
            {

                RepeaterUser.DataSource = Membership.FindUsersByName(txtTimKiem.Text.ToLower().Trim(), currentPage - 1, pageSize, out totalUsers);
                totalPages = ((totalUsers - 1) / pageSize) + 1;


                // Ensure that we do not navigate past the last page of users.

                if (currentPage > totalPages)
                {
                    currentPage = totalPages;
                    GetUsers();
                    return;
                }

                RepeaterUser.DataBind();
                CurrentPageLabel.Text = currentPage.ToString();
                TotalPagesLabel.Text = totalPages.ToString();

                if (currentPage == totalPages)
                    NextButton.Visible = false;
                else
                    NextButton.Visible = true;

                if (currentPage == 1)
                    PreviousButton.Visible = false;
                else
                    PreviousButton.Visible = true;

                if (totalUsers <= 0)
                    NavigationPanel.Visible = false;
                else
                    NavigationPanel.Visible = true;
                //RepeaterUser.DataSource = Membership.FindUsersByName(txtTimKiem.Text.ToLower().Trim());
                //RepeaterUser.DataBind();
            }
        }
        else if (RadioButtonEmail.Checked)
        {
            if (txtTimKiem.Text != "")
            {

                RepeaterUser.DataSource = Membership.FindUsersByEmail(txtTimKiem.Text.ToLower().Trim(), currentPage - 1, pageSize, out totalUsers);
                totalPages = ((totalUsers - 1) / pageSize) + 1;


                // Ensure that we do not navigate past the last page of users.

                if (currentPage > totalPages)
                {
                    currentPage = totalPages;
                    GetUsers();
                    return;
                }

                RepeaterUser.DataBind();
                CurrentPageLabel.Text = currentPage.ToString();
                TotalPagesLabel.Text = totalPages.ToString();

                if (currentPage == totalPages)
                    NextButton.Visible = false;
                else
                    NextButton.Visible = true;

                if (currentPage == 1)
                    PreviousButton.Visible = false;
                else
                    PreviousButton.Visible = true;

                if (totalUsers <= 0)
                    NavigationPanel.Visible = false;
                else
                    NavigationPanel.Visible = true;
            }
        }
        else if (RadioButtonLastActivityDate.Checked)
        {
            txtTimKiem.Text = "";
            if (txtTimKiem.Text != "")
            {
                RepeaterUser.FindControl(txtTimKiem.Text.ToLower().Trim());
                RepeaterUser.DataBind();
            }
        }
    }
}