import {GAME_STATE} from '../../common/constants';

export default function MapNewGameRequestResponseToState({ props, state }) {
    const { newGameRequestResponse } = props;
    const result = JSON.parse(newGameRequestResponse.board);
    state.set('app.board', result.state);
    state.set('app.gameState', GAME_STATE.InProgress);
    state.set('app.boardInputsAreActive', true);
}