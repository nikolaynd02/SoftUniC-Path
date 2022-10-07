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

//P.06
function StoreCatalogue(input){
    let result = {};

    for(const obj of input.sort((a, b) => a.localeCompare(b))){
        let [product, price] = obj.split(` : `);
        price = Number(price);

        let firstLetter = product[0];
        let object = {product, price};

        if(!result[firstLetter]){
            result[firstLetter] = [];
        }
        result[firstLetter].push(object);
    }

    for(const item of Object.keys(result)){
        console.log(item);
        for(const pr of result[item]){
            console.log(`  ${pr.product}: ${pr.price}`);
        }
    }
}

//P.07
function TownsToJSON(arr) {
    let result = [];
    const properties = arr[0].split(/\s*\|\s*/mg).filter(e => e.trim());

    for (let i = 1; i < arr.length; i++) {
        let data = arr[i].split(/\s*\|\s*/mg).filter(e => e.trim());

        let name = data[0];
        let latitude = Number(data[1]).toFixed(2);
        let longtitude = Number(data[2]).toFixed(2);

        let town = {};
        town[properties[0]] = name;
        town[properties[1]] = Number(latitude);
        town[properties[2]] = Number(longtitude);

        result.push(town);
    }

    let jsonString = JSON.stringify(result);
    return jsonString;
}

//P.08 Rectangle
function rectangle(width, height, color) {
    let rectangle = {
        width: width,
        height: height,
        color: color[0].toUpperCase() + color.slice(1),
        calcArea() { return this.width * this.height }
    }

    return rectangle;
}