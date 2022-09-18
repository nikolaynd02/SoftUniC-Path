//P.01
function Fruit(fruit, weight, price){
    let totalPrice = (weight / 1000) * price;
    console.log(`I need $${totalPrice.toFixed(2)} to buy ${(weight / 1000).toFixed(2)} kilograms ${fruit}.`)
}

//P.02
function GCD(num1, num2){
    let gcd = 0;
    let end = num1 > num2 ? num2 : num1;

    for(let i = 1; i <= end; i++){
        if(num1 % i == 0 && num2 % i == 0){
            gcd = i;
        }
    }

    console.log(gcd);
}

//P.03
function SameNumber(num){
    let digit = num % 10;
    let same = true;
    let sum = 0;

    while (num != 0)
    {
        let currentDigit = num % 10;
 
        num = parseInt(num / 10);
        sum+=currentDigit;
 
        if (currentDigit != digit)
        {
            same = false;
        }
    }
 
    if(same){
        console.log(`true`);
    }
    else{
        console.log(`false`)
    }
    console.log(sum);
}

//P.04
function PreviosDay(year, month, day){

    let date = new Date(`${year}-${month}-${day}`);
    let previous = new Date(date.setDate(date.getDate() - 1));

    console.log(`${previous.getFullYear()}-${previous.getMonth() + 1}-${previous.getDate()}`);
}

//P.05
function TimeToWalk(steps, footprintLength, speed){
    let distance = steps * footprintLength;
    speed = speed * 0.277778;
    let rests = Math.floor(distance / 500) * 60;;

    let time = (distance / speed) + rests;

    let seconds = Math.round(time % 60).toString();
    time = Math.floor(time / 60);
    let minutes = (time % 60).toString();
    time = Math.floor(time / 60);
    let hours = time.toString();

    console.log(`${hours.padStart(2, `0`)}:${minutes.padStart(2, `0`)}:${seconds.padStart(2, `0`)}`)
    
}

//P.06
function RoadRadar(speed, area){
    let zones = [`motorway`, `interstate`, `city`, `residential`];
    let limits = [130, 90, 50, 20];

    let zoneIndex = zones.indexOf(area);
    let zoneLimit = limits[zoneIndex];
    speed = Number(speed)

    if(speed <= zoneLimit){
        console.log( `Driving ${speed} km/h in a ${zoneLimit} zone`)
    }
    else{
        let speedDiff = speed - zoneLimit;

        if(speedDiff <= 20){
            console.log(`The speed is ${speedDiff} km/h faster than the allowed speed of ${zoneLimit} - speeding`)
        }
        else if(speedDiff <= 40){
            console.log(`The speed is ${speedDiff} km/h faster than the allowed speed of ${zoneLimit} - excessive speeding`)
        }
        else{
            console.log(`The speed is ${speedDiff} km/h faster than the allowed speed of ${zoneLimit} - reckless driving`)
        }
    }
}

RoadRadar(200, 'motorway')