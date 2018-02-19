import { Module } from 'cerebral';
import { set } from 'cerebral/operators';
import { state } from 'cerebral/tags';
import Router from '@cerebral/router';

import StartNewGameChain from './chain/startNewGameChain'
import MakeMoveChain from './chain/makeMoveChain'

import {GAME_STATE} from '../common/constants';


const router = Router({
  routes: [{
      path: '/',
      signal: 'indexRouted'
  }]
});

export default Module({
  state: {
    app: {
      board: [],
      gameState: GAME_STATE.NotInitialized,
      boardInputsAreActive: false
    }
  },
  signals: {
    indexRouted: StartNewGameChain,
    makeMove: MakeMoveChain,
    startNewGame: StartNewGameChain
  },
  modules: {router}
});