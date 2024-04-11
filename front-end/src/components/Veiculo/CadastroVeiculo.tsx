import axios from 'axios';
import { useForm } from 'react-hook-form';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';
import Typography from '@mui/material/Typography';
import Box from '@mui/material/Box';
import Container from '@mui/material/Container';
import Grid from '@mui/material/Grid';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import { useNavigate } from 'react-router-dom';
import { InputLabel } from '@mui/material';

interface FormData {
    placa: string;
    chassi: string;
    tipoVeiculo: string;
    cor: string;
    latitude: string;
    longitude: string;
}

const CadastroVeiculo = () => {
    const { register, handleSubmit, formState: { errors } } = useForm<FormData>();
    const navigate = useNavigate();

    const onSubmit = async (data: FormData) => {
        try {
            const response = await axios.post('https://localhost:5000/Veiculo/Cadastrar', data);
            if (response.status === 201 || response.status === 200) {
                navigate('/');
            }
        } catch (error) {
            console.error('Erro ao cadastrar veículo:', error);
        }
    };

    return (
        <Container>
            <Box mt={5}>
                <Typography variant="h4" align="center" gutterBottom>Cadastro de Veículo</Typography>
                <form onSubmit={handleSubmit(onSubmit)}>
                    <Grid container spacing={2}>
                        <Grid item xs={12} sm={6}>
                            <FormControl fullWidth>
                                <TextField
                                    label="Placa"
                                    {...register('placa', { required: true, minLength: 7, maxLength: 7 })}
                                    error={!!errors.placa}
                                    helperText={errors.placa ? 'A placa deve conter 7 caracteres' : ''}
                                    fullWidth
                                    variant="outlined"
                                />
                            </FormControl>
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <FormControl fullWidth>
                                <TextField
                                    label="Chassi"
                                    {...register('chassi', { minLength: 17, maxLength: 17 })}
                                    error={!!errors.chassi}
                                    helperText={errors.chassi ? 'O chassi deve conter 17 caracteres' : ''}
                                    fullWidth
                                    variant="outlined"
                                />
                            </FormControl>
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <FormControl fullWidth>
                                <InputLabel id="tipoVeiculo-label">Tipo Veículo</InputLabel>
                                <Select
                                    labelId="tipoVeiculo-label"
                                    label="Tipo Veículo"
                                    {...register('tipoVeiculo', { required: true })}
                                    error={!!errors.tipoVeiculo}
                                    variant="outlined"
                                    fullWidth
                                >
                                    <MenuItem value="1">Ônibus</MenuItem>
                                    <MenuItem value="2">Caminhão</MenuItem>
                                </Select>
                            </FormControl>
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <FormControl fullWidth>
                                <TextField
                                    label="Cor"
                                    {...register('cor')}
                                    fullWidth
                                    variant="outlined"
                                />
                            </FormControl>
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <FormControl fullWidth>
                                <TextField
                                    label="Latitude"
                                    {...register('latitude', { required: true, pattern: /^-?\d*\.?\d*$/ })}
                                    error={!!errors.latitude}
                                    helperText={errors.latitude ? 'A latitude deve conter apenas números' : ''}
                                    fullWidth
                                    variant="outlined"
                                />
                            </FormControl>
                        </Grid>
                        <Grid item xs={12} sm={6}>
                            <FormControl fullWidth>
                                <TextField
                                    label="Longitude"
                                    {...register('longitude', { required: true, pattern: /^-?\d*\.?\d*$/ })}
                                    error={!!errors.longitude}
                                    helperText={errors.longitude ? 'A longitude deve conter apenas números' : ''}
                                    fullWidth
                                    variant="outlined"
                                />
                            </FormControl>
                        </Grid>
                        <Grid item xs={12}>
                            <Box display="flex" justifyContent="flex-end" alignItems="center">
                                <Button variant="outlined" color="primary" type="button" onClick={() => navigate('/')}>Cancelar</Button>
                                <Box ml={1}>
                                    <Button type="submit" variant="contained" color="primary">Salvar</Button>
                                </Box>
                            </Box>
                        </Grid>
                    </Grid>
                </form>
            </Box>
        </Container>
    );
};

export default CadastroVeiculo;