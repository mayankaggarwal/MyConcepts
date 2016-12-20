var arr = new Array();
var arr1 = [1,2,3,4];

var arr2 = [
    1,
    false,
    {
        name : "Mayank",
        address : '111 Main st'
    },
    function(name) {
        var greeting = 'Hello';
        log(greeting + name);
    },
    function() {
        log(this);
    },
    "Hello"
];

log(arr2);
log(arr2[2]);
arr2[3](" " + arr2[2].name);
arr2[4]();