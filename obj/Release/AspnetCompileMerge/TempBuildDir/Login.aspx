<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Quiz_System.Login" EnableEventValidation="false" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login to Quiz-Fast</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
	<meta charset="utf-8" />
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="login1/images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="login1/vendor/bootstrap/css/bootstrap.min.css"/>
	<link rel="stylesheet" type="text/css" href="login1/vendor/bootstrap/css/bootstrap.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="login1/fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="login1/fonts/iconic/css/material-design-iconic-font.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="login1/vendor/animate/animate.css"/>
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="login1/vendor/css-hamburgers/hamburgers.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="login1/vendor/animsition/css/animsition.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="login1/vendor/select2/select2.min.css"/>
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="login1/vendor/daterangepicker/daterangepicker.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="login1/css/util.css"/>
	<link rel="stylesheet" type="text/css" href="login1/css/main.css"/>
<!--===============================================================================================-->

</head>
<body>
    <form id="form1" runat="server">
        <<div class="limiter">
			<div class="container-login100" style="background-image: url('pictures/default.jpg');">
				<div class="wrap-login100">
					<form class="login100-form validate-form">
						<span class="login100-form-logo">
							<i class="zmdi zmdi-landscape"></i>
						</span>

						<span class="login100-form-title p-b-34 p-t-27">
							Log in
						</span>

						<div class="wrap-input100 validate-input" data-validate = "Enter username">
							<input runat="server" id="username" class="input100" type="text" name="username" placeholder="Username">
							<span class="focus-input100" data-placeholder="&#xf207;"></span>
						</div>

						<div class="wrap-input100 validate-input" data-validate="Enter password">
							<input class="input100" runat="server" id="pass" type="password" name="pass" placeholder="Password">
							<span class="focus-input100" data-placeholder="&#xf191;"></span>
						</div>

						<div class="contact100-form-checkbox">
							<input class="input-checkbox100" id="ckb1" type="checkbox" name="remember-me">
							<label class="label-checkbox100" for="ckb1">
								Remember me
							</label>
						</div>
						<div>
							<asp:Literal ID="ltMessage" runat="server" />
						</div>
						<div class="container-login100-form-btn">
							<asp:button runat="server" ID="login" OnClick="login_Click" class="login100-form-btn" Text="Login" />
						</div>

						<div class="text-center p-t-90">
							<a class="txt1" href="Register.aspx">
								No Account? Register!
							</a>
						</div>
					</form>
				</div>
			</div>
		</div>
	

		<div id="dropDownSelect1"></div>
	
	<!--===============================================================================================-->
		<script src="login1/vendor/jquery/jquery-3.2.1.min.js"></script>
	<!--===============================================================================================-->
		<script src="login1/vendor/animsition/js/animsition.min.js"></script>
	<!--===============================================================================================-->
		<script src="login1/vendor/bootstrap/js/popper.js"></script>
		<script src="login1/vendor/bootstrap/js/bootstrap.min.js"></script>
	<!--===============================================================================================-->
		<script src="login1/vendor/select2/select2.min.js"></script>
	<!--===============================================================================================-->
		<script src="login1/vendor/daterangepicker/moment.min.js"></script>
		<script src="login1/vendor/daterangepicker/daterangepicker.js"></script>
	<!--===============================================================================================-->
		<script src="login1/vendor/countdowntime/countdowntime.js"></script>
	<!--===============================================================================================-->
		<script src="login1/js/main.js"></script>
    </form>
</body>
</html>
