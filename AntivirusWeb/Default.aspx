<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AntivirusWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ANTIVIRUS APPLICATION</h1>
        <p class="lead">Cloud Based Antivirus Application for CS 643/743 Cloud Security class at UAB.</p>        
    </div>

    <div class="row">
        <div class="col-md-4">            
        <asp:FileUpload ID="FileUpload1" runat="server" Width="349px" AllowMultiple="True" />
        <br /><br />
        <asp:Button ID="btnScan" runat="server" Text="Scan" Height="49px" class="btn btn-primary btn-lg" OnClick="btnScan_Click" Width="115px" /><br /><br />            <asp:Label runat="server" id="StatusLabel" text="Upload status: " /> <br/><br/>           
            
        </div>        
        <div class="col-md-4">
            <asp:ListBox ID="listBox1" runat="server" Height="250px" Width="250px" SelectionMode="Multiple"></asp:ListBox>            
                    
        </div>
        <div class="col-md-4"><label>Download the application:</label>
        <asp:Button ID="btnDownload" runat="server" Text="Download" Height="49px" class="btn btn-primary btn-lg" OnClick="btnDownload_Click" Width="115px" /></div>
        <div class="col-md-4">
            <asp:Label runat="server" id="lbl_Error" Visible="False" ForeColor="Red" />
        </div>
    </div>

</asp:Content>
