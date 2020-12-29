var RemotoValidateUse;//远程验证重复的操作类型,新增:Add,修改:Update
var RemotoId;//修改验证时需要提供的id
var validateFault = new Dictionary();

//非空验证
function validate_required(ele, msg) {
    if (ele.val() == "") {
        showErrorMsgElement(ele, msg)
        return false;
    } else {
        hideErrorMsgElement(ele)
    }
    return true;
}

//数字验证
function validate_number(ele, msg) {
    var value = ele.val();
    var ret = $.isNumeric(value);
    if (ret == false && value != "") {
        showErrorMsgElement(ele, msg)
        return false;
    } else {
        hideErrorMsgElement(ele)
    }
    return ret;
}

//范围验证
function validate_rang(ele, msg, param) {
    var rang = param.split(',');
    var min = rang[0];
    var max = rang[1]
    var value = ele.val();
    var result = false;
    if ($.isNumeric(min) == true && $.isNumeric(max) == true && $.isNumeric(value) == true) {
        value = Number.parseInt(value);
        min = Number.parseInt(min);
        max = Number.parseInt(max);
        if (value >= min && value <= max) {
            hideErrorMsgElement(ele);
            result = true;
        } else {
            showErrorMsgElement(ele, msg)
        }
    } else {
        showErrorMsgElement(ele, msg)
    }
    return result;
}

//远程验证
async function validate_remoto(ele, msg, param, id) {
    $.get(
        param,
        { value: ele.val(), ExceptId: id },
        function (data, status) {
            if (status == "success") {
                var retjosn = data;
                var id = ele.attr("id");
                if (retjosn.ret == true) {
                    showErrorMsgElement(ele, msg);
                    validateFault.Add(id, id);
                } else {
                    hideErrorMsgElement(ele);
                    if (validateFault.Find(id) != null) {
                        validateFault.Remove(id);
                    }
                }
            }
        }
    );
}

//验证失败时，显示错误信息
function showErrorMsgElement(ele, msg) {
    var span = ele.next();
    span.show();
    span.text(msg);
}

//验证通过时，隐藏错误信息
function hideErrorMsgElement(ele) {
    var span = ele.next();
    span.hide();
}

//根据验证规则，调用不同验证方法
function validate(ele, rule, msg, param) {
    switch (rule) {
        case "required":
            return validate_required($(ele), msg);
            break;
        case "Number":
            return validate_number($(ele), msg);
            break;
        case "Remoto":
            if (RemotoValidateUse == "Add") {
                return validate_remoto($(ele), msg, param);
            } else if (RemotoValidateUse == "Update") {
                return validate_remoto($(ele), msg, param, RemotoId);
            }
        case "Rang":
            return validate_rang($(ele), msg, param);
    }
}

//单个验证
function validateStart(ele,type) {
    var errorcount = 0;
    var validateDictionary = SetValidate();
    var name = ele.attr("name");
    var rules = validateDictionary.Find(name);
    if (rules != 'undefined') {
        if (type == "keybord") {
            for (var i = 0; i < rules.length; i++) {
                if (validate(ele, rules[i].Name, rules[i].Msg, rules[i].param) == false) {
                    return false;
                }
            }
        } else {
            for (var i = 0; i < rules.length; i++) {
                if (rules[i].Name != "Remoto" && validate(ele, rules[i].Name, rules[i].Msg, rules[i].param) == false) {
                    return false;
                }
            }
        }
    }
}

//键盘up时进行验证
function ClassValidate() {
    var elements = $(".validate");
    elements.keyup(function () {
        validateStart($(this),"keybord");
    });
}

//按钮提交时进行验证
function SubmitValidate() {
    var elements = $(".validate");
    var error = 0;
    if (typeof (elements) != "undefined") {
        for (var i = 0; i < elements.length; i = i + 1) {
            if (validateStart($(elements[i]),"button") == false) {
                error = error + 1;
            }
        }
    }
    if (error > 0) {
        return false;
    } else {
        if (validateFault.Count() > 0) {
            for (var key in validateFault._Database) {
                var id = validateFault._Database[key];
                $(("#" + id)).next().show();
            }
            return false;
        } else {
            return true;
        }
    }
}

//验证规则对象
function Rules() {
    var Name;
    var Msg;
    var param;
}

