<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Quiz_System.About" %>

<asp:Content ContentPlaceHolderID="HeadHolder" runat="server">
    <style>
        body
        {
            background-image: url("pictures/about.jpg");
            background-repeat: no-repeat;
            background-size: cover;
        }

    </style>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Learning Management System (LMS)</h3>
    <p>Quiz Fast is a software that Universities/schools/colleges may use to hold quizzes under emergency circumstances in order to reduce academic loss of students. Our proposed system will offer interfaces for Teachers and Students to answer questions and get corresponding results.</p>
</asp:Content>
