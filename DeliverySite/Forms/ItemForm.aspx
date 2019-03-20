<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemForm.aspx.cs" Inherits="DeliverySite.Forms.ItemForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style="width: 389px; height: 369px">
    <form id="form1" runat="server">
        <div style="height: 288px; width: 385px">
           <center> <asp:Label ID="Label1" runat="server" Text="Denumirea Produsului" ForeColor="SkyBlue" ></asp:Label></center>
            <asp:Image ID="ImageItem" runat="server" Height="264px" ImageUrl="~/ImageForForms/FoodDelivery.jpg" Width="381px" />
         </div>

         <div>
             <asp:Label ID="DescriptionItem" runat="server" Text="Descrierea produsului succint" ForeColor="SkyBlue"  ></asp:Label>
         </div>

         <div>
            <center> <asp:Label ID="Weigth" runat="server" Text="400 gr" ForeColor="SkyBlue" ></asp:Label></center>
         </div>
         <div>
            <asp:Button ID="AddButton" runat="server" Text="Adauga în coș" BackColor="#66FF33" OnClick="Button1_Click" style="margin-left: 276px; margin-top: 0px;" Width="109px" Height="33px" />
         </div>
    </form>
</body>
</html>
