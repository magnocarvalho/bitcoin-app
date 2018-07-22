# Bitcoin App

Aplicativo desenvolvido em __Xamarin.Forms__.

Bibliotecas utilizadas:
* [Microcharts](https://github.com/aloisdeniel/Microcharts)
* [Newonsoft](https://github.com/JamesNK/Newtonsoft.Json)
* [SQLite-net](https://github.com/praeclarum/sqlite-net)
* [Unity](https://github.com/unitycontainer/unity)
* [Conectify Plugin](https://github.com/jamesmontemagno/ConnectivityPlugin)
* [Xamarin Forms Labs](https://github.com/XLabs/Xamarin-Forms-Labs)

## O que há de novo

* O App voltou a funcionar. \o/
* Internacionalização: os textos e datas do App estão em Inglês e Português, e acordo com o idioma do dispositivo.
* Agora o App tem um ícone bonitão :heart:
* Foi implementada uma listagem das cotações diárias do Bitcoin, informando inclusive se o valor subiu ou caiu, de acordo com o dia anterior.


## Screenshots
![Tela inicial do app com a cotação atual do Bitcoin e um gráfico com a sua evolução](https://gitlab.com/lucasfcoelho1/bitcoin-app/blob/master/BitcoinApp/Screenshots/home.png "Tela incial do App")

![Tela de listagem das cotações com a diferença de um dia pro outro](https://gitlab.com/lucasfcoelho1/bitcoin-app/blob/master/BitcoinApp/Screenshots/list.png "Tela de listagem do App")


### Problemas conhecidos

1. ~~Por algum problema com a injeção de dependência na classe __App.xaml.cs__ o app parou de funcionar na sua última versão =(. [Vide branch dev2]~~ Por 'gastar' muito tempo tentando consertar este erro, os seguintes itens não foram concluídos:
   1. ~~Faltou uma listagem com os valores das cotações diárias, que seria chamada ao clicar no botão "Mais opções da MainPage"~~
   1. ~~Internacionalização, faltou a criação dos AppResources para formatar as datas e exibir as mensagens em outros idiomas~~
   1. Alguns métodos e propriedades ficaram 'sobrando' no projeto. Não tive tempo de dar um refinamento.
   1. ~~O ícone do App é o default do Xamarin~~
   1. Não tem nenhum teste unitário =(




