import './App.css';
import Titulo from './components/Titulo/Titulo';
import Card from './components/CardEvento/card-evento';

function App() {
  return (
    <div className="App">
      <h1>Hello React</h1>
      <Titulo texto="Luuucas" />
      <Titulo texto="Josemias" />
      <Titulo texto="Rafaelis" />
      <Titulo texto="Manerus" />

      <div className="cards">
        <Card
          tituloEvento="Ninguém chamou a Catarina"
          descricaoEvento="Breve descrição do evento, pode ser um paragrafo pequenoBreve descrição do evento, pode ser um paragrafo pequeno.Breve descrição do evento, pode ser um paragrafo pequeno."
          textoLink="Venha"
          status={true} />

        <Card
          tituloEvento="Ninguém chamou o Tirrasgo"
          descricaoEvento="Breve descrição do evento, pode ser um paragrafo pequenoBreve descrição do evento, pode ser um paragrafo pequeno.Breve descrição do evento, pode ser um paragrafo pequeno."
          textoLink="Entra aqui"
          status={true} />

        <Card
          tituloEvento="Enzo, o rei da Tira"
          descricaoEvento="Breve descrição do evento, pode ser um paragrafo pequenoBreve descrição do evento, pode ser um paragrafo pequeno.Breve descrição do evento, pode ser um paragrafo pequeno."
          textoLink="Let's goo"
          status={false} />
      </div>
    </div>
  );
}

export default App;