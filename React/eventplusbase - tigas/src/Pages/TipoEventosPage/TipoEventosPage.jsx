import React, { useState } from "react";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";

import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Container from "../../Components/Container/Container";
import { Button, Input } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Service";
import TableTp from "./TableTp/TableTp";

const TipoEventosPage = () => {
  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState("");

  // Fake JSON / Fake Array de objetos
  const [tipoEventos, setTipoEventos] = useState([
    { idTipoEvento: "123", titulo: "Evento ABC" },
    { idTipoEvento: "555", titulo: "Evento xpto" },
    { idTipoEvento: "444", titulo: "Evento de JavaScript" },
  ]); // Array mocado

  async function handleSubmit(e) {
    // parar o submit do formulário
    e.preventDefault();
    // validar pelo menos 3 caracteres
    if (titulo.trim().length < 3) {
      alert("O Título deve ter no mínimo 3 caracteres");
      return;
    }
    // chamar a api
    try {
      const retorno = await api.post("/TiposEvento", { titulo: titulo });
      console.log("CADASTRADO COM SUCESSO");
      console.log(retorno.data);
      setTitulo(""); // Limpa a variável
    } catch (error) {
      console.log("Deu ruim na api: ");
      console.log(error);
    }
  }

  //******************************************* EDITAR CADASTRO ****************************************** */
  function handleUpdate() {
    alert("Bora atualizar");
  }

  function showUpdateForm() {
    alert("Mostrando a tela de update");
  }

  function editActionAbort() {
    alert("Cancelar a tela de edição de dados");
  }

  function handleDelete() {
    alert("Bora lá apagar na api");
  }

  return (
    <MainContent>
      {/* Cadastro de tipo de eventos */}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página Tipos de Eventos"} />
            <ImageIllustrator
              alterText={"?????"}
              imageRender={eventTypeImage}
            />

            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              {!frmEdit ? (
                <>
                  <Input
                    type={"text"}
                    id={"titulo"}
                    name={"titulo"}
                    placeholder={"Título"}
                    required={"required"}
                    value={titulo}
                    manipulationFunction={(e) => {
                      setTitulo(e.target.value);
                    }}
                  />
                  <span>{titulo}</span>
                  <Button
                    type={"submit"}
                    id={"Cadastrar"}
                    name={"Cadastrar"}
                    textButton={"Cadastrar"}
                  />
                </>
              ) : (
                <p>Tela de Edição</p>
              )}
            </form>
          </div>
        </Container>
      </section>

      {/* LISTAGEM DE TIPO DE EVENTOS */}
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista Tipo de Eventos"} color="white" />

          <TableTp
            dados={tipoEventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;
