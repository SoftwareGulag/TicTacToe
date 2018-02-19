import request from 'superagent';

export default function SendMakeMoveRequest({ props }) {
    return request
        .post(`http://localhost:63566/game/move/${props.cellId}`)
        .send()
        .then(response => {
        return { makeMoveRequestResponse: response.body }
    });
}