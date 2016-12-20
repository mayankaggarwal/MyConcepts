//polyfill
if(!Object.create) {
    Object.create = function(o) {
        if(arguments.length > 1) {
            throw new Error('Object.create implementation only accepts first paramter');
        }
        
        function F(){}
        F.prototype = o;
        return new F();
    };
}

var person = {
    firstname : 'Default',
    lastname : 'Default',
    greet : function() {
        //Here writting this is important as if not present firstname will be searched in global execution context as objects don't create their execution context.
        return 'Hi' + ' ' + this.firstname;
    }
}

var john = Object.create(person);
log(john);
john.firstname = 'Mayank';
john.lastname = 'Aggarwal';
log(john);
log(john.greet());