import React, { useState } from "react";

const Input = (props) => {
  const [valor, setValor] = useState();

  return (
    <div>
      <input
        type={props.tipo}
        id={props.id}
        name={props.nome}
        placeholder={props.dicaCampo}
        onChange={(e) => {
          props.fnAltera(e.target.value); // valor atual do componente
        }}
      />
      <span>{props.valor}</span>
    </div>
  );
};

export default Input;
