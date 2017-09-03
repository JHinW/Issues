


let lst = [1, 2, 4, 5, 7, 7, 9, 10, 20, 20, 22, 33, 34, 45, 46, 47];


function BinSearch(lst, len, key) {
    let begin = 0;
    let end = len - 1;

    let mid = parseInt((end - 1) / 2);


    // if(lst[begin] === key ) return begin;

    // if(lst[end] === key ) return len -1;

    if (lst[mid] === key) return mid;

    if (begin >= end) return "nothing";
    else {


        if (lst[mid] < key) {
            return mid + 1 + BinSearch(lst.slice(mid + 1, end + 1), end - mid, key);
        }

        if (lst[mid] > key) {
            return begin + BinSearch(lst.slice(begin, mid), mid - begin, key);
        }
    }

}



function BinSearch2(lst, len, key) {
    let begin = 0;
    let end = len - 1;
    let mid = -1;

    while (begin <= end) {
        mid = parseInt((end + begin) / 2);
        if (lst[mid] == key) return mid;
        if (lst[mid] < key) begin = mid + 1;
        if (lst[mid] > key) end = mid - 1;
    }

    return mid;

}


function searchLowwerBound(lst, low, high, target) {
    if (high < low || target <= lst[low]) return -1;

    let mid = parseInt((low + high) / 2);

    while (high > low) {


        if (lst[mid] >= target) high = mid - 1;
        else
            low = mid;

            mid = parseInt((low + high) / 2);
    }

    return mid;
}

function searchUpperBound(lst, low, high, target) {
    if (high < low || target >= lst[high]) return -1;

    let mid = parseInt((low + high) / 2);

    while (high > low) {


        if (lst[mid] > target) high = mid;
        else
            low = mid + 1;

            mid = parseInt((low + high) / 2);
    }

    return mid;
}


// var index = BinSearch2(lst, lst.length, 5);

let index = searchUpperBound(lst, 0, lst.length - 1, 7);

console.log(`index: ${index}`);
console.log(`result: ${lst[index]}`);