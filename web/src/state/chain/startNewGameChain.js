import SendNewGameRequest from '../action/sendNewGameRequest';
import MapNewGameRequestResponseToState from '../action/mapNewGameRequestResponseToState';

const StartNewGameChain = [SendNewGameRequest, MapNewGameRequestResponseToState];

export default StartNewGameChain;