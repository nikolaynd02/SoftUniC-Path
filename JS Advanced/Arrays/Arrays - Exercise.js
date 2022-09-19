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

console.log(RotateArray(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15));