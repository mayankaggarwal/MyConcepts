var a = 1;
var b = new Number(1);

log(a);
log(b);

var c = "Mayank";
var d = new String("Mayank");

log(c);
log(d);

//Here c is boxed inside String object so it will also have access to methods of String.prototype
log(c.indexOf("a"));
log(d.substr(1,2));

var e = new Date('12/8/2016');
e.setHours(13);
e.setMinutes(45);
log(e);

//Adding a feature to all Strings
String.prototype.isLengthGreaterThan = function(limit) {
    return this.length > limit;
}

// Here John was converted to object;
log('John'.isLengthGreaterThan(3));

Number.prototype.isPositive = function() {
    return this > 0;
}

//Here Javascript fails to convert 3 into object
//log(3.isPositive());

var x = new Number(3);
log(x.isPositive());


var m = 3;
var n = new Number(3);

log(m==n); //results to true
log(m===n); //results to false


var arr = ['John','Jim','Jane'];

for(var prop in arr) {
    log(prop + ': ' + arr[prop]);
}

//Adding custom feature
log('Adding custom feature');
Array.prototype.mycustomfeature = 'cool!';
for(var prop in arr) {
    log(prop + ': ' + arr[prop]);
}

log('So instead use for loop instead of for in');
for (var i = 0; i < arr.length ; i++) {
    log(i + ': ' + arr[i]);
}
