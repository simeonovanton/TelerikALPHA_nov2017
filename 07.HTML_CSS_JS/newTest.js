'use strict'
function outer(x){
    function inner(y){
        return x + ' ' + y;
    }
    return inner;
}

let result = outer('text');

console.log(result);
console.log(typeof(result));

let newResult = result('newText');
console.log(newResult);

let thirdResult = result('3Text');
console.log(thirdResult);
var 
