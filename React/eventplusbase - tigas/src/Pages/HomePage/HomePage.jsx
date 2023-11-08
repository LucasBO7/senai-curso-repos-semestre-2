import React from 'react';
import './HomePage.css';
import MainContent from '../../Components/MainContent/MainContent';
import Banner from '../../Components/Banner/Banner';
import ContactSection from '../../Components/ContactSection/ContactSection';
import VisionSection from '../../Components/Visionction/VisionSection';
import NextEvent from '../../Components/NextEvent/NextEvent';
import Title from '../../Components/Title/Title';
import Container from '../../Components/Container/Container';


const HomePage = () => {
    return (
        <MainContent>
            <Banner />
            <section className='proximos-eventos'>
                <Container>
                    <Title titleText={"Próximos evento"} />

                    <div className="events-box">
                        <NextEvent title={"Evento X"} description={"Evento legal :)"} eventDate={"14/11/2023"} idEvento={"3j4328uh23"} />
                        <NextEvent title={"Evento X"} description={"Evento legal :)"} eventDate={"14/11/2023"} idEvento={"3j4328uh23"} />
                        <NextEvent title={"Evento X"} description={"Evento legal :)"} eventDate={"14/11/2023"} idEvento={"3j4328uh23"} />
                        <NextEvent title={"Evento X"} description={"Evento legal :)"} eventDate={"14/11/2023"} idEvento={"3j4328uh23"} />
                    </div>
                </Container>
            </section>

            <VisionSection />
            <ContactSection />
        </MainContent>
    );
};

export default HomePage;