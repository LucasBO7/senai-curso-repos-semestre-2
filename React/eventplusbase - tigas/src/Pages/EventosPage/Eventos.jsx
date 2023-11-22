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

import api from "../../Services/Service";

const Eventos = () => {
  const [eventos, setEventos] = useState([]);
  // const [eventoSelecionado, seteventoSelecionado] = useState([]);

  // Fake JSON / Fake Array de objetos
  const [tipoEventos, setTipoEventos] = useState([]);

  useEffect(() => {
    // Busca todos os eventos e guarda-os em um array (eventos)
    async function getEventos() {
      try {
        const promise = await api.get("/Evento");

        setEventos(promise.data);
      } catch (error) {
        alert("DEU RUIM!"); //alertPalterar
      }
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

  function handleUpdate() {
    return;
  }

  function handleDelete(idEvento) {
    try {
      async function deleteEvento() {
        try {
          const promise = await api.delete(`/Evento/${idEvento}`);

          setTipoEventos(promise.data);
        } catch (error) {
          alert("Houve um erro na api!");
        }
      }
      deleteEvento();
    } catch (error) {
      alert("Deu erro!!");
    }
    return;
  }

  return (
    <MainContent>
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title titleText={"Página de Evento"} />

            <ImageIllustrator
              alterText={"????"}
              imageRender={eventImageIlustration}
            />

            {/* Formulário */}
            <form className="ftipo-evento">
              <>
                <Input
                  type={"text"}
                  id={"nome"}
                  name={"nome"}
                  placeholder={"Nome"}
                  //   manipulationFunction={"???"} // PENDENTE
                />
                <Input
                  type={"text"}
                  id={"descricao"}
                  name={"descricao"}
                  placeholder={"Descrição"}
                  //   manipulationFunction={"???"} // PENDENTE
                />

                <Select tipoEventos={tipoEventos} />

                <Input
                  type={"date"}
                  id={"data"}
                  name={"data"}
                  //   placeholder={"dd/mm/aaaa"}
                  //   manipulationFunction={"???"} // PENDENTE
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
