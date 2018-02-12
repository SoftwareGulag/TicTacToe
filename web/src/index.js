import React from 'react';
import ReactDOM from 'react-dom';
import registerServiceWorker from './registerServiceWorker';
import { Container } from "@cerebral/react";
import controller from "./state/controller";
import App from './App';
import './index.css';

ReactDOM.render(
(
    <Container controller={controller}>
        <App />
    </Container>
), 
document.getElementById('root'));
registerServiceWorker();
