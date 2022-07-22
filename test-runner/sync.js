const sx = require('shelljs');
const iconv = require('iconv-lite')
const { program, Option } = require('commander');
const path = require('path')
const fs = require('fs');
const glob = require('glob');
const download = require('download')
program.requiredOption("--version <version>", "the JS backend will be used");
program.addOption(
    new Option("--org <org>", "The Using localfolder of puerts")
        .default("Tencent")
)
program.parse(process.argv);
const options = program.opts();

const TEMP_PATH = `${__dirname}/../.temp`

;(async function() {
    console.log('[Puer] cleaning');
    sx.rm("-rf", TEMP_PATH);
    
    console.log('[Puer] downloading');
    const downV8 = download(`https://github.com/${options.org}/puerts/releases/download/Unity_v${options.version}/PuerTS_V8_${options.version}.tgz`, path.join(TEMP_PATH, 'v8'), { extract: true });
    const downNodeJS = download(`https://github.com/${options.org}/puerts/releases/download/Unity_v${options.version}/PuerTS_Nodejs_${options.version}_EDITOR_ONLY.tgz`, path.join(TEMP_PATH, 'nodejs'), { extract: true });
    await Promise.all([downV8, downNodeJS]);

    console.log('[Puer] merging');
    sx.mkdir("-p", path.join(TEMP_PATH, 'package'));
    sx.cp("-r", path.join(TEMP_PATH, 'v8/Puerts', 'Runtime'), path.join(TEMP_PATH, 'package'));
    sx.cp("-r", path.join(TEMP_PATH, 'v8/Puerts', 'Typing'), path.join(TEMP_PATH, 'package'));
    sx.cp("-r", path.join(TEMP_PATH, 'nodejs/Puerts', 'Editor'), path.join(TEMP_PATH, 'package'));

    glob.sync(path.join(__dirname, '/../package/*').replace(/\\/g, '/')).forEach(filepath=> {
        sx.cp(filepath, path.join(TEMP_PATH, 'package', path.basename(filepath)))
    })
    glob.sync(path.join(__dirname, '/../package/**/*.meta').replace(/\\/g, '/')).forEach(filepath=> {
        const relative = path.relative(path.join(__dirname, '/../package/'), filepath);
        sx.cp(filepath, path.dirname(path.join(TEMP_PATH, 'package', relative)))
    });

    console.log('[Puer] update package.json');
    const packageJSON = JSON.parse(fs.readFileSync(path.join(TEMP_PATH, 'package', 'package.json')));
    packageJSON.version = options.version;
    fs.writeFileSync(
        path.join(TEMP_PATH, 'package', 'package.json'), 
        JSON.stringify(packageJSON),
        'utf-8'
    );

    console.log('[Puer] copying');
    sx.rm('-rf', path.join(__dirname, '/../package/'));
    sx.cp('-r', path.join(TEMP_PATH, 'package'), path.join(__dirname, "/../"))
    
    console.log('[Puer] cleaning');
    sx.rm("-rf", TEMP_PATH);
})()
.catch(err=> console.error(err));