# Processamento de Imagens HSI e Conversão para CMY (C#)

Este projeto implementa diversas operações de processamento de imagem no espaço de cores HSI, usando C#. Em particular, permite ajustar interativamente os canais de **Matiz (Hue)**, **Saturação (Saturation)** e **Intensidade (Intensity)** de uma imagem, além de converter cada pixel para o modelo de cores subtrativas **CMY** (Ciano, Magenta, Amarelo) como complemento de RGB. O projeto também gera imagens em escala de cinza para cada canal H, S e I, facilitando a visualização da contribuição individual de cada componente【20†L321-L324】. Em outras palavras, além de exibir a imagem original e processada, o programa apresenta em tons de cinza o conteúdo de cada canal do modelo HSI.

【15†embed_image】 *Figura 1: Diagrama do espaço de cores HSI. A Matiz (H) é representada por um ângulo em 0–360°, a Saturação (S) pela distância ao eixo central, e a Intensidade (I) pelo eixo vertical【13†L73-L79】. Cores puras (vivas) têm alta saturação, enquanto cores mais acinzentadas têm baixa saturação【13†L73-L79】【2†L128-L132】.*

## Funcionalidades Principais

- **Ajuste de Matiz, Saturação e Intensidade (HSI):** Permite modificar cada componente do espaço de cores HSI de forma independente【13†L73-L79】. A *matiz* indica o tom de cor (ex.: 0°=vermelho, 120°=verde, 240°=azul)【13†L73-L79】, a *saturação* indica a “pureza” da cor (0% = cinza, 100% = cor vibrante)【2†L128-L132】, e a *intensidade* (ou brilho) representa o valor de luminância da imagem. Em termos práticos, o canal I é calculado como a média dos valores RGB e controla o quão clara ou escura é a imagem【2†L128-L132】.  
- **Conversão RGB → CMY:** Cada pixel é convertido para o modelo CMY como complemento subtrativo do RGB:  
  \[
    C = 1 - R,\quad M = 1 - G,\quad Y = 1 - B
  \]  
  (assumindo canais normalizados de 0 a 1)【8†L179-L187】. Em outras palavras, as cores *ciano*, *magenta* e *amarelo* são os complementos das componentes R, G, B respectivamente【8†L179-L187】. Essa conversão é útil por exemplo em aplicações de impressão de cores, onde CMY representa pigmentos que absorvem luz.  
- **Geração de Canais em Tons de Cinza:** O projeto extrai os canais H, S e I de uma imagem e converte cada um para uma imagem em escala de cinza, onde o brilho de cada pixel reflete o valor da componente correspondente. Por exemplo, na imagem do canal de Saturação, pixels altamente saturados aparecerão claros e os pouco saturados aparecerão escuros. Essa visualização facilita a análise de como cada componente contribui para a imagem original【20†L321-L324】.  

## Como Usar

1. **Clone o repositório:**  
   ```
   git clone <URL-do-repositório>
   ```  
2. **Abra o projeto:** Abra a solução em uma IDE compatível (ex.: Visual Studio) ou use a CLI do .NET.  
3. **Compile e execute:** Por exemplo, usando .NET CLI:  
   ```
   dotnet build
   dotnet run -- <caminho-para-imagem>
   ```  
4. **Ajuste as configurações:** No programa, carregue uma imagem de entrada. Ajuste os controles deslizantes para Matiz, Saturação e Intensidade, ou escolha converter para CMY. O programa exibirá a imagem resultante, bem como as imagens em escala de cinza dos canais H, S e I correspondentes.  
5. **Exemplos de uso:**  

   - Para modificar a matiz de uma imagem mantendo brilho e saturação, mova o slider de Matiz.  
   - Para visualizar o canal de saturação isoladamente, acione a opção de visualizar canais HSI em tons de cinza.  
   - Para obter o complemento subtrativo de CMY de uma imagem RGB, selecione a conversão RGB→CMY.  

Cada operação altera dinamicamente a imagem exibida, tornando possível comparar lado a lado a imagem original e a processada.  

## Exemplo de Saída

【33†embed_image】 *Figura 2: Exemplo de saída do processamento. À esquerda, imagem do canal **Matiz (H)** em tons de cinza; no centro, canal **Saturação (S)**; à direita, canal **Intensidade (I)**. Note que cada imagem destaca diferentes aspectos de cor: o canal H ilustra zonas de cores distintas, o canal S mostra a vivacidade das cores, e o canal I revela variações de brilho【20†L323-L325】.*  

Nesta figura, retiramos os canais H, S e I de uma imagem de exemplo (um cachorro de camisa havaiana) e mostramos cada canal em uma imagem monocromática. O canal de Matiz (esquerda) enfatiza as bordas e contornos das áreas coloridas; o canal de Saturação (centro) destaca regiões vivas (camisa colorida) em branco e regiões pouco saturadas (fundo cinza) em escuro; o canal de Intensidade (direita) corresponde à versão em níveis de cinza da imagem original, onde áreas claras aparecem mais claras【20†L323-L325】.

## Tech Stack

- **Linguagem:** C# (dotnet)  
- **Framework:** .NET 6+ (pode ser .NET 7 ou superior)  
- **Bibliotecas:** System.Drawing (ou equivalente) para manipulação de imagens, além de eventuais bibliotecas de UI (WinForms, WPF) se houver interface gráfica.  
- **Plataforma:** Windows (aplicação desktop) ou compatível com .NET.  

## Autores

- [@GabrielPissininMenossi](https://github.com/GabrielPissininMenossi)  
- [@MthsAmaral](https://github.com/MthsAmaral)  
- [@matheusmen1](https://github.com/matheusmen1)  

## Licença

Este projeto está licenciado sob a Licença MIT (arquivo [LICENSE](LICENSE) incluído no repositório).

## Referências

- *Krita Manual – Modos de cor HSI*【13†L73-L79】  
- *Notas de aula sobre modelos de cor HSI*【2†L124-L132】  
- *GeeksForGeeks – HSI Color Space*【11†L111-L117】  
- *Slides de Processamento de Imagens – Modelo CMY*【8†L179-L187】  
- *Online PNG Tools – Conversão de PNG para HSI* (descrição de extração de canais)【20†L321-L324】  

Estas referências explicam os fundamentos dos modelos de cor RGB, HSI e CMY, bem como a separação e visualização dos canais H, S e I em tons de cinza, complementando este projeto.
