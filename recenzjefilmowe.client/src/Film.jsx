import React from "react";
import { useEffect, useState } from "react";
import { useNavigate, useParams } from "react-router-dom";
import { Navigate } from "react-router-dom";
import moment from 'moment';

const Film = () => {

    const { id } = useParams();

    const [film, setFilm] = useState({});

    const [autor, setAutor] = useState('');
    const [data, setData] = useState();
    const [ocena, setOcena] = useState();
    const [tekst, setTekst] = useState('');
    const [filmId, setFilmId] = useState(id);
    const [Id, setId] = useState();


    const [recenzja, setRecenzja] = useState();

    useEffect(() => {
        fetch(`https://localhost:7184/film/${id}`)
            .then(response => response.json())
            .then(data => {
                setFilm(data)
                console.log(data)
            })
            .catch(error => console.error(error))
    }, [])

    const handleSubmit = (e) => {
        e.preventDefault();

        const recenzjaData = {autor, ocena, tekst, filmId}
        setFilmId(id);

        fetch('https://localhost:7184/recenzja', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(recenzjaData),
        })
            .then(response => {
                if (response.ok) {
                    window.location.reload();
                }
                else {
                    console.log("Error")
                }
            })
            .catch(error => console.error(error))
    }

    useEffect(() => {
        fetch(`https://localhost:7184/recenzja/${id}`)
            .then(response => response.json())
            .then(data => {
                setRecenzja(data)
                console.log(data)
            })
            .catch(error => console.error(error))
    }, [])

    return (
        <div>
            <div className="div">
                <img src={film.zdjecie} />
                 <h1>{film.tytul}</h1>
                 <h2>Premiera: {film.premiera}</h2>
                 <h2>Czas trwania: {film.czas} min.</h2>
                <h2>Rezyseria: {film.rezyseria}</h2>
                <iframe width="1200" height="720" src={film.link} frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" referrerpolicy="strict-origin-when-cross-origin" allowfullscreen></iframe>
            </div>
            <br></br>
            <div className="div">
                <h2>Napisz recenzje</h2>
                <form onSubmit={handleSubmit}>
                    <label>
                        <span>Autor: </span>
                        <input type="text" required value={autor} onChange={(e) => setAutor(e.target.value)} />
                    </label>
                   
                    <label>
                        <span>Ocena: </span>
                        <input type="number" required min="1" max="5" value={ocena} onChange={(e) => setOcena(e.target.value)} />
                    </label>
                    <br></br>
                    <br></br>
                    <label>
                        <textarea rows="12" cols="100" placeholder="Napisz recenzje" value={tekst} onChange={(e) => setTekst(e.target.value)} />
                    </label>
                    <br></br>
                    <button type="submit">Dodaj</button>
                </form>
            </div>
            <div>
                <h1>RECENZJE:</h1>
                <br></br>
                {recenzja?.map(Recenzja => (
                        <div className="div" key={Recenzja.id}>
                        <h2>Autor: {Recenzja.autor}</h2>
                        <h3>{moment(Recenzja.data).format("DD-MM-YYYY H:mm:ss")}</h3>
                        <h3>Ocena: {Recenzja.ocena}/5</h3>
                        <textarea className="textarea" readOnly>{Recenzja.tekst}</textarea>
                        </div>))}
            </div>
        </div>
    )
}

export default Film;