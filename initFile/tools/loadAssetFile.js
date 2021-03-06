const { addFileMultiEx, writeFileToString, mkdirSync, readVersion } = require( './util' );
const { versionPath } = require('./config');

let detectExtensions = ['json', 'csv', 'mp3', 'm4a', 'ogg', 'wav', 'fnt', 'png', 'jpg'];
let detectExtensions2 = ['json', 'fnt'];

async function loadAssets2D( root, srcDir, distDir )
{
    root = root || '../';
    srcDir = srcDir || '';
    distDir = distDir || root;
    let preload = {};
    preload.atlas = getFileArr( srcDir + 'atlas/', root, detectExtensions2 );
    preload.csv = getFileArr( srcDir + 'csv/', root );
    preload.data = getFileArr( srcDir + 'data/', root );
    preload.font = getFileArr( srcDir + 'font/', root, detectExtensions2 );
    preload.image = getFileArr( srcDir + 'image/', root );
    preload.json = getFileArr( srcDir + 'json/', root );
    preload.sound = getFileArr( srcDir + 'sound/', root );
    preload.spine = getFileArr( srcDir + 'spine/', root, detectExtensions2 );

    const version = await readVersion( versionPath );
    const versionQuery = `?vs=${version.Major}.${version.Miner}.${version.Patch}`;

    for( let key in preload ) {
        const obj = preload[key];
        for( let i = 0; i < obj.length; i++ ) {
            obj[i].path += versionQuery;
        }
    }

    writeFileToString(distDir + 'preload.json', JSON.stringify( preload, null, 2 ));
}

function getFileArr( path, root, extensions )
{
    extensions = extensions || detectExtensions;
    let fileArr = [];
    addFileMultiEx( root, path, extensions, fileArr );
    return fileArr;
}

const rootDir = __dirname + '/../';
loadAssets2D( rootDir, 'assets/', 'assets/' );
console.log( "에셋파일 생성 완료" );
