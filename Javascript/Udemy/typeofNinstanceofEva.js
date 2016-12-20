log('type of var a = 3');
var a = 3;
log(typeof a);

log('type of var b = "Hello"');
var b = "Hello";
log(typeof b);

log('type of var c = {}');
var c = {};
log(typeof c);

log('type of var d = []');
var d = [];
log(typeof d); //'weird'
log(d.toString());
log('calling Object.prototype.toString.call(d)');
log(Object.prototype.toString.call(d));

function Person(name) {
    this.name = name;
}

var e = new Person('Jane');
log('typeof e');
log(typeof e);
log('e instanceof Person')
log(e instanceof Person);

log('typeof undefined');
log(typeof undefined);
log('typeof null')
log(typeof null); // bug since forever

var z = function() {};
log(typeof z);
