//P.01
function area() {
        return Math.abs(this.x * this.y);
}
function vol() {
        return Math.abs(this.x * this.y * this.z);
}

function bigFunc(area, vol, input){
    let points = JSON.parse(input);
    let result = [];

    for(const cordinates of points){
        result.push({
            area: area.call(cordinates),
            volume: vol.call(cordinates)
        });
    }

    return result;
}

/* function fancySolve(area, vol, input) {
    return JSON.parse(input)
    .map(x=> ({
        area: area.call(x),
        volume: vol.call(x)
    }));
}
 */

//P.02
function solution(number) {
    return (a) => a + number;
}


//P.03
function createFormatter(separator, symbol, symbolFirst, formatter) {
    return formatter.bind(this, separator, symbol, symbolFirst);   
}
function currencyFormatter(separator, symbol, symbolFirst, value) {
    let result = Math.trunc(value) + separator;
    result += value.toFixed(2).substr(-2,2);
    if (symbolFirst) return symbol + ' ' + result;
    else return result + ' ' + symbol;
}

//P.04
function filterEmp(input, chriteria) {
    let data = JSON.parse(input);
    let[property, value] = chriteria.split('-');
    return data.filter(x => x[property] == value)
    .map((x, i) => `${i}. ${x.first_name} ${x.last_name} - ${x.email}`)
    .forEach(x => console.log(x));
}

//P.05
function commandProc() {
    let result = '';
    return {
        append: (str) => result += str,
        removeStart: (n) => result = result.substring(n),
        removeEnd: (n) => result = result.substring(0, result.length - n),
        print: () => console.log(result),
    };
}

//P.06
function listProc(input) {
    let processor = (function () {
        let result = [];

        return function processor(data) {
            let [command, value] = data.split(' ');

            let process = {
                add: () => result.push(value),
                remove: () => result = result.filter(w => w !== value),
                print: () => console.log(result.join(',')),
            }
            process[command].call(value);
        }
    })();

    for (let data of input) {
        processor(data);
    }
}


//P.07
function car(input) {
    let data = [];
 
    let action = carsManipulator();
 
    for (const task of input) {
        let [cmd, name, key, value] = task.split(' ');
 
        if (key == 'inherit') {
            cmd += key;
            key = value;
        }
 
        action[cmd](name, key, value);
 
    }
 
    function carsManipulator() {
 
        let result = {
            create: (name) => {
                data[name] = {};
            },
 
            createinherit: (name, nameOfParent) => {
                let newObj = Object.create(data[nameOfParent]);
                data[name] = newObj;
            },
 
            set: (name, key, value) => {
              data[name][key] = value;
            },
 
            print: (name) => {
              let output = [];
              
              for (var prop in data[name]) {
                output.push(`${prop}:${data[name][prop]}`);
              }
                
                let s = output.join(',');
 
                console.log(s);
            }
        }
 
        return result;
    }
}

car(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2'
]);