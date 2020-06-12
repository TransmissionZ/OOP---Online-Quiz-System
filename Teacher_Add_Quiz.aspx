<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Teacher_Add_Quiz.aspx.cs" Inherits="Quiz_System.Teacher_Add_Quiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadHolder" runat="server">
    <style type="text/css">
        @import url('https://fonts.googleapis.com/css?family=Noto+Sans:400,400i,700,700i&subset=greek-ext');

		body{
			background-image: url("pictures/about.jpg");
			background-position: center;
			background-origin: content-box;
			background-repeat: no-repeat;
			background-size: cover;
			min-height:100vh;
			font-family: 'Noto Sans', sans-serif;
		}
		.text-center{
			color:#fff;	
			text-transform:uppercase;
			font-size: 23px;
			margin: -50px 0 80px 0;
			display: block;
			text-align: center;
		}
		.box{
			position:absolute;
			left:50%;
			top:50%;
			transform: translate(-50%,-50%);
			background-color: rgba(0, 0, 0, 0.89);
			border-radius:3px;
			padding:70px 100px;
		}
		.input-container{
			position:relative;
			margin-bottom:25px;
            top: 5px;
            left: 1px;
        }
		.input-container label{
			position:absolute;
			top:0px;
			left:0px;
			font-size:16px;
			color:#fff;
			transition: all 0.5s ease-in-out;
		}
		.input-container input{ 
		  border:0;
		  border-bottom:1px solid #555;  
		  background:transparent;
		  width:100%;
		  padding:8px 0 5px 0;
		  font-size:16px;
		  color:#fff;
		}
		.input-container input:focus{ 
		 border:none;	
		 outline:none;
		 border-bottom:1px solid #e74c3c;	
		}
		.btn{
			color:#fff;
			background-color:#e74c3c;
			outline: none;
			border: 0;
			color: #fff;
			padding:10px 20px;
			text-transform:uppercase;
			margin-top:50px;
			border-radius:2px;
			cursor:pointer;
			position:relative;
		}
		/*.btn:after{
			content:"";
			position:absolute;
			background:rgba(0,0,0,0.50);
			top:0;
			right:0;
			width:100%;
			height:100%;
		}*/
		.input-container input:focus ~ label,
		.input-container input:valid ~ label{
			top:-12px;
			font-size:12px;
	
		}
    </style>
	<%--Popup Style--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="LoginBar" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LogoutBar" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
	<div class="input-container">
		<asp:TextBox runat="server" ID="name" required=""/>
		<label>Quiz Title</label>		
	</div>
	<div class="input-container">		
		<asp:TextBox runat="server" ID="time" required=""/>
		<asp:RegularExpressionValidator ID="RegularExpressionValidator1"
			ControlToValidate="time" runat="server"
			ErrorMessage="Please Enter time in minutes e.g 75"
			ValidationExpression="\d+">
		</asp:RegularExpressionValidator>
		<label>Time (min)</label>
	</div>
	<br />
	<div class="input-container">
		<label>Subject</label>
	</div>
    <br />
	<asp:DropDownList runat="server" ID="subject" Height="25px" Width="166px">
		<asp:ListItem Value="" Selected="True">Please Select</asp:ListItem>  
		<asp:ListItem Text="Mathematics" Value="Math"></asp:ListItem>
		<asp:ListItem Text="English" Value="English"></asp:ListItem>
	</asp:DropDownList>
    <br />
    <br />
    <br />
	<div class="input-container">		
		<asp:TextBox runat="server" ID="question"/>
		<label>Question&nbsp;<asp:Label runat="server" ID="Q_no">1</asp:Label></label>
	</div>
	<br />
    <br />
	<div class="input-container">		
		<asp:TextBox runat="server" Text="" ID="ans1"/>
		<label>Option 1</label>
	</div>
	<div class="input-container">		
		<asp:TextBox runat="server" Text="" ID="ans2"/>
		<label>Option 2</label>
	</div>
	<div class="input-container">		
		<asp:TextBox runat="server" Text="" ID="ans3"/>
		<label>Option 3</label>
	</div>
	<div class="input-container">		
		<asp:TextBox runat="server" Text="" ID="ans4"/>
		<label>Option 4</label>
	</div>
    <br />
	<div class="input-container">
		<label>Correct Answer</label>
	</div>
    <br />
	<asp:DropDownList runat="server" ID="CorrectAns" Height="25px" Width="166px">
		<asp:ListItem Value="" Selected="True">Please Select</asp:ListItem>  
		<asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
		<asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
		<asp:ListItem Text="Option 3" Value="3"></asp:ListItem>
		<asp:ListItem Text="Option 4" Value="4"></asp:ListItem>
	</asp:DropDownList>
    <br />
	<asp:Button runat="server" ID="addquestion" Text="Add Question" OnClick="addquestion_Click" CssClass="btn"/>
    <br />
	<asp:Button Cssclass="btn" runat="server" ID="SubmitQuiz" OnClick="SubmitQuiz_Click" Text="Submit"></asp:Button>
	
</asp:Content>
