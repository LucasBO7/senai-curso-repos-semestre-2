import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";

import HomePage from './Pages/HomePage/HomePage';
import TipoEventosPage from './Pages/TipoEventosPage/TipoEventosPage';
import EventosPage from './Pages/EventosPage/Eventos';
import LoginPage from './Pages/LoginPage/LoginPage';
import TestePage from './Pages/TestePage/TestePage';
import Footer from './Components/Footer/Footer';


import Header from './Components/Header/Header';

const Rotas = () => {
    return (
            <BrowserRouter>
            <Header />
                <Routes>
                    <Route element={<HomePage />} path="/" exact />
                    <Route element={<TipoEventosPage />} path="/tipo-eventos" />
                    <Route element={<LoginPage />} path="/login" />
                    <Route element={<EventosPage />} path="/eventos" />
                    <Route element={<TestePage />} path="/testes" />
                </Routes>

                <Footer />
            </BrowserRouter>
    );
};

export default Rotas;