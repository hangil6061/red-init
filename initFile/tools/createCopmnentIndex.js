const { addFileMultiEx, writeFileToString } = require( './util' );

const detectExtensions = ['js', 'ts'];
const fileArr = getFileArr( '', 'scripts/components/'  );


let importString = `import Red from './../../framework';`;
let addString = '';
let exportString = ``;

for( let i = 0; i < fileArr.length; i++ ) {
    const file = fileArr[i];
    if( file.key === 'index' ) continue;

    const compName = file.key.charAt(0).toUpperCase() + file.key.slice(1);
    const dirStr = `'./${file.path.split('.')[0]}';`;

    importString += `
import ${compName} from ${dirStr}`;
    addString += `Red.ComponentManager.Instance.addComponent( '${file.key}', ${compName} );
`;
    exportString += `
    ${compName},`;
}

writeFileToString( './scripts/components/index.ts',
`${importString}

${addString}

export {${exportString}
};`);


function getFileArr( path, root, extensions )
{
    extensions = extensions || detectExtensions;
    let fileArr = [];
    addFileMultiEx( root, path, extensions, fileArr );
    return fileArr;
}