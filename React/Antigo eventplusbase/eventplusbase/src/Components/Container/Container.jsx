import React from "react";
import "./Container.css";

const Container = ({ children }) => {
  return (
    <div className="container">
      {/* {props.children}     OU */}
      {children}
    </div>
  );
};

export default Container;
