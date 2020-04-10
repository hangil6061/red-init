const execSync = require('child_process').execSync;
const fs = require('fs');
const rimraf = require("rimraf");
const git = require('git-state');

const { dirCopy, addFileMultiEx, writeFileToString, formatDate, getJsonFile, readVersion } = require( './util' );
const { root, gitPaths, buildLogPath, versionPath, buildPath, copyDirList, cssSrcPath } = require('./config');


// const root = __dirname + '/../';
// const gitPaths = ['./', './framework'];
// const buildLogPath = './buildLog/';
// const versionPath = buildLogPath + 'lastVersion.json';
// const buildPath = './dist/';
//
// const copyDirList = [ './assets/', './css/' ];
// const cssSrcPath = 'css/';


async function checkGit( paths ) {
    const checkCount = {
        dirty : 0,
        untracked : 0
    };

    for( let i = 0;i  < paths.length; i++ ) {
        const path = paths[i];
        const isGit = await git.isGitSync( path );
        if( isGit ) {
            const result = await git.checkSync( path );

            if( result.dirty > 0 ) {
                console.error( `커밋되지 않은 파일 발견(${path} : ${result.dirty})` );
            }
            if( result.untracked > 0 ) {
                console.error( `추적되지 않은 파일 발견(${path} : ${result.untracked})` );
            }

            checkCount.dirty += result.dirty;
            checkCount.untracked += result.untracked;
        }
    }

    return checkCount.dirty === 0 && checkCount.untracked === 0;
}

async function lastCommit( paths ) {
    let resultString = "";
    for( let i = 0;i  < paths.length; i++ ) {
        const path = paths[i];
        resultString += "============================================\n";
        resultString += path + "\n";
        resultString += "--------------------------------------------\n";
        let commit = await messageSync( path );
        commit = commit.toString();
        resultString += commit + "\n";
    }
    resultString += "============================================\n";
    return resultString;
}

function messageSync (repo, opts) {
    opts = opts || {};
    return execSync('git log -1 --pretty=fuller', {cwd: repo, maxBuffer: opts.maxBuffer});
}

async function webpack() {
    return execSync('webpack --mode=production --config=webpack.config.prod.js').toString();
}

async function build() {

    console.log( '커밋 상태 확인...' );
    const check = await checkGit( gitPaths );
    if( !check ) {
        console.error( '변경 사항을 커밋 해주세요.' );
        return;
    }

    console.log( '빌드 디렉토리 정리...' );
    rimraf.sync(buildPath);

    try {
        console.log( 'webpack 빌드...' );
        const result = await webpack();
        console.log( result );
    }
    catch (e) {
        console.error( 'webpack 빌드 실패' );
        return;
    }

    for( let i = 0; i < copyDirList.length; i++ ) {
        console.log( copyDirList[i] + '폴더 복사...' );
        const dst = buildPath + copyDirList[i];
        if(!fs.existsSync(dst)){
            fs.mkdirSync(dst);
        }
        dirCopy( copyDirList[i], dst );
    }

    const packageFile = await getJsonFile(root + 'package.json');
    let title = packageFile.name;
    let cssList = "";

    console.log( 'index 파일 작성...' );
    const version = await readVersion( versionPath );
    const versionQuery = `?vs=${version.Major}.${version.Miner}.${version.Patch}`;

    const cssFileList = [];
    addFileMultiEx( root, cssSrcPath, ['css'], cssFileList );

    for( let i= 0;i < cssFileList.length; i++ ) {
        const data = cssFileList[i];
        cssList +=
        `<link href='${data.path}${versionQuery}' rel='stylesheet' type='text/css'>
`;
    }

    const index =
`<!DOCTYPE html>
<html lang="ko">
<head>
    <meta charset="UTF-8">
    <title>${title}</title>
    <meta name="viewport" content="width=device-width, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0">
    ${cssList}
</head>
<body>
    <script src="js/game.js${versionQuery}"></script>
</body>
</html>
`;

    await writeFileToString( buildPath + 'index.html', index );


    console.log( '로그 작성...' );
    const commit = await lastCommit( gitPaths );
    const versionStr = `${version.Major}.${version.Miner}.${version.Patch}`;
    const date = formatDate( new Date(Date.now()) );
    const log =
`빌드 버전
${versionStr}

빌드 날짜
${date}

빌드된 커밋 정보
${commit}
`;

    await writeFileToString( buildLogPath + versionStr + '.txt', log );
    await writeFileToString( versionPath, JSON.stringify( version ) );
    await writeFileToString( buildPath + 'version.json', JSON.stringify({ version : versionStr, title } ));

    console.log( '빌드 완료.' );
}


build();
