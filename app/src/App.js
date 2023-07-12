import './App.css';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <p>
          Edit <code>src/App.js</code> and save to reload.
        </p>
        <a target="_blank" href={process.env.PUBLIC_URL + "oldpage.html"} rel = "norefferer"> oldpage</a>

      </header>
    </div>
  );
}

export default App;
