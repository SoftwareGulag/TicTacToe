import {GAME_STATE} from '../../common/constants';

export default function MapMakeMoveRequestResponseToState({props, state}) {
    const { makeMoveRequestResponse } = props;
    const result = JSON.parse(makeMoveRequestResponse.board);
    state.set('app.board', result.state);
    if (makeMoveRequestResponse.hasOWonGame) {
        state.set('app.gameState', GAME_STATE.OHasWon);
        state.set('app.boardInputsAreActive', false);
    }
    if (makeMoveRequestResponse.hasXWonGame) {
        state.set('app.gameState', GAME_STATE.XHasWon);
        state.set('app.boardInputsAreActive', false);
    }
    if (makeMoveRequestResponse.draw) {
        state.set('app.gameState', GAME_STATE.Draw);
        state.set('app.boardInputsAreActive', false);
    }
    if (makeMoveRequestResponse.openOutcome) {
        state.set('app.gameState', GAME_STATE.InProgress);
    }
}