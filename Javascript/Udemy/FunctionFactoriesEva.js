function makeGreeting(language) {
    return function(firstname,lastname) {
        if(language === 'en') {
            log('Hello ' + firstname + ' ' + lastname);
        }
        
        if(language === 'es') {
            log('Hola ' + firstname + ' ' + lastname);
        }
    }
}

var greetEnglish = makeGreeting('en');
var greetSpanish = makeGreeting('es');

greetEnglish('Mayank','Aggarwal');
greetSpanish('Mayank','Aggarwal');