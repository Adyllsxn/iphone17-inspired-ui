import React, { useEffect, useState } from 'react';
import { FaEdit, FaTrash, FaInfoCircle, FaPlus, FaSearch } from 'react-icons/fa';
import apiservice from '../../../service/ApiService';
import Alert from '../../shared/Alert';
import './TipoEvento.css';

export default function TipoEvento() {
  const [tiposEvento, setTiposEvento] = useState([]);
  const [alerta, setAlerta] = useState({ message: '', type: '' });
  const [busca, setBusca] = useState('');

  // Novos estados para controle do formulário
  const [modoFormulario, setModoFormulario] = useState(null); // 'edit' | 'view' | null
  const [idSelecionado, setIdSelecionado] = useState(null);
  const [tipoEventoAtual, setTipoEventoAtual] = useState({ nome: '' });
  const [carregando, setCarregando] = useState(false);

  useEffect(() => {
    carregarTiposEvento();
  }, []);

  // Carregar lista
  const carregarTiposEvento = async () => {
    try {
      const token = localStorage.getItem('token');
      const config = { headers: { Authorization: `Bearer ${token}` } };

      const response = await apiservice.get('/v1/TipoEventos', config);
      const dados = response?.data?.data;

      if (Array.isArray(dados)) {
        setTiposEvento(dados);
      } else {
        throw new Error('Formato de dados inválido na resposta da API.');
      }
    } catch (error) {
      console.error('Erro ao carregar tipos de evento:', error);
      setAlerta({ message: 'Erro ao buscar tipos de evento.', type: 'error' });
    }
  };

  // Busca
  const buscarTipoPorNome = async () => {
    if (!busca.trim()) {
      carregarTiposEvento();
      return;
    }

    try {
      const token = localStorage.getItem('token');
      const config = { headers: { Authorization: `Bearer ${token}` } };

      const response = await apiservice.get(`/v1/SearchTipoEvento?Nome=${encodeURIComponent(busca)}`, config);
      const dados = response?.data?.data;

      if (Array.isArray(dados)) {
        setTiposEvento(dados);
      } else {
        setTiposEvento([]);
      }
    } catch (error) {
      console.error('Erro na busca:', error);
      setAlerta({ message: 'Erro ao buscar tipos de evento pelo nome.', type: 'error' });
    }
  };

  // Carregar tipo para editar ou visualizar
  const carregarTipoEventoPorId = async (id) => {
    setCarregando(true);
    try {
      const token = localStorage.getItem('token');
      const config = { headers: { Authorization: `Bearer ${token}` } };

      const response = await apiservice.get(`/v1/TipoEventos/${id}`, config);
      const data = response?.data?.data;

      if (data) {
        setTipoEventoAtual({ nome: data.nome });
      } else {
        setAlerta({ message: 'Tipo de evento não encontrado.', type: 'error' });
        setModoFormulario(null);
      }
    } catch (error) {
      console.error('Erro ao carregar tipo de evento:', error);
      setAlerta({ message: 'Erro ao carregar tipo de evento.', type: 'error' });
      setModoFormulario(null);
    }
    setCarregando(false);
  };

  // Abrir formulário para editar
  const handleEditar = async (id) => {
    setIdSelecionado(id);
    await carregarTipoEventoPorId(id);
    setModoFormulario('edit');
  };

  // Abrir formulário para detalhes (view only)
  const handleDetalhes = async (id) => {
    setIdSelecionado(id);
    await carregarTipoEventoPorId(id);
    setModoFormulario('view');
  };

  // Excluir
  const handleEliminar = async (id) => {
    if (window.confirm('Tem certeza que deseja eliminar este tipo de evento?')) {
      try {
        const token = localStorage.getItem('token');
        const config = { headers: { Authorization: `Bearer ${token}` } };

        await apiservice.delete(`/v1/DeleteTipoEvento?Id=${id}`, config);
        setAlerta({ message: 'Tipo de evento eliminado com sucesso.', type: 'success' });
        carregarTiposEvento();
      } catch (error) {
        console.error('Erro ao eliminar tipo:', error);
        setAlerta({ message: 'Erro ao eliminar tipo de evento.', type: 'error' });
      }
    }
  };

  // Abrir formulário para cadastrar
  const handleCadastrar = () => {
    setIdSelecionado(null);
    setTipoEventoAtual({ nome: '' });
    setModoFormulario('edit');
  };

  // Voltar para lista
  const handleVoltar = () => {
    setModoFormulario(null);
    setTipoEventoAtual({ nome: '' });
    setIdSelecionado(null);
    carregarTiposEvento();
  };

  // Atualizar campo no formulário
  const handleChange = (e) => {
    setTipoEventoAtual({ ...tipoEventoAtual, [e.target.name]: e.target.value });
  };

  // Salvar (create ou update)
  const handleSalvar = async () => {
    if (!tipoEventoAtual.nome.trim()) {
      setAlerta({ message: 'Nome é obrigatório.', type: 'error' });
      return;
    }

    try {
      const token = localStorage.getItem('token');
      const config = { headers: { Authorization: `Bearer ${token}` } };

      if (idSelecionado) {
        // Atualizar
        await apiservice.put(`/v1/TipoEventos/${idSelecionado}`, tipoEventoAtual, config);
        setAlerta({ message: 'Tipo de evento atualizado com sucesso.', type: 'success' });
      } else {
        // Criar
        await apiservice.post(`/v1/TipoEventos`, tipoEventoAtual, config);
        setAlerta({ message: 'Tipo de evento criado com sucesso.', type: 'success' });
      }

      handleVoltar();
    } catch (error) {
      console.error('Erro ao salvar tipo de evento:', error);
      setAlerta({ message: 'Erro ao salvar tipo de evento.', type: 'error' });
    }
  };

  // Renderizar lista ou formulário
  if (modoFormulario) {
    return (
      <main>
        <section className='tipo-evento-section'>
          <div className='layout-container'>
            <h2>{modoFormulario === 'edit' ? (idSelecionado ? 'Editar Tipo de Evento' : 'Cadastrar Tipo de Evento') : 'Detalhes do Tipo de Evento'}</h2>

            {alerta.message && (
              <Alert
                message={alerta.message}
                type={alerta.type}
                onClose={() => setAlerta({ message: '', type: '' })}
              />
            )}

            {carregando ? (
              <p>Carregando...</p>
            ) : (
              <form onSubmit={e => { e.preventDefault(); if(modoFormulario === 'edit') handleSalvar(); }}>
                <label>
                  Nome:
                  <input
                    type="text"
                    name="nome"
                    value={tipoEventoAtual.nome}
                    onChange={handleChange}
                    disabled={modoFormulario === 'view'}
                  />
                </label>

                <div className="botoes">
                  {modoFormulario === 'edit' && (
                    <button type="submit" className='btn-salvar'>Salvar</button>
                  )}
                  <button type="button" onClick={handleVoltar} className='btn-voltar'>Voltar</button>
                </div>
              </form>
            )}
          </div>
        </section>
      </main>
    );
  }

  // Render lista normal
  return (
    <main>
      <section className='tipo-evento-section'>
        <div className='layout-container'>
          <div className="tipo-evento-header">
            <h1>Tipos de Evento</h1>
            <button className='btn-cadastrar' onClick={handleCadastrar}>
              <FaPlus /> Cadastrar Tipo
            </button>
          </div>

          <div className="busca-container">
            <input
              type="text"
              placeholder="Buscar por nome..."
              value={busca}
              onChange={(e) => setBusca(e.target.value)}
            />
            <button className="btn-buscar" onClick={buscarTipoPorNome}>
              <FaSearch /> Buscar
            </button>
          </div>

          {alerta.message && (
            <Alert
              message={alerta.message}
              type={alerta.type}
              onClose={() => setAlerta({ message: '', type: '' })}
            />
          )}

          <table className='tipo-evento-tabela'>
            <thead>
              <tr>
                <th>ID</th>
                <th>Nome</th>
                <th>Ações</th>
              </tr>
            </thead>
            <tbody>
              {tiposEvento.map(tipo => (
                <tr key={tipo.id}>
                  <td>{tipo.id}</td>
                  <td>{tipo.nome}</td>
                  <td className="acoes">
                    <button onClick={() => handleEditar(tipo.id)} title="Editar"><FaEdit /></button>
                    <button onClick={() => handleDetalhes(tipo.id)} title="Detalhes"><FaInfoCircle /></button>
                    <button onClick={() => handleEliminar(tipo.id)} title="Eliminar"><FaTrash /></button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>

          {tiposEvento.length === 0 && <p className='vazio'>Nenhum tipo de evento encontrado.</p>}
        </div>
      </section>
    </main>
  );
}
