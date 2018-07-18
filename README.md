# Bitcoin App

Aplicativo desenvolvido em __Xamarin.Forms__.

Bibliotecas utilizadas:
* [Microcharts](https://github.com/aloisdeniel/Microcharts)
* [Newonsoft](https://github.com/JamesNK/Newtonsoft.Json)
* [SQLite-net](https://github.com/praeclarum/sqlite-net)
* [Unity](https://github.com/unitycontainer/unity)
* [Conectify Plugin](https://github.com/jamesmontemagno/ConnectivityPlugin)
* [Xamarin Forms Labs](https://github.com/XLabs/Xamarin-Forms-Labs)

### Problemas conhecidos

1. Por algum problema com a injeção de dependência na classe __App.xaml.cs__ o app parou de funcionar na sua última versão =(. Por 'gastar' muito tempo tentando consertar este erro, os seguintes itens não foram concluídos:
   1. Faltou uma listagem com os valores das cotações diárias, que seria chamada ao clicar no botão "Mais opções da MainPage"
   1. Internacionalização, faltou a criação dos AppResources para formatar as datas e exibir as mensagens em outros idiomas
   1. Não tem nenhum teste unitário =(


