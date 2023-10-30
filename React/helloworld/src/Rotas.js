import React from "react";
// import dos componentes da rota
import { BrowserRouter, Routes, Route } from "react-router-dom";
import HomePage from "./Pages/HomePage/HomePage";
import LoginPage from "./Pages/LoginPage/LoginPage";
import ProdutoPage from "./Pages/ProdutoPage/ProdutoPage";

const Rotas = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<HomePage />} path="/" exact />
        <Route element={<LoginPage />} path="/login" />
        <Route element={<ProdutoPage />} path="/produtos" />
      </Routes>
    </BrowserRouter>
  );
};

export default Rotas;
