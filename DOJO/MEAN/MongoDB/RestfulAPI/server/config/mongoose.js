var fs = require("fs");

var path = require("path");

var modelsPath = path.join(__dirname, "./../models");

fs.readdirSync(modelsPath).forEach(file =>{
    if(file.indexOf(".js") >= 0)
        require(modelsPath+"/"+file);
    }
)