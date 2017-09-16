
function quickSort(array) {
	// 交换元素位置
	function swap(array, i, k) {
		var temp = array[i];
		array[i] = array[k];
		array[k] = temp;
	}
	// 数组分区，左小右大
	function partition(array, left, right) {
		var storeIndex = left;        
		var pivot = array[right]; // 直接选最右边的元素为基准元素
		for (var i = left; i < right; i++) {
			if (array[i] < pivot) {
				swap(array, storeIndex, i);
				storeIndex++; // 交换位置后，storeIndex 自增 1，代表下一个可能要交换的位置
			}
		}
		swap(array, right, storeIndex); // 将基准元素放置到最后的正确位置上
		return storeIndex;
	}
	function sort(array, left, right) {
		if (left > right) {
			return;
		}
		var storeIndex = partition(array, left, right);
		sort(array, left, storeIndex - 1);
		sort(array, storeIndex + 1, right);
	}
	sort(array, 0, array.length - 1);
	return array;
}


function quickSort2(array) {
	// 交换元素位置
	function swap(array, i, k) {
		var temp = array[i];
		array[i] = array[k];
		array[k] = temp;
	}
	// 数组分区，左小右大
	function partition(array, left, right) {
        let start = left;
        let end = right -1;
        let pivot = array[right];
        while(start < end){
            while(array[start] < pivot) start++;
            while(array[end] > pivot) end--;

            swap(array, start, end);
            start++; end--;
        }

        if(start == end) {
            let postion = null;
            if(array[end] > pivot) {
                postion = end;
                swap(array, postion, right);
            }else{
                postion = end +1;
                swap(array, postion, right);
            }
            
            return postion;
        }
        else{
            swap(array, end + 1, right);
            return end + 1;
        }
	}
	function sort(array, left, right) {
		if (left > right) {
			return;
		}
		var storeIndex = partition(array, left, right);
		sort(array, left, storeIndex - 1);
		sort(array, storeIndex + 1, right);
	}
	sort(array, 0, array.length - 1);
	return array;
}


let lst = [1, 2, 4, 225, 7,33, 7, 9,1, 10, 22220, 20, 22,12321, 33, 34, 45, 46, 47];

let results = quickSort2(lst);

// console.log(`index: ${index}`);
console.log(`result: ${results}`);