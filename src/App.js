import Index from './index';
import Sidebar from "./Components/Sidebar";
import NotFound from "./Components/NotFound"; // Importa tu componente de página no encontrada
import React from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';

function App() {
 
  return (
      <Router>
        <Route path="/index" component={Index} />
        <Route path="/sidebar" component={Sidebar} />
        <Route component={NotFound} />
    </Router>
  );
  
}

export default App;
