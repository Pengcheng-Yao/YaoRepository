function Dictionary() {
    this._Database = [];
    this.Add = Add;
    this.Remove = Remove;
    this.Find = Find;
    this.Count = Count;
    this.Clear = Clear;
    this.kSort = kSort;
    this.vSort = vSort;
    this.getValues = getValues;
}

function Add(key, data) {
    this._Database[key] = data;
}

function Remove(key) {
    delete this._Database[key];
}

function Find(key) {
    return this._Database[key];
}

function Count() {
    var n = 0;
    for (var key in Object.keys(this._Database)) {
        n = n+1;
    }
    return n;
}

function Clear() {
    for (var key in this._Database) {
        delete this._Database[key];
    }
}

function kSort() {
    var dic = this.datastore;
    var res = Object.keys(dic).sort();
    for (var key in res) {
        console.log(res[key] + " : " + dic[res[key]]);
    }
}
// 按键(key)排序，降序
function vSort() {
    var dic = this.datastore;
    var res = Object.keys(dic).sort(function (a, b) {
        return dic[a] - dic[b];
    });
    for (var key in res) {
        console.log(res[key] + " : " + dic[res[key]]);
    }
}

function getValues() {
    var keys = "";
    for (var key in this._Database) {
        if (keys == "") {
            keys = this._Database[key];
        } else {
            keys = keys + "," + this._Database[key];
        }
    }
    return keys;
}

