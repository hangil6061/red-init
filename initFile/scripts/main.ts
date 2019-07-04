import Red from '../framework';
import './components';
import '../framework/scripts/etc/version';

window.onload = function () {
    PIXI.utils.skipHello();
    const game = new Red.Game( { width : 540, height : 960, maxWidth : 720, resizeType : Red.RESIZE_TYPE.responsive } );
    Red.Preloader.loadPreload( './assets/preload.json' + '?vs=' + Math.random(), ( resources, sounds )=> {
        game.resources = resources;

        for( let soundKey in sounds ) {
            if (!sounds.hasOwnProperty( soundKey )) {
                continue;
            }
            game.soundManager.addSound( soundKey, sounds[ soundKey ] );
        }

        game.load( resources['scene'].data );
    });
};

