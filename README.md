# ucl-davi-felipe

Fernunes CO.

  Olá, fizemos um programa a partir do vscode de compra de ingressos, registro de eventos e impressão do mesmo.
  
  Primeiramente começamos com a classe "Evento que basicamente a gente só declarou e preenchou com as propriedades Nome, Valor do ingresso, idade minima(definimos que para fazer qualquer compra a idade miníma exigida seria de 13 anos) para a compra do mesmo e quantidade de ingressos pra ver se possui em estoque. Logo após aplicamos o método booleano para verificar primeiramente se tem ingressos disponíveis, logo após adicionamos um "if" para verificar se a quantidade de ingressos disponíveis é menor ou igual ao número de usuários, caso retorne "false" é porque não há ingressos disponíveis, caso retorne true é pq há sim ingressos a venda. Após isso aplicamos outro método booleano para checar a idade minima, basicamente com as mesmas estruturas, se a idade fornecida pelo usuário for maior ou igual a idade miníma, ele estará apto a comprar o ingresso de determinado evento.
  
  Prosseguimos com a próxima classe chamda "Usuario", que basicamente o mesmo iria preencher qual evento ele iria querer comprar o determinado ingresso, iria colocar também o seu nome, idade miníma e o seu email. Após isso aplicamos o método booleano de novo, porém, dessa vez junto a ele aplicamos também o método "Contains" que verifica se a string espeicificada está dentro da string principal. Após isso aplicamos outro booleano apenas para checar a idade do cadastro que o valor mínimo aceito era de 13 anos assim como foi dito acima, e assim terminamos de construir nossas classes. Para armazenar as informações concedida pelas 2 classes e o programa, e nos retornar o relátorio de ingressos, criamos um banco de dados simples a partir do txt que fica dentro da pasta "dados" do código, em que nelas possuímos um voltando para o eventos e outro para o usuários.
  
  Á partir desse momento iniciamos o arquivo principal ou então o "program" com o método 'namespace' que é usado para agrupar classes e ajudando a organizar o código, logo abaixo no método 'Main', criamos uma
instância da classe "Program" que chama o método "MenuInicial". Embaixo do mesmo iniciamos outro método  que lê um arquivo de texto cujo linhas contêm informações sobre eventos e assim retorna uma lista de objetos
do tipo "Evento", assim utilizamos o File.ReadAllLines para ler todas as linhas do mesmo arquivo especificado e armazena em um vetor ou array de strings, e logo abaixo dela apenas criamos uma lista vazia de objetos do tipo
"Evento".

  Logo após utilizamos a estrutura "foreach" para facilitar a iteração das estruturas, e embaixo ja criamos um novo objeto em "Evento" e após isso utilizamos o "Split" para dividir a linha em substrings usando o ";" e 
armazenar elas em um conjunto de dados. Após isso atribuimos o primeiro valor do vetor "dados" à propriedade "nome do objeto "evento",e pra finalizar utilizamos o "int.parse" para converter a segunda, terceira e quarta substring
para um número inteiro e atribuir à propriedade "Valor", "IdadeMinima" e "QntIngressos" tudo para o objeto "evento" e fechamos ele com um simples return para a lista de eventos.

  Abaixo dele reutilizamos praticamente o código acima inteiro porém dessa vez seria para a lista de usuários, utilizamos outro foreach para a Itera das array de linhas e o mesmo "Split". Como dito anteriormente, dessa vez atri-
buimos os valores das substrings ao objeto "Usuario", convertendo a primeira e a terceira substring para inteiro e atribuindo a "Evento" e "Idade", e a segunda e a quarta substring para "Nome" e "Email", logo abaixo utilizamos
a estrutura ".Add" simplesmeste para adicionar o objeto "Usuário" à lista do mesmo, e por fim fechamos com outro 
return.

  Seguimos o código com outro método booleano e dessa vez utilizando o "StreamWriter" apenas para abrir o arquivo no modo de acréscimo, embaixo nós formatamos os dados do objeto "Evento" em uma string separada
por ";", logo após utilizamos o "writer.WriteLine(linha)" só para ela printar a string formatada no arquivo e por fim, fechamos com mais um "return true" indicando exito na operação.

  Depois disso damos continuidade a outro método booleano só que dessa vez seria referente ao "Usuario", nada de muito novo, reaproveitamos o código inteiro e demos continuidade.
  
  E agora nós iniciamos a "interface" do nosso programa, abrimos com a variável "opcao" com uma string vazia e embaixo iniciamos um loop com o "while" que irá rodar até que a opção digitada seja "0", e logo abaixo pra darmos
realmente inicio a interface apenas abrimos alguns "Console.WriteLines" para personalizar e instruir o usuário a como fazer a inserção de um evento, a comprar um ingresso, a imprimir o relátorio de eventos ou até mesmo a 
sair do programa.

----

Este trecho de código tem o objetivo de facilitar o cadastro de eventos, a compra de ingressos por parte dos usuários e a geração de relatórios sobre os eventos e suas vendas.

O funcionamento central do sistema está baseado em um bloco switch que executa diferentes ações de acordo com a opção escolhida pelo usuário. Ao iniciar, o programa pode sair imediatamente se a opção selecionada for "0". Caso o usuário escolha o "1", o sistema inicia o processo de cadastro de um novo evento, solicitando informações como nome do evento, valor, idade mínima para participação e quantidade de ingressos disponíveis. Há uma verificação para garantir que a idade mínima seja superior a 13 anos. Se os dados forem válidos, o evento é salvo em um arquivo chamado "dados/eventos.txt" e o usuário recebe uma confirmação na tela.

Se a opção selecionada for "2", o sistema permite a compra de ingressos. Ele inicia lendo os eventos armazenados no arquivo "dados/eventos.txt" e exibe uma lista numerada dos eventos disponíveis para o usuário escolher. Após a seleção do evento, o código verifica a validade da escolha e lê os usuários do arquivo "dados/usuarios.txt" para encontrar aqueles que já compraram ingressos para o evento selecionado. Se ainda houver ingressos disponíveis, o sistema solicita informações do usuário, como nome, idade e e-mail, realizando verificações adicionais para garantir que a idade seja apropriada e o e-mail contenha um domínio válido. Se todas as verificações forem bem-sucedidas, os dados do usuário são salvos no arquivo "dados/usuarios.txt" e uma confirmação é exibida na tela.

Na opção "3", o sistema gera um relatório detalhado, lendo os eventos e usuários dos arquivos "dados/eventos.txt" e "dados/usuarios.txt", respectivamente. Ele calcula o total de eventos cadastrados, a quantidade de ingressos adquiridos por evento e o valor monetário arrecadado por cada evento. O relatório também inclui o valor total arrecadado por todos os eventos. Após exibir essas informações, o sistema aguarda que o usuário pressione uma tecla para continuar.

Resumindo, este código proporciona uma maneira eficiente de gerenciar eventos e vendas de ingressos, assegurando que todas as entradas de dados sejam validadas adequadamente e fornecendo relatórios detalhados sobre a atividade dos eventos e suas vendas.
