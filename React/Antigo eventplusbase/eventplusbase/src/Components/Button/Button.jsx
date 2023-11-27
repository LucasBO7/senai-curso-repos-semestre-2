import React from "react";

const Button = (props) => {
  return <button type={props.tipo}>{props.textoBotao}</button>;
};

export default Button;
