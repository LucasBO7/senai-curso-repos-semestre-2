function cadastrar() {
    const pessoa = new {
        nome: document.getElementById("nome").value,
        sobrenome: document.getElementById("sobrenome").value,
        email: document.getElementById("email").value
    }

    const numeroInserido = new {
        pais: document.getElementById("pais").value,
        ddd: document.getElementById("ddd").value,
        telefone: document.getElementById("telefone").value
    }

    const enderecoInserido = new {
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
}