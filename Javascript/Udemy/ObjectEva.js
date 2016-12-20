var person = new Object();

person["firstname"] = "Tony";
person["lastname"] = "Aggarwal";

var firstnameProperty = "firstname";

log(person);
log(person[firstnameProperty]);

log(person.lastname);

person.address = new Object();
person.address.street = 'Vikas Yadav Maarg';
person.address.city = "Gurgaon";
person.address.state = "Haryana";

log(person.address.street);
log(person.address.city);
log(person["address"]["state"]);