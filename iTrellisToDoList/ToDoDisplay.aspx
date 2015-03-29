<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoDisplay.aspx.cs" Inherits="iTrellisToDoList.ToDoDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="ViewTasksForm" runat="server">
        <asp:Label ID="PendingLabel" runat="server" Text="Pending Tasks" Font-Bold="True" Font-Size="Large"></asp:Label>
        <br />
        <asp:GridView ID="PendingGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="PendingTaskCheckBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Task" DataField="Title" />
                <asp:BoundField HeaderText="Due Date" DataField="DueDate" NullDisplayText="Indefinite" />
                <asp:HyperLinkField DataTextField="Description" HeaderText="Details" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="AddButton" runat="server" Text="Add New Task..." />
        &nbsp;&nbsp;
        <asp:Button ID="CompleteButton" runat="server" Text="Mark Selected as Completed" OnClick="CompleteButton_Click" />
        &nbsp;&nbsp;
        <asp:Button ID="PendingDeleteButton" runat="server" Text="Delete Selected" OnClick="PendingDeleteButton_Click" />
        <br />
        <br />
        <asp:Label ID="CompletedLabel" runat="server" Text="Completed Tasks" Font-Bold="True" Font-Size="Large"></asp:Label>
        <br />
        <asp:GridView ID="CompletedGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CompletedTaskCheckBox" runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Task" DataField="Title" />
                <asp:BoundField HeaderText="Due Date" DataField="DueDate" NullDisplayText="Indefinite" />
                <asp:HyperLinkField DataTextField="Description" HeaderText="Details" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="CompletedDeleteButton" runat="server" Text="Delete Selected" OnClick="CompletedDeleteButton_Click" />
        <br />
        <br />
        <asp:Button ID="LoadTestData" runat="server" Text="Use Sample Data" OnClick="LoadTestData_Click" BackColor="#00CC00" />
    </form>
</body>
</html>
