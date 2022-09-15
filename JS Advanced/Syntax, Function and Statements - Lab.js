//P.01
function echo(text){   
    console.log(text.length);
    console.log(text);
}

//P.02
function calcLength(first,second,third){
    let total = first.length + second.length + third.length;
    let avg = Math.floor(total/3);
    console.log(total);
    console.log(avg)
}

//P.03
function MaxNumber(num1, num2, num3){
    if(num1 >= num2 && num1 >= num3){
        console.log(`The largest number is ${num1}.`);
    }
    else if(num2 >= num1 && num2 >= num3){
        console.log(`The largest number is ${num2}.`);
    }
    else{
        console.log(`The largest number is ${num3}.`);
    }
}

//P.04
function CircleArea(input){
    let inputType = typeof(input);

    if(inputType == `number`){
        let area = (input ** 2) * Math.PI;
        console.log(area.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
}


//P.05
function MathOperation(num1, num2, symbol){
    let result = 0;

    switch(symbol){
        case `+`:
            result = num1 + num2;
            break;
        case `-`:
            result = num1 - num2;
            break;
        case `/`:
            result = num1 / num2;
            break;
        case `*`:
            result = num1 * num2;
            break;
        case `%`:
            result = num1 % num2;
            break;
        case `**`:
            result = num1 ** num2;
            break;
    }

    console.log(result);
}

//P.06
function SumAllNumbersBetween(num1, num2){
    let n = Number(num1);
    let m = Number(num2);
    let result = 0;

    for(let i = n; i<=m; i++){
        result += i;
    }

    console.log(result);
}

//P.07
function DayOfWeek(input){
    let output = 0;

    switch(input){
        case `Monday`: output = 1; break;
        case `Tuesday`: output = 2; break;
        case `Wednesday`: output = 3; break;
        case `Thursday`: output = 4; break;
        case `Friday`: output = 5; break;
        case `Saturday`: output = 6; break;
        case `Sunday`: output = 7; break;
    }

    if(output>0){
        console.log(output);
    }
    else{
        console.log(`error`);
    }
}

//P.08
function DaysInMonth(month, year){
    const days = new Date(year, month, 0).getDate();
    
    console.log(days);
}

//P.09
function SquareOfStars(size){
    for(let x = 0; x < size; x++){
        let row = ``;
        for(let y = 0; y< size; y++){
            row += `* `;
        }
        console.log(row);
    }   
}

//P.10
function AggregateElements(arr){
    let elements = arr;
    let sum = elements.reduce((a, b) => a + b, 0);
    console.log(sum);

    let str = ``;

    for(let i=0; i<elements.length; i++){
        str += elements[i];
        elements[i] = 1/elements[i];
    }
    console.log(elements.reduce((a, b) => a + b, 0));
    console.log(str);

}

AggregateElements([2, 4, 8, 16])