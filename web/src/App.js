import React from 'react';
import {connect} from '@cerebral/react';
import {state} from 'cerebral/tags';
import MuiThemeProvider from 'material-ui/styles/MuiThemeProvider';
import {Card, CardActions, CardHeader, CardMedia, CardTitle, CardText} from 'material-ui/Card';
import FlatButton from 'material-ui/FlatButton';
import Board from './component/Board';
import NewGameButton from './component/NewGameButton';

import './App.css';

function App (props) {
    return (
        <div>
            <MuiThemeProvider>
                <Card>
                    {/* <CardHeader
                        title="Tic Tac Toe"
                        subtitle=".net core example"
                        avatar="https://picsum.photos/200/300"
                    /> */}
                    <CardTitle style={{"text-align": "center"}} title={props.gameState} subtitle="Game State" />
                    <Board/>
                    <CardActions>
                      <NewGameButton/>
                    </CardActions>
                </Card>
            </MuiThemeProvider>            
        </div>
    );
}

export default connect({
  gameState: state`app.gameState`
}, App);