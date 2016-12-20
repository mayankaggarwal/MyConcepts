log('Closures example');

function greet(whattosay) {
    return function(name) {
        log(whattosay + ' ' + name);
    }
}

var sayHi = greet('Hi');

//Even after execution context of greet is destroyed the memory space is available to function defined inside greet
sayHi('Mayank');


function buildFunctions() {
    var arr = [];
    
    for(var i = 0;i < 3;i++) {
        arr.push(function() {
           log(i); 
        });
    }
    
    return arr;
}

var fs = buildFunctions();

fs[0]();
fs[1]();
fs[2]();


//Solving free variable problem with ES6
function buildFunctions2() {
    var arr = [];
    for(var i = 0;i < 3;i++) {
        // let variable is scoped to the block so a new variable is created for each loop
        let j = i;
        arr.push(
            function() {
                log(j);
            });
    }
    
    return arr;
}

var fs2 = buildFunctions2();

fs2[0]();
fs2[1]();
fs2[2]();

//Solving free variable problem with ES5
function buildFunctions3() {
    var arr = [];
    for(var i = 0;i < 3;i++) {
        arr.push(
            (function(j) {
                return function() {
                    log(j);
                }
            }(i))
        )
    }
    
    return arr;
}

var fs3 = buildFunctions3();
fs3[0]();
fs3[1]();
fs3[2]();
