import React, { useContext, useEffect, useState } from "react";
import Header from "../../Components/Header/Header";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import Table from "./TableEvA/Table";
import Container from "../../Components/Container/Container";
import { Select } from "../../Components/FormComponents/FormComponents";
import Modal from "../../Components/Modal/Modal";

import "./EventosAlunoPage.css";
import { UserContext } from "../../context/AuthContext";

import Notification from "../../Components/Notification/Notification";
import Spinner from "../../Components/Spinner/Spinner";
import api from "../../Services/Service";

const EventosAlunoPage = () => {
  // state do menu mobile
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [notifyUser, setNotifyUser] = useState([]);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: 1, text: "Todos os eventos" },
    { value: 2, text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);

  useEffect(() => {
    async function loadEventsType() {
      // Trazer todos os eventos
      try {
        setShowSpinner(true);

        // let promise;

        if (tipoEvento === "1") {
          const promise = await api.get("/Evento");
          const promiseMeusEventos = await api.get(
            `/PresencasEvento/ListarMinhas/${userData.userId}`
          );

          const eventosComPresenca = verificaPresenca(
            promise.data,
            promiseMeusEventos.data
          );
          console.clear();
          console.log("DADOS MARCADOS");
          console.log(eventosComPresenca);
          setEventos(promise.data);
        } else {
          let arrEventos = [];
          const promise = await api.get(
            `/PresencasEvento/ListarMinhas/${userData.userId}`
          );
          promise.data.forEach((element) => {
            arrEventos.push({ ...element.evento, situacao: element.situacao });
          });
          setEventos(arrEventos);
        }

        setShowSpinner(false);
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
      // Trazer os meus eventos
      //é luquinas, nem tudo é uma plantação de morango...
    }

    loadEventsType();
  }, [tipoEvento, userData.userId]);

  const verificaPresenca = (arrayAllEvents, eventsUser) => {
    // Para cada evento (todos)
    for (let x = 0; x < arrayAllEvents.length; x++) {
      // Verifica se o aluno está participando do evento atual (x)
      for (let i = 0; i < eventsUser.length; i++) {
        // Verifica em meus eventos
        if (arrayAllEvents[x].idEvento === eventsUser[i].evento.idEvento) {
          arrayAllEvents[x].situacao = true;
          break;
        }
      }
    }
    return arrayAllEvents;
  };

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }
  //é luquinas, nem tudo é uma plantação de morango...

  async function loadMyComentary(idComentary) {
    return "????";
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };
  //é luquinas, nem tudo é uma plantação de morango...

  function handleConnect() {
    alert("Desenvolver a função conectar evento");
  }
  return (
    <>
      {/* <Header exibeNavbar={exibeNavbar} setExibeNavbar={setExibeNavbar} /> */}

      <MainContent>
        <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
        {showSpinner ? <Spinner /> : null}
        <Container>
          <Title titleText={"Eventos"} className="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            dados={quaisEventos} // aqui o array dos tipos
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultValue={tipoEvento}
            additionalClass="select-tp-evento"
          />
          <Table
            //é luquinas, nem tudo é uma plantação de morango...

            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}
        />
      ) : //é luquinas, nem tudo é uma plantação de morango...

      null}
    </>
  );
};

export default EventosAlunoPage;
