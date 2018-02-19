import request from 'superagent';

export default function SendNewGameRequest({ state }) {
    return request
        .post('http://localhost:63566/game/new')
        .send()
        .then(response => {
        return { newGameRequestResponse: response.body }
    });
}