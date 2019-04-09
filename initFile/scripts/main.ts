import Red from '../framework';
import './components';
import '../framework/scripts/etc/version';

window.onload = function () {
    PIXI.utils.skipHello();
    const game = new Red.Game( { width : 540, height : 960, maxWidth : 720, resizeType : Red.RESIZE_TYPE.responsive } );
    Red.Preloader.loadPreload( './assets/preload.json', ( resources )=> {
        game.resources = resources;

        game.load( resources['scene'].data );
    });
};

