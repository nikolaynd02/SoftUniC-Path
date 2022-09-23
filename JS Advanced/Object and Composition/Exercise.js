//P.01
function CalorieObject(params){
    
    let food ={};
    
    for(let i=0; i < params.length; i+=2){
               
        let name = params[i];
        let calories = Number(params[i + 1]);
        
        food[name] = calories;

    }

    return food;
}


//P.02
function ConstructionCrew(data){
    let worker = data;

    if(worker.dizziness){
        worker.levelOfHydrated += worker.weight * worker.experience * 0.1;
        worker.dizziness = false;
    }

    return worker;
}

//P.03
function CarFactory(input){
    
    const wheels = Array(4);
    input.wheelsize % 2 == 0
        ? wheels.fill(input.wheelsize - 1, 0, 4)
        : wheels.fill(input.wheelsize, 0, 4);


    function getEngine(power) {
        if (power > 120) {
            return { power: 200, volume: 3500 };
        } else if (power > 90) {
            return { power: 120, volume: 2400 };
        } else {
            return { power: 90, volume: 1800 }
        }
    }
    
    let finalProduct = {
        model: input.model,
        engine: getEngine(input.power),
        carriage: { type: input.carriage, color: input.color },
        wheels
    }

    return finalProduct;
}

console.log(CarFactory({
    model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 15
}
));