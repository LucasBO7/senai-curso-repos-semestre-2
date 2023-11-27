import React, { useState } from 'react';
import './Header.css';
import Container from "../Container/Container";
import PerfilUsuario from '../PerfilUsuario/PerfilUsuario';
import Nav from '../Nav/Nav';
import menuBar from "../../assets/images/menubar.png";
 
const Header = () => {
    const [exibeNavbar, setExibeNavbar] = useState(false);
    return (
       <header className='headerpage'>
        <Container>
            <div className='header-flex'>
                <img 
                src={menuBar}
                className='headerpage__menubar'
                alt='Imagem menu de barras, Serve
                para exibir ou esconder o menu no
                smarthphone'
                onClick={() => {setExibeNavbar(true)}}
                />

                <Nav exibeNavbar={exibeNavbar}
                setExibeNavbar={setExibeNavbar}
                />
                
                <PerfilUsuario />
            </div>
        </Container>
       </header>
    );
};

export default Header;