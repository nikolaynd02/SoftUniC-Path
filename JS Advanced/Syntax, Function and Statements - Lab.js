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

calcLength('pasta', '5', '22.3')
