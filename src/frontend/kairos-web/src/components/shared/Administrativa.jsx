import React from 'react';
import { Link } from 'react-router-dom';
import '../../styles/shared/Administrativa.css';

export default function Administrativa() {
    return (
        <main>
            <section className='administrativa-section'>
                <div className='layout-container'>
                    <div className='administrativa-content'>
                        <div className='administrativa-context'>
                            <h1>Área Administrativa</h1>
                            <p>
                                Esta área é exclusiva para membros autorizados da equipe administrativa e de organização da igreja. 
                                Aqui, é possível gerenciar eventos, definir responsáveis, controlar presença, ajustar horários e organizar os recursos para os cultos.
                            </p>
                        </div>
                        <div className='administrativa-button'>
                            <Link  className='nav-link'>
                                <button className='button-org'>
                                    Organização
                                </button>
                            </Link>
                            <Link  className='nav-link'>
                                <button className='button-adm'>
                                    Administradores
                                </button>
                            </Link>
                        </div>
                    </div>  
                </div>
            </section>
        </main>
    );
}