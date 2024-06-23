import { useEffect, useState } from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Link } from "react-router-dom";
import './App.css';
import Film from './Film.jsx'
import Filmy from './Filmy.jsx'

function App() {
    return (

      <BrowserRouter>
        <div>
          <Routes>
            <Route path='/' element={<Filmy/>}/>
            <Route path='/film/:id' element={<Film/>} />
          </Routes>
        </div>
        </BrowserRouter>
    )
}

export default App;