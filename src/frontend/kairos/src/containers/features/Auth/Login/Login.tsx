import { useState } from 'react';
import { FaUser, FaLock } from 'react-icons/fa';
import api from '../../../../core/service/api';
import Alert from '../../../../components/shared/Alert/Alert';
import './Login.css';

type AlertType = 'info' | 'success' | 'warning' | 'error';

type LoginProps = {
  onLogin: () => void;
};

export default function Login({ onLogin }: LoginProps) {
    const [showPassword, setShowPassword] = useState(false);
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [loading, setLoading] = useState(false);
    const [alert, setAlert] = useState<{ message: string; type: AlertType | '' }>({
        message: '',
        type: '',
    });

    async function login(event: React.FormEvent<HTMLFormElement>) {
        event.preventDefault();
        setLoading(true);
        const data = { email, password };

    try {
        const response = await api.post('/v1/Login', data);

        localStorage.setItem('email', response.data.email);
        localStorage.setItem('token', response.data.token);
        localStorage.setItem('perfilID', response.data.perfilID);

        onLogin();
    } catch (error: any) {
        let message = 'Erro ao fazer login.';
        if (error.response) {
            if (error.response.status === 401) {
            message = 'Email ou senha inválidos.';
            } else if (error.response.status === 404) {
            message = 'Usuário não encontrado.';
            } else {
            message = error.response.data?.message || 'Erro inesperado.';
            }
        } else if (error.request) {
            message = 'Servidor não respondeu. Verifique sua conexão.';
        } else {
            message = error.message;
        }

        setAlert({ message, type: 'error' });
    } finally {
        setLoading(false);
    }
  }

    return (
        <main className='loginWrap'>
            {alert.message && (
                <Alert
                message={alert.message}
                type={alert.type as AlertType}
                onClose={() => setAlert({ message: '', type: '' })}
                />
            )}

            <div className='loginConteiner'>
                <form onSubmit={login}>
                <h1>Kairos</h1>

                <div className='inputField'>
                    <input
                    type="email"
                    placeholder="Exemplo@gmail.com"
                    required
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                    />
                    <FaUser className='icon' />
                </div>

                <div className='inputField'>
                    <input
                    type={showPassword ? 'text' : 'password'}
                    placeholder="Senha"
                    required
                    value={password}
                    onChange={(e) => setPassword(e.target.value)}
                    />
                    <FaLock className='icon' />
                </div>

                <div className='togglePassword'>
                    <input
                    type="checkbox"
                    id="showPassword"
                    checked={showPassword}
                    onChange={() => setShowPassword(!showPassword)}
                    />
                    <label htmlFor="showPassword">Mostrar a senha</label>
                </div>

                <button type="submit" disabled={loading}>
                    {loading ? 'Aguarde...' : 'Entrar'}
                </button>
                </form>
            </div>
        </main>
    );
}
