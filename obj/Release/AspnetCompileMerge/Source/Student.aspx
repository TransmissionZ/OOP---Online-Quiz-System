<%@ Page Title="Student" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="Quiz_System.Student" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="LoginBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LogoutBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
     <div>
         <br />
         <br />
        <h3>Welcome&nbsp<asp:Label ID="username" runat="server"></asp:Label></h3> 
        
         <br />
         <asp:Label Font-Size="Medium" Font-Italic="true" runat="server">Please find your results and quizzes below, happy quizing :)</asp:Label>
         <br />
         <hr />
         <br />
        <asp:PlaceHolder ID="English" runat="server">
            <h4 style="text-decoration:underline">English Quizzes</h4>
            <asp:Literal ID = "ltTable" runat = "server" />
        </asp:PlaceHolder>
         
        <h4 style="text-decoration:underline">Mathematics Quizzes</h4>
        <asp:PlaceHolder ID="Math" runat="server">
            <asp:Literal ID = "mathltTable" runat = "server" />
            <div id="mathtitle" runat="server" style="float:left"></div>
            <div id="mathattempt" runat="server" style="text-align:center"></div>
            <div id="mathscore" runat="server" style="float:right;text-align:right" ></div>
        </asp:PlaceHolder>  
    </div>

</asp:Content>
