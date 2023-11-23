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

  const [eventoInserido, setEventoInserido] = useState([]);
  const [eventos, setEventos] = useState([]);
  const [tipoEventos, setTipoEventos] = useState([]);
  // const [eventoSelecionado, seteventoSelecionado] = useState([]);

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

  async function getAllEventos() {
    const retornoGet = await api.get("/Evento");
    setEventos(retornoGet.data);
  }

  // Cadastra um Evento no banco
  function handleSubmit(e) {
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
      const promise = api.post("/Evento", {
        dataEvento: eventoInserido.dataEvento,
        nomeEvento: eventoInserido.nomeEvento,
        descricao: eventoInserido.descricao,
        // PAREI AQUI, OH FÉ
      });
      console.log(eventoInserido);
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

  function handleUpdate() {
    return;
  }

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
            <form className="ftipo-evento" onSubmit={handleSubmit}>
              <>
                <Input
                  type={"text"}
                  id={"nome"}
                  name={"nome"}
                  placeholder={"Nome"}
                  value={eventoInserido.nomeEvento}
                  manipulationFunction={(e) => {
                    // setValue(prevState => ({ ...prevState, value1: 'novo valor' }));
                    setEventoInserido((prevState) => ({
                      ...prevState,
                      nomeEvento: e.target.value,
                    }));
                    // setEventoInserido.nomeEvento(e.target.value);
                  }} // PENDENTE
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
                    // setEventoInserido.descricao(e.target.value);
                  }} // PENDENTE
                />

                <Select
                  required
                  tipoEventosDados={tipoEventos}
                  manipulationFunction={(e) => {
                    setEventoInserido((prevState) => ({
                      ...prevState,
                      tipoEventos: e.target.value,
                    }));
                    // setEventoInserido.descricao(e.target.value);
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
                  }} // PENDENTE
                  //   placeholder={"dd/mm/aaaa"}
                />

                <Button
                  type={"submit"}
                  id={"Cadastrar"}
                  name={"Cadastrar"}
                  textButton={"Cadastrar"}
                />
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
            fnUpdate={handleUpdate}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default Eventos;
