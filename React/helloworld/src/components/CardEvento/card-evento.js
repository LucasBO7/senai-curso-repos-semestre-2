import React from "react"; // "Using" para importar o pacote react
import "./card-evento.css";

const Card = (props) => {
    return (
        <div className="card">
            <h3 className="card__title">{props.tituloEvento}</h3>
            <p className="card__description">{props.descricaoEvento}</p>
            <a
                href=""
                className={
                    props.status ? "card__connect" : "card__connect--disabled"
                }>
                {props.textoLink}
            </a>
        </div >
    );
}

export default Card;