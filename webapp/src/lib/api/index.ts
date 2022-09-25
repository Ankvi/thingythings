import axios from 'axios';
import { Agent } from 'https';

const baseURL = 'https://localhost:56534';
const api = axios.create({
    baseURL,
    httpsAgent: new Agent({
        rejectUnauthorized: false
    })
})

export default api;
