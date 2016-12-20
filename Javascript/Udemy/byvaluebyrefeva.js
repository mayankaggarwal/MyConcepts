// by value premitives
log("by value premitives");
var a = 3;
var b;

b = a;
a = 2;

log(a);
log(b);

// by reference (all objects (including functions))
log("by reference (all objects (including functions))");
var c = { greeting : 'hi'};
var d;

d = c;

c.greeting = 'Hello';

log(d);
log(c);

//by reference(even as paramters)

log("by reference(even as paramters)");

function changeGreeting(obj) {
    obj.greeting = 'Hola'; //mutate
}

changeGreeting(d);
log(c);
log(d);

// equals operator sets up new memory space (new address)
log("equals operator sets up new memory space (new address)");

c = {greeting: "howdy"};
log(c);
log(d);