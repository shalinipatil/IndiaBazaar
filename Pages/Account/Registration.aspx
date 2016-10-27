<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Pages_Account_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table cellspacing="4" cellpadding="4" align="center">
        <tr>
            <td style="font-weight: 700">Name: </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-weight: 700">Password: </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtPassword" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-weight: 700">Confirm Password: </td>
            <td>
                <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtConfirm" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="font-weight: 700">E-mail: </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtEmail" ErrorMessage="*"></asp:RequiredFieldValidator>
            </td>
        </tr>
        
         <tr>
         <td style="width: 210px">
             <b>
    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </b>
                </td>
            <td style="text-align: left; width: 289px">
    <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Width="258px" style="font-weight: bold"></asp:TextBox>
   
           
                <b>
   
           
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAddress" ErrorMessage="*"></asp:RequiredFieldValidator>
                </b>
           </td>
            </tr>
       <tr>
           <td style="width: 210px"><asp:Label ID="lblCity" runat="server" Text="City" style="font-weight: 700"></asp:Label></td>
           <td style="text-align: left; width: 289px"><asp:TextBox ID="txtCity" runat="server" Width="258px"></asp:TextBox>
               
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCity" ErrorMessage="*"></asp:RequiredFieldValidator>
         </td>
               </tr>
   <tr><td style="width: 210px"><asp:Label ID="lblState" runat="server" Text="State" style="font-weight: 700"></asp:Label></td>
       <td style="text-align: left; width: 289px"> <asp:TextBox ID="txtState" runat="server" Width="258px"></asp:TextBox>
      
           <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtState" ErrorMessage="*"></asp:RequiredFieldValidator>
     </td>
          </tr>
    
   <tr>
       <td style="width: 210px"><asp:Label ID="lblZip" runat="server" Text="Zipcode" style="font-weight: 700"></asp:Label></td>
       <td style="text-align: left; width: 289px">  <asp:TextBox ID="txtZip" runat="server" Width="258px"></asp:TextBox>
       
           <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtZip" ErrorMessage="*"></asp:RequiredFieldValidator>
       </td>
   </tr>
   
    
<tr><td style="width: 210px"><asp:Label ID="lblPhone" runat="server" Text="Phone Number" style="font-weight: 700"></asp:Label></td>
    <td style="text-align: left; width: 289px"> <asp:TextBox ID="txtPhone" runat="server" Width="258px"></asp:TextBox>
   
        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPhone" ErrorMessage="*"></asp:RequiredFieldValidator></td>
    </tr> 
    
    <tr>
     <td style="width: 289px; text-align: right"> 
         <br />
         <asp:Button ID="btnRegister" runat="server" Text="Register"  onclick="btnRegister_Click" style="margin-left: 0px" Width="86px" />
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtConfirm" ControlToValidate="txtPassword" ErrorMessage="Passwords must match"></asp:CompareValidator>
                <br />
                <asp:Label ID="lblResult" runat="server"></asp:Label>
         </td>
            <td>
                &nbsp;</td>
        </tr>
  
    </table>
</asp:Content>

