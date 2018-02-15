import React from 'react';
import {state} from 'cerebral/tags';
import {connect} from '@cerebral/react';
import Cell from './Cell';

function Board (props) {
    return (<div><Cell state={props.board}/></div>);
}

export default connect({
    board: state`app.board`
},
Board);