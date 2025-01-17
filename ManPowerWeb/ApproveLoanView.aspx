﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveLoanView.aspx.cs" Inherits="ManPowerWeb.ApproveLoanView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="card o-hidden border-0 shadow-lg my-3 p-4">

        <h2>Approve Loan</h2>

        <div class="card-body">

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="lblName" runat="server" Text="Loan Type"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlLoanType" runat="server" CssClass="form-control form-control-user" Enabled="true"></asp:DropDownList>

                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal1" runat="server" Text="Full Name"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control form-control-user" Enabled="true"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal2" runat="server" Text="Position"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtPosition" runat="server" CssClass="form-control form-control-user" Enabled="true"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>





            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal4" runat="server" Text="Position Type"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtPositionType" runat="server" CssClass="form-control form-control-user" Enabled="true"></asp:TextBox>

                        </div>
                    </div>
                </div>
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal3" runat="server" Text="Work Place"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtWorkPlace" runat="server" CssClass="form-control form-control-user" Enabled="true"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>




            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal5" runat="server" Text="Appointment Date"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtAppointmentDate" runat="server" CssClass="form-control form-control-user" TextMode="Date" Enabled="true"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal6" runat="server" Text="Basic Salary"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtBasicSalary" runat="server" CssClass="form-control form-control-user" Enabled="true"></asp:TextBox>

                        </div>
                    </div>
                </div>

                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal7" runat="server" Text="Appeal Amount"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtAppealAmount" runat="server" CssClass="form-control form-control-user" Enabled="true"></asp:TextBox>

                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal8" runat="server" Text="Date Wanted"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="txtDateWanted" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtDateWanted" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <h4>For Finnance Assistance Manger</h4>
            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal9" runat="server" Text="Last Date Loan Approved"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:TextBox>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ValidationGroup="1"
                                    ControlToValidate="txtDateWanted" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1 mt-3">
                <div class="col-sm-6">
                    <div class="row">
                        <div class="col-sm-3">
                            <asp:Literal ID="Literal10" runat="server" Text="Last Month Loan Approved"></asp:Literal>
                        </div>

                        <div class="col-md-6">
                            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control form-control-user" TextMode="Date"></asp:DropDownList>
                            <div class="d-flex text-danger">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="1"
                                    ControlToValidate="ddlMonth" ErrorMessage="Required">*</asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row mb-3 ms-1">
                <div class="col-sm-3">
                    <div class="row mb-3 ms-1">
                        <div class="col-sm-6">
                            <asp:Button ID="btnApproval" runat="server" Text="Send to Approval" CssClass="btn btn-primary" ValidationGroup="1" />
                        </div>
                        <div class="col-sm-6">
                            <asp:Button ID="btnReject" runat="server" Text="Reject" CssClass="btn btn-danger" />
                        </div>
                        <%--  <div class="col-sm-6">
                            <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-secondary btn-user btn-block" BackColor="#212529" BorderColor="#212529"  />
                        </div>--%>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 m-3">
                <asp:Label ID="lblSuccessMsg" runat="server" Text="" ForeColor="#33cc33"></asp:Label>
            </div>

        </div>
    </div>
</asp:Content>
