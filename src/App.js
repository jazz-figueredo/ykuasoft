import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import './App.css';
import Sidebar from "./Components/Sidebar"
import { Component } from 'react';

class App extends Component {
  render(){
    return (
      <div><Sidebar /></div>
    );
  }
}

export default App;
