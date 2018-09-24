<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="ADO.AddUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <table>
          <input type="hidden" name="uid" value="<%=uid %>"/>
          <tr> 
              <td>昵称</td>
              <td><input type="text" name="nickname" value="<%=nickname %>"/></td>
          </tr>
          <tr>
              <td>姓名</td>
              <td><input type="text" name="truename" value="<%=truename %>"/></td>
          </tr>
          <tr>
              <td>姓别</td>
              <td><input type="text" name="sex" value="<%=sex %>"/></td>
          </tr>
          <tr>
              <td>头像</td>
              <td><input type="text" name="face" value="<%=face %>"/></td>
          </tr>
          <tr>
              <td>密码</td>
              <td><input type="text" name="password" value="<%=password %>"/></td>
          </tr>
          <tr>
              <td>电话</td>
              <td><input type="text" name="mobile" value="<%=mobile %>"/></td>
          </tr>
          <tr>
              <td>邮箱</td>
              <td><input type="text" name="email" value="<%=email %>"/></td>
          </tr>
          <tr><td><input type="hidden" name="type" value="1"/></td></tr>
          <tr><td><input type="submit" value="<%=save %>" /></td>
              <td><a href="/UserInfo.aspx">返回</a></td>
          </tr>
      </table>
    </div>
    </form>
</body>
</html>
