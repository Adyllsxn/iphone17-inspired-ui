# 📘 Dicionário de Dados – Sistema Kairos

## 🧑‍💼 Tabela: Tbl_Usuario

| Campo         | Descrição                               | Tipo de Dados | Tamanho     | Obrigatório | Chave Primária | Chave Estrangeira | Observações                                        |
|---------------|-----------------------------------------|---------------|-------------|-------------|----------------|-------------------|--------------------------------------------------|
| id            | Identificador único do usuário          | INT           | -           | Sim         | Sim            | Não               | Auto incremento                                   |
| nome          | Nome do usuário                         | NVARCHAR      | 50         | Sim         | Não            | Não               |                                                  |
| sobrenome     | Sobrenome do usuário                    | NVARCHAR      | 50         | Sim         | Não            | Não               |                                                  |
| email         | E-mail do usuário                       | NVARCHAR      | 250         | Sim         | Não            | Não               | Deve ser único                                   |
| fotoUrl       | URL da imagem de perfil                 | NVARCHAR(MAX) | -           | Não         | Não            | Não               |                                                  |
| perfilId      | ID do perfil do usuário                 | INT           | -           | Sim         | Não            | Sim               | FK para `Tbl_Perfil`                             |
| dataCadastro  | Data do cadastro do usuário             | DATETIME      | -           | Sim         | Não            | Não               |                                                  |
| isActive      | Indica se o usuário está ativo          | BIT           | -           | Sim         | Não            | Não               | 1 (ativo), 0 (inativo)                            |
| passwordHash  | Hash da senha                           | NVARCHAR(MAX) | -           | Sim         | Não            | Não               | Armazenamento seguro                             |
| passwordSalt  | Salt da senha                           | NVARCHAR(MAX) | -           | Sim         | Não            | Não               |                                                  |
| telefone      | Telefone do usuário                     | NVARCHAR      | 20          | Não         | Não            | Não               |                                                  |
| BI            | Número de BI (identificação pessoal)    | NVARCHAR      | 50          | Não         | Não            | Não               |                                                  |

---

## 🧾 Tabela: Tbl_Perfil

| Campo | Descrição                  | Tipo de Dados | Tamanho | Obrigatório | Chave Primária | Observações                          |
|-------|----------------------------|---------------|---------|-------------|----------------|--------------------------------------|
| id    | Identificador do perfil    | INT           | -       | Sim         | Sim            | Auto incremento                      |
| nome  | Nome do perfil             | NVARCHAR      | 50      | Sim         | Não            | Ex: Administrador, Organizador, etc. |

---

## 🎭 Tabela: Tbl_TipoEvento

| Campo | Descrição                      | Tipo de Dados | Tamanho | Obrigatório | Chave Primária | Observações                          |
|-------|--------------------------------|---------------|---------|-------------|----------------|--------------------------------------|
| id    | ID do tipo de evento           | INT           | -       | Sim         | Sim            | Auto incremento                      |
| nome  | Nome do tipo de evento         | NVARCHAR      | 50      | Sim         | Não            | Ex: Culto, Vigília, etc.             |

---

## 📅 Tabela: Tbl_Evento

| Campo           | Descrição                                | Tipo de Dados | Tamanho     | Obrigatório | Chave Primária | Chave Estrangeira | Observações                                           |
|-----------------|------------------------------------------|---------------|-------------|-------------|----------------|-------------------|-------------------------------------------------------|
| id              | Identificador do evento                  | INT           | -           | Sim         | Sim            | Não               | Auto incremento                                        |
| titulo          | Título do evento                         | NVARCHAR      | 100         | Sim         | Não            | Não               |                                                       |
| descricao       | Descrição do evento                      | NVARCHAR(MAX) | -           | Sim         | Não            | Não               |                                                       |
| dataHoraInicio  | Data/hora de início                      | DATETIME      | -           | Sim         | Não            | Não               |                                                       |
| dataHoraFim     | Data/hora de fim                         | DATETIME      | -           | Sim         | Não            | Não               |                                                       |
| local           | Local do evento                          | NVARCHAR      | 250         | Sim         | Não            | Não               |                                                       |
| tipoEventoId    | ID do tipo de evento                     | INT           | -           | Sim         | Não            | Sim               | FK para `Tbl_TipoEvento`                              |
| usuarioId       | ID do organizador                        | INT           | -           | Sim         | Não            | Sim               | FK para `Tbl_Usuario`                                 |
| statusAprovacao | Status de aprovação                      | NVARCHAR      | 20          | Sim         | Não            | Não               | Valores: Aprovado, Rejeitado, Pendente                |
| imagemUrl       | URL da imagem do evento                  | NVARCHAR(MAX) | -           | Não         | Não            | Não               | Pode conter panfleto, banner, etc.                    |

---

## 🎟️ Tabela: Tbl_Presenca

| Campo           | Descrição                               | Tipo de Dados | Tamanho | Obrigatório | Chave Primária | Chave Estrangeira | Observações                               |
|-----------------|-----------------------------------------|---------------|---------|-------------|----------------|-------------------|-------------------------------------------|
| id              | Identificador da presença               | INT           | -       | Sim         | Sim            | Não               | Auto incremento                          |
| usuarioId       | ID do usuário presente                  | INT           | -       | Sim         | Não            | Sim               | FK para `Tbl_Usuario`                    |
| eventoId        | ID do evento                            | INT           | -       | Sim         | Não            | Sim               | FK para `Tbl_Evento`                     |
| confirmado      | Indica se a presença foi confirmada     | BIT           | -       | Sim         | Não            | Não               | 1 = confirmado, 0 = não confirmado        |
| dataHoraCheckin | Data/hora do check-in                   | DATETIME      | -       | Não         | Não            | Não               | Opcional dependendo do fluxo do sistema  |

---

## 📝 Tabela: Tbl_Blog

| Campo          | Descrição                          | Tipo de Dados | Tamanho     | Obrigatório | Chave Primária | Chave Estrangeira | Observações                           |
|----------------|------------------------------------|---------------|-------------|-------------|----------------|-------------------|---------------------------------------|
| id             | Identificador do post              | INT           | -           | Sim         | Sim            | Não               | Auto incremento                      |
| usuarioId      | Autor do post                      | INT           | -           | Sim         | Não            | Sim               | FK para `Tbl_Usuario`                |
| titulo         | Título do post                     | NVARCHAR      | 100         | Sim         | Não            | Não               |                                      |
| conteudo       | Conteúdo do post                   | NVARCHAR(MAX) | -           | Sim         | Não            | Não               | Pode conter HTML                     |
| imagemCapaUrl  | URL da imagem de capa              | NVARCHAR(MAX) | -           | Não         | Não            | Não               | Opcional                             |
| dataPublicacao | Data de publicação                 | DATETIME      | -           | Sim         | Não            | Não               |                                      |
| status         | Status do post                     | NVARCHAR      | 20          | Sim         | Não            | Não               | Ex: Publicado, Rascunho, Rejeitado   |
