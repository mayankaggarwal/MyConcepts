var a = 0;
var b = false;

if (a == b) {
    console.log("A equal to b with equality operator");
    if (a === b) {
        Console.log("A equal to b with strict equality operator");
    } else {
        console.log("A not equal to b with strict equality operator");
    }
} else {
    console.log("A not equal to b with equality operator");
}

if ("" == 0)
    console.log("\"\" is equal to 0");

if(false == 0)
    console.log("false is equal to 0");

if(-0 == +0)
    console.log("+0 is strict equal to -0");

if(Object.is(+0,-0))
    console.log("Object is for +0 and -0 are true");
else
    console.log("Object is for +0 and -0 are false");

if(NaN == NaN)
    console.log("NaN is equal to NaN");
else
    console.log("NaN is not equal to NaN");

if(Object.is(NaN,NaN))
    console.log("Object is NaN is equal to NaN");
else
    console.log("Object is NaN is not equal to NaN");

//Equality comaprisons and sameness developer.mozilla.org