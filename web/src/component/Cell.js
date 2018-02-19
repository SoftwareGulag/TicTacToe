import React, {Component} from 'react';
import {signal} from 'cerebral/tags';
import {connect} from '@cerebral/react';

import Paper from 'material-ui/Paper';
import FlatButton from 'material-ui/FlatButton';
import XIcon from 'material-ui/svg-icons/content/clear';
import OIcon from 'material-ui/svg-icons/toggle/radio-button-unchecked';

import {CELL_STATE} from '../common/constants';

const POPPED_DEPTH = 3;
const PUSHED_DEPTH = 1;

function renderCellState (state) {
    if (state === CELL_STATE.O) {
        return (<OIcon className={'xo-symbol'}/>);
    }
    if (state === CELL_STATE.X) {
        return (<XIcon className={'xo-symbol'}/>);
    }
    return (<div className={'xo-symbol'}/>);
}

class Cell extends Component {
    constructor (props) {
        super(props);
        this.handleOnMakeMove = this.handleOnMakeMove.bind(this);
    }

    handleOnMakeMove () {
        const { cellId, makeMove } = this.props;
        makeMove({cellId});
    }

    render () {
        const { state, isActive, className } = this.props;
        const isActiveAndNotMarked = state === CELL_STATE.Empty && isActive;
        return (
            <Paper className={className} zDepth={isActiveAndNotMarked ? POPPED_DEPTH : PUSHED_DEPTH}>
                <FlatButton 
                    className={'expand-100 font-100'}
                    onClick={this.handleOnMakeMove}
                    label={renderCellState(state)}
                    disabled={!isActiveAndNotMarked}
                />
            </Paper>
        );
    }
}

export default connect({
    makeMove: signal`makeMove`
}, Cell);
