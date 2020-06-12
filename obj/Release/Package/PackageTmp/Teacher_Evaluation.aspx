<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teacher_Evaluation.aspx.cs" Inherits="Quiz_System.Teacher_Evaluation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
    <style>
        body
        {
            background-image: url("pictures/about.jpg");
            background-repeat: no-repeat;
            background-size: cover;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LogoutBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <asp:PlaceHolder ID="PC" runat="server"></asp:PlaceHolder>
</asp:Content>
