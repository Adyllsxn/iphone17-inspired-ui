import { Navigate, Route, Routes } from "react-router-dom";
import { Header, Footer, Home } from "./imports";

function App() {
  return (
    <>
      <Header />
      <Routes>
        <Route path="/" element={<Home />} />
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
      <Footer />
    </>
  );
}

export default App;
