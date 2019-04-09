import Red from '../framework';
import './components';

window.onload = function () {
    const game = new Red.Game( { width : 540, height : 960, maxWidth : 720, resizeType : Red.RESIZE_TYPE.responsive } );
    Red.Preloader.loadPreload( './assets/preload.json', ( resources )=> {
        game.resources = resources;

        game.load( resources['scene'].data );
    });
};

