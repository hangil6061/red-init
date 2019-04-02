#!/usr/bin/env node
const path = require("path");
const fs = require("fs");

dirCopy( __dirname + '/../initFile/', path.resolve('./') + '/' );

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

function fileCopy( src, dst )
{
    fs.createReadStream(src).pipe(fs.createWriteStream(dst));
}
