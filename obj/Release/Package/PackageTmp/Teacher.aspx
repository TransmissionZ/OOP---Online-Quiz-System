<%@ Page Title="Teacher's Personal Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teacher.aspx.cs" Inherits="Quiz_System.Teacher"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
    <link rel="stylesheet" href="/TeacherData/ButtonStyle.css" runat="server"/>
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
    <h2><%: Title %>.</h2>
    <h2>Welcome <asp:Label runat="server" ID="username"></asp:Label></h2>

    <div class="button_cont" align="center">
        <a class="example_e" href="Teacher_Add_Quiz.aspx" target="_blank" rel="nofollow noopener" runat="server">Add Quiz</a>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <a class="example_e" href="Teacher_Evaluation.aspx" target="_blank" rel="nofollow noopener" runat="server">Evaluation</a>
    </div>
</asp:Content>
