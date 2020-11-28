<%@ Page Language="VB" AutoEventWireup="false" CodeFile="BestBuy.aspx.vb" Inherits="BestBuy" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:LinkButton ID="LinkButton1" runat="server">Year Data</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton2" runat="server">Sub-Category Data</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton3" runat="server">State Data</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LinkButton4" runat="server">Wine Data</asp:LinkButton>
        </div>
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                &nbsp;Please Select a year.<br />
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                    <asp:ListItem>2011</asp:ListItem>
                    <asp:ListItem>2012</asp:ListItem>
                    <asp:ListItem>2013</asp:ListItem>
                    <asp:ListItem>2014</asp:ListItem>
                </asp:DropDownList>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </asp:View>
            <asp:View ID="View2" runat="server">
                Please select a category.<br />
                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                <asp:GridView ID="GridView2" runat="server">
                </asp:GridView>
            </asp:View>
            <asp:View ID="View3" runat="server">
                Please select a state.<br />
                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                <asp:GridView ID="GridView3" runat="server">
                </asp:GridView>
            </asp:View>
            <asp:View ID="View4" runat="server">
                Please select a country.<br />
                <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                <asp:GridView ID="GridView4" runat="server">
                </asp:GridView>
            </asp:View>
        </asp:MultiView>
    </form>
</body>
</html>
