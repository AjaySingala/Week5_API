/*
 As inheritance in JavaScript is implemented using an object chain, 
 and not using a class hierarchy, to understand prototypal inheritance
 we have to know how object chaining behaves.
*/

class Person {}

const personOne = new Person();
const personTwo = new Person();

const personOnePrototype = Reflect.getPrototypeOf(personOne);
const personTwoPrototype = Reflect.getPrototypeOf(personTwo);

console.log(personOne === personTwo); // false
console.log(personOnePrototype === personTwoPrototype); // true.

/*
 1. The objects are different, but they share their prototypes.
 2. The instance personOne of Person has a prototype Person {}, 
 which in turn has a prototype {}, which has null as its prototype,
 resulting in end of the prototype chain.
*/