//Написать функцию для подсчёта результата выражения. На вход приходит строка с арифметическим выражением. 
//Внутри выражения записываются вещественные числа (в качестве разделителя целой и дробной части используется точка), 
//разделённые математическими операторами (+ − * /). Между числом и оператором может стоять пробел. В конце строки стоит знак «равно».

let mathOperators = [ "+" , "-" , "*" , "/", "=" ]
let expression = "1.5* 2 -3 + 15 / 7.5 = ";
let foundDigits = expression;
let foundOperators = expression;

for (let i = 0 ; i < mathOperators.length; i++){
    foundDigits = foundDigits.split(mathOperators[i]).join(" ");
}

// удаление пустых
foundDigits = foundDigits.split(" ").filter(item => item != "");

for (let i = 0 ; i < foundDigits.length; i++){
    foundDigits[i] = parseFloat(foundDigits[i]);
}

for(let i = 0 ; i < foundDigits.length; i++){
    foundOperators = foundOperators.split(foundDigits[i]).join(" ");
}

// удаление пустых
foundOperators = foundOperators.split(" ").filter(item => item != "");

let result = foundDigits[0];

for(let i = 0 ; i < foundDigits.length-1; i++) {
    if (foundOperators[i] == "+") 
        result += foundDigits[i+1];
    if (foundOperators[i] == "-") 
        result -= foundDigits[i+1];
    if (foundOperators[i] == "*") 
        result *= foundDigits[i+1];
    if (foundOperators[i] == "/") 
        result /= foundDigits[i+1];
}

result = parseFloat(result).toFixed(2);

console.log(result)