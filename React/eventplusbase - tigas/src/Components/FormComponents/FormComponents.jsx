import React from "react";
import "./FormComponents.css";

export const Input = ({
  type,
  id,
  value,
  required,
  additionalClass,
  name,
  placeholder,
  manipulationFunction,
}) => {
  return (
    <input
      type={type}
      id={id}
      name={name}
      value={value}
      required={required}
      className={`input-component ${additionalClass}`}
      placeholder={placeholder}
      onChange={manipulationFunction}
      autoComplete="off"
    />
  );
};

export const Button = ({
  textButton,
  id,
  name,
  type,
  additionalClass = "",
  manipulationFunction,
}) => {
  return (
    <button
      type={type}
      name={name}
      id={id}
      className={`button-component ${additionalClass}`}
      textButton={textButton}
      onClick={manipulationFunction}
    >
      {textButton}
    </button>
  );
};

export const Select = ({
  id,
  name,
  required,
  tipoEventosDados = [],
  additionalClass = "",
  manipulationFunction,
  defaultValue,
}) => {
  return (
    <select
      id={id}
      name={name}
      required={required}
      className={`input-component ${additionalClass}`}
      onChange={manipulationFunction}
      value={defaultValue}
      // name="tipo-evento-select"
      // className="input-component"
    >
      <option value="">Selecione</option>
      {tipoEventosDados.map((tp) => {
        return <option value={tp.idTipoEvento}>{`${tp.titulo}`}</option>;
      })}
    </select>
  );
};
