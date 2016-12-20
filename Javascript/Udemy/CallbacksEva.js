function sayHiLater() {
    var greeting = 'Hi';
    
    setTimeout(function() {
       log(greeting); 
    },3000);
}

sayHiLater();

// jQuery uses function expressions and first-class functions
//$("button").click(function() {
//    
//});

function tellMeWhenDone(callback) {
    var a = 1000; //somework
    var b = 2000; // some work
    
    callback(); // the callback , it runs the function I give it
}

tellMeWhenDone(function() {
    log('I am done');
});


tellMeWhenDone(function() {
    alert('I am done');
});