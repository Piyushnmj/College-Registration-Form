<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="CollegeForm.WebForms.Receipt" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../StyleSheet/Receipt.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div>
            <h1>Registration Receipt</h1>
        </div>
        <br />
        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="915px" AutoGenerateRows="False" DataKeyNames="Bill_Id" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True">
                <EditRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <Fields>
                    <asp:BoundField DataField="Bill_Id" HeaderText="Bill_Id" InsertVisible="False" ReadOnly="True" SortExpression="Bill_Id" />
                    <asp:BoundField DataField="Bill_Date" HeaderText="Bill_Date" SortExpression="Bill_Date" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender" ReadOnly="True" />
                    <asp:BoundField DataField="Date_Of_Birth" HeaderText="Date_Of_Birth" SortExpression="Date_Of_Birth" ReadOnly="True" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="PhoneNumber" HeaderText="PhoneNumber" SortExpression="PhoneNumber" />
                    <asp:BoundField DataField="Course" HeaderText="Course" SortExpression="Course" ReadOnly="True" />
                    <asp:BoundField DataField="Course_Fee" HeaderText="Course_Fee" SortExpression="Course_Fee" ReadOnly="True" />
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Fields>
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
            </asp:DetailsView>
        </div>
    </center>
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>--Select Export Format--</asp:ListItem>
            <asp:ListItem>Excel</asp:ListItem>
            <asp:ListItem>Pdf</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <asp:Button ID="Button1" runat="server" Text="Export" OnClick="Export" />
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:CollegeStudentFormConnectionString %>" SelectCommand="SELECT * FROM [StudentDetails]"
        DeleteCommand="DELETE FROM [StudentDetails] WHERE [Bill_Id] = @Bill_Id"
        UpdateCommand="UPDATE [StudentDetails] Set [Name] = @Name, [Address] = @Address, [Email] = @Email, [PhoneNumber] = @PhoneNumber WHERE [Bill_Id] = @Bill_Id">
        <DeleteParameters>
            <asp:Parameter Name="Bill_Id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String"></asp:Parameter>
            <asp:Parameter Name="Address" Type="String"></asp:Parameter>
            <asp:Parameter Name="Email" Type="String"></asp:Parameter>
            <asp:Parameter Name="PhoneNumber" Type="String"></asp:Parameter>
        </UpdateParameters>
    </asp:SqlDataSource>
</asp:Content>

