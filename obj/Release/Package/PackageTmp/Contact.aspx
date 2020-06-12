<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Quiz_System.Contact" %>
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
    <%--<h2><%: Title %>.</h2>--%>
    <%--<h2>Welcome <asp:Label runat="server" ID="username"></asp:Label></h2>--%>
    <br />
    <h3>Reach out to Us!.</h3>
    <address>
        ZOOM University of Virtual Classes And Technology<br />
        2-G, Block-6, PECHS, Karachi.<br />
        <abbr title="Phone">Tel:</abbr>
        (021) 439 0941-5
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:k190145@nu.edu.pk">K190145@nu.edu.pk - Haroon</a><br />
        <strong>Marketing:</strong> <a href="mailto:k191484@nu.edu.pk">K191484@nu.edu.pk - Sameer</a>
    </address>
    
</asp:Content>
