const fs = require('fs');
// const path = require('path');

function addFileMultiEx(root, path, extensions, fileList = [] )
{
    try
    {
        mkdirSync( root + path );

        fs.readdirSync(root + path).forEach(function (file)
        {
            let curPath = path + file;

            if( file.indexOf('.git') !== -1)
            {

            }
            else if (!fs.lstatSync(root + curPath).isDirectory())
            {
                for( let i = 0; i < extensions.length; i++ )
                {
                    if( file.indexOf( '.' + extensions[i] ) === -1) continue;
                    fileList.push( { key : file.replace('.' + extensions[i], ''), path : curPath } );
                    break;
                }
            }
            else
            {
                addFileMultiEx( root, curPath + "/", extensions, fileList);
            }
        });
    }
    catch (e)
    {
        console.log(e);
    }
}

function mkdirSync( path ) {
    if(!fs.existsSync(path)){
        fs.mkdirSync(path);
    }
}

function getFileList(root, path, fileList = [] ) {
    fs.readdirSync(root + path).forEach(function (file) {
        const crtPath = `${path}${file}`;
        if (fs.lstatSync(root + crtPath + '/').isDirectory()) {
            getFileList(root, crtPath + '/', fileList);
        }
        else {
            fileList.push({
                path : path,
                fullPath : root + crtPath
            });
        }
    });
}

async function writeFileToString( filePath, str )
{
    try {
        await fs.open(filePath,'w',function(err)
        {
            if( err ) console.log( err );
        });

        await fs.writeFile(filePath, str, function (error)
        {
            if( error ) console.log( error );
        });

        return true;
    }
    catch (e) {
        console.log( e );
        return false;
    }

}

function stringFormat ()
{
    let theString = arguments[0];
    for (let i = 1; i < arguments.length; i++) {
        const regEx = new RegExp("\\{" + (i - 1) + "\\}", "gm");
        theString = theString.replace(regEx, arguments[i]);
    }
    return theString;
}

function fileCopy( src, dst )
{
    fs.createReadStream(src).pipe(fs.createWriteStream(dst));
}

function dirCopy( src, dst )
{
    try
    {
        fs.readdirSync(src).forEach(function (file)
        {
            let curPath = src + file;
            if (!fs.lstatSync(curPath).isDirectory())
            {
                fileCopy( curPath, dst + file )
            }
            else
            {
                if(!fs.existsSync(dst + file)){
                    fs.mkdirSync(dst + file);
                }
                dirCopy( curPath + "/", dst + file + "/");
            }
        });
    }
    catch (e) {
        console.log(e);
    }
}

function formatDate(date) {
    return date.getFullYear() + '.' +
        (date.getMonth() + 1) + '.' +
        date.getDate() + ' ' +
        date.getHours() + ':' +
        date.getMinutes() + ':' +
        date.getSeconds();
}

function getJsonFile(path) {
    if( fs.existsSync( path  ) ) {
        const data = fs.readFileSync( path ).toString();
        return JSON.parse( data );
    }
}

async function readVersion( path ) {
    const dirArr = path.split('/');
    let cPath = '';
    for( let i = 0; i <dirArr.length-1; i++ ) {
        if( dirArr[i] === '.' ) continue;
        cPath += dirArr[i];
        if( !fs.existsSync( cPath ) ) {
            fs.mkdirSync(cPath);
        }
    }

    let version;
    if( fs.existsSync( path ) ) {
        version = JSON.parse( fs.readFileSync( path ).toString() );
        version.Patch++;
        // await util.writeFileToString( versionPath, JSON.stringify( result ) );
    }
    else {
        version = {
            Major : 0,
            Miner : 0,
            Patch : 0
        };
    }

    return version;
}

module.exports = {
    writeFileToString,
    stringFormat,
    addFileMultiEx,
    fileCopy,
    dirCopy,
    formatDate,
    getJsonFile,
    getFileList,
    mkdirSync,
    readVersion
};
