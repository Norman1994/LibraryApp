const { defineConfig } = require('@vue/cli-service')
    // module.exports = defineConfig({
    //   transpileDependencies: true
    // })

module.exports = {

    // css: {
    //     loaderOptions: {
    //         sass: {
    //             additionalData: `@import "~@/App.scss"; `

    //         }
    //     }
    // },
    devServer: {
        proxy: {
            '': {
                target: 'https://localhost:5001',
                ws: true,
                changeOrigin: true
            }
        }
    }
}