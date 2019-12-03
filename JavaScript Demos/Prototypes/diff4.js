/*
Difference between prototype, getPrototypeOf and _proto_.
1. Person.prototype is used to establish the prototype of objects created 
by new operator i.e new Person().
2. Object.getPrototypeOf(person1) is used for retrieving person1's prototype object.
3. person.proto is non-standard mechanism for retrieving person1's prototype object.
*/

class Person {}

Person.prototype.birthYear = 2000;
Person.prototype.calculateAge = function() {
    return new Date().getFullYear() - this.birthYear;
};
Person.prototype.incrementBirthYearByOne = function() {
    this.birthYear += 1;
};

const person1 = new Person();
const person2 = new Person();

console.log(Object.getPrototypeOf(person1) === Person.prototype); // true.
console.log(person1.__proto__ === Person.prototype); // true.