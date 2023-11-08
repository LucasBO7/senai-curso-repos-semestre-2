import React, { useState } from 'react';
import Title from '../../Components/Title/Title';

import Input from "../../Components/Input/Input";
import Button from '../../Components/Button/Button';

const TestePage = () => {

    const [total, setTotal] = useState();
    const [n1, setN1] = useState();
    const [n2, setN2] = useState();

    function handleCalcular(e) {
        e.preventDefault();
        setTotal(parseFloat(n1) + parseFloat(n2));
    }


    return (
        <>

<Title titleText={"Página de Teste"} />
        <h2>Calculator</h2>
        
        <form onSubmit={handleCalcular}>
            <Input 
            tipo="number"
            id="numero1"
            name="numero1"
            dicaCampo="Primeiro numero"
            valor={n1}
            fnAltera={setN1}
            />
            <Input 
            tipo="number"
            id="numero2"
            name="numero2"
            dicaCampo="Segundo numero"
            valor={n2}
            fnAltera={setN2}
            />

            <Button tipo="submit" textoBotao="Somar"/>

            <span>
             <p>Resultado: <strong>{total}</strong></p>  
            </span>
        </form>
        </>
    );
};

export default TestePage;