import React, { useContext, useState } from "react";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import logo from "../../assets/images/logo-pink.svg";
import { Input, Button } from "../../Components/FormComponents/FormComponents";

import "./LoginPage.css";
import loginImage from "../../assets/images/login.svg";
import api from "../../Services/Service";
import { UserContext, userDecodeToken } from "../../context/AuthContext";

const LoginPage = () => {
  const [user, setUser] = useState({ email: "", senha: "" });
  // dados globais do usuário
  const { userData, setUserData } = useContext(UserContext);

  async function handleSubmit(e) {
    e.preventDefault();
    if (user.email.length >= 3 && user.senha.length > 3) {
      // chamar a api
      try {
        const retorno = await api.post("/Login", {
          email: user.email,
          senha: user.senha,
        });
        // console.log(retorno.data);

        const userFullToken = userDecodeToken(retorno.data.token);

        setUserData(userFullToken); // guarda os dados decodificados (payload)
        console.log("Token: " + retorno.data.token);
        // localStorage.setItem("token", JSON.stringify(userFullToken));
        console.log("DADOS DO USUÁRIO");
        console.log(userData);
      } catch (error) {
        alert(
          "Usuário ou senha inválidos ou conexão com a internet foi interrompida!"
        );
      }
    } else {
      alert("Preencha os campos corretamente");
    }
    console.log(user);
  }

  return (
    <div className="layout-grid-login">
      <div className="login">
        <div className="login__illustration">
          <div className="login__illustration-rotate"></div>
          <ImageIllustrator
            imageRender={loginImage}
            imageName="login"
            altText="Imagem de um homem em frente de uma porta de entrada"
            additionalClass="login-illustrator"
          />
        </div>

        <div className="frm-login">
          <img src={logo} className="frm-login__logo" alt="" />

          <form className="frm-login__formbox" onSubmit={handleSubmit}>
            <Input
              additionalClass="frm-login__entry"
              type="email"
              id="login"
              name="login"
              required={true}
              value={user.email}
              manipulationFunction={(e) => {
                setUser({
                  ...user,
                  email: e.target.value.trim(),
                });
              }}
              placeholder="Username"
            />
            <Input
              additionalClass="frm-login__entry"
              type="password"
              id="senha"
              name="senha"
              required={true}
              value={user.senha}
              manipulationFunction={(e) => {
                setUser({
                  ...user,
                  senha: e.target.value.trim(),
                });
              }}
              placeholder="****"
            />

            <a href="" className="frm-login__link">
              Esqueceu a senha?
            </a>

            <Button
              textButton={"Login"}
              id="btn-login"
              name="btn-login"
              type="submit"
              additionalClass="frm-login__button"
              manipulationFunction={() => {}}
            />
          </form>
        </div>
      </div>
    </div>
  );
};

export default LoginPage;
