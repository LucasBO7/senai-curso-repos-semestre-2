import React from "react"; // "Using" para importar o pacote react
import './Titulo.css';

const Titulo = (props) => {
    return (
        <h1 className="titulo">Olá {props.texto}</h1>
    );
}

// Comando que permite que utilizemos as functions dentro do documento js em outros comandos. Ou seja, quando não há o expert, a function "fica private", com o export, "fica public"
export default Titulo;