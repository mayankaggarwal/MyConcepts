function greet(firstname,lastname,language) {
    log(firstname);
    log(lastname);
    log(language);
    log('-----------------------');
}

greet();
greet("John");
greet("John",'Doe');
greet('John','Doe','es');

//default values of arguments is not supported by all browsers
function greet1(firstname,lastname,language = 'en') {
    lastname = lastname || 'Aggarwal';
    
    if(arguments.length === 0) {
        log('Missing Paramters');
        log('----------------');
        return;
    }
    log(firstname);
    log(lastname);
    log(language);
    log(arguments);
    log('-----------------------');
}

greet1();
greet1("John");
greet1("John",'Doe');
greet1('John','Doe','es');
