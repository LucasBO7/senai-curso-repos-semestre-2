const listaPessoas = []; // lista vazia

function calcular(event) {
    event.preventDefault(); // interrompe/captura o evento disparado no submit do form

    // Inserção de dados aos parâmetros
    let nome = document.getElementById("nome").value.trim();
    let altura = document.getElementById("altura").value;
    let peso = document.getElementById("peso").value;

    // Não permite a inserção de inputs vazios ou NOT A NUMBER
    if (nome == "" || isNaN(altura) || isNaN(peso)) {
        alert("É necessário preencher todos os campos.");
        return;
    }

    // recebe o valor do imc
    const imc = calcularImc(altura, peso).toFixed(2);
    // pega a situação
    const situacaoGerada = gerarSituacao(imc);

    // Inicialização da variável - com object short sintaxe exceto a última propriedade
    const pessoa = {
        nome,
        altura,
        peso,
        imc,
        situacao: situacaoGerada
    };
    console.log(pessoa);

    // Adiciona na lista de pessoas
    listaPessoas.push(pessoa);

    // Inserção dos dados na tabela
    /*
    document.getElementById("cadastro").innerHTML +=
        `<tr>
            <td> <p>${pessoa.nome}</p> </td>
            <td> <p>${pessoa.altura}</p> </td>
            <td> <p>${pessoa.peso}</p> </td>
            <td> <p>${pessoa.imc}</p> </td>
            <td> <p>${pessoa.situacao}</p> </td>
        </tr>
    `;
    */

    exibirPessoas();
}

// Realiza a função do imc
function calcularImc(alturaPessoa, pesoPessoa) {
    return pesoPessoa / Math.pow(alturaPessoa, 2);
}

// Insere uma situação com base no imc
function gerarSituacao(imc) {
    if (imc < 18.5) {
        return "Magreza";
    } else if (imc < 25) {
        return "Normal";
    } else if (imc < 30) {
        return "Sobrepeso";
    } else if (imc < 35) {
        return "Obesidade grau I";
    } else if (imc < 40) {
        return "Obesidade grau II";
    } else {
        return "Obesidade grau III";
    }
}

function exibirPessoas() {
    console.log(listaPessoas);

    // inserir as linhas de tabela no html
    let linhas = "";// template nome mais correto. linhas é didático

    listaPessoas.forEach(function (objPessoa) {
        linhas += `
        <tr>
            <td> <p>${objPessoa.nome}</p> </td>
            <td> <p>${objPessoa.altura}</p> </td>
            <td> <p>${objPessoa.peso}</p> </td>
            <td> <p>${objPessoa.imc}</p> </td>
            <td> <p>${objPessoa.situacao}</p> </td>
        </tr>
    `
    });

    document.getElementById("cadastro").innerHTML = linhas;
}


/*
// escopo => abrangência

// variável global (pode inclusive ser usada em outro script. E isto antigamente dava problemas pois todas as variáveis eram globais, e isto resultava em diversos problemas ao unir scripts. Então NÃO USE VAR)
let x = 10;
let xpto = "Eduardo"; 

if (x >= 10) {
    console.log(xpto);
}

console.log(x);
console.log(xpto);*/