import './assets/css/style.css';
import { Header } from './components/ui/Header';
import {Routes, Route} from 'react-router-dom';
import Projects from './pages/Projects';
import Tasks from './pages/Tasks';
import Reports from './pages/Reports';
import Settings from './pages/Settings';
import Home from './pages/Home';
import Footer from './components/ui/Footer';

function App() {
  return (<>
    <Header />
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/projects" element={<Projects />} />
      <Route path="/tasks" element={<Tasks />} />
      <Route path="/reports" element={<Reports />} />
      <Route path="/settings" element={<Settings />} />
    </Routes>
    <Footer />
  </>
  );
}

export default App;
