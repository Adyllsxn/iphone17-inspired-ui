import Header from './components/Header'
import Footer from './components/Footer'
import Administrativa from './components/shared/Administrativa'
import Home from './pages/Home'
import Login from './pages/public/Login'
import Listar from './pages/evento/Listar';
import Detalhes from './pages/evento/Detalhes';
import Ajuda from './pages/public/Ajuda';
import FAQ from './pages/public/FAQ';
import SobreNos from './pages/public/SobreNos';
import PoliticaDePrivacidade from './pages/public/PoliticaDePrivacidade';

import { Routes, Route, Navigate } from 'react-router-dom';
import React, { useState } from 'react'

import './styles/App.css'



function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false)

  function handleLogin() {
    setIsLoggedIn(true)
  }

  function handleLogout() {
    setIsLoggedIn(false)
  }

  if (!isLoggedIn) {
    return <Login onLogin={handleLogin} />
  }

  return (
    <>
      <Header onLogout={handleLogout} />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/administrativa" element={<Administrativa />} />
        <Route path="/listarEvento" element={<Listar />} />
        <Route path="/detalhesEvento" element={<Detalhes />} />
        <Route path="/ajuda" element={<Ajuda />} />
        <Route path="/faq" element={<FAQ />} />
        <Route path="/sobreNos" element={<SobreNos />} />
        <Route path="/politicaDePrivacidade" element={<PoliticaDePrivacidade />} />
        <Route path="/login" element={<Navigate to="/" replace />} />
      </Routes>
      <Footer />
    </>
  )
}

export default App
