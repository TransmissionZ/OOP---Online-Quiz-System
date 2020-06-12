<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Quiz_System.Register" EnableEventValidation="false"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>

    <title></title>

    <!-- Font Icon -->
    <link rel="stylesheet" href="Registration/fonts/material-icon/css/material-design-iconic-font.min.css"/>

    <!-- Main css -->
    <link rel="stylesheet" href="Registration/css/style.css"/>

</head>
<body>
    <form id="form1" runat="server">
        <div class="main">
            <h1>Quiz-Fast&nbsp;&nbsp;&nbsp;</h1>
            <div class="container">
                <div class="sign-up-content">
                    <form method="POST" class="signup-form">
                        <h2 class="form-title">Please select your occupation!</h2>
                        <div class="form-radio">
                            <asp:RadioButtonList id="role" runat="server">
                                <asp:ListItem Value="Teacher">Teacher</asp:ListItem>
                                <asp:ListItem Value="Student">Student</asp:ListItem>
                           
                            </asp:RadioButtonList>
                        </div>

                        <div class="form-textbox">
                            <label for="name">Full Name</label>
                            <input type="text" name="name" runat="server" ID="Name"/>
                        </div>

                        <div class="form-textbox">
                            <label for="email">Email</label>
                            <input type="email" name="email" runat="server" ID="Email" />
                        </div>

                        <div class="form-textbox">
                            <label for="pass">Password</label>
                            <input type="password" name="pass" runat="server" ID="Password"/>
                        </div>

                        <div class="form-group">
                            <input type="checkbox" name="agree-term" id="agree-term" class="agree-term" />
                            <label for="agree-term" class="label-agree-term"><span><span></span></span>I agree all statements in  <a href="#" class="term-service">Terms of service</a></label>
                        </div>

                        <div class="form-textbox">
                            <asp:Button type="submit" name="submit" class="submit" text="Create account" runat="server" ID="Submit" OnClick="submit_Click"/>
                        </div>
                    </form>

                    <p class="loginhere">
                        Already have an account ?<a href="#" class="loginhere-link"> Log in</a>
                    </p>
                    <asp:Literal ID="prompt" runat="server"></asp:Literal>
                </div>
            </div>

        </div>

        <!-- JS -->
        <script src="Registration/vendor/jquery/jquery.min.js"></script>
        <script src="Registration/js/main.js"></script>
    </form>
</body>
</html>
