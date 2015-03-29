<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ToDoDisplay.aspx.cs" Inherits="iTrellisToDoList.ToDoDisplay" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Form1" runat="server">
        <asp:Panel ID="ViewTasksPanel" runat="server">
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
                <asp:TemplateField HeaderText="Details">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_self" Text="Hover" ToolTip='<%# Eval("Description") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="AddButton" runat="server" Text="Add New Task..." OnClick="AddButton_Click" />
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
                <asp:TemplateField HeaderText="Details">
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_self" Text="Hover" ToolTip='<%# Eval("Description") %>'></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="CompletedDeleteButton" runat="server" Text="Delete Selected" OnClick="CompletedDeleteButton_Click" />
        <br />
        <br />
        <asp:Button ID="LoadTestData" runat="server" Text="Use Sample Data" OnClick="LoadTestData_Click" BackColor="#00CC00" />
            </asp:Panel>
        <asp:Panel ID="AddTaskPanel" runat="server" Visible="false">
            <asp:Label ID="TitleLabel" runat="server" Text="Title: "></asp:Label>

            <asp:TextBox ID="TitleTextBox" runat="server" Width="500px"></asp:TextBox>

            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Details: "></asp:Label>

            <asp:TextBox ID="DetailsTextBox" runat="server" Width="500px"></asp:TextBox>

            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Due Date: "></asp:Label>

            <asp:CheckBox ID="NoDueDateCheckBox" runat="server" ViewStateMode="Inherit" Text="N/A" AutoPostBack="True" OnCheckedChanged="NoDueDateCheckBox_CheckedChanged" />
            <asp:Calendar ID="DueDateCalendar" runat="server"></asp:Calendar>

            <br />
            <asp:Button ID="FinalizeAddButton" runat="server" Text="Add Task" OnClick="FinalizeAddButton_Click" />

            &nbsp;
            <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Visible="False"></asp:Label>

        </asp:Panel>
    </form>
</body>
</html>
