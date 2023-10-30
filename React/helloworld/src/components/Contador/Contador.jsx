import React, { useState } from "react";
import './Contador.css';

const Contador = () => {
    const [contador, setContador] = useState(0); // "setContador" é uma função que altera o valor de "contador"
    let mensagemErro;

    function handleIncrementar() {
        setContador(contador + 1);
    }

    function handleDecrementar() {
        contador > 0 ? setContador(contador - 1) : mensagemErro = "Não é possível decrementar de 0.";
        console.log(mensagemErro);
    }

    return (
        <>
            <p>{contador}</p>
            <button onClick={handleIncrementar}>Incrementar</button>
            <button onClick={handleDecrementar}>Decrementar</button> <span id="error-message">{mensagemErro}</span>
        </>
    ); // expressão
}

export default Contador;