import { Link, useNavigate } from 'react-router-dom';
import styles from './Header.module.css';
import { useState, useEffect } from 'react';

type HeaderProps = {
   onLogout: () => void;
};

const Header = ({ onLogout }: HeaderProps) => {
    const [email, setEmail] = useState('');
    const [/*perfilID*/, setPerfilID] = useState<number | null>(null);
    const navigate = useNavigate();

    useEffect(() => {
        const storedEmail = localStorage.getItem('email');
        const perfilIDString = localStorage.getItem('perfilID');
        const storedPerfilID = perfilIDString ? parseInt(perfilIDString, 10) : null;

        if (storedEmail) setEmail(storedEmail);
        if (storedPerfilID !== null && !isNaN(storedPerfilID)) {
        setPerfilID(storedPerfilID);
        }
    }, []);

    function handleLogoutClick() {
        onLogout();
        navigate('/login');
    }

    return (
        <header className={styles.header}>
        <div className="layoutContainer">
            <div className={styles.userName}>
            <p>Bem-vindo: <strong>{email || 'Usuário'}</strong></p>
            </div>

            <nav className={styles.navBar}>
            <div className={styles.navBarLogo}>
                <Link to="/" className={styles.navLink}>Kairos</Link>
            </div>

            <ul className={styles.navMenu}>
                <li className={styles.navBarItem}>
                <Link to="/" className={styles.navLink}>Início</Link>
                </li>
                <li className={styles.navBarItem}>
                <Link to="/listarEvento" className={styles.navLink}>Eventos</Link>
                </li>
                <li className={styles.navBarItem}>
                <Link to="/listarEvento" className={styles.navLink}>Blog</Link>
                </li>
                <li className={styles.navBarItem}>
                <Link to="/administrativa" className={styles.navLink}>Administrativa</Link>
                </li>
                <li className={`${styles.navBarItem} ${styles.dropHover}`}>
                <span className={styles.navLink}>Perfil</span>
                <div className={styles.drop}>
                    <Link to="/verPerfil" className={styles.navLinkDrop}>Ver Perfil</Link>
                    <span className={styles.navLinkDrop} onClick={handleLogoutClick}>Logout</span>
                </div>
                </li>
            </ul>

            <div className={styles.menuToggle}>
                <span className={styles.bar}></span>
                <span className={styles.bar}></span>
                <span className={styles.bar}></span>
            </div>
            </nav>
        </div>
        </header>
    );
};

export default Header;
