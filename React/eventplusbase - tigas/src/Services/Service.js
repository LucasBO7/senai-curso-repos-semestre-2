import axios from "axios";

const apiPort = '5000';
const localApiUrl = `http://localhost:${apiPort}/api`;
const externalApi = null;
const api = axios.create({
    baseURL: localApiUrl
});

export default api;