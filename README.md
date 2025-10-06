# MetodosOrdenacao

Este repositório tem a intenção de mostrar um comparativo entre os seguintes métodos de ordenação:

- Bubble Sort
- Selection Sort
- Insertion Sort
- Quick Sort

Para executar o backendo rode os seguintes comandos:

```
dotnet build ./backend/MetodosOrdenacao.sln
dotnet run --project ./backend/MetodosOrdenacao/MetodosOrdenacao.csproj
```

Exemplo da aplicação rodando (frontend e backend):
<img width="1279" height="851" alt="image" src="https://github.com/user-attachments/assets/6230b083-5983-4d8b-8f28-f301b4f82f6a" />

## Problemas conhecidos

1. Ao executar várias vezes a mesma sequência de caracteres o programa não é capaz de verificar que a mesma sequência de caracteres (com o mesmo número de letras) foi rodada, duplicando a entrada no gráfico;
2. Ao aumentar muito a quantidade de caracteres o backend começa a quebrar por conta de uma exceção ao rodar o método de ordenação "BubbleSort", muito possivelmente o problema está nas chamadas recursivas que esse método faz;
