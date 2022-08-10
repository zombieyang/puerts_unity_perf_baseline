const fs = require('fs');
const path = require('path')
const pwd = process.cwd();

if (!fs.existsSync(`${pwd}/package.json`) || !fs.existsSync(`${pwd}/unity-project`)) {
    console.error("[Puer] invalid directory, please run in the root of puerts-unity-perf-baseline");
    process.exit(1);``
}
if (!fs.existsSync(`${pwd}/node_modules`)) {
    console.log("[Puer] installing node_modules");
    require('child_process').execSync('npm i')
}

const sx = require('shelljs');
const { program, Option } = require('commander');
const runConfig = JSON.parse(fs.readFileSync(`${__dirname}/run-config.json`, 'utf-8'));

program.addOption(
    new Option("--unity <profileOrPath>", "The Unity binary")
        .default("lastUse")
)
program.addOption(
    new Option("--upm <version>", "The Using version of puerts")
        .default("")
        .conflicts("local")
)
program.addOption(
    new Option("--local <foldername>", "The Using localfolder of puerts")
        .default("")
        .conflicts("upm")
)
program.parse()
const options = program.opts();

console.log("[Puer] finding unity");
let unityPath = "";
if (runConfig.unity[options.unity]) {
    unityPath = runConfig.unity[options.unity];

} else if (path.isAbsolute(options.unity)) {
    unityPath = options.unity

} else {
    console.error("invalid unity path: " + options.unity);
    process.exit(1);
}

runConfig.unity['lastUse'] = unityPath;
fs.writeFileSync(`${__dirname}/run-config.json`, JSON.stringify(runConfig));

const upmSetting = JSON.parse(fs.readFileSync(`${__dirname}/../unity-project/Packages/manifest.json`))
if (options.local || options.upm) {
    let use = "";
    if (options.upm) {
        use = options.upm
    }
    if (options.local) {
        use = `file:../../${options.local}`
    }
    console.log("[Puer] changing puerts version to: " + use);
    upmSetting.dependencies['com.tencent.puerts.core'] = use;
    fs.writeFileSync(`${__dirname}/../unity-project/Packages/manifest.json`, JSON.stringify(upmSetting));
}

console.log("[Puer] running test");
sx.exec(`${unityPath} -batchmode -testPlatform StandaloneWindows64 -projectPath "${pwd}/unity-project" -runTests -testResults "${pwd}/res.xml" -logFile "log.txt"`);
console.log("[Puer] parsing result");
const output = require('./lib/parse-result').parseResult(`${pwd}/res.xml`);

console.log("[Puer] writing file");
sx.mkdir("-p", path.join(pwd, '.test-report'));
fs.writeFileSync(
    path.join(pwd, '.test-report', upmSetting.dependencies['com.tencent.puerts.core'].replace('file:../../', '') + '.txt'), 
    output
);

console.log("[Puer] cleaning");
sx.rm(`${pwd}/res.xml`)
sx.rm(`${pwd}/log.txt`)
sx.rm('-rf', `${pwd}/unity-project/Library`)
sx.rm('-rf', `${pwd}/unity-project/Logs`)