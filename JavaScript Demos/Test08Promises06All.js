// var request1 = fetch('users.json');
// var request2 = fetch('products.json');

var request1 = new Promise(function(resolve, reject) { 
	resolve('request1 worked!'); 
}) 
var request2 = new Promise(function(resolve, reject) { 
	resolve('request2 worked!'); 
}) 
			
Promise.all([request1, request2]).then(function(results) {
  console.log("Both promises are done.");
});
