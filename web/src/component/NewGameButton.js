import React, {Component} from 'react';
import {signal} from 'cerebral/tags';
import {connect} from '@cerebral/react';
import FlatButton from 'material-ui/FlatButton';
import {NEW_GAME_BUTTON} from '../common/text';

const NEW_GAME_BUTTON_STYLE = {width: '100%', height: '100%'};

class NewGameButton extends Component {
    constructor (props) {
        super(props);
        this.handleOnStartNewGame = this.handleOnStartNewGame.bind(this);
    }

    handleOnStartNewGame () {
        this.props.startNewGame({});
    }

    render () {
        return (
            <div>
                <FlatButton 
                    className={'expand-100'} 
                    onClick={this.handleOnStartNewGame} 
                    label={NEW_GAME_BUTTON}
                />
            </div>
        );
    }
}

export default connect({
    startNewGame: signal`startNewGame`
}, NewGameButton);
