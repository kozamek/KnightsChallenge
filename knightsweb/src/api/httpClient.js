import axios from 'axios';

const httpClient = axios.create({
    baseURL: 'http://localhost:56616/',
    timeout: 10000,
    headers: {
        "Content-Type": "application/json"
    }
});

export default httpClient;
