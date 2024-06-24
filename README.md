# ucl-davi-felipe

Fernunes CO.

  Olá, fizemos um programa a partir do vscode de compra de ingressos, registro de eventos e impressão do mesmo.
  
  Primeiramente começamos com a classe "Evento que basicamente a gente só declarou e preenchou com as propriedades Nome, Valor do ingresso, idade minima(definimos que para fazer qualquer compra a idade miníma exigida seria de 13 anos) para a compra do mesmo e quantidade de ingressos pra ver se possui em estoque. Logo após aplicamos o método booleano para verificar primeiramente se tem ingressos disponíveis, logo após adicionamos um "if" para verificar se a quantidade de ingressos disponíveis é menor ou igual ao número de usuários, caso retorne "false" é porque não há ingressos disponíveis, caso retorne true é pq há sim ingressos a venda. Após isso aplicamos outro método booleano para checar a idade minima, basicamente com as mesmas estruturas, se a idade fornecida pelo usuário for maior ou igual a idade miníma, ele estará apto a comprar o ingresso de determinado evento.
  
  Prosseguimos com a próxima classe chamda "Usuario", que basicamente o mesmo iria preencher qual evento ele iria querer comprar o determinado ingresso, iria colocar também o seu nome, idade miníma e o seu email. Após isso aplicamos o método booleano de novo, porém, dessa vez junto a ele aplicamos também o método "Contains" que verifica se a string espeicificada está dentro da string principal. Após isso aplicamos outro booleano apenas para checar a idade do cadastro que o valor mínimo aceito era de 13 anos assim como foi dito acima, e assim terminamos de construir nossas classes. Para armazenar as informações concedida pelas 2 classes e o programa, e nos retornar o relátorio de ingressos, criamos um banco de dados simples a partir do txt que fica dentro da pasta "dados" do código, em que nelas possuímos um voltando para o eventos e outro para o usuários.
  

