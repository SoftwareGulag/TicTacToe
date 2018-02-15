import React, {Component} from 'react';
import {signal} from 'cerebral/tags';
import {connect} from '@cerebral/react';

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
        return (
            <button onClick={this.handleOnMakeMove}>
                {this.props.state}
            </button>
        );
    }
}

export default connect({
    makeMove: signal`makeMove`
}, Cell);
