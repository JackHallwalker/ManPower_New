﻿using ManPowerCore.Common;
using ManPowerCore.Controller;
using ManPowerCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManPowerWeb
{
    public partial class ApproveLoanAdmin1Front : System.Web.UI.Page
    {
        static List<LoanDetail> loanDetailList = new List<LoanDetail>();
        LoanDetailsController loanDetailsController = ControllerFactory.CreateLoanDetailsController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataSource();
            }

        }

        public void BindDataSource()
        {
            loanDetailList = loanDetailsController.GetAllLoanDetailWithStatus(true, true);
            loanDetailList = loanDetailList.Where(x => x.ApprovalStatusId == 4).ToList();

            gvApprove1Admin.DataSource = loanDetailList;
            gvApprove1Admin.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            GridViewRow gv = (GridViewRow)((LinkButton)sender).NamingContainer;

            int rowIndex = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;

            string url = "ApproveLoanDGM.aspx?LoanDetailId=" + loanDetailList[rowIndex].LoanDetailsId;
            Response.Redirect(url);
        }
    }
}