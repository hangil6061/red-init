const readLine = require('readline');
const fs = require('fs');

const { writeFileToString } = require('./util');


const r = readLine.createInterface({
    input:process.stdin,
    output:process.stdout
});

r.question("Input Component Name : ", async function(name) {

    const result = await CreateComponent(name);
    r.close();
    if( result ) {
        console.log( '컴포넌트 생성 완료' );
    }
    else {
        console.log( '컴포넌트 생성 실패' );
    }

});

async function CreateComponent( name ) {

    if( name === '' ) return;

    const fullPath = `${__dirname}/../scripts/components/${name}.ts`;
    if( fs.existsSync(fullPath) ) return;

    const dirs = name.split( '/' );
    let path = `${__dirname}/../scripts/components/`;
    let compName = dirs[ dirs.length - 1 ];
    compName = compName.charAt(0).toUpperCase() + compName.slice(1);

    for( let i = 0; i < dirs.length - 1; i++ ) {
        path = `${path}/${dirs[i]}`;
        if( !fs.existsSync(path) ) {
            fs.mkdirSync(path);
        }
    }

    let outPath = '../../';
    for( let i = 1; i < dirs.length; i++ ) {
        outPath += '../';
    }

    const script =
`import Red from "${outPath}framework";

class ${compName} extends Red.Script {
    start() {
    }

    update( delta : number ) {
    }
}

export default ${compName};
`;
    return await writeFileToString( fullPath, script );
}
