import logo from './logo.svg';
import './userModal.css';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faEdit, faTrashAlt } from '@fortawesome/free-solid-svg-icons';
import { Modal, ModalBody, ModalHeader, ModalFooter } from 'reactstrap';
import { Component } from 'react';

class App extends Component {
  //para hacer peticiones get
  //estado para almacenar datos
  state={
    modalInsert: false,
  }

  //metodo para cambiar el estado del modal
  //para ver o no ver
  modalInsert=()=>{
    this.setState({modalInsert: !this.state.modalInsert});
  }



  render(){
  return (
    <div className="App">
      <br />
      <button className='btn btn-success' onClick={()=>this.modalInsert()}>Agregar Usuario</button>
      <Modal isOpen={this.state.modalInsert}>
          <ModalHeader style={{display: 'block'}}>
            <span style={{float: 'right'}}>x</span>
          </ModalHeader>
          <ModalBody>
            <div className='form-group'>
              <label htmlFor='name'>Nombre y Apellido</label>
              <input className='form-control' type='text' name='name' id='name'/>
              <br />
              <label htmlFor='document'>Número de documento</label>
              <input className='form-control' type='text' name='document' id='document'/>
              <br />
              <label htmlFor='user'>Usuario</label>
              <input className='form-control' type='text' name='user' id='user'/>
              <br />
              <label htmlFor='password'>Contraseña</label>
              <input className='form-control' type='password' name='password' id='password'/>
            </div>
          </ModalBody>

          <ModalFooter>
            <button className='btn btn-success'>Insertar</button>
            <button className='btn btn-danger' onClick={()=>this.modalInsert()}>
              Cancelar
            </button>
          </ModalFooter>
      </Modal>
    </div>
  );
}
}

export default UserModal;
