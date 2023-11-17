import React, { useEffect, useState } from "react";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import MainContent from "../../Components/MainContent/MainContent";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";

import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Container from "../../Components/Container/Container";
import { Button, Input } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Service";
import TableTp from "./TableTp/TableTp";

import Notification from "../../Components/Notification/Notification";

const TipoEventosPage = () => {
  const [notifyUser, setNotifyUser] = useState([]);
  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState("");
  const [tipoEventoSelecionado, setTipoEventoSelecionado] = useState("");
  const [tipoEventos, setTipoEventos] = useState([]);

  useEffect(() => {
    async function getTiposEvento() {
      try {
        const promise = await api.get("/TiposEvento");

        console.log(promise.data);
        setTipoEventos(promise.data);
      } catch (error) {
        alert(`Ocorreu um erro! ${error}`);
      }
    }
    getTiposEvento();
  }, []);

  // Fake JSON / Fake Array de objetos
  // const [tipoEventos, setTipoEventos] = useState([
  //   { idTipoEvento: "123", titulo: "Evento ABC" },
  //   { idTipoEvento: "555", titulo: "Evento xpto" },
  //   { idTipoEvento: "444", titulo: "Evento de JavaScript" },
  // ]);

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
      const retorno = await api.post("/TiposEvento", { titulo });
      console.log("CADASTRADO COM SUCESSO");
      console.log(retorno.data);
      setTitulo(""); // Limpa a variável

      const retornoGet = await api.get("/TiposEvento");
      setTipoEventos(retornoGet.data);
    } catch (error) {
      console.log("Deu ruim na api: ");
      console.log(error);
    }
  }

  //******************************************* EDITAR CADASTRO ****************************************** */
  async function handleUpdate(e) {
    // parar o submit do formulário
    e.preventDefault();
    // validar pelo menos 3 caracteres
    if (titulo.trim().length < 3) {
      alert("O Título deve ter no mínimo 3 caracteres");
      return;
    }
    // chamar a api
    try {
      const retorno = await api.put(
        `/TiposEvento/${tipoEventoSelecionado.idTipoEvento}`,
        { titulo }
      );
      console.log("ATUALIZADO COM SUCESSO!");
      console.log(retorno.data);
      setTitulo(""); // Limpa a variável
    } catch (error) {
      console.log("Deu ruim na api: ");
      console.log(error);
    }

    alert("Bora atualizar");
  }

  async function showUpdateForm(tipoEvento) {
    setFrmEdit(true);
    // Passa o objeto selecionado
    setTipoEventoSelecionado(tipoEvento);

    console.log(tipoEvento);
    try {
      //--------Input Atualizar--------
      // Busca o elemento de Input
      const inputEdit = document.getElementById("titulo");
      // Insere o valor antigo nele
      inputEdit.value = await tipoEvento.titulo;

      //--------Botão Atualizar--------
      // Busca o elemento de Botão de Cadastro
      const cadastrarBotao = document.getElementById("Cadastrar");
      // Altera o texto do botão para Atualizar
      cadastrarBotao.textContent = "Atualizar";
    } catch (error) {
      alert(`Um erro ocorreu! ${error}`);
    }
  }

  function editActionAbort() {
    alert("Cancelar a tela de edição de dados");
  }

  async function handleDelete(idEvento) {
    try {
      const retorno = await api.delete(`/TiposEvento/${idEvento}`);
      alert("Registro apagado com sucesso!");

      const retornoGet = await api.get("/TiposEvento");
      setTipoEventos(retornoGet.data);
    } catch (error) {
      console.log("Erro ao excluir!");
    }
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
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
              {/* {!frmEdit ? (
                // Cadastrar */}
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
              {/* ) : (
                <p>Tela de Edição</p>
              )} */}
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
