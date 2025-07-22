import { useEffect, useState } from "react";
import {
  FaPen,
  FaInfo,
  FaThumbsDown,
  FaThumbsUp,
  FaMagnifyingGlass,
  FaPlus,
  FaTrash,
  FaPrint,
  FaX,
} from "react-icons/fa6";
import api from "../../../../core/service/api";
import jsPDF from "jspdf";
import autoTable from "jspdf-autotable";
import "./Eventos.css";

interface TipoEvento {
  id: number;
  nome: string;
}

interface Usuario {
  id: number;
  nome: string;
  sobreNome: string;
}

interface Evento {
  id: number;
  titulo: string;
  local: string;
  statusAprovacao: number;
  tipoEvento: TipoEvento;
  usuario: Usuario;
  dataHoraInicio: string;
}

interface ApiResponse {
  data: Evento[];
  message: string;
  code: number;
}

const Eventos = () => {
  const [perfilID, setPerfilID] = useState<number | null>(null);
  const [eventosOriginais, setEventosOriginais] = useState<Evento[]>([]);
  const [eventosFiltrados, setEventosFiltrados] = useState<Evento[]>([]);
  const [currentPage, setCurrentPage] = useState<number>(1);
  const [titulo, setTitulo] = useState<string>("");
  const [dataInicio, setDataInicio] = useState<string>("");
  const [dataFim, setDataFim] = useState<string>("");
  const [mensagem, setMensagem] = useState<string>("");

  const [mostrarModal, setMostrarModal] = useState(false);
  const [tiposEvento, setTiposEvento] = useState<TipoEvento[]>([]);
  const [novoEvento, setNovoEvento] = useState({
    titulo: "",
    descricao: "",
    dataHoraInicio: "",
    dataHoraFim: "",
    local: "",
    tipoEventoID: 0,
    imagem: null as File | null,
  });

  const pageSize = 5;

  useEffect(() => {
    const storedPerfilID = localStorage.getItem("perfilID");
    if (storedPerfilID) {
      setPerfilID(parseInt(storedPerfilID, 10));
    }
    carregarEventos();
    carregarTiposEvento();
  }, []);

  const carregarEventos = async () => {
    try {
      const response = await api.get<ApiResponse>("/v1/ListEvento");
      if (response.data?.data) {
        setEventosOriginais(response.data.data);
        setEventosFiltrados(response.data.data);
        setMensagem("");
      }
    } catch (error) {
      console.error("Erro ao buscar eventos:", error);
    }
  };

  const carregarTiposEvento = async () => {
    try {
      const tiposRes = await api.get("/v1/ListTipoEvento");
      setTiposEvento(tiposRes.data.data);
    } catch (err) {
      console.error("Erro ao carregar tipos:", err);
    }
  };

  const filtrarEventos = () => {
    let filtrados = [...eventosOriginais];

    if (titulo.trim()) {
      filtrados = filtrados.filter((evento) =>
        evento.titulo.toLowerCase().includes(titulo.toLowerCase())
      );
    }

    if (dataInicio && dataFim) {
      const inicio = new Date(dataInicio);
      const fim = new Date(dataFim);
      filtrados = filtrados.filter((evento) => {
        const dataEvento = new Date(evento.dataHoraInicio);
        return dataEvento >= inicio && dataEvento <= fim;
      });
    }

    setMensagem(filtrados.length === 0 ? "Nenhum evento encontrado." : "");
    setEventosFiltrados(filtrados);
    setCurrentPage(1);
  };

  const statusLabel = (status: number): string => {
    switch (status) {
      case 0:
        return "Pendente";
      case 1:
        return "Aprovado";
      case 2:
        return "Rejeitado";
      default:
        return "Desconhecido";
    }
  };

  const eventosPaginados = eventosFiltrados.slice(
    (currentPage - 1) * pageSize,
    currentPage * pageSize
  );

  const totalPages = Math.ceil(eventosFiltrados.length / pageSize);

  const handleGerarPDF = () => {
    const doc = new jsPDF();
    doc.setFontSize(18);
    doc.text("Relatório de Eventos", 14, 20);

    autoTable(doc, {
      startY: 30,
      head: [["ID", "Título", "Local", "Tipo Evento", "Responsável", "Data", "Estado"]],
      body: eventosFiltrados.map((evento) => [
        evento.id,
        evento.titulo,
        evento.local,
        evento.tipoEvento?.nome,
        `${evento.usuario?.nome} ${evento.usuario?.sobreNome}`,
        new Date(evento.dataHoraInicio).toLocaleDateString(),
        statusLabel(evento.statusAprovacao),
      ]),
      styles: { fontSize: 10 },
      headStyles: { fillColor: [52, 58, 64] },
    });

    doc.save("relatorio_eventos.pdf");
  };

  const handleChangeNovo = (
    e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement | HTMLSelectElement>
  ) => {
    const { name, value, files } = e.target as HTMLInputElement;
    if (name === "imagem" && files?.length) {
      setNovoEvento((prev) => ({ ...prev, imagem: files[0] }));
    } else {
      setNovoEvento((prev) => ({ ...prev, [name]: value }));
    }
  };

  const criarEvento = async () => {
    const {
      titulo,
      descricao,
      dataHoraInicio,
      dataHoraFim,
      local,
      tipoEventoID,
      imagem,
    } = novoEvento;

    if (!titulo || !descricao || !dataHoraInicio || !dataHoraFim || !local || !tipoEventoID || !imagem) {
      alert("Todos os campos são obrigatórios.");
      return;
    }

    const formData = new FormData();
    formData.append("Titulo", titulo);
    formData.append("Descricao", descricao);
    formData.append("DataHoraInicio", dataHoraInicio);
    formData.append("DataHoraFim", dataHoraFim);
    formData.append("Local", local);
    formData.append("TipoEventoID", String(tipoEventoID));
    formData.append("ImagemUrl", imagem);

    try {
      const res = await api.post("/v1/CreateEvento", formData, {
        headers: {
          "Content-Type": "multipart/form-data",
          Authorization: `Bearer ${localStorage.getItem("token") || ""}`,
        },
      });

      if (res.data?.isSuccess) {
        alert("Evento criado com sucesso!");
        setMostrarModal(false);
        setNovoEvento({
          titulo: "",
          descricao: "",
          dataHoraInicio: "",
          dataHoraFim: "",
          local: "",
          tipoEventoID: 0,
          imagem: null,
        });
        carregarEventos();
      } else {
        alert("Erro ao cadastrar evento.");
      }
    } catch (err) {
      console.error("Erro ao criar evento:", err);
      alert("Erro no cadastro do evento.");
    }
  };

  const isAdmin = perfilID === 1;

  return (
    <section className="eventoMain">
      <div className="eventoHeader">
        <button className="eventoBtnAdd" onClick={() => setMostrarModal(true)}>
          <FaPlus /> Add Evento
        </button>

        <div className="eventoBuscar">
          <input type="text" placeholder="Buscar por título..." value={titulo} onChange={(e) => setTitulo(e.target.value)} />
          <input type="date" value={dataInicio} onChange={(e) => setDataInicio(e.target.value)} />
          <input type="date" value={dataFim} onChange={(e) => setDataFim(e.target.value)} />
          <button className="eventoBtnSearch" onClick={filtrarEventos}>
            <FaMagnifyingGlass />
          </button>
        </div>
      </div>

      {mensagem && <div className="mensagem-erro">{mensagem}</div>}

      <div className="eventoTabela">
        <table>
          <thead>
            <tr>
              <th>ID</th>
              <th>Título</th>
              <th>Local</th>
              <th>Estado</th>
              <th>Ação</th>
            </tr>
          </thead>
          <tbody>
            {eventosPaginados.length > 0 ? (
              eventosPaginados.map((evento) => (
                <tr key={evento.id}>
                  <td>{evento.id}</td>
                  <td>{evento.titulo}</td>
                  <td>{evento.local}</td>
                  <td>
                    <p className={`status-${evento.statusAprovacao}`}>
                      {statusLabel(evento.statusAprovacao)}
                    </p>
                  </td>
                  <td className="acoes">
                    <button title="Editar"><FaPen /></button>
                    <button title="Detalhes"><FaInfo /></button>
                    {isAdmin && (
                      <>
                        <button title="Rejeitar"><FaThumbsDown /></button>
                        <button title="Aprovar"><FaThumbsUp /></button>
                      </>
                    )}
                    <button title="Eliminar"><FaTrash /></button>
                  </td>
                </tr>
              ))
            ) : (
              <tr><td colSpan={5}>Nenhum evento encontrado.</td></tr>
            )}
          </tbody>
        </table>
      </div>

      <div className="paginacao">
        <button onClick={() => setCurrentPage((p) => Math.max(p - 1, 1))} disabled={currentPage === 1}>
          Anterior
        </button>
        <span>Página {currentPage} de {totalPages}</span>
        <button onClick={() => setCurrentPage((p) => Math.min(p + 1, totalPages))} disabled={currentPage === totalPages}>
          Próxima
        </button>
      </div>

      {dataInicio && dataFim && eventosFiltrados.length > 0 && (
        <div className="imprimir">
          <button onClick={handleGerarPDF}>
            <FaPrint /> Gerar Relatório PDF
          </button>
        </div>
      )}

      {mostrarModal && (
        <div className="modal-overlay">
          <div className="modal-content">
            <button className="close-btn" onClick={() => setMostrarModal(false)}><FaX /></button>
            <h2>Criar Novo Evento</h2>
            <input name="titulo" placeholder="Título" value={novoEvento.titulo} onChange={handleChangeNovo} />
            <textarea name="descricao" placeholder="Descrição" value={novoEvento.descricao} onChange={handleChangeNovo}></textarea>
            <input type="datetime-local" name="dataHoraInicio" value={novoEvento.dataHoraInicio} onChange={handleChangeNovo} />
            <input type="datetime-local" name="dataHoraFim" value={novoEvento.dataHoraFim} onChange={handleChangeNovo} />
            <input name="local" placeholder="Local" value={novoEvento.local} onChange={handleChangeNovo} />
            <select name="tipoEventoID" value={novoEvento.tipoEventoID} onChange={handleChangeNovo}>
              <option value={0}>-- Tipo de Evento --</option>
              {tiposEvento.map((tipo) => (
                <option key={tipo.id} value={tipo.id}>{tipo.nome}</option>
              ))}
            </select>
            <input type="file" name="imagem" onChange={handleChangeNovo} accept="image/*" />
            {novoEvento.imagem && (
              <img src={URL.createObjectURL(novoEvento.imagem)} alt="Preview" style={{ width: 150, marginTop: 10, borderRadius: 8 }} />
            )}
            <div className="modal-actions">
              <button onClick={criarEvento}>Salvar</button>
              <button onClick={() => setMostrarModal(false)}>Cancelar</button>
            </div>
          </div>
        </div>
      )}
    </section>
  );
};

export default Eventos;
