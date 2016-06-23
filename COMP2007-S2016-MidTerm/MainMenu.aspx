<%@ Page Title="MainMenu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="COMP2007_S2016_MidTerm.MainMenu" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Main Menu</h1>
                <div class="well">
                    <h3><i class="fa fa-leanpub fa-lg"></i> ToDo Details</h3>
                    <div class="list-group">
                        <a class="list-group-item" href="/Todos.aspx"><i class="fa fa-th-list"></i> ToDo List</a>
                        <a class="list-group-item" href="/TodoDetails.aspx"><i class="fa fa-plus-circle"></i> Add a To Do</a>
                    </div>
                </div>  
            </div>
        </div>
    </div>
</asp:Content>
