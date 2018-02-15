import React from 'react';
import {state} from 'cerebral/tags';
import {connect} from '@cerebral/react';
import Cell from './Cell';

function Board (props) {
    const { board } = props;
    const cells = board.map((cellState, index) => {
        return (<Cell key={index} cellId={index} state={cellState}/>);
    });
    return (<div>{cells}</div>);
}

export default connect({
    board: state`app.board`
}, Board);