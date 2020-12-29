//全选checkbox
function setAllCheckBoxChecked() {
    $(":checkbox").prop("checked", true);
}

//取消全选checkbox
function RemoveAllCheckBoxChecked() {
    $(":checkbox").prop("checked", false);
}

//全选和反选
function HeadCheckboxClick(box) {
    if ($(box).is(":checked") == true) {
        setAllCheckBoxChecked();
    } else {
        RemoveAllCheckBoxChecked()
    }
}

//鼠标停留增加背景样式
function addbackgroud(row) {
    $(row).addClass("RowSelect");
}

//鼠标离开移除背景样式
function removebackgroud(row) {
    $(row).removeClass("RowSelect");
}