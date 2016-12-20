;(function(global,$){
    var Greetr = function(firstname,lastname,language) {
        return new Greetr.init(firstname,lastname,language);    
    }
    
    var supportedLanguages = ['en','es'];
    
    var greetings = {
        en : 'Hello',
        es : 'Hola'
    };
    
    var formalGreetings = {
        en : 'Greetings',
        es : 'Saludos'
    };
    
    var logMessages = {
        en  : 'Logged in',
        es : 'Inicio session'
    };
    
    Greetr.prototype = {
        fullname : function() {
            return this.firstname + ' ' + this.lastname;
        },
        
        validate : function() {
            if (supportedLanguages.indexOf(this.language) === -1) {
                throw "Invalid Language";
            }
        },
        
        greeting : function() {
            return greetings[this.language] + ' ' + this.firstname + '!';
        },
        
        formalGreeting : function() {
            return formalGreetings[this.language] + ' ' + this.fullname() + '!';
        },
        
        greet : function(formal) {
            var msg;
            
            //if undefined or null it will be coerced to false
            if(formal) {
                msg = this.formalGreeting();
            }
            else {
                msg = this.greeting();
            }
            
            if(console) {
                console.log(msg);
            }
            
            //this refers to calling object at execution time makes the method chainable
            return this;
        },
        
        log : function() {
            if(console) {
                console.log(logMessages[this.language] + ': ' + this.fullname());
            }
            
            return this;
        },
        
        setLang : function(lang) {
            this.language = lang;
            this.validate();
            return this;
        },
        
        greetBySelector : function(selector,formal) {
            if(!$){
                throw 'jquery not loaded';
            }
            
            if(!selector) {
                throw 'Missing JQuery Selector';
            }
            
            var msg;
            
            //if undefined or null it will be coerced to false
            if(formal) {
                msg = this.formalGreeting();
            }
            else {
                msg = this.greeting();
            } 
            $(selector).html(msg);
            
            return this;
        }
    
    };
    
    Greetr.init = function(firstname,lastname,language) {
        var self = this;
        self.firstname = firstname || '';
        self.lastname = lastname || '';
        self.language = language || 'en';
        self.validate();
    }
    
    Greetr.init.prototype = Greetr.prototype;
    
    global.Greetr = global.G$ = Greetr;
    
}(window,jQuery));