<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="ADO.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <style>
        .table {
            border:1px solid black;
            border-left:1px solid black;
            border-top:1px solid black;
        }
            .table td {
                border:1px solid black;
                border-right:1px solid black;
                border-bottom:1px solid black;
            }
    </style>

    <script>
        //更新
        function myupdate(uid,nickname,truename,sex,email)
        {
            window.location.href = "/AddUser.aspx?flag=update&uid="+uid+ "&nickname= "+nickname+"&truename="+truename+"&sex="+sex+"&email="+email;
        }
        //删除
        function mydelete(uid) {
            window.location.href = "/UserInfo.aspx?flag=delete&uid=" + uid;
        }
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="table">
            <thead>
                <tr>
                    <td>ID</td>
                    <td>昵称</td>
                    <td>姓名</td>
                    <td>性别</td>
                    <td>邮箱</td>
                    <td>注册时间</td>
                    <td colspan="2">操作</td>
                </tr>
            </thead>
            <tbody>
                <% foreach (model.userinfo user in userInfo)
                {%>
                <tr>
                    <td><%=user.id %></td>
                    <td><%=user.nickname %></td>
                    <td><%=user.truename %></td>
                    <td><%=user.sex %></td>
                    <td><%=user.email %></td>
                    <td><%=user.regtime %></td>
                    <td><button type="button" onclick="myupdate(<%=user.id %>,'<%=user.nickname %>','<%=user.truename %>','<%=user.sex %>','<%=user.email %>')">修改</button></td>
                    <td><button type="button" onclick="mydelete(<%=user.id %>)">删除</button></td>
                </tr>
                 <%}
                %>
                <tr><td><a href="AddUser.aspx">添加用户</a></td></tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
