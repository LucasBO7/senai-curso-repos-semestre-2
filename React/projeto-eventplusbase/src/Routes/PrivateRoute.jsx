import { Navigate, redirect } from "react-router-dom"; // Importa o Navigate e o redirect

export const PrivateRoute = ({ children, redirectTo = "/" }) => {
  // Verifica se está autenticado
  const isAuthenticated = localStorage.getItem("token") !== null;

  // Se estiver autenticado, retorna children, se não, retorna o Navigate, que leva o usuário para outra página
  return isAuthenticated ? children : <Navigate to={redirectTo} />;
};
