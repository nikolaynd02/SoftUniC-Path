//P.01
function PrintWithDelimiter(words, delimiter){
    console.log(words.join(delimiter));
}

//P.02
function PrintElementsWithStep(arr, step){
    let result = [];
    for(let i = 0; i < arr.length; i+=step){
        result.push(arr[i]);
    }

    return result;
}

//P.03
function AddOrRemoveNums(commands){
    let result = [];
    let num = 1;
       
    for (let command of commands) {

        if (command == `add`) {
            result.push(num);
        }else{
            result.pop();
        }

        num++;
    }   

    return result.length == 0 ? `Empty` : result.join('\n');
}

//P.04
function RotateArray(arr, step){
    for(let i = 0; i < step; i++){
        arr.unshift(arr.pop());
    }
    
    console.log(arr.join(` `));
}


//P.05
function IncSubsetArray(arr){
    let result = [];
    let biggestNum = 0;

    for(let num of arr){
        if( biggestNum <= num ){
            result.push(num);
            biggestNum = num;
        }
    }
    return result;
}

//P.06
function ListNames(arr){
    let result = arr
    .sort((a, b) => a.localeCompare(b))
    .forEach((el, number) => console.log(`${number + 1}.${el}`));
}

//P.07
function SortingNumbers(arr){
    let sorted = arr.sort((a, b) => a - b);
    let result = [];

    while (sorted.length != 0) {
        result.push(sorted.shift(), sorted.pop());
    }

    return result;
}

//P.08
function SortArrayWith2Criteria(arr){
    let result = arr.sort((a, b) => {
        if(a.length == b.length){
            return a.localeCompare(b);
        }
        else{
            return a.length - b.length;
        }
    });
    return result.join(`\n`);
}

//P.09
function MagicMatrices(arr){
    let target = arr[0].reduce((a, b) => a + b);
    let size = arr.length;
    let rowSum = 0;
    let isMagic = true;

    arr.forEach(arr => {
        rowSum = arr.reduce((acc, num) => acc + num);
        if (rowSum != target) {
            isMagic = false;
        }
    })

    if (!isMagic) {
        return false;
    }

    for (let col = 0; col < size; col++) {
        let colSum = 0;
        for (let row = 0; row < size; row++) {
            colSum += arr[row][col];
        }

        if (colSum != target) {
            isMagic = false;
            break;
        }
    }
    
    return isMagic;
}

console.log(MagicMatrices([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]));
