<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="TestResultsWeb2.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="row">
        <div id="normal_div">
            <p><a href="http://www.readium.org">
                <img src="http://readium.github.io/test-results/images/ReadiumLogo.png" alt="Readium Logo" height="97" width="321" />
            </a></p>
            <h1>CloudReader Results</h1>
            <p>
                This page contains the results from testing of the Readium
CloudReader across a large number of browsers and platforms. The score
in each row is linked to the actual spreadsheet, so just click on the
link to download the Excel spreadsheet.
            </p>
        </div>
    </div>
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br/>
        <asp:Button ID="btnUpload" runat="server"
            Height="21px" Text="Submit"
            Width="92px" OnClick="btnUpload_Click" />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
             <Columns>
                         <asp:BoundField DataField="Tester" HeaderText="Tester" />
                         <asp:BoundField DataField="Date" HeaderText="Date" />
                         <asp:BoundField DataField="CR Version" HeaderText="CR Version" />
                         <asp:BoundField DataField="Device" HeaderText="Device" />
                         <asp:BoundField DataField="OS" HeaderText="OS" />
                         <asp:BoundField DataField="Locale" HeaderText="Locale" />
                         <asp:BoundField DataField="Browser" HeaderText="Browser" />
                         <asp:BoundField DataField="Score" HeaderText="Score" />
                    </Columns>
        </asp:GridView>
    </div>
    </div>
    </form>
</body>
</html>
