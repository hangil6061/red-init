const fs = require( 'fs' );
const FormData = require( 'form-data' );
const request = require('request');

const { getJsonFile, getFileList } = require('./util');

const root = `${__dirname}/../dist/`;
const url = 'http://parkhg.kr:3000/';
// const url = 'http://localhost:3000/';


const list = [];
getFileList( root, '', list );
// const packageFile = getJsonFile(__dirname+'/../package.json');
const versionFile = getJsonFile( root + 'version.json' );
// const version = versionFile.version;

request({
    url: url + 'game/add/',
    method: "POST",
    json: true,
    body: {
        title : versionFile.title
    }
}, function (err, res, body)
{
    if( res.statusCode === 200 ) {
        if( body.version ) {
            if( checkVersion( versionFile.version, body.version )  ) {
                upload();
            }
            else {
                console.log( '이전버전 보다 높아야 합니다.' )
            }
        }
        else {
            upload();
        }
    }
    else {
        console.log( '실패' );
    }
});

function upload() {
    const form = new FormData();
    form.append( 'prj_title', versionFile.title );
    form.append( 'prj_version', versionFile.version );

    for( let i = 0; i < list.length; i++ ) {
        form.append( list[i].path, fs.createReadStream( list[i].fullPath )  );
    }

    form.submit( url + 'uploads/', function ( err, res ) {
        if( res.statusCode === 200 ) {
            console.log( "업로드 완료" );
        }
        else {
            console.log( "업로드 실패" );
        }
    } );

}



//v1 > v2 ?
function checkVersion( v1, v2 ) {
    const v1Arr = v1.split('.');
    const v2Arr = v2.split('.');

    const v1Major = parseInt(v1Arr[0]);
    const v1Miner = parseInt(v1Arr[1]);
    const v1Patch = parseInt(v1Arr[2]);

    const v2Major = parseInt(v2Arr[0]);
    const v2Miner = parseInt(v2Arr[1]);
    const v2Patch = parseInt(v2Arr[2]);

    return v1Major > v2Major ?
        true : (v1Major < v2Major ?
            false : (v1Miner > v2Miner ?
                true : (v1Miner < v2Miner ?
                    false : (v1Patch > v2Patch)
                )));
}
