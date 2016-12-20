function greet() {
    log('Hello Mayank');
}

greet.country = 'India';

log(greet);
log(greet.country);


greet1();

function greet1(){
    log('Hello from greet1 in function statement');
}

//anonymousGreet(); // This will not work as it is undefined;

var anonymousGreet = function greet2(){
    log('Hello from anonymous function in function expression');
}

anonymousGreet();


function loggingfunction(a) {
    console.log(a);
    a();
}

loggingfunction(function() {
    console.log('Hi from function as parater');
})