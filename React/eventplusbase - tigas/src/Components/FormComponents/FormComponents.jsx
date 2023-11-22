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

export const Select = ({ tipoEventos }) => {
  return (
    <select className="input-component" name="tipo-evento-select">
      {tipoEventos.map((tp) => {
        return <option value={tipoEventos}>{`${tp.titulo}`}</option>;
      })}
    </select>
  );
};
