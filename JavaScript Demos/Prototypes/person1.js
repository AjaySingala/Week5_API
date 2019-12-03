var person = {
    firstname: 'John',
    lastname: 'Smith'
};

console.log(person);
console.log(person.firstname);

// Error as it does not exist.
person.work();

var employment = {
    work: function() {
        console.log('Working...');
    }
}

// Outputs default prototype as there is no prototype object is assosicated with person.
console.log('__proto__', person.__proto__);

person.__proto__ = employment;

// Outputs "Working..."
person.work();
// Outputs {work: f}
console.log('__proto__', person.__proto__);