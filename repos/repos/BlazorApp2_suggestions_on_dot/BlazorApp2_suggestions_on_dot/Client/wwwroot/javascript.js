
var p1="hello"
var cnt=0

function get_context(s) {
    p1 = s;
    cnt = cnt + 1;
    console.log(s);
    return s;
}

function get_context1() {
    return p1;
}

function get_cnt() {
    return cnt;
}