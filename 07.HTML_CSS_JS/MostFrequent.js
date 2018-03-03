const getGets = (arr) => {
    let index = 0;

    return () => {
        const toReturn = arr[index];
        index += 1;
        return toReturn;
    };
};
// this is the test
const test = `13
4
1
1
4
2
3
4
4
1
2
4
9
3`.split('\n');

const gets = this.gets || getGets(test);
const print = this.print || console.log;

var n = parseInt(gets());
var counts = {};

for(i = 0; i < n; i += 1){
    var x = parseInt(gets());
    if(!counts[x]) {
        counts[x] = 0;  
    }   
    counts[x] += 1;
    console.log(counts);
}
console.log('a'.charCodeAt(0));