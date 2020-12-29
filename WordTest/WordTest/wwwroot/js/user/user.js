var userids = new Dictionary();//存储用户信息的字典

//弹出添加用户对话框
function ShowDlg(usetype) {
    switch (usetype) {
        case "Add":
            RemotoValidateUse = "Add";
            ShowAddDlg();
            break;
        case "Update":
            RemotoValidateUse = "Update";
            ShowUpdateDlg();
            break;
    }
}

function ShowAddDlg() {
    ClearDlg();
    $("myModalLabel").html("添加用户");
    $("#Userdlg").modal("show");
}

function ClearDlg() {
    $("#Name").val("");
    $("#Name").next().hide();
    $("#Acc").val("");
    $("#Acc").next().hide();
    $("#Pwd").val("");
    $("#Pwd").next().hide();
    $("#Age").val("");
    $("#Age").next().hide();
}


//弹出修改对话框
function ShowUpdateDlg() {
    getSelectedIds();
    //标记模态框的用途
    RemotoId = userids.getValues();
    ////判断是否只选中数据
    var selectedCount = userids.Count();
    if (selectedCount != 1) {
        alert("请选择一条要修改的用户信息！");
        return;
    }
    var userId = RemotoId;
    //查询数据
    $.post(
        "GetUserById",
        { id: userId },
        function (data, status) {
            if (status == "success") {
                if (data != null) {
                    //-查询数据是否存在,存在则加载模态框.
                    $("#Name").val(data.name);
                    $("#Age").val(data.age);
                    $("#Acc").val(data.acc);
                    $("#Pwd").val(data.pwd);
                    $("#Gender").val((data.gender));
                    $("myModalLabel").html("修改用户！");

                    $("#Userdlg").modal("show");
                } else {
                    //-查询数据为空，则弹出提示.
                    alert("没有查询到相关数据！");
                }
            }
        }
    );
}

function modalSubmit() {
    switch (RemotoValidateUse) {
        case "Add":
            AddUser();
            break;
        case "Update":
            UpdateUser();
            break;
    }
}

//添加用户
function AddUser() {
    if (SubmitValidate() == false) return;//进行验证
    var UserName = $("#Name");
    var UserAge = $("#Age");
    var UserAcc = $("#Acc");
    var UserPwd = $("#Pwd");
    var gender = $("#Gender option:selected").val();
    $.post(
        "AddUser",
        { Name: UserName.val(), Gender: gender, Acc: UserAcc.val(), Pwd: UserPwd.val(), Age: UserAge.val() },
        function (data, status) {
            if (status == "success") {
                $("#userGridview").html(data);
                $("#Userdlg").modal("hide");
            }
        }
    );
}

//修改用户信息
function UpdateUser() {
    if (SubmitValidate() == false) return;//进行验证
    var UserName = $("#Name");
    var UserAge = $("#Age");
    var UserAcc = $("#Acc");
    var UserPwd = $("#Pwd");
    var gender = $("#Gender option:selected").val();
    $.post(
        "UpdateUser",
        { Id: RemotoId, Name: UserName.val(), Gender: gender, Acc: UserAcc.val(), Pwd: UserPwd.val(), Age: UserAge.val() },
        function (data, status) {
            if (status == "success") {
                $("#userGridview").html(data);
                $("#Userdlg").modal("hide");
            }
        }
    );
}

//删除用户
function Remove() {
    //获取选中的用户
    getSelectedIds();
    var keys = userids.getValues();
    //判断是否有选中的用户
    if (keys == "") {
        alert("请先选中要删除的用户!");
        return;
    }
    //二次确认删除
    if (confirm("确定要删除吗?") == true) {
        $.post(
            "RemoveUser",
            { UserId: keys },
            function (data, status) {
                if (status == "success") {
                    $("#userGridview").html(data);
                }
            }
        );
    }
}

//初始化验证
function SetValidate() {
    var content = new Dictionary();
    var rule1 = new Rules();
    rule1.Name = "required";
    rule1.Msg = "请输入昵称!";
    var rule5 = new Rules();
    rule5.Name = "Remoto";
    rule5.Msg = "昵称已被使用!";
    rule5.param = "IsNickRepeat";
    content.Add("Name", new Array(rule1, rule5));

    var rule2 = new Rules();
    rule2.Name = "required";
    rule2.Msg = "请输入账号!";
    var rule6 = new Rules();
    rule6.Name = "Remoto";
    rule6.Msg = "账号已存在！";
    rule6.param = "IsAccRepeat";
    content.Add("Acc", new Array(rule2, rule6));

    var rule3 = new Rules();
    rule3.Name = "required";
    rule3.Msg = "请输入密码!";
    content.Add("Pwd", new Array(rule3));

    var rule4 = new Rules();
    rule4.Name = "Number";
    rule4.Msg = "请输入数字!";

    var rule7 = new Rules();
    rule7.Name = "Rang";
    rule7.Msg = "请输入1到150的数字!";
    rule7.param = "1,150";
    content.Add("Age", new Array(rule4, rule7));
    return content;
}

//获取所有选中的用户id
function getSelectedIds() {
    ClearIds();
    $(":checkbox").each(function () {
        var ret = $(this).is(":checked");
        if (ret == true) {
            var id = $(this).attr("id");
            userids.Add(id, id);
        }
    });
}

//清空全局用户数据字典
function ClearIds() {
    userids.Clear();
}


//上一页
function pagePre(currentPage) {
    $.get(
        "getTable",
        { page: (currentPage - 1), pagesize: 9 },
        function (data, status) {
            if (status == "success") {
                $("#userGridview").html(data);
            }
        }
    );
}

//下一页
function pageNext(currentPage) {
    $.get(
        "getTable",
        { page: (currentPage + 1), pagesize: 9 },
        function (data, status) {
            if (status == "success") {
                $("#userGridview").html(data);
            }
        }
    );
}

$(document).ready(
    function () {
        //初始化控件验证信息
        ClassValidate();
    });