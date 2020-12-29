var roles = new Dictionary();

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

//弹出添加角色对话框
function ShowAddDlg() {
    ClearDlg();
    $("myModalLabel").html("添加角色");
    $("#customdlg").modal("show");
}

//清空对话框中数据
function ClearDlg() {
    $("#Name").val("");
    $("#Name").next().hide();
    $("#Code").val("");
    $("#Code").next().hide();
}

//弹出修改对话框
function ShowUpdateDlg() {
    getSelectedIds();
    //标记模态框的用途
    RemotoValidateUse = "Update";
    RemotoId = roles.getValues();
    ////判断是否只选中数据
    var selectedCount = roles.Count();
    if (selectedCount != 1) {
        alert("请选择一条要修改的角色信息！");
        return;
    }
    var roleId = RemotoId;
    //查询数据
    $.post(
        "GetRoleById",
        { id: roleId },
        function (data, status) {
            if (status == "success") {
                if (data != null) {
                    //-查询数据是否存在,存在则加载模态框.
                    $("#Name").val(data.name);
                    $("#Code").val(data.code);
                    $("myModalLabel").html("修改角色！");
                    $("#customdlg").modal("show");
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
            AddRole();
            break;
        case "Update":
            UpdateRole();
            break;
    }
}

//添加角色
function AddRole() {
    if (SubmitValidate() == false) return;//进行验证
    var roleName = $("#Name");
    var roleCode = $("#Code");
    $.post(
        "AddRole",
        { Name: roleName.val(), Code: roleCode.val()},
        function (data, status) {
            if (status == "success") {
                $("#gridview").html(data);
                $("#customdlg").modal("hide");
            }
        }
    );
}

//修改角色信息
function UpdateRole() {
    if (SubmitValidate() == false) return;//进行验证
    var RoleName = $("#Name");
    var RoleCode = $("#Code");
    $.post(
        "UpdateRole",
        { Id: RemotoId,Code: RoleCode.val(), Name: RoleName.val()},
        function (data, status) {
            if (status == "success") {
                $("#gridview").html(data);
                $("#customdlg").modal("hide");
            }
        }
    );
}

//删除角色
function Remove() {
    //获取选中的用户
    getSelectedIds();
    var keys = roles.getValues();
    //判断是否有选中的用户
    if (keys == "") {
        alert("请先选中要删除的用户!");
        return;
    }
    //二次确认删除
    if (confirm("确定要删除吗?") == true) {
        $.post(
            "RemoveRole",
            { RoleId: keys },
            function (data, status) {
                if (status == "success") {
                    $("#gridview").html(data);
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
    rule1.Msg = "请输入角色代码!";
    var rule2 = new Rules();
    rule2.Name = "Remoto";
    rule2.Msg = "角色代码已被使用!";
    rule2.param = "IsRoleCodeRepeat";
    content.Add("Code", new Array(rule1, rule2));

    var rule3 = new Rules();
    rule3.Name = "required";
    rule3.Msg = "请输入角色名称!";
    var rule4 = new Rules();
    rule4.Name = "Remoto";
    rule4.Msg = "角色名称已被使用!";
    rule4.param = "IsRoleNameRepeat";
    content.Add("Name", new Array(rule3, rule4));
    return content;
}

//获取所有选中的用户id
function getSelectedIds() {
    ClearIds();
    $(":checkbox").each(function () {
        var ret = $(this).is(":checked");
        if (ret == true) {
            var id = $(this).attr("id");
            roles.Add(id, id);
        }
    });
}

//清空全局用户数据字典
function ClearIds() {
    roles.Clear();
}


//上一页
function pagePre(currentPage) {
    $.get(
        "getPageData",
        { page: (currentPage - 1), pagesize: 9 },
        function (data, status) {
            if (status == "success") {
                $("#gridview").html(data);
            }
        }
    );
}
 
//下一页
function pageNext(currentPage) {
    $.get(
        "getPageData",
        { page: (currentPage + 1), pagesize: 9 },
        function (data, status) {
            if (status == "success") {
                $("#gridview").html(data);
            }
        }
    );
}

$(document).ready(
    function () {
        //初始化控件验证信息
        ClassValidate();
    });