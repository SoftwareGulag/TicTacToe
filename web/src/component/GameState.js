import React from 'react';
import {state} from 'cerebral/tags';
import {connect} from '@cerebral/react';

function GameState (props) {
    return (<div>{props.gameState}</div>);
}

export default connect({
    gameState: state`app.gameState`
}, GameState);