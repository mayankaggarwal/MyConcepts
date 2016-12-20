log(this);

// Function statement
function a() {
    log(this);
    log("Attaching variable top global function");
    this.newvariable = "Hello";
}

// Function expression
var b = function() {
    log(this);
}
a();

log(newvariable);
b();

var c = {
    name : 'The c object',
    writeLog : function() {
        var self = this;
        this.name = "Updated c object";
        log(this);
        
        self.name = "updated c object by self";
        log(self);
        
        var setname = function(newname) {
            // here this variable is pointing to global execution environment
            this.name = newname;
        }
        
        var setnameself = function(newname) {
            //here self is pointing to this object of c object
            self.name = newname;
        }
        
        setname("Updated again! the c object!");
        setnameself("Updated again by self! the c object");
        log(this);
        log(self);
    }
}

c.writeLog();

log(this.name);