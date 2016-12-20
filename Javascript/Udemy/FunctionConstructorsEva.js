//Person funtion is a Function constructor because it can be used to create an Object using new keyword
function Person(firstname,lastname) {
    log(this);
    this.firstname = firstname; //adding property firstname
    this.lastname = lastname; //adding property lastname
    log('This function is invoked');
    
    //Stops from creating the object of type Person
    //return {greeting:'I got in the way'};
}

Person('Function called','Directly');
//John is an object with properties firstname and lastname
var john = new Person('Function called','By John');
log(john);

var jane = new Person('Function called','By Jane');
log(jane);