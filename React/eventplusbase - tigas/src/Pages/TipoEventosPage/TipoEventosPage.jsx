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
import Spinner from "../../Components/Spinner/Spinner";

const TipoEventosPage = () => {
  const [notifyUser, setNotifyUser] = useState([]);
  const [showSpinner, setShowSpinner] = useState(false);

  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState("");
  const [tipoEventoSelecionado, setTipoEventoSelecionado] = useState("");
  const [tipoEventos, setTipoEventos] = useState([]);

  useEffect(() => {
    async function getTiposEvento() {
      setShowSpinner(true);
      try {
        const promise = await api.get("/TiposEvento");

        console.log(promise.data);
        setTipoEventos(promise.data);
      } catch (error) {
        setNotifyUser({
          titleNote: "Erro",
          textNote: `Ocorreu um erro na api!`,
          imgIcon: "danger",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de sucesso",
          showMessage: true,
        });
      }
      setShowSpinner(false);
    }
    getTiposEvento();
  }, []);

  // Fake JSON / Fake Array de objetos
  // const [tipoEventos, setTipoEventos] = useState([
  //   { idTipoEvento: "123", titulo: "Evento ABC" },
  //   { idTipoEvento: "555", titulo: "Evento xpto" },
  //   { idTipoEvento: "444", titulo: "Evento de JavaScript" },
  // ]);

  // Cadastra um novo Tipo de evento
  async function handleSubmit(e) {
    // parar o submit do formulário
    e.preventDefault();
    // validar pelo menos 3 caracteres
    if (titulo.trim().length < 3) {
      setNotifyUser({
        titleNote: "Aviso",
        textNote: `O Título deve ter no mínimo 3 caracteres`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de sucesso",
        showMessage: true,
      });
      return;
    }
    // chamar a api
    try {
      const retorno = await api.post("/TiposEvento", { titulo });
      console.log("CADASTRADO COM SUCESSO");

      setNotifyUser({
        titleNote: "Concluído",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de sucesso",
        showMessage: true,
      });

      console.log(retorno.data);
      setTitulo(""); // Limpa a variável

      getAllTiposEvento();
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
      setNotifyUser({
        titleNote: "Aviso",
        textNote: `O Título deve ter no mínimo 3 caracteres`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de sucesso",
        showMessage: true,
      });
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

      setNotifyUser({
        titleNote: "Concluído",
        textNote: `Alterado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de sucesso",
        showMessage: true,
      });

      getAllTiposEvento();
    } catch (error) {
      console.log("Deu ruim na api: ");
      console.log(error);
    }

    alert("Bora atualizar");
  }

  // Altera o Form para edição
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
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Ocorreu um erro na api!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de sucesso",
        showMessage: true,
      });
    }
  }

  // Cancela a edição do Tipo de evento
  function editActionAbort() {
    setFrmEdit(false);
    setTitulo("");
    //--------Botão Atualizar--------
    // Busca o elemento de Botão de Cadastro
    const cadastrarBotao = document.getElementById("Cadastrar");
    // Altera o texto do botão para Cadastrar
    cadastrarBotao.textContent = "Cadastrar";
  }

  // Deleta o Tipo de evento
  async function handleDelete(idEvento) {
    try {
      const retorno = await api.delete(`/TiposEvento/${idEvento}`);

      setNotifyUser({
        titleNote: "Concluído",
        textNote: `Removido com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de sucesso",
        showMessage: true,
      });

      getAllTiposEvento();
    } catch (error) {
      console.log("Erro ao excluir!");
    }
  }

  async function getAllTiposEvento() {
    const retornoGet = await api.get("/TiposEvento");
    setTipoEventos(retornoGet.data);
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner /> : null}

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
              {/* Cadastro/Atualização de tipos de evento */}
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
                {/* Botão Cadastrar/Atualizar */}
                <div className="buttons-editbox">
                  <Button
                    type={"submit"}
                    id={"Cadastrar"}
                    name={"Cadastrar"}
                    textButton={"Cadastrar"}
                  />
                  {/* Botão cancelar edição */}
                  {frmEdit ? (
                    <Button
                      type="button"
                      id={"cancelar"}
                      name={"cancelar"}
                      textButton={"Cancelar"}
                      manipulationFunction={editActionAbort}
                    />
                  ) : (
                    <p></p>
                  )}
                </div>
              </>
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
