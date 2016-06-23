<%@ Page Title="Todo List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoList.aspx.cs" Inherits="COMP2007_S2016_MidTerm.TodoList" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>To Do List</h1>
                <br />
                <a href="TodoDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus fa-lg"></i> Add A To Do</a>
                <div>
                    <label for="PageSizeDropDownList">To Do's per Page: </label>
                    <asp:DropDownList ID="PageSizeDropDownList" runat="server"
                        AutoPostBack="true" CssClass="btn btn-default bt-sm dropdown-toggle"
                        OnSelectedIndexChanged="PageSizeDropDownList_SelectedIndexChanged">
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="5" Value="5" />
                        <asp:ListItem Text="10" Value="10" />
                        <asp:ListItem Text="All" Value="10000" />
                    </asp:DropDownList>
                </div>
                <br />
                <asp:GridView runat="server" ID="TodosGridView" AutoGenerateColumns="false" CssClass="table table-bordered table-striped table-hover" DataKeyNames="TodoID"
                AllowPaging="true" PageSize="3" OnPageIndexChanging="TodosGridView_PageIndexChanging" AllowSorting="true" OnSorting="TodosGridView_Sorting"
                OnRowDataBound="TodosGridView_RowDataBound" OnRowDeleting="TodosGridView_RowDeleting" PagerStyle-CssClass="pagination-ys">

                <Columns>
                        <asp:BoundField DataField="TodoID" HeaderText="To Do ID" Visible="true"/>
                        <asp:BoundField DataField="TodoName" HeaderText="To Do Name" Visible="true"/>
                        <asp:BoundField DataField="TodoNotes" HeaderText="Notes" Visible="true"/>
                        <asp:BoundField DataField="Completed" HeaderText="Completed" Visible="true"/>
                        <asp:CheckBoxField DataField="Completed" HeaderText="Completed" Visible="true" />

                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" 
                            NavigateUrl="~/TodoDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="TodoID" DataNavigateUrlFormatString="TodoDetails.aspx?TodoID={0}" />
                        <asp:CommandField  HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>     
</asp:Content>
