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
console.log(ConstructionCrew({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}
));