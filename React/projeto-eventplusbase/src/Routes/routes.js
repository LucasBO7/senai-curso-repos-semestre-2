import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";

import HomePage from "../Pages/HomePage/HomePage";
import TipoEventosPage from "../Pages/TipoEventosPage/TipoEventosPage";
import EventosPage from "../Pages/EventosPage/Eventos";
import EventosAlunoPage from "../Pages/EventosAlunoPage/EventosAlunoPage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import TestePage from "../Pages/TestePage/TestePage";
import Footer from "../Components/Footer/Footer";

import Header from "../Components/Header/Header";
import { PrivateRoute } from "./PrivateRoute";

const Rotas = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} path="/" exact />
        <Route
          path="/tipo-eventos"
          element={
            <PrivateRoute>
              <TipoEventosPage />
            </PrivateRoute>
          }
        />

        <Route
          path="/eventos"
          element={
            <PrivateRoute>
              <EventosPage />
            </PrivateRoute>
          }
        />

        <Route
          path="/eventos-aluno"
          element={
            <PrivateRoute>
              <EventosAlunoPage />
            </PrivateRoute>
          }
        />

        <Route element={<LoginPage />} path="/login" />
        <Route element={<TestePage />} path="/testes" />
      </Routes>

      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;
