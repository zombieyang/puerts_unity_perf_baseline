const fs = require('fs');
const path = require('path');
const pwd = process.cwd();

const { program } = require('commander');
const xmljs = require('xml-js');

if (require.main === module) {
    program.parse()
    parseResult(path.join(pwd, program.args[0]));

} else {
    exports.parseResult = parseResult;
}

function parseResult(xmlPath) {
    const xmlResultPath = xmlPath;
    const resultFileContent = fs.readFileSync(xmlResultPath, 'utf-8');
    const json = xmljs.xml2js(resultFileContent, { compact: false, spaces: 4 });
    formatPrint(iterateXMLNode(json));
    // fs.writeFileSync(xmlResultPath + ".json", JSON.stringify(iterateXMLNode(json)));
    
    function iterateXMLNode(xmlNode) {
        const ret = {};
        if (xmlNode.attributes?.type == "TestSuite") {
            ret.type = 'test-suite'
            ret.name = xmlNode.attributes.name;
        }
        if (xmlNode.attributes?.type == "TestFixture") {
            ret.type = 'test-fixture'
            ret.name = xmlNode.attributes.name;
        }
        if (xmlNode.attributes?.type == "Assembly") {
            ret.type = 'assembly'
            ret.name = xmlNode.attributes.name;
        }
    
        if (xmlNode.name == "test-case") {
            ret.type = 'test-case'
            ret.name = xmlNode.attributes.fullname;
            ret.result = xmlNode.attributes.result
            ret.avg = xmlNode.elements.find(item => item.name == 'output')?.elements[0].cdata.match(/Avg:([\d\.]+)/)[1];
    
        } else {
            const elements = xmlNode.elements?.map(node => {
                return iterateXMLNode(node);
            }).filter(n => n);
            if (elements?.length) {
                ret.elements = elements;
            }
        }
        return Object.keys(ret) == 0 ? null : ret;
    }
    function formatPrint(jsonNode, layer = 0) {
        if (!jsonNode.type) {
            jsonNode.elements.forEach(element => {
                formatPrint(element, layer)
            })
    
        } else {
            if (
                jsonNode.type == 'test-suite' ||
                jsonNode.type == 'assembly' ||
                jsonNode.type == 'test-fixture'
            ) {
                console.log(makeIndent(layer) + jsonNode.name + ":");
            }
    
            if (jsonNode.type == 'test-case') {
                console.log(makeIndent(layer) + jsonNode.result + " - " + jsonNode.name + " - " + "avg: " + (jsonNode.avg || 0))
            }
            jsonNode.elements?.forEach(element => {
                formatPrint(element, layer + 1)
            })
        }
    }
    function makeIndent(number) {
        let ret = '';
        for (let i = 0; i < number; i++) {
            if (i == number - 1) ret += '|- '
            else ret += '  '
        };
        return ret;
    }
}