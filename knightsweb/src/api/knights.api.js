import httpClient from "./httpClient";

const END_POINT = "/Knights";

const getAllKnights = () =>
    httpClient.get(END_POINT).then((response) => response.data);

const getKnightById = (id) =>
    httpClient
        .get(`${END_POINT}/${id}`)
        .then((response) => response.data)
        .catch((error) => {
            console.error("ERROR", error);
            throw error;
        });

const deleteKnight = (id) =>
    httpClient
        .delete(`${END_POINT}/${id}`)
        .then((response) => response.data)
        .catch((error) => {
            console.error("ERROR", error);
            throw error;
        });

const updateKnight = (id, newName) =>
    httpClient
        .put(`${END_POINT}/${id}`, newName)
        .then((response) => response.data)
        .catch((error) => {
            console.error("ERROR", error);
            throw error;
        });

const createKnight = (knight) =>
    httpClient
        .post(END_POINT, knight)
        .then((response) => response.data)
        .catch((error) => {
            console.error("ERROR", error);
            throw error;
        });

const getAllHeroes = () =>
    httpClient.get(`${END_POINT}/Heroes`).then((response) => response.data);

export {
    getAllKnights,
    deleteKnight,
    getKnightById,
    updateKnight,
    createKnight,
    getAllHeroes
};
