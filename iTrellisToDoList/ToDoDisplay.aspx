<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoDisplay.aspx.cs" Inherits="iTrellisToDoList.ToDoDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <asp:Button ID="AddButton" runat="server" Text="Add New Task..." />
        &nbsp;&nbsp;
        <asp:Button ID="CompleteButton" runat="server" Text="Mark Selected as Completed" />
        &nbsp;&nbsp;
        <asp:Button ID="DeleteButton" runat="server" Text="Delete Selected" />
    </form>
</body>
</html>
