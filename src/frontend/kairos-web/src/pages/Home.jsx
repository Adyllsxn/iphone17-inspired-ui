import React from 'react';
import '../styles/Home.css';
import videoSrc from '../assets/videos/background.mp4';
import InspirationalSlider from '../components/shared/InspirationalSlider';

export default function Home() {
    return (
        <main>

            {/* HERO */}
            <section className='hero'>
                <div className='hero-section'>
                    <div id="hero-background">
                        <video loop autoPlay muted>
                            <source src={videoSrc} type="video/mp4" />
                        </video>
                    </div>
                    <div className='layout-container'>
                        <div className='hero-content'>
                            <h1>
                                Onde experiências inesquecíveis com Deus são organizadas com excelência
                            </h1>
                            <p>
                                A plataforma Kairos une tecnologia, propósito e fé para transformar a gestão de cultos e eventos.
                            </p>
                            <div>
                                <a href="#" className='cta-button'>Descubra o Kairos</a>
                            </div>
                        </div>
                    </div>
                </div>
            </section>

            {/* WELCOME */}
            <section className='welcome-section'>
                <div className='layout-container'>
                    <div className='welcome-content'>
                        <div className='welcome-text'>
                            <h1>Bem-vindo ao Kairos</h1>
                            <p>
                                Aqui você pode consultar facilmente todos os eventos da igreja, desde cultos regulares até encontros especiais, conferências e projetos de ministério. 
                                Acompanhe suas inscrições, participe ativamente e mantenha-se conectado com a comunidade.
                                Também poderá gerenciar seu perfil e receber notificações sobre novidades e mudanças na programação.
                            </p>
                        </div>
                        <div className='welcome-buttons'>
                            <a href="/eventos">Ver Eventos</a>
                            <a href="/inscricoes">Minhas Inscrições</a>
                            <a href="/perfil">Meu Perfil</a>
                        </div>
                    </div>
                </div>
            </section>

            {/* CARDS */}
            <section className='cards-section'>
                <div className='layout-container'>
                    <div className='cards-grid'>
                        <div className='card'>
                            <h1>Fique por dentro</h1>
                            <p>
                                Confira toda a programação atualizada dos cultos, encontros e eventos especiais da igreja.
                            </p>
                        </div>
                        <div className='card'>
                            <h1>Participe facilmente</h1>
                            <p>
                                Inscreva-se e acompanhe sua participação de forma prática e rápida pelo sistema.
                            </p>
                        </div>
                        <div className='card'>
                            <h1>Seu espaço pessoal</h1>
                            <p>
                                Gerencie seus dados, veja suas inscrições e mantenha tudo organizado em um só lugar.
                            </p>
                        </div>
                    </div>
                </div>
            </section>

            {/* MAPA DA IGREJA */}
            <section className='mapa-section'>
                <div className='layout-container'>
                    <h2 className='mapa-title'>Como Chegar</h2>
                    <p className='mapa-subtitle'>Veja nossa localização e venha nos visitar!</p>
                    <div className='mapa-container'>
                        <iframe
                            title="Localização da Igreja"
                            src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3890.2996508237295!2d13.23835331482178!3d-8.838333190180294!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x1a52f1ef3ab65a8f%3A0x9fcfbb00eb70548d!2sLuanda!5e0!3m2!1spt-PT!2sao!4v1717583183521!5m2!1spt-PT!2sao"
                            allowFullScreen=""
                            loading="lazy"
                            referrerPolicy="no-referrer-when-downgrade"
                        >
                        </iframe>
                    </div>
                    <a
                    href="https://www.google.com/maps/place/Luanda"
                    target="_blank"
                    rel="noopener noreferrer"
                    className="mapa-button"
                    >
                    Abrir no Google Maps
                    </a>
                </div>
            </section>

            {/* SLIDE DE FRASES */}
            <InspirationalSlider />


        </main>
    )
}
