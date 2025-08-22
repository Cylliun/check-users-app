   import { defineConfig } from 'vite';
   import { resolve } from 'path';

   export default defineConfig({
     root: resolve(__dirname, 'src'), // Define a pasta 'src' como raiz do projeto
     build: {
       outDir: resolve(__dirname, 'dist'), // Define a pasta 'dist' como saída da build
     },
     server: {
       port: 3000, // Define a porta do servidor de desenvolvimento
     },
     resolve: {
       alias: {
         '@': resolve(__dirname, 'src'), // Define um alias para a pasta 'src'
       },
     },
   });