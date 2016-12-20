var objectliteral = {
    firstname:'Mayank',
    isAProgrammer:true
};

log(objectliteral);

log(JSON.stringify(objectliteral));

var jsonValue = JSON.parse('{"firstname":"Mayank","isAProgrammer":true}');
log(jsonValue);