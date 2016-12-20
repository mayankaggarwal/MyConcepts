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

//loop over every member of object
for (var prop in john) {
    if (john.hasOwnProperty(prop))
        log('Property of john :' + prop + ' ' + john[prop]);
    else
        log('Property of prototype :' + prop + ' ' + john[prop]);
}

var jane = {
    address : '111 Main St.',
    getFullName : function() {
        return this.lastname + ' ' + this.firstname; 
    }
}

var jim = {
    getFirstName : function() {
        return firstname;
    }
}

//Extend takes all the methods and properties of jane and jim and binds to john
_.extend(john,jane,jim);

log(john);