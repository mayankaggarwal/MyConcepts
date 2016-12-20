function greet(name) {
    log('Hello ' + name);
}

function greetUpdated(name) {
    name = name || "Micku";
    log('Hello ' + name);
}

greet('Mayank');
log("Calling greet without any parameter");
greet();
log("undefined is coerced to string on concatination");
log("Calling greet updated");
greetUpdated();