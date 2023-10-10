function calcular() {
    event.preventDefault(); // interrope o submit do form. Podemos utilizá-lo principalmente para teste. Pois quando a requisição do form for postada, o sistema impedirá que o submit seja feito. Podemos então passar a action para o próprio sistema, e veremos a requisição aparecer
    let number1 = parseFloat(document.getElementById("numero1").value);
    let number2 = parseFloat(document.getElementById("numero2").value);
    let result;
    let operator = document.getElementById("operacao").value;

    if (isNaN(number1) || isNaN(number2)) {
        alert("Preencha todos os campos");
        return;
    }

    switch (operator) {
        case '+':
            result = sum(number1, number2);
            break;
        case '-':
            result = subtract(number1, number2);
            break;
        case '/':
            result = divide(number1, number2);
            break;
        case '*':
            result = multiply(number1, number2);
            break;
        default:
            result = "Operação inválida! escolha uma das operações válidas para execução da conta!";
            break;
    }
    document.getElementById("obj-resultado").innerText = result;
}

function sum(x, y) {
    return (x + y).toFixed(2);
}
function subtract(x, y) {
    return (x - y).toFixed(2);
}
function divide(x, y) {
    if (y == 0) {
        alert("OPERAÇÃO INVÁLIDA! Não é possível realizar uma divisão por zero.");
        return "Não é possível realizar uma divisão por 0.";
    }
    return (x / y).toFixed(2);
}
function multiply(x, y) {
    return (x * y).toFixed(2);
}