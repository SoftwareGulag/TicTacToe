import SendMakeMoveRequest from '../action/sendMakeMoveRequest';
import MapMakeMoveRequestResponseToState from '../action/mapMakeMoveRequestResponseToState';

const MakeMoveChain = [SendMakeMoveRequest, MapMakeMoveRequestResponseToState];

export default MakeMoveChain;