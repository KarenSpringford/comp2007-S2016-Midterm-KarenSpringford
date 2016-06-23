<%@ Page Title="Todo Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TodoDetails.aspx.cs" Inherits="COMP2007_S2016_MidTerm.TodoDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>To Do Details</h1>
                <br />
                <div class="form-group">
                    <label class="control-label" for="TodoNameTextBox">To Do Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TodoNameTextBox" placeholder="To DO!" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TodoNotesTextBox">Notes</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TodoNotesTextBox" placeholder="Notes" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="CompletedTextBox">Completed</label>
                    <asp:CheckBox runat="server" Checked="false" ID="Completed" EnableViewState="false"/>
                </div> 
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn-danger btn-lg" runat="server" UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click"/>
                    <asp:Button Text="SAVE" ID="SaveButton" CssClass="btn-primary btn-lg" runat="server" OnClick="SaveButton_Click"/>
                </div>
            </div>
        </div>
    </div>
     
</asp:Content>
