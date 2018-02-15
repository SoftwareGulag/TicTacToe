import { Module } from 'cerebral';
import { set } from 'cerebral/operators';
import { state } from 'cerebral/tags';
import Router from '@cerebral/router';

const router = Router({
  routes: [{
      path: '/',
      signal: 'indexRouted'
  }]
});

export default Module({
  state: {
    app: {
      board: []
    }
  },
  signals: {
    indexRouted: [set(state`app.board`, ['_','_','_','_','_','_','_','_','_',])]
  },
  modules: {
    router
  }
});