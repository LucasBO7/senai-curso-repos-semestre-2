//#region Imports
import React, { useEffect, useState } from "react";
// Import da imagem
import eventImageIlustration from "../../assets/images/evento.svg";
// Import do CSS da página
import "./Eventos.css";

import MainContent from "../../Components/MainContent/MainContent";
import Container from "../../Components/Container/Container";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import Title from "../../Components/Title/Title";
import {
  Button,
  Input,
  Select,
} from "../../Components/FormComponents/FormComponents";
import TableEv from "./TableEv/TableEv";

import Notification from "../../Components/Notification/Notification";
import Spinner from "../../Components/Spinner/Spinner";
import api from "../../Services/Service";
//#endregion

const Eventos = () => {
  const [showSpinner, setShowSpinner] = useState(false);
  const [notifyUser, setNotifyUser] = useState([]);

  const [idInstituicao, setIdInstituicao] = useState();
  const [eventoInserido, setEventoInserido] = useState({ idInstituicao: "" });
  const [eventos, setEventos] = useState([]);
  const [tipoEventos, setTipoEventos] = useState([]);

  const [isFrmEdit, setIsFrmEdit] = useState(false);

  useEffect(() => {
    // Busca todos os eventos e guarda-os em um array (eventos)
    async function getEventos() {
      setShowSpinner(true); // Mostra animação de carregamento
      try {
        const promise = await api.get("/Evento");

        setEventos(promise.data);
      } catch (error) {
        alert("DEU RUIM!"); //alertPalterar
      }

      getInstituicaoAndInsertInEvento();
      setShowSpinner(false); // Oculta animação de carregamento
    }

    // Busca os tipo eventos e guarda-os em um array (tipoEventos)
    async function getTipoEventos() {
      try {
        const promise = await api.get("/TiposEvento");

        setTipoEventos(promise.data);
      } catch (error) {
        alert("Houve um erro na api!");
      }
    }
    getEventos();
    getTipoEventos();
  }, []);

  // Busca todos os eventos e guarda-os em um array (eventos)
  async function getAllEventos() {
    const retornoGet = await api.get("/Evento");
    setEventos(retornoGet.data);
  }

  // Busca a Instituição salva no banco e a insere em uma variável (idInstituicao)
  async function getInstituicaoAndInsertInEvento() {
    try {
      // Pega a instituição
      const promise = await api.get("/Instituicao");

      // Pega o id da Instituição
      const instituicaoBuscada = promise.data;
      const idInstituicao = instituicaoBuscada[0].idInstituicao;

      // Insere a instituição no Evento
      setIdInstituicao(idInstituicao);
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

  // Cadastra um Evento no banco
  async function handleSubmit(e) {
    // Para o submit do form
    e.preventDefault();

    // Impede o cadastro de eventos com menos de 3 caracteres de título
    if (eventoInserido.nomeEvento.trim().length < 3) {
      setNotifyUser({
        titleNote: "Aviso",
        textNote: `O Título deve ter no mínimo 3 caracteres`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de suc  esso. Moça segurando um balão com símbolo de sucesso",
        showMessage: true,
      });
      return;
    }

    try {
      // Dá o post na api
      const promise = await api.post("/Evento", {
        nomeEvento: eventoInserido.nomeEvento,
        dataEvento: eventoInserido.dataEvento,
        descricao: eventoInserido.descricao,
        idTipoEvento: eventoInserido.idTipoEvento,
        idInstituicao: idInstituicao,
      });

      getAllEventos();

      setNotifyUser({
        titleNote: "Concluído",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de sucesso",
        showMessage: true,
      });
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

  // Atualiza um Evento no banco
  function handleUpdate(e) {
    // parar o submit do formulário
    e.preventDefault();

    // Impede o cadastro de eventos com menos de 3 caracteres de título
    if (eventoInserido.nomeEvento.trim().length < 3) {
      setNotifyUser({
        titleNote: "Aviso",
        textNote: `O Título deve ter no mínimo 3 caracteres`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de suc  esso. Moça segurando um balão com símbolo de sucesso",
        showMessage: true,
      });
      return;
    }

    try {
      // Realiza o put passando os dados pelo corpo da requisição
      const promise = api.put(`/Evento/${eventoInserido.idEvento}`, {
        nomeEvento: eventoInserido.nomeEvento,
        dataEvento: eventoInserido.dataEvento,
        descricao: eventoInserido.descricao,
        idTipoEvento: eventoInserido.idTipoEvento,
        idInstituicao: idInstituicao,
      });

      getAllEventos();
      setEventoInserido("");
    } catch (error) {
      // Mensagem de erro
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Ocorreu um erro na api!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de sucesso",
        showMessage: true,
      });
    }
    return;
  }

  // Mostra o Form de edição
  function showUpdateForm(evento) {
    setIsFrmEdit(true);

    // Converte para o formato necessário: dd-MM-yyyy
    let formatedDate = new Date(evento.dataEvento).toISOString().split("T")[0];

    // Insere os dados no formulário
    document.getElementById("nome").value = evento.nomeEvento;
    document.getElementById("descricao").value = evento.descricao;
    document.getElementById("idTipoEvento").value = evento.idTipoEvento;
    document.getElementById("data").value = formatedDate;
  }

  // Cancela a edição, voltando para a área de cadastro do form
  function abortUpdateAction() {
    document.getElementById("nome").value = "";
    document.getElementById("descricao").value = "";
    document.getElementById("idTipoEvento").value = "";
    document.getElementById("data").value = "";
    setIsFrmEdit(false);
  }

  // Deleta um Evento do banco por id
  async function handleDelete(id) {
    setShowSpinner(true); // Mostra animação de carregamento
    try {
      const promise = await api.delete(`/Evento/${id}`);

      setNotifyUser({
        titleNote: "Concluído",
        textNote: `Removido com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de sucesso",
        showMessage: true,
      });

      getAllEventos();
    } catch (error) {
      alert("Deu erro!!");
    }
    setShowSpinner(false); // Oculta animação de carregamento
  }

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner /> : null}

      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página de Evento"} />

            <ImageIllustrator
              alterText={"????"}
              imageRender={eventImageIlustration}
            />

            {/* Formulário */}
            <form
              className="ftipo-evento"
              onSubmit={isFrmEdit ? handleUpdate : handleSubmit}
            >
              <>
                <Input
                  type={"text"}
                  id={"nome"}
                  name={"nome"}
                  placeholder={"Nome"}
                  value={eventoInserido.nomeEvento}
                  manipulationFunction={(e) => {
                    setEventoInserido((prevState) => ({
                      ...prevState,
                      nomeEvento: e.target.value,
                    }));
                  }}
                />
                <Input
                  type={"text"}
                  id={"descricao"}
                  name={"descricao"}
                  placeholder={"Descrição"}
                  value={eventoInserido.descricao}
                  manipulationFunction={(e) => {
                    setEventoInserido((prevState) => ({
                      ...prevState,
                      descricao: e.target.value,
                    }));
                  }}
                />

                <Select
                  id={"idTipoEvento"}
                  required
                  tipoEventosDados={tipoEventos}
                  manipulationFunction={(e) => {
                    setEventoInserido((prevState) => ({
                      ...prevState,
                      idTipoEvento: e.target.value,
                    }));
                  }}
                />

                <Input
                  type={"date"}
                  id={"data"}
                  name={"data"}
                  value={eventoInserido.dataEvento}
                  manipulationFunction={(e) => {
                    setEventoInserido((prevState) => ({
                      ...prevState,
                      dataEvento: e.target.value,
                    }));
                  }}
                />

                {isFrmEdit ? (
                  <div className="buttons-editbox">
                    <Button
                      type={"submit"}
                      id={"Atualizar"}
                      name={"Atualizar"}
                      textButton={"Alterar"}
                    />

                    <Button
                      type={"button"}
                      id={"cancelar"}
                      name={"cancelar"}
                      textButton={"Cancelar"}
                      manipulationFunction={abortUpdateAction}
                    />
                  </div>
                ) : (
                  <Button
                    type={"submit"}
                    id={"Cadastrar"}
                    name={"Cadastrar"}
                    textButton={"Cadastrar"}
                  />
                )}
              </>
            </form>
          </div>
        </Container>
      </section>

      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de eventos"} color="white" />

          <TableEv
            dados={eventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default Eventos;
