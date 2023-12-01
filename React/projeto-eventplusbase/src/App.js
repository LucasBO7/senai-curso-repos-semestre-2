import "./App.css";

import Rotas from "./Routes/routes";
import { UserContext } from "./context/AuthContext";
import { useEffect, useState } from "react";

function App() {
  const [userData, setUserData] = useState({});

  useEffect(() => {
    const token = localStorage.getItem("token");
    // Se o token tiver valor, o token será convertido para JSON
    setUserData(token === null ? {} : JSON.stringify(token));

    // Se o token tiver valor, o token será convertido para objeto
    if (token !== null) setUserData(JSON.parse(token));
  }, []);

  return (
    <UserContext.Provider value={{ userData, setUserData }}>
      <Rotas />
    </UserContext.Provider>
  );
}

export default App;
