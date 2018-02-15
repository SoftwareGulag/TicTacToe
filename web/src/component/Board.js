import React from 'react';
import {state} from 'cerebral/tags';
import {connect} from '@cerebral/react';

function Board (props) {
    return (<div>{props.board}</div>);
}

export default connect({
    board: state`app.board`
},
Board);