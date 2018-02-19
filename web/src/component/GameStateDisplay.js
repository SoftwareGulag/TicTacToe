import React from 'react';
import {state} from 'cerebral/tags';
import {connect} from '@cerebral/react';

function GameStateDisplay (props) {
    return (<div>{props.gameState}</div>);
}

export default connect({
    gameState: state`app.gameState`
}, GameStateDisplay);