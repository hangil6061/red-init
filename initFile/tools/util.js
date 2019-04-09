const fs = require('fs');
const path = require('path');

function addFileMultiEx(root, path, extensions, fileList = [] )
{
    try
    {
        if(!fs.existsSync(root + path)){
            fs.mkdirSync(root + path);
        }
        else {
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
                        if( file.indexOf( extensions[i] ) === -1) continue;
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
    }
    catch (e)
    {
        console.log(e);
    }
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

module.exports = {
    writeFileToString,
    stringFormat,
    addFileMultiEx,
    fileCopy,
    dirCopy,
    formatDate
};
