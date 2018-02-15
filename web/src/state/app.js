import { Module } from 'cerebral';
import { set } from 'cerebral/operators';
import { state } from 'cerebral/tags';
import Router from '@cerebral/router';
import request from 'superagent';
import {GAME_STATE} from '../common/constants';

const router = Router({
  routes: [{
      path: '/',
      signal: 'indexRouted'
  }]
});

function SendNewGameRequest({ state }) {
  return request
    .post('http://localhost:63566/game/new')
    .send()
    .then(response => {
      return { newGameRequestResponse: response.body }
    });
}

function MapNewGameRequestResponseToState({ props, state }) {
  const { newGameRequestResponse } = props;
  const result = JSON.parse(newGameRequestResponse.board);
  state.set('app.board', result.state);
  state.set('app.gameState', GAME_STATE.InProgress);
}

function CallMakeMove({ props }) {
  const { cellId } = props;
  return request
    .post(`http://localhost:63566/game/move/${cellId}`)
    .send()
    .then(response => {
      return { makeMoveRequestResponse: response.body }
    });
}

function MapMakeMoveRequestResponseToState({props, state}) {
  const { makeMoveRequestResponse } = props;
  const result = JSON.parse(makeMoveRequestResponse.board);
  state.set('app.board', result.state);
  if (makeMoveRequestResponse.hasOWonGame) {
    state.set('app.gameState', GAME_STATE.OHasWon);
  }
  if (makeMoveRequestResponse.hasXWonGame) {
    state.set('app.gameState', GAME_STATE.XHasWon);
  }
}

export default Module({
  state: {
    app: {
      board: [],
      gameState: GAME_STATE.NotInitialized
    }
  },
  signals: {
    indexRouted: [SendNewGameRequest, MapNewGameRequestResponseToState],
    makeMove: [CallMakeMove, MapMakeMoveRequestResponseToState]
  },
  modules: {
    router
  }
});