//Function Statement
function greet(name) {
    log('Hello ' + name);
}
greet('John in function statement');

// Function Expression
var greetFunc = function(name) {
    log('Hello ' + name);
}
greetFunc('John in function expression');

// Using immediately invoked function expression
var greeting = function(name) {
    return 'Hello ' + name;
}('John from Immediately Invoked function expression');

log(greeting);
// log(greeting());  // this line throws error
// No errors with following lines
3;
"I am a string";

{
    name : "Mayank"
};

// Following function syntax will throw error
//function(name) {
//    return 'Hello ' + name;
//}

(function(name) {
    log('Inside function expression created on fly');
    //return 'Hello ' + name;
    var greeting = 'Inside IIFE :Hello';
    log(greeting + ' ' + name);
}('Mayank'));
//})('Mayank');  // This also works
