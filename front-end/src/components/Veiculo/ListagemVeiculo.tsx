import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { MapContainer, TileLayer, Marker, Popup } from 'react-leaflet';
import 'leaflet/dist/leaflet.css';
import { useNavigate } from 'react-router-dom';
import { IconButton } from '@mui/material';
import AddIcon from '@mui/icons-material/Add';
import { Icon } from 'leaflet';

interface VeiculoDTO {
    id: number;
    placa: string;
    chassi: string;
    tipoVeiculo: string;
    descricaoTipoVeiculo: string;
    cor: string;
    latitude: number;
    longitude: number;
}

const ListagemVeiculos: React.FC = () => {
    const [veiculos, setVeiculos] = useState<VeiculoDTO[]>([]);
    const [selectedVeiculoId, setSelectedVeiculoId] = useState<number | null>(null);
    const [userPosition, setUserPosition] = useState<[number, number] | null>(null);
    const navigate = useNavigate();

    useEffect(() => {
        if(!userPosition){
            return;
        }

        const fetchVeiculos = async () => {
            try {
                const response = await axios.get(`https://localhost:5000/Veiculo/Listar?latitude=${userPosition[0]}&longitude=${userPosition[1]}`);
                setVeiculos(response.data.data || []);
            } catch (error) {
                console.error('Erro ao buscar veículos:', error);
            }
        };

        fetchVeiculos();
    }, [userPosition]);

    const handleVeiculoSelecionado = (id: number) => {
        setSelectedVeiculoId(id);
    };

    const handleCadastrarVeiculo = () => {
        navigate('/cadastro-veiculo');
    };

    const getMarkerIcon = (tipoVeiculo: any) => {
        if (tipoVeiculo === 1) return busIcon;
        return truckIcon;
    };

    const busIcon = new Icon({
        iconUrl: 'https://img.icons8.com/ios-filled/50/000000/bus.png',
        iconSize: [35, 35]
    });

    const truckIcon = new Icon({
        iconUrl: 'https://img.icons8.com/pastel-glyph/64/000000/truck--v2.png',
        iconSize: [35, 35]
    });

    const userLocationIcon = new Icon({
        iconUrl: 'https://img.icons8.com/external-smashingstocks-flat-smashing-stocks/66/external-map-pointer-medical-smashingstocks-flat-smashing-stocks.png',
        iconSize: [35, 35]
    });

    useEffect(() => {
        if ('geolocation' in navigator) {
            navigator.geolocation.getCurrentPosition(
                position => {
                    setUserPosition([position.coords.latitude, position.coords.longitude]);
                },
                error => {
                    console.error('Erro ao obter a localização:', error);
                }
            );
        } else {
            console.error('Geolocalização não suportada pelo navegador.');
        }
    }, []);

    return (
        <div style={{ display: 'flex' }}>
            <div style={{ flex: 1, padding: '20px' }}>
                <div>
                    <div>
                        <h2>Listagem de Veículos</h2>
                    </div>
                    <div style={{ flex: 1, display: 'flex', alignItems: 'right' }}>
                        <IconButton color="primary" onClick={handleCadastrarVeiculo}>
                            <AddIcon />
                        </IconButton>
                    </div>
                </div>
                <table style={{ width: '100%', borderCollapse: 'collapse' }}>
                    <thead>
                        <tr style={{ backgroundColor: '#f2f2f2' }}>
                            <th style={{ padding: '10px', textAlign: 'left' }}>Placa</th>
                            <th style={{ padding: '10px', textAlign: 'left' }}>Chassi</th>
                            <th style={{ padding: '10px', textAlign: 'left' }}>Descrição Tipo Veículo</th>
                            <th style={{ padding: '10px', textAlign: 'left' }}>Cor</th>
                        </tr>
                    </thead>
                    <tbody>
                        {Array.isArray(veiculos) && veiculos.map(veiculo => (
                            <tr
                                key={veiculo.id}
                                onClick={() => handleVeiculoSelecionado(veiculo.id || 0)}
                                style={{ cursor: 'pointer', backgroundColor: selectedVeiculoId === veiculo.id ? '#dcdcdc' : 'transparent' }}
                            >
                                <td style={{ padding: '10px' }}>{veiculo.placa}</td>
                                <td style={{ padding: '10px' }}>{veiculo.chassi}</td>
                                <td style={{ padding: '10px' }}>{veiculo.descricaoTipoVeiculo}</td>
                                <td style={{ padding: '10px' }}>{veiculo.cor}</td>
                            </tr>
                        ))}
                    </tbody>
                </table>
            </div>
            <div style={{ flex: 2, padding: '20px' }}>
                <h2>Mapa de Veículos</h2>
                <MapContainer center={[0, 0]} zoom={2} style={{ height: '600px', width: '100%' }}>
                    <TileLayer url="https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png" />
                    {userPosition && (
                        <Marker position={userPosition} icon={userLocationIcon} >
                            <Popup>Minha posição:{userPosition}</Popup>
                        </Marker>
                    )}
                    {veiculos.map((veiculo: { id: any; latitude: any; longitude: any; placa: any; chassi: any; descricaoTipoVeiculo: any; cor: any; tipoVeiculo: any; }) => (
                        <div key={veiculo.id} onClick={() => handleVeiculoSelecionado(veiculo.id || 0)}>
                            <Marker
                                position={[veiculo.latitude || 0, veiculo.longitude || 0]}
                                opacity={selectedVeiculoId === veiculo.id ? 1 : 0.5}
                                icon={getMarkerIcon(veiculo.tipoVeiculo)}
                            >
                                <Popup>
                                    <div>
                                        <p>Placa: {veiculo.placa}</p>
                                        <p>Chassi: {veiculo.chassi}</p>
                                        <p>Descrição Tipo Veículo: {veiculo.descricaoTipoVeiculo}</p>
                                        <p>Cor: {veiculo.cor}</p>
                                        <p>Posição: {veiculo.latitude}, {veiculo.longitude} </p>
                                    </div>
                                </Popup>
                            </Marker>
                        </div>
                    ))}
                </MapContainer>
            </div>            
        </div>
    );
};

export default ListagemVeiculos;
