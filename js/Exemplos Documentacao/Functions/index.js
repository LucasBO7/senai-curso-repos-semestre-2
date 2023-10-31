let nomes = ['Eduardo', 'Wilson', 'Jonas', 'Margareth', 'James'];

//envolve os nomes por um parágrafo
nomes = function (nome) {
    return 'Olá!' + nome;
};

// Pode ser escrito da seguinte forma (ARROW FUNCTIONS):

nomes = (nome) => {
    return 'Olá!' + nome;
};

// ou

nomes = (nome) => {
    'Olá!' + nome
};

// ou

nomes = (nome) => 'Olá!' + nome;

// ou

nomes = nome => 'Olá!' + nome;

// ou

nomes = nome => (`Olá! ${nome}`);


// Função de callback

//    FORMA 1 --> criando uma function local dentro do argumento do método "imprimir"
function testarLocal() {
    imprimir(() => { return 2 + 5 });
}

/*  PARA EXECULTAR ESTA FUNCTION, DESCOMENTAR O CÓDIGO ABAIXO
function imprimir(valor) {
    //  Aqui ele chama o método para que o sistema não imprima a função inserida no argumento da função imprimir na function testarLocal
    console.log(valor());
};
*/


//   FORMA 2 --> chamando a function "imprimir", passando como argumento uma outra function "somarNumero"
function testar() {
    imprimir(somarNumero());
}

/*  PARA EXECULTAR ESTA FUNCTION, DESCOMENTAR O CÓDIGO ABAIXO
function imprimir(valor) {
    console.log(valor);
};

function somarNumero() {
    return 2 + 5;
}*/