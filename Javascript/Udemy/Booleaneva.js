// Boolean evaluation
if (!Boolean(undefined))
    log("Boolean(undefined) is false");

if(!Boolean(""))
    log("\"\" parsed to false with Boolean");

var a;

// goes to internet and looks for value of a;
//if a is "" , null or undefined

a = "";
log("if a is \"\" , null or undefined and also 0");
if(a) {
    log("Something is there.");
} else {
    log("Nothing in the data");
}

a = "Hi"
log("Setting a to Hi");
if(a) {
    log("Something is there.");
} else {
    log("Nothing in the data");
}

log("Setting a to 0");
if(a || a===0)
    log("Something is there as === has higher precedence than ||");