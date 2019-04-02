import Red from '../framework'
import './components';

const game = new Red.Game( { width : 540, height : 960, maxWidth : 720, resizeType : Red.RESIZE_TYPE.responsive } );
Red.Preloader.loadPreload( './assets/preload.json', ( resources )=> {
    game.load( resources['scene'].data );
});
