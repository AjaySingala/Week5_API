/*
Gets are Deep, but Sets are Shallow.
The motivation behind the inheritance is to reuse the methods and properties.
In class-based inheritance, the instances of a class reuse the members of the 
class’ base class. Whereas, in the case of prototypal inheritance,
the prototype is reused by delegating calls to its prototype.

However, the behavior is widely different when we are trying to get a property
as compared to setting it.
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

console.log(person1.calculateAge()); // 19.
console.log(person2.calculateAge()); // 19.

person1.incrementBirthYearByOne();

console.log(person1.calculateAge()); // 18.
console.log(person2.calculateAge()); // 19.