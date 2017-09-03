
let lst = [1, 2, 4, 225, 7,33, 7, 9,1, 10, 22220, 20, 22,12321, 33, 34, 45, 46, 47];

function mergeSort(array) {
    function sort(array, first, last) {
        first = (first === undefined) ? 0 : first
        last = (last === undefined) ? array.length - 1 : last
        if (last - first < 1) {
            return;
        }
        var middle = Math.floor((first + last) / 2);
        sort(array, first, middle);
        sort(array, middle + 1, last);
        var f = first,
            m = middle,
            i,
            temp;
        while (f <= m && m + 1 <= last) {
            if (array[f] >= array[m + 1]) { // 这里使用了插入排序的思想
                temp = array[m + 1];
                for (i = m; i >= f; i--) {
                    array[i + 1] = array[i];
                }
                array[f] = temp;
                m++
            } else {
                f++
            }
        }
        return array;
    }
    return sort(array);
}

function swap(array, i, j){
    var temp = array[i];
    array[i] = array[j];
    array[j] = temp;

}


let results = mergeSort(lst);

// console.log(`index: ${index}`);
console.log(`result: ${results}`);