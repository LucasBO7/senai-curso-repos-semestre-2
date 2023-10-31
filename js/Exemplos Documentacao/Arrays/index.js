/* -----------------------------------------------------------------------
    O QUE ESTE SCRIPT FAZ?

Basicamente cria um array produtos, que receberá um array "camisasTime", onde dentro deste array há várias camisas.

No código, inserimos um array (camisasTime) dentro de outro array (produtos).
Com isso, quando imprimimos somente a index 0 de produtos, estamos pedindo para que ele imprima o array "camisasTime", que contém diversos elementos, e o sistema mesmo já se encarrega de imprimir todos os elementos deste array.
   ------------------------------------------------------------------------ */


// Array vazio
const produtos = [];

let times = ['São Paulo', 'Avaí', 'Grêmio'];

// Array com propriedades
const camisasTime = [
    {
        time: times[0],
        tamanho: 'G',
        quantidade: 11,
        preco: 150.00
    },
    {
        time: times[1],
        tamanho: 'G',
        quantidade: 8,
        preco: 135.00
    },
    {
        time: times[2],
        tamanho: 'M',
        quantidade: 10,
        preco: 150.00
    }
];


// Inserção de arrays em um outro array vazio
produtos.push(camisasTime);

// Mostrar no console
function mostrarCamisas() {
    console.log(produtos[0]);
    console.log(produtos);
}