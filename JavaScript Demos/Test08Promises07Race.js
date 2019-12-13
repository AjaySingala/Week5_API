// request1 promise never gets resolved!
var request1 = new Promise(function(resolve, reject) { 
  setTimeout(function() { resolve('First!'); }, 5000);
});


var request2 = new Promise(function(resolve, reject) { 
  setTimeout(function() { resolve('Second!'); }, 1000);
});


Promise.race([request1, request2]).then(function(output) {
  console.log('Output: ', output);
});
