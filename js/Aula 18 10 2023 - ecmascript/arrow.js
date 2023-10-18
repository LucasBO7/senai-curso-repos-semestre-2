const somar = (x, y) => { // Uma função sem nome chama-se função anônima
    return x + y;
}

// const dobro = (numero) => {
//    return numero * 2;
// }

// const dobro = numero => {
//    return numero * 2;
// }

//const dobro = numero => numero * 2;
//console.log(dobro(9));

//const boaTarde = () => { console.log("Boa tarde"); }
//boaTarde();

console.log(somar(50, 10));

const convidados = [
    { nome: "Carlos", idade: 36 },
    { nome: "Claiton", idade: 43 },
    { nome: "Rebeca", idade: 16 },
    { nome: "Magalhães", idade: 18 },
    { nome: "Lucca", idade: 18 },
    { nome: "Guilherme Bastos", idade: 18 },
    { nome: "Baptista", idade: 16 },
];

convidados.forEach(convidados => {
    console.log(`convidado: ${convidados}`);
});