var mayank = {
    firstname : "Mayank",
    lastname:"Aggarwal",
    address:{
        street:"Vikas Yadav marg",
        city:"Gurgaon",
        state:"Haryana"
    }
};

function greet(person) {
    log('Hi ' + person.firstname);
}

greet(mayank);
greet({firstname:"Mickku",lastname:'mm'});
//greet();
log(mayank);

mayank.address = {
    street: '333 Second St.'
}