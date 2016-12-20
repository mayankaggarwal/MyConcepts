function Person(firstname,lastname) {
    log(this);
    this.firstname = firstname; //adding property firstname
    this.lastname = lastname; //adding property lastname
    //Specifying method like below will put it in every single object of Person type
    //this.getFullName = function() {......}
    log('This function is invoked');
}

log(Person.prototype);

Person.prototype.getFullName = function() {
    return this.firstname + ' ' + this.lastname;
}

//John points to Person.prototype as its prototype
var john = new Person('Function called','By John');
log(john);
log(john.getFullName());


//jane points to Person.prototype as its prototype
var jane = new Person('Function called','By Jane');
log(jane);
log(jane.getFullName());

Person.prototype.getFormalFullName = function() {
    return this.lastname + ' ' + this.firstname;
}

log(john.getFormalFullName());
//Mayank is undefined
var mayank = Person('Mayank','Aggarwal');
log('Forgot the New keyword');
log(mayank);
