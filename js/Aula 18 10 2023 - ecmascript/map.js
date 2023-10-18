// FOREACH

const comentarios = [
    { comentario: "bla bla bla", exibe: true },
    { comentario: "O evento foi uma merda", exibe: false },
    { comentario: "Ótimo evento!", exibe: true },
];

const comentariosOk = comentarios.filter(c => c.exibe)

comentariosOk.forEach(c => console.log(c.comentario));

// ==
// exibir os comentários no console, utilizando o foreach




//      MAP - retorna um novo array modificado --> função de call back,
/*
const numeros = [1, 2, 4, 6, 8, 10, 200];
const dobro = numeros.map((n) => {
    return n * 2;
});

console.log(numeros);
console.log(dobro);*/




//      FILTER - retorna um novo array apenas com elementos que atenderam a uma condição

// const numeros = [1, 2, 4, 6, 8, 10, 200];
// const numerosMaior10 = numeros.filter((e) => {
//     return e >= 10;
// })
// console.log(numerosMaior10);




//      REDUCE


const numeros = [1, 2, 4, 6, 8, 10, 200];

const soma = numeros.reduce((valorInicial, n) => {
    return valorInicial + n;
}, 200);
console.log(soma);