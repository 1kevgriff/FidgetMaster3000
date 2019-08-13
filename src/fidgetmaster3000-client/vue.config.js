const path = require("path");

module.exports = {
    configureWebpack: {
        optimization: {
            splitChunks: {
                minSize: 10000,
                maxSize: 200000,
            }
        },
    },
    outputDir: path.resolve(__dirname, "../FidgetPro.Fidgetmaster.Web/wwwroot")
}