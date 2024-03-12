<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ProviderSignUp.aspx.vb" Inherits="roadresqconnect.ProviderSignUp" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Provider Sign Up</title>
 <style>
  
     <link href="https://fonts.googleapis.com/css?family=Lato:300" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300" rel="stylesheet">
        body {
            background-color: #2a2a2a;
            font-family: 'Lato', sans-serif;
            color: #fff;
            margin: 0;
            padding: 0;
        }

        form {
            background-color: #fff;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            padding: 30px;
            width: 400px;
            margin: auto;
            margin-top: 50px;
        }

        h1 {
            font-size: 28px;
            margin-bottom: 20px;
            text-align: center;
            color: #333;
        }

        label {
            display: block;
            margin-bottom: 10px;
            font-size: 16px;
            color: #555;
        }

        input[type="text"],
        input[type="password"],
        textarea,
        select {
            width: 100%;
            padding: 12px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 8px;
            box-sizing: border-box;
            font-size: 16px;
            color: #555;
            background-color: #f9f9f9;
        }

        input[type="radio"] {
            display: inline;
            margin-right: 10px;
        }

        button {
            width: 100%;
            height: 50px;
            background-color: #ff9966;
            color: #fff;
            border: none;
            border-radius: 8px;
            font-size: 18px;
            cursor: pointer;
            transition: background-color 0.3s ease;
        }

        button:hover {
            background-color: #e68a00;
        }

        /* Style for RadioButtonList */
        .horizontal-radiolist {
            display: flex;
            align-items: center;
        }

        input[type="radio"] {
        display: inline; /* Display radio buttons inline */
        margin-right: 10px; /* Add margin between radio buttons */
    }

    label {
        display: inline-block; /* Ensure labels are displayed inline-block */
        margin-right: 10px; /* Add margin between labels */
    }

    .control-button{
  border: none;
  margin-top: 15px;
}

        .control-button{
  cursor: pointer;
  display: block;
  margin-left: auto;
  margin-right: auto;
  width: 140px;
  height: 40px;
  font-size: 14px;
  text-transform: uppercase;
  background: none;
  border-radius: 20px;
  color: white;
}
        .control-button:focus{
  outline:none;
}


        .control-button.up{
  background-color: #ff9966;
}
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Sign Up</h1>
         

            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <br />

            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblDOB" runat="server" Text="Date of Birth:" ></asp:Label>
            <asp:TextBox ID="txtDOB" runat="server" placeholder="YYYY-MM-DD"></asp:TextBox>
            <br />

            <asp:Label ID="lblGender" runat="server" Text="Gender:"  ></asp:Label> 
            <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
            </asp:RadioButtonList>
            <br />

            <asp:Label ID="lblAddress" runat="server" Text="Address:"></asp:Label>
            <asp:TextBox ID="txtAddress" TextMode="MultiLine" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblContactNo" runat="server" Text="Contact Number:"></asp:Label>
            <asp:TextBox ID="txtContactNo" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblYearsOfExperience" runat="server" Text="Years of Experience:"></asp:Label>
            <asp:TextBox ID="txtYearsOfExperience" runat="server"></asp:TextBox>
            <br />

            <asp:Label ID="lblServiceArea" runat="server" Text="Service Area:"></asp:Label>
            <asp:TextBox ID="txtServiceArea" runat="server"></asp:TextBox>
            <br />


           
        <asp:label for="assistanceTypeDropDown" id="lbl"  runat="server" Text="Type of Assistance:"></asp:label></asp:>
        <select id="assistanceTypeDropDown" runat="server" class="form-control">
            <option value="Towing">Towing</option>
            <option value="Roadside Assistance">Roadside Assistance</option>
        </select>
   

            <asp:Button ID="btnSubmit" runat="server" Text="Submit"  class="control-button up" OnClick="btnSubmit_Click" />
        </div>
    </form>
</body>
</html>
