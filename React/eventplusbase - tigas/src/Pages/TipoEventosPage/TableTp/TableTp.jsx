import React from "react";
import "./TableTp.css";

import editPen from "../../../assets/images/edit-pen.svg";
import trashDelete from "../../../assets/images/trash-delete.svg";

const TableTp = ({ dados, fnUpdate, fnDelete }) => {
  return (
    <table className="table-data">
      <thead className="table-data__head">
        <tr className="table-data__head-row">
          <th className="table-data__head-title table-data__head-title--big">
            Título
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Editar
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Deletar
          </th>
        </tr>
      </thead>

      <tbody>
        {dados.map((tipoEvento) => {
          return (
            <tr className="table-data__head-row">
              <td className="table-data__data table-data__data--big">
                {tipoEvento.titulo}
              </td>

              {/* Edição */}
              <td className="table-data__data table-data__data--little">
                <img
                  className="table-data__icon"
                  src={editPen}
                  alt="Ícone de lápis, indicando edição dos dados"
                  onClick={() => {
                    fnUpdate(tipoEvento);
                  }}
                />
              </td>

              {/* Deleção */}
              <td className="table-data__data table-data__data--little">
                <img
                  className="table-data__icon"
                  src={trashDelete}
                  alt="Ícone de lixeira, indicando deleção dos dados"
                  onClick={() => {
                    fnDelete(tipoEvento.idTipoEvento);
                  }}
                />
              </td>
            </tr>
          ); // fim do retorno do métodos
        })}
      </tbody>
    </table>
  );
};

export default TableTp;
