function a()
{
    b();
    var c = '1';
}

var b = function(){
    var d = "2";
}

a();
var d = "3";