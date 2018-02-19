import React from 'react';
import {state} from 'cerebral/tags';
import {connect} from '@cerebral/react';
import Cell from './Cell';
import _ from 'lodash';

function renderRow (ids, board, inputsAreActive) {
    const cells = _.map(ids, id => (<Cell className={'cell'} cellId={id} state={board[id]} isActive={inputsAreActive}/>));
    return (<div className={'board-row'}>{cells}</div>);
}

function generateRowRanges (rowLimits) {
    return _.map(rowLimits, limits => _.range(limits[0], limits[1]));
}

const rowRangesToRows = _.curry((board, boardInputsAreActive, rowRanges) => {
    return _.map(rowRanges, range => renderRow(range, board, boardInputsAreActive));
});

function Board (props) {
    const { board, boardInputsAreActive } = props;
    const rows = _.flow(generateRowRanges, rowRangesToRows(board, boardInputsAreActive))([[0, 3], [3, 6], [6, 9]]);
    return (<div>{rows}</div>);
}

export default connect({
    board: state`app.board`,
    boardInputsAreActive: state`app.boardInputsAreActive`,
}, Board);