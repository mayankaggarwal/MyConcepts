var m = 8;
function a()
{
    console.log(m);
}

function b()
{
    var m = 5;
    a();
}

b();