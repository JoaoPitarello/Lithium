NOME DA DUPLA: João Pedro Pitarello de Abreu Vicente e Isabela Frata Santos

EXPLICAÇÃO DO CÓDIGO:

controller fornecedor:
A FornecedorController é a parte do sistema que controla o cadastro de fornecedores. Ela funciona como um “meio de campo” entre a tela (View) onde o usuário preenche os dados e o banco de dados onde essas informações serão salvas.
Logo no começo, ela recebe a configuração do projeto (IConfiguration) para conseguir acessar a connection string

CadastrarForn() - Esse método é chamado quando o usuário abre a página de cadastro de fornecedor. Ele simplesmente retorna a View.

CadastrarForn(Fornecedor fornecedor) - Esse método é acionado quando o usuário envia o formulário. Ele faz o seguinte passo a passo:
1. Verifica se os dados enviados são válidos usando ModelState.IsValid
2. Pega a connection string do banco
3. Abre uma conexão com o MySQL usando MySqlConnection
4. Dentro do try/catch, ele prepara um comando SQL INSERT para inserir o novo fornecedor na tabela tbFornecedor
5. Passa os dados do objeto Fornecedor para os parâmetros do SQL
6. xecuta o comando com ExecuteNonQuery()
7. Se tudo funcionar, o usuário é redirecionado para a página inicial (RedirectToAction("Index", "Home"))


controller funcionário:
A FuncionarioController é responsável por todo o fluxo de cadastro de funcionários. Ela faz a ponte entre a tela onde o usuário preenche os dados e o banco de dados onde essas informações serão armazenadas. 
Logo no início, ela recebe a IConfiguration, que serve para buscar a connection string do banco de dados.

CadastrarFun() - Esse método é chamado quando o usuário abre a página de cadastro de funcionário. Ele simplesmente retorna a View.

CadastrarFun(Funcionario funcionario) - Esse é o método que processa o envio do formulário. O fluxo dele é o mesmo da anterior.


controller login:
A LoginCliController é a parte do sistema responsável pelo cadastro de clientes. Apesar do nome “Login”, ela basicamente funciona como uma controller de cadastro de cliente, seguindo o padrão MVC: recebe os dados da View, valida e envia para o banco.
Logo no início, ela recebe a IConfiguration, que é usada para ler a connection string do banco de dados.

CadastrarCli() - Esse método só exibe a tela de cadastro de clientes. Quando o usuário acessa a página, o sistema mostra a View correspondente ao formulário.

CadastrarCli(Cliente cliente) - Esse método processa o envio do formulário após o usuário preencher. Ele funciona da mesma forma do anterior.


controller material:
A MaterialController é a parte do sistema responsável pelo cadastro de materiais. Ela segue o padrão MVC, funcionando como a ponte entre a tela onde o usuário preenche os dados do material e o banco de dados onde esses dados serão registrados.
No construtor, a controller recebe a IConfiguration, que é usada para acessar a connection string do banco.

CadastrarMat() - Esse método apenas exibe a página de cadastro. Quando o usuário abre a tela de “Cadastrar Material”, essa ação retorna a View.

CadastrarMat(Material material) - Esse método recebe e processa os dados enviados pelo formulário. O fluxo dele é o mesmo do anterior.


controller produção:
A ProducaoController é responsável por cadastrar uma produção nova no sistema. Ela tem acesso à configuração do projeto para pegar a string de conexão com o banco de dados.

CadastrarProdu() - Simplesmente retorna a view.

CadastrarProdu(Producao producao) - Segue o mesmo fluxo dos anteriores.


controller produto:
A ProdutoController cuida do cadastro de novos produtos no sistema. Ela recebe a configuração do projeto para conseguir acessar a string de conexão com o banco de dados.

Cadastrar() - Retorna a view.

Cadastrar(Produto produto) - recebe o objeto produto com as informações preenchidas. Segue o mesmo fluxo das anteriores.


controller venda:
A VendaController é responsável por registrar uma nova venda no sistema.

CadastrarVend() - retorna a view.

CadastrarVend(Venda venda) - ecebe o objeto venda com todas as informações e segue o fluxo das anteriores.



Todas as páginas de Model seguem a mesma estrutura:
representam as informações necessárias para registrar uma produção dentro do sistema. Elas funciona como um "molde" que define quais dados o usuário deve preencher no formulário. Elas validam os dados e definem como as informações vão ser mostradas.


E as views seguem a mesma estrutura, apresentando ao usuário uma interface para a inserção dos dados.
