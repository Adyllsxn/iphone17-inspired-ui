import React from 'react';
import {Link} from 'react-router-dom';
import '../../styles/shared/Administrativa.css'

export default function Administrativa() {
    return (
        <main>
            <section className='administrativa-section'>
                <div className='layout-container'>
                    <div className='administrativa-content'>
                        <div className='administrativa-context'>
                            <h1>Área Administrativa</h1>
                            <p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Rerum aut cupiditate eum aperiam hic illo quos obcaecati exercitationem, omnis maiores eveniet totam, quidem dolorum odit. Impedit molestias iusto nisi quisquam.</p>
                        </div>
                        <div className='administrativa-button'>
                            <button className='button-org'>
                                <Link className='nav-link'>Organização</Link>
                            </button>
                            <button className='button-adm'>
                                <Link className='nav-link'>Administradores</Link>
                            </button>
                        </div>
                    </div>  
                </div>
            </section>
        </main>
    )
}
