const fs = require( 'fs' );
const FormData = require( 'form-data' );
const {getPackageFile, getFileList} = require('./util');

const root = `${__dirname}/../dist/`;
const url = 'http://parkhg.kr:3000/uploads/';
// const url = 'http://localhost:3000/uploads/';


const list = [];
getFileList( root, '', list );
const packageFile = getPackageFile(__dirname+'/../');

const form = new FormData();
form.append( 'prj_title', packageFile.name );

for( let i = 0; i < list.length; i++ ) {
    form.append( list[i].path, fs.createReadStream( list[i].fullPath )  );
}

form.submit( url, function ( err, res ) {
    if( res.statusCode === 200 ) {
        console.log( "업로드 완료" );
    }
    else {
        console.log( "업로드 실패" );
    }
} );

