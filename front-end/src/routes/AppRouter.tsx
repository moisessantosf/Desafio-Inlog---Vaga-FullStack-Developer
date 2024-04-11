import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import CadastroVeiculo from '../components/Veiculo/CadastroVeiculo';
import ListagemVeiculos from '../components/Veiculo/ListagemVeiculo';

const AppRouter: React.FC = () => {
    return (
        <Router>
            <Routes>
                <Route path="/" element={<ListagemVeiculos />}  />
                <Route path="/listagem" element={<ListagemVeiculos />}  />
                <Route path="/cadastro-veiculo" element={<CadastroVeiculo />} />
                {/* Outras rotas podem ser definidas aqui */}
            </Routes>
        </Router>
    );
};

export default AppRouter;