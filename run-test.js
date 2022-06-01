const fs = require('fs');
const pwd = process.cwd();

if (!fs.existsSync(`${pwd}/node_modules`)) {
    console.log("[Puer] installing node_modules");
    require('child_process').execSync('npm i')
}

const sx = require('shelljs');
const { program } = require('commander');

program.parse()
if (!program.args[0]) {
    console.error("[Puer] resultXML path notfound, please run as node run-test.js xxx/unity.exe");
    process.exit();
}
sx.exec(`${program.args[0]} -batchmode -testPlatform StandaloneWindows -projectPath "${pwd}/unity-project" -runTests -testResults "../res.xml" -logFile "log.txt"`);
require('./parse-result').parseResult(`${pwd}/res.xml`);
sx.rm(`${pwd}/res.xml`)
sx.rm(`${pwd}/log.txt`)