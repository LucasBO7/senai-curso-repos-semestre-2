import React from "react";
import editPen from "../../../assets/images/edit-pen.svg";
import deleteTrash from "../../../assets/images/trash-delete.svg";

const TableEv = ({ dados, fnUpdate, fnDelete }) => {
  return (
    <table className="table-data">
      <thead>
        <tr className="table-data__head-row">
          <th className="table-data__head-title table-data__head-title--big">
            Evento
          </th>
          <th className="table-data__head-title table-data__head-title--big">
            Descrição
          </th>
          <th className="table-data__head-title table-data__head-title--big">Tipo Evento</th>
          <th className="table-data__head-title table-data__head-title--big">
            Data
          </th>
          <th className="table-data__head-title table-data__head-title--big">
            Editar
          </th>
          <th className="table-data__head-title table-data__head-title--big">
            Deletar
          </th>
        </tr>
      </thead>

      <tbody>
        {dados.map((evento) => {
          return (
            <tr className="table-data__head-row">
              <td className="table-data__data table-data__data--big">
                {evento.nomeEvento}
              </td>
              <td className="table-data__data table-data__data--big">
                {evento.descricao}
              </td>
              <td className="table-data__data table-data__data--big">{evento.tiposEvento.titulo}</td>
              <td className="table-data__data table-data__data--big">
                {new Date(evento.dataEvento).toLocaleDateString()}
              </td>
              <td className="table-data__data table-data__data--big">
                <img
                  className="table-data__icon"
                  src={editPen}
                  alt="Ícone de lápis, indicando edição dos dados"
                  onClick={() => {
                    fnUpdate(evento);
                  }}
                />
              </td>

              <td className="table-data__data table-data__data--big">
                <img
                  className="table-data__icon"
                  src={deleteTrash}
                  alt="Lata de lixo, indicando deleção dos dados"
                  onClick={() => {
                    fnDelete(evento.IdEvento);
                  }}
                />
              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default TableEv;
