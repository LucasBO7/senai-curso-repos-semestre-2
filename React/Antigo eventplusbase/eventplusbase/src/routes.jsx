import React from "react";
// Gerenciador de rotas / Coleção de rotas / Cada Rota
import { BrowserRouter, Routes, Route } from "react-router-dom";

// Import dos componentes da página
import HomePage from "./Pages/HomePage/HomePage";
import TipoEventosPage from "./Pages/TipoEventosPage/TipoEventosPage";
import EventosPage from "./Pages/EventosPage/EventosPage";
import LoginPage from "./Pages/LoginPage/LoginPage";
import TestePage from "./Pages/TestePage/TestePage";

import Header from "./Components/Header/Header";
import Footer from "./Components/Footer/Footer";
const Rotas = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} path="/" exact />
        <Route element={<TipoEventosPage />} path="/tipo-eventos" />
        <Route element={<EventosPage />} path="/eventos" />
        <Route element={<LoginPage />} path="/login" />
        <Route element={<TestePage />} path="/testes" />
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;
