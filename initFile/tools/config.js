const root = __dirname + '/../';
const gitPaths = ['./', './framework'];
const buildLogPath = './buildLog/';
const versionPath = buildLogPath + 'lastVersion.json';
const buildPath = './dist/';

const copyDirList = [ './assets/', './css/', './launcher/' ];
const cssSrcPath = 'css/';

module.exports = {
    root,
    gitPaths,
    buildLogPath,
    versionPath,
    buildPath,
    copyDirList,
    cssSrcPath
};