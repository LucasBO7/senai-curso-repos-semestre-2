import React, { useEffect, useState } from 'react';
import './HomePage.css';
import MainContent from '../../Components/MainContent/MainContent';
import Banner from '../../Components/Banner/Banner';
import ContactSection from '../../Components/ContactSection/ContactSection';
import VisionSection from '../../Components/Visionction/VisionSection';
import NextEvent from '../../Components/NextEvent/NextEvent';
import Title from '../../Components/Title/Title';
import Container from '../../Components/Container/Container';


const HomePage = () => {

    useEffect(() => {
        // chamar a api
    }, []);

    // fake mock - api mocada
    const [nextEvents, setNextEvents] = useState([
        { id: 1, titulo: "Evento X", descricao: "Evento de Sql Server", data: "10/11/2023" },
        { id: 2, titulo: "Evento Y", descricao: "Bora codar JS", data: "11/11/2023" },
        { id: 3, titulo: "Evento Z", descricao: "Evento de Sql Server", data: "12/11/2023" },
        { id: 4, titulo: "Evento C", descricao: "Bora codar JS", data: "13/11/2023" }
    ]);

    return (
        <MainContent>
            <Banner />

            {/* PRÓXIMOS EVENTOS */}
            <section className='proximos-eventos'>
                <Container>
                    <Title titleText={"Próximos evento"} />

                    <div className="events-box">
                        {
                            // execulta em cada elemento do array
                            nextEvents.map((e) => {
                                return (
                                    <NextEvent title={e.titulo} description={e.descricao} eventDate={e.data} idEvento={e.id} />
                                );
                            })
                        }
                    </div>
                </Container>
            </section>

            <VisionSection />
            <ContactSection />
        </MainContent>
    );
};

export default HomePage;