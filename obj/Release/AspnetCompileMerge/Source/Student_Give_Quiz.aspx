<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student_Give_Quiz.aspx.cs" Inherits="Quiz_System.Student_Give_Quiz"  enableEventValidation="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
    <style>
        body
        {
            background-image: url("pictures/about.jpg");
            background-repeat: no-repeat;
            background-size: cover;
        }

    </style>
    <style>
        .radioboxlist radioboxlistStyle
        {
        font-size:x-large;
        padding-right: 20px;
        }
        .radioboxlist label {
        color: #3E3928;
        background-color:#E8E5D4;
        padding-left: 6px;
        padding-right: 16px;
        padding-top: 2px;
        padding-bottom: 2px;
        border: 1px solid #AAAAAA;
        white-space: nowrap;
        clear: left;
        margin-right: 10px;
        margin-left: 10px;
        }
        .radioboxlist label:hover
        {
        color: #CC3300;
        background: #D1CFC2;
        }
        input:checked + label {
        color: #CC3300;
        background: #D1CFC2;
        }
    </style>
    <style scoped="">
        .button-success,
        .button-error,
        .button-warning,
        .button-secondary {
            color: white;
            border-radius: 5px;
            text-shadow: 0 1px 1px rgba(0, 0, 0, 0.2);
        }

        .button-success {
            background: rgb(28, 184, 65);
            /* this is a green */
        }

        .button-error {
            background: rgb(202, 60, 60);
            /* this is a maroon */
        }

        .button-warning {
            background: rgb(223, 117, 20);
            /* this is an orange */
        }

        .button-secondary {
            background: rgb(66, 184, 221);
            /* this is a light blue */
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LogoutBar" runat="server">
</asp:Content>
<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div runat="server" id="final" align="center">
    <asp:PlaceHolder runat="server" ID="Result"></asp:PlaceHolder></div>
    <asp:PlaceHolder runat="server" ID="Content4">
        <div>
        <asp:Timer ID="timer1" runat="server" Interval="1000" OnTick="timer1_tick">
        </asp:Timer>
        </div>
        <br />
        <div align="right">
        <asp:UpdatePanel id="updPnl" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lblTimer" runat="server" Font-Bold="True" Font-Names="Arial" Font-Size="Medium" ForeColor="#FF0000"></asp:Label>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="timer1" EventName ="tick" />
            </Triggers>
        </asp:UpdatePanel>
        </div>
        <br />
        <br />
        <h3><asp:Label runat="server" ID="Question" Text=""></asp:Label></h3>
        <br />
        <br />
        <asp:RadioButtonList ID="Choices" runat="server" CssClass="radioboxlist">
            <asp:ListItem Text="" Value="1"></asp:ListItem>
            <asp:ListItem Text="" Value="2"></asp:ListItem>
            <asp:ListItem Text="" Value="3"></asp:ListItem>
            <asp:ListItem Text="" Value="4"></asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        <div align="left">
            <asp:Button runat="server" OnClick="submitAns_Click" Cssclass="button-success pure-button" Text="Submit Answer"></asp:Button>
            <%--<button class="button-warning pure-button">Go Back</button>--%>
        </div>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <div align="center">
            <asp:Label runat="server" Text="Good Luck!"></asp:Label>
        </div>
    </asp:PlaceHolder>
</asp:Content>
