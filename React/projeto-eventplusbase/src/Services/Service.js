import axios from "axios";

// const apiPort = '5001';
// const localApi = `http://localhost:${apiPort}/api`;
const externalApi = 'https://eventlucas.azurewebsites.net/api';
// const externalApi = null;

const api = axios.create({
    baseURL: externalApi
});

export default api;