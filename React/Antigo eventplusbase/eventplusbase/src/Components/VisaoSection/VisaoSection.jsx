import React from "react";
import "./Vision";
import Title from "../Title/Title";

const VisaoSection = () => {
  return (
    <section className="vision">
      <div className="vision__box">
        <Title
          titleText={"Visão"}
          color="white"
          additionalClass="vision__title"
        />

        <p>
          Mussum Ipsum, cacilds vidis litro abertis. Leite de capivaris, leite
          de mula manquis sem cabeça. Interessantiss quisso pudia ce receita de
          bolis, mais bolis eu num gostis.
        </p>
      </div>
    </section>
  );
};

export default VisaoSection;
