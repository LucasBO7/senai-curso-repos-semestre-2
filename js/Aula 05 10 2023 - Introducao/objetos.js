// FORMA 1
let eduardo = {
    nome: "Eduardo",
    idade: 41,
    altura: 1.82
};

// As propriedades no JS são dinâmicas, então ao usarmos uma propriedade como se ela existisse, ela será criada
eduardo.peso = 89;

// FORMA 2
let carlos = new Object();
carlos.nome = "Carlos";
carlos.idade = 36;
carlos.sobrenome = "Roque"

console.log(eduardo);
console.log(carlos);

let pessoas = [];
pessoas.push(eduardo, carlos);
console.log(pessoas);

pessoas.forEach((p) => {
    console.log(p);
});