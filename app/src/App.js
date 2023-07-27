import "./assets/css/style.css";
import { Header } from "./components/ui/Header";
import { Routes, Route } from "react-router-dom";
import Projects from "./pages/Projects";
import Tasks from "./pages/Tasks";
import Reports from "./pages/Reports";
import Settings from "./pages/Settings";
import Home from "./pages/Home";
import Footer from "./components/ui/Footer";
import { useState } from "react";
import Signin from "./pages/Signin";

function App() {
  const [authenticated, setAuthenticated] = useState(false);
  return (
    <>
      {authenticated && <Header />}
      <Routes>
        {!authenticated && (
          <Route path="/*" element={<Signin setSignIn={setAuthenticated} />} />
        )}
        {authenticated && <Route path="/" element={<Home />} />}
        {authenticated && <Route path="/projects" element={<Projects />} />}
        {authenticated && <Route path="/tasks" element={<Tasks />} />}
        {authenticated && <Route path="/reports" element={<Reports />} />}
        {authenticated && <Route path="/settings" element={<Settings />} />}
      </Routes>
      {authenticated && <Footer />}
    </>
  );
}

export default App;
