import React from "react";
import { useNavigate, useParams } from "react-router-dom";
import { useEffect, useState } from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Link } from "react-router-dom";
import  zdj1 from "./zdj/1.jpg"

const Filmy = () => {

    const [tytul, setTytul] = useState('')


    const [filmy, setFilmy] = useState();
    
        useEffect(() => {
        fetch(`https://localhost:7184/film`)
            .then(response => response.json())
            .then(data => {
                setFilmy(data)
                console.log(data)
            })
            .catch(error => console.error(error))
        }, [])

         /*
        useEffect(() => {
            fetch(`https://localhost:7184/film/${tytul}`)
                .then(response => response.json())
                .then(data => {
                    setFilmy(data)
                    console.log(data)
                })
                .catch(error => console.error(error))
        }, []) 
        
        
        <input type="text" id="tytul" value={tytul} name="tytul" placeholder="FILTRUJ TYTU£Y" onChange={(e) => setTytul(e.target.value)} />


        */

    return (
        <div>

       
            <h1>FILMY:</h1>

            {filmy?.map(Filmy => (
                <Link key={Filmy.id} to={`/film/${Filmy.id}`}>
                    <div className="div">
                        <img src={Filmy.zdjecie} />
                        <h2>{Filmy.tytul}</h2>
                    </div> <br></br>
                </Link>))}
        </div>
    )
}

export default Filmy;