<%@ Master Language="C#" AutoEventWireup="true" CodeFile="MasterPage.master.cs" Inherits="MasterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="shortcut icon" href="favicon.ico" />

       <title>IndiaBazaar</title>
    <script type="text/javascript" src="../JavaScript/jquery-1.3.2.min.js"></script>
    <script type="text/javascript">
        function mainmenu() {
            $(" #nav ul ").css({ display: "none" }); // Opera Fix

            $(" #nav li").hover(function () {
                $(this).find('ul:first').css({ visibility: "visible", display: "none" }).show(400);
            }
            , function () {
                $(this).find('ul:first').css({ visibility: "hidden" });
            });
        }

        $(document).ready(function () {
            mainmenu();
        });
    </script>
    <link rel="stylesheet" type ="text/css" href="~/Style/Stylesheet.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <div id="navigation">
        <ul id="nav">
            <li><a href="https://github.com/shalinipatil/IndiaBazaar/blob/master/Pages/Home.aspx" runat="server">Home</a></li>
             
            <li><a href="https://github.com/shalinipatil/IndiaBazaar/blob/master/Pages/OrderProduct.aspx" runat="server">Shop</a></li>
            <li><a href="#" runat="server">AboutUs</a>
            <ul>
                    <li><a id="A1" href="https://github.com/shalinipatil/IndiaBazaar/blob/master/Pages/AboutUs.aspx" runat="server">AboutUs</a></li>
                   <li><a id="A2" href="https://github.com/shalinipatil/IndiaBazaar/blob/master/Pages/ContactUs.aspx" runat="server">ContactUs</a></li>
                   

                </ul>
                </li>
            <li><a href="#">Management</a>
                <ul>
                    <li><a href="https://github.com/shalinipatil/IndiaBazaar/blob/master/Pages/ProductOverview.aspx" runat="server">Products</a></li>
                   <li><a href="https://github.com/shalinipatil/IndiaBazaar/blob/master/Pages/Account/Admin.aspx" runat="server">Users</a></li>
                   <li><a href="https://github.com/shalinipatil/IndiaBazaar/blob/master/Pages/Orders.aspx" runat="server">Orders</a></li>

                </ul>
            </li>
        </ul>
            <div id="Login" align="right">
                <asp:Label ID="LabelLogin" runat="server" Text="" ForeColor="White"></asp:Label>
                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>
            </div>
       </div>
         <div id="Banner">
            
           
            <asp:AdRotator ID="AdRotator1"  runat="server" AdvertisementFile ="~/Add.xml"   Width="1100px" height ="350px" />
          
          
            </div>
    
    <div id="contentarea">
        <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server">
        </asp:ContentPlaceHolder>
        </div>
        <div id="sidebar"></div>
        <div id="footer"><p> All Right Reserved 2014</p></div>
    </div>
    </form>
</body>
</html>
