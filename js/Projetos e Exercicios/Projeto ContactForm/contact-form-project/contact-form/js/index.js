const urlLocal = "http://localhost:3000/contatos";

// Insere um novo contato
async function Cadastrar(event) {
    event.preventDefault();

    // Recepção e inserção de valores em objetos
    const pessoa = {
        nome: document.getElementById("nome").value,
        sobrenome: document.getElementById("sobrenome").value,
        email: document.getElementById("email").value
    }

    const numeroInserido = {
        pais: document.getElementById("pais").value,
        ddd: document.getElementById("ddd").value,
        telefone: document.getElementById("telefone").value
    }

    const enderecoInserido = {
        cep: document.getElementById("cep").value,
        rua: document.getElementById("rua").value,
        numero: document.getElementById("numero").value,
        complemento: document.getElementById("complemento").value,
        bairro: document.getElementById("bairro").value,
        cidade: document.getElementById("cidade").value,
        UF: document.getElementById("UF").value
    };

    const anotacoes = document.getElementById("anotacoes").value;

    pessoa.telefone = numeroInserido;
    pessoa.endereco = enderecoInserido;
    pessoa.anotacoes = anotacoes;

    try {
        const promise = await fetch(urlLocal, {
            // transforma um objeto em json
            body: JSON.stringify(pessoa),
            headers: { "Content-Type": "application/json" },
            method: "post"
        });

        const retorno = promise.json(); // pega o retorno da api
        console.log(retorno);

        // Retorno de inserção com sucesso
        alert("Contato adicionado com sucesso!");
        document.getElementById('form').reset(); // Limpa os dados do formulário
    } catch (error) {
        alert(`Um erro ocorreu: ${error}`)
    }
}

// Insere os valores do endereço passados do método "buscarCepApi" nos inputs das respectivas propriedades
function inserirEnderecoBuscado(enderecoBuscado) {
    document.getElementById("rua").value = enderecoBuscado.logradouro;
    document.getElementById("bairro").value = enderecoBuscado.bairro;
    document.getElementById("cidade").value = enderecoBuscado.localidade;
    document.getElementById("UF").value = enderecoBuscado.uf;
}

// Apaga o cep inserido (usado na function "buscarCepApi")
function apagarCep() {
    document.getElementById("cep").value = "";
}

// Utiliza a api "Viacep" para encontrar o restante das informações do endereço por meio do cep inserido pelo usuário
async function buscarCepApi() {
    const cepObj = document.getElementById("cep"); // Usaremos no if do "endereco.includes" para alteração do style do elemento ao dar erro
    const cep = cepObj.value;

    // Se o CEP tiver algum valor
    if (cep) {
        try {
            const url = `https://viacep.com.br/ws/${cep}/json/`;
            const promise = await fetch(url);
            const endereco = await promise.json(); // Extrai o JSON

            // Verifica se o endereço é válido, pois dependendo do cep, pode ser que o sistema retorne um objeto com a propriedade "erro: true", passando os valores aos outros inputs como "undefined",como no ex do cep: 00000002
            if (endereco.erro) {
                alert("CEP inserido inválido!");
                apagarCep();
            } else {
                inserirEnderecoBuscado(endereco);
            }

        } catch (erro) {
            // Se a api for recusada
            console.log(`Houve um problema! ${erro}`);
            alert("CEP inserido inválido!");
            apagarCep();
        }
    }
}


// function formatarTelefone() {
//     const telefone = document.getElementById("telefone").value;
//     let numeroFormatado = telefone.substr(0, 5) + "-" + telefone.substr(5);

//     console.log(numeroFormatado);
//     document.getElementById("telefone").value = numeroFormatado;
// }'