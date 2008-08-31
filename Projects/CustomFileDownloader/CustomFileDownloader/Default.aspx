<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CustomFileDownloader._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 210px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table align="center" class="style1">
            <tr>
                <td>
                    URL</td>
                <td width="150">
                    <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Save as</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Pw</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: right">
                    <asp:Button ID="Button1" runat="server" Text="Download" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
