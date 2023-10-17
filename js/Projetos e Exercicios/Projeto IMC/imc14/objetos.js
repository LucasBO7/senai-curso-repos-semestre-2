// Objetos no JS são estruturas dinâmicas: podemos já ter as propriedades ou não
let eduardo = { // objeto literal --> usado por boas práticas
    nome: "Eduardo",
    idade: 41,
    altura: 1.67
};

let carlos = new Object();
carlos.nome = "Carlos";
carlos.idade = 36;

console.log(eduardo);
console.log(carlos);

// ------------------------------
const sacola = new Object();
sacola.itens = []; // lista/array

sacola.guardarItem = function (item) {
    this.itens.push(item);
}

sacola.guardarItem("banana");
console.log(sacola.itens);

