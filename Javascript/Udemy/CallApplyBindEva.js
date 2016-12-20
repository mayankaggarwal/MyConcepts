var person = {
    firstname: 'John',
    lastname: 'Aggarwal',
    getFullName : function() {
        var fullname = this.firstname + ' ' + this.lastname;
        return fullname;
    }
};

var logName = function(lang1,lang2) {
    log('Logged: ' + this.getFullName());
    log('Arguments: ' + lang1 + ' ' + lang2);
    log('----------------------------');
};

var logPersonName = logName.bind(person);
log('Calling using bind');
logPersonName('en');
log('Calling using call');
logName.call(person,'en','es');
log('Calling using apply which requires array as arguments');
logName.apply(person,['en','es']);

(function(lang1,lang2) {
    log('Logged: ' + this.getFullName());
    log('Arguments: ' + lang1 + ' ' + lang2);
    log('----------------------------');
}).apply(person,['en','es']);


//function borrowing
log('function borrowing');
var person2 = {
    firstname: 'Mayank',
    lastname: 'Doe'
};

log(person.getFullName.apply(person2));

//function currying
//with bind we are copying the function

function multiply(a,b) {
    return a*b;
}

log('passing parameters to bind means permanently setting the value of argument of fn');
var multiplyByTwo = multiply.bind(this,2);

log(multiplyByTwo(4,13));