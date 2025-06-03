import React, { useState, useEffect } from 'react';
import { Link } from 'react-router-dom';
import apiservice from '../../service/ApiService';
import Foto from '../../assets/images/img2.jpeg';
import '../../styles/evento/Listar.css';

export default function Listar() {
    const [eventos, setEventos] = useState([]);

    const token = localStorage.getItem("token");
    const authorization = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    useEffect(() => {
        apiservice.get('/v1/EventosAprovados', authorization)
            .then(response => {
                setEventos(response.data.data);
            })
            .catch(error => {
                console.error("Erro ao buscar eventos:", error);
            });
    }, []);

    return (
        <main>
            <div className='layout-container'>
                <section className='eventos-section'>
                    <div className='evento-content'>
                        <h1>Lista dos Eventos</h1>
                        <form>
                            <input type="text" placeholder='Buscar Eventos' />
                            <button>Buscar</button>
                        </form>
                    </div>

                    <div className='evento-cards'>
                            {eventos.map(evento => (
                                <div key={evento.id} className="evento-card-content">
                                    <div className='evento-card-img'>
                                        <img 
                                            src={`http://localhost:5232/${evento.imagemUrl}`} 
                                            alt={evento.titulo} />
                                    </div>
                                    <div className='evento-card-inf'>
                                        <h5>{evento.titulo}</h5>
                                        <p>
                                            <Link to="/detalhesEvento" className='evento-card-inf-link'>Ver Detalhes</Link>
                                        </p>
                                    </div>
                                </div>
                            ))}
                    </div>
                </section>
            </div>
        </main>
    );
}
