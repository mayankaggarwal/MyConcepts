var person = {
    firstname : 'Default',
    lastname : 'Default',
    getFullName : function() {
        return this.firstname + ' ' + this.lastname;
    }
}

var john = {
    firstname : 'Mayank',
    lastname : 'Aggarwal'
}

//don't do this EVER! for demo purpose only
john.__proto__ = person;
log(john.getFullName());
log(john.firstname);
log(john.__proto__.firstname);

var jane = {
    firstname : 'jane'
}

jane.__proto__ = person;
log(jane.getFullName());
log(jane.lastname);

