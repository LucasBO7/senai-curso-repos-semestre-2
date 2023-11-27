import React from "react";
import Banner from "../../Components/Banner/Banner";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";

const HomePage = () => {
  return (
    <MainContent>
      <Banner />

      <Title titleText={"Página Home"} />
    </MainContent>
  );
};

export default HomePage;
