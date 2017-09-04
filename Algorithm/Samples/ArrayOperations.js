

let lst = [1, 2, 4, 5, 7, 7, 9, 10, 20, 20, 22, 33, 34, 45, 46, 47];

Array.prototype.distinct = function(){
    for(let i= 0; i< this.length; i ++){
        var cur = this[i];
        this.splice(i, 1, null);
        if(this.indexOf(cur) < 0){
            this.splice(i, 1, cur);
        }else{
            this.splice(i, 1);
        }
    }
    return this;
}

// let results = lst.distinct();
let results2 = lst.concat().sort();
let results1 = results2.sort( (a,b) =>{
    if(a==b){
        let n =  results2.indexOf(a);
        results2.splice(n, 1);
    }
})

console.log(`result: ${results1}`);