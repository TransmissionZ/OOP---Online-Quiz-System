<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Quiz_System._Default" %>
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
    <div class="jumbotron">
        <h1>Quiz-Fast</h1>
        <p class="lead">Quiz-Fast is a Online Quiz System developed using ASP.net and C#</p>
        <p><a href="/Contact" class="btn btn-primary btn-lg">Contact Us</a></p>
    </div>
    
    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                Quiz Fast is a software that Universities/schools/colleges is used by Teachers and Students around the world to hold online quizzes.
                For Password related queries contact us on our contact page.
                For Submission related queries contact raabta.nu@hotmail.com.
            </p>
            <p>
                <a class="btn btn-default" href="Login.aspx">Let's Go! &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Covid'19 Policy</h2>
            <p>
                We appreciate that this is a worrying and difficult time and recognize many of you are understandably anxious, given the unprecedented circumstances the world faces with the current corona virus pandemic.

                Further policy will be published here as and when required. You should use this as your main source of information about our response to this situation.
            </p>
        </div>
        <div class="col-md-4">
            <h2>Sustainability targets</h2>
            <p>
                The Quiz Fast Sustainable Study Plan, launched in 2018, laid the blueprint for achieving this strategy. We continue to work towards the ambitious targets we have set ourselves for halving our educational environmental, improving the system and well being of 1 million students, and enhancing the ease of education to millions.
            </p>
        </div>
    </div>

</asp:Content>
