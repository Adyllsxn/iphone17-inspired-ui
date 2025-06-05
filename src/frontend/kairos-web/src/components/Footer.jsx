import React from 'react';
import { Link } from 'react-router-dom';
import { FaInstagram, FaFacebookF, FaXTwitter, FaArrowUp } from 'react-icons/fa6';
import '../styles/Footer.css';

export default function Footer() {
    return (
        <footer className='site-footer'>
            <div className='layout-container'>
                <div className='footer-top'>
                    <div className="footer-title">
                        <h1>Unidos para servir melhor</h1>
                    </div>
                    <div className='footer-links'>
                        <div className='footer-column'>
                            <h3>Institucional</h3>
                            <ul>
                                <li><Link to="/sobreNos" className='nav-link'>Sobre Nós</Link></li>
                                <li><Link to="/ajuda" className='nav-link'>Ajuda</Link></li>
                                <li><Link to="/faq" className='nav-link'>FAQ</Link></li>
                            </ul>
                        </div>
                        <div className='footer-column'>
                            <h3>Igreja Sossego em Cristo</h3>
                            <ul>
                                <li>Endereço: Rua Exemplo, 123 - Sossego</li>
                                <li>Telefone: (+244) 912-034-678</li>
                                <li>Email: contato@sossegoemcristo.org</li>
                            </ul>
                        </div>
                        <div className='footer-column'>
                            <h3>Redes Sociais</h3>
                            <div className='social-icons'>
                                <a href="#" target="_blank" rel="noopener noreferrer" aria-label="Instagram">
                                    <FaInstagram />
                                </a>
                                <a href="#" target="_blank" rel="noopener noreferrer" aria-label="Facebook">
                                    <FaFacebookF />
                                </a>
                                <a href="#" target="_blank" rel="noopener noreferrer" aria-label="X (Twitter)">
                                    <FaXTwitter />
                                </a>
                            </div>
                        </div>
                    </div>
                </div>

                <div className="footer-bottom">
                    <p>© {new Date().getFullYear()} Kairos | Todos os direitos reservados</p>
                    <p>
                        <Link to="/politicaDePrivacidade" className='nav-link'>Política de Privacidade</Link>
                    </p>
                </div>
            </div>

            <button 
                className='btn-top' 
                onClick={() => window.scrollTo({ top: 0, behavior: 'smooth' })}
                aria-label="Voltar ao topo">
                <FaArrowUp />
            </button>
        </footer>
    );
}