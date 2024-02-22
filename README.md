# DevFreela

<p>O projeto DevFreela foi realizado durante o curso de Formação em ASP Net Core afim de aperfeiçoar minhas habilidades na construção de APIs. Ele consiste em dois serviços (um de projetos e um de pagamentos) que se comunicam entre sí. </p>

### Descrição
<p>Plataforma para cadastro e contratação de serviços de Freelancer de desenvolvedores no formato de API. Oferece uma plataforma unificada para os clientes contratarem os melhores freelancers para seus projetos, de maneira confiável e gerenciada.</p>

### Entidades

<h3>User</h3>

- ID (int)
- FirstName (string)
- LastName (string)
- Email (string)
- Skills (list of skill)
- OwnedProjects (list of project)
- FreelancerProjects (list of project)

<h3>Project</h3>

- ID (int)
- Title (string)
- Description (string)
- IdClient (int)
- IdFreelancer (int)
- TotalCost (decimal)
- StartedAt (datetime)
- FinishedAt (datetime)
- Comments (list of comment)

<h3>Skill</h3>

- Description (string)

<h3>Comment</h3>

- ID (int)
- IdProject (int)
- IdUser (int)
- Content (string)


### Pilha de tecnologias

- .NET 8.0
- Entity Framework Core 8.0

### Regras de negócio
- [x] Um projeto não pode ser iniciado caso já tenha sido finalizado;
- [x] Um projeto não pode ser finalizado caso já tenha sido iniciado;
- [x] Ao criar um projeto, o título e a descrição são obrigatórios;
- [x] O usuário é obrigado a informar pelo menos uma habilidade ao se cadastrar;
- [x] O email deve ser único para cada usuário na plataforma;
- [x] Um usuário pode ser tanto cliente quanto freelancer, mas não pode ser ambos em um mesmo projeto;

### Conceitos aplicados

- [x] Utilizar docker para gerenciar os serviços e os bancos de dados;
- [x] Aplicar documentação de APIs com o Swagger
- [x] Arquiteturar camadas da arquitetura limpa
- [x] Aplicar ORM EfCore nas entidades
- [x] Arquiteturar o padrão CQRS no projeto
- [x] Arquiteturar o padrão Repository nas entidades do projeto
- [x] Aplicar validação de APIs com middleware global na camada Application
- [x] Aplicar autenticação com JWT
    - [x] Criar funcão para gerar token JWT
    - [x] Gerar migrations com dados de Login;
    - [x] Computar o SHA256 ao salvar a senha no banco de dados (salvar a role também);
    - [x] Implementar o login nos serviços;
    - [x] Configurar as permissões por recurso e por papel;
- [x] Aplicar testes unitários com o NSubstitute:
    - [x] Entender o que é um Mock;
    - [x] Entender correspondencia de argumentos;
    - [x] Criar dois testes utilizando o NSubstitute;
- [ ] Criar um serviço de pagamento para o serviço de projetos
    - [x] Criar uma abstração de pagamentos no serviço de projetos;
    - [x] Criar uma conexão entre o serviço de projetos e pagamentos via HTTP;
    - [x] Criar um repositório para salvar os pagamentos em um banco de dados MySQL;
    - [ ] Criar uma conexão entre o serviço de projetos e pagamentos via mensagens (RabbitMQ);
      - [ ] No serviço de projetos, criar a conexão com as filas RabbitMQ e publicar uma mensagem de pagamento ao finalizar projeto;
      - [ ] No serviço de pagamentos, criar um background service para consumir as mensagens de pagamentos; 
        - [ ] Caso seja realizado com sucesso, enviar uma mensagem para uma fila de "Pagamentos aprovados";
        - [ ] Caso seja realizado com falha, enviar uma mensagem para uma fila de "Pagamentos reprovados";
      - [ ] No serviço de projetos, consumir as mensagens das filas aprovados e reprovados, e realizar alteração correspondente no projeto;
- [ ] Aplicar conceitos de DevOps com o Azure

### Linkedin

- [ ] Realizar publicação
