﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ApproveLeave.aspx.cs" Inherits="ManPowerWeb.ApproveLeave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="card ml-4 p-4">
            <h2>Approve Leave</h2>


            <div class="mt-3">


                <div class="row mb-3 ms-1">

                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal3" runat="server" Text="HO DIvision"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlHo" runat="server" CssClass="form-control form-control-user">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal1" runat="server" Text="District"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control form-control-user" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>





                </div>
                <div class="row mb-3 ms-1">



                    <div class="col-sm-6">
                        <div class="row">
                            <div class="col-sm-4">

                                <asp:Literal ID="Literal4" runat="server" Text="DS Division"></asp:Literal>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlDS" runat="server" CssClass="form-control form-control-user">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-2">
                            </div>
                        </div>
                    </div>



                </div>



                <div class="row mb-5 ms-1 mt-4">
                    <div class="col-sm-2">

                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Search" />


                    </div>
                </div>

            </div>


        </div>


        <div class="table-responsive" style="width: 100%;">
            <asp:GridView Style="margin-top: 30px;" ID="gvApproveLeave" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                CellPadding="4" GridLines="None" HeaderStyle-HorizontalAlign="Center" OnRowDataBound="gvApproveLeave_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="DATE" HeaderStyle-CssClass="table-dark" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="EmployeeNIC" HeaderText="NIC" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="EmpInitials" HeaderText="INITIAL NAME" HeaderStyle-CssClass="table-dark" />
                    <asp:BoundField DataField="_EmploymentDetailsSingle.CompanyName" HeaderText="LAST NAME" HeaderStyle-CssClass="table-dark" />
                    <asp:TemplateField HeaderText="Action" HeaderStyle-CssClass="table-dark">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="View" CssClass="btn btn-success">

                            </asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>