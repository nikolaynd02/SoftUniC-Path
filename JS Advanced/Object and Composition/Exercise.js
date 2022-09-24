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

//P.04
function HeroicInvertory(input){
    let result = [];

    for(let info of input){
        let [name, level, items] = info.split(` / `);
        level = Number(level);
        items = items ? items.split(`, `) : [];
        result.push({name, level, items}); 
    }

    return JSON.stringify(result);
}

//P.05
function LowestPriceInCities(input){
    let result = [];

    for (const line of input) {
        let [town, product, price] = line.split(' | ');
        price = Number(price);

        let obj = result.find(x => x.product === product);
        if (obj) {

            if (price < obj.price) {
                obj.price = price;
                obj.town = town;
            }
        }
        else {
            obj = { product, price, town };
            result.push(obj);
        }
    }

    for (let item of result) {
        console.log(`${item.product} -> ${item.price} (${item.town})`);
    }
}


LowestPriceInCities(['Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10']);