USE db_dedinfoservices
GO

CREATE TABLE [usuario] (
	ide_usuario bigint IDENTITY(1,1) NOT NULL,
	nome varchar(25) NOT NULL,
	sobrenome varchar(60) NOT NULL,
	guuid varchar(max) NOT NULL,
	email varchar(150) NOT NULL,
	senha varchar(max) NOT NULL,
	dtc_inclusao datetime NOT NULL,
	sts_exclusao bit NOT NULL,
	qtd_acessos bigint NULL,
	dtc_ultimo_acesso datetime NULL,
	ide_perfil int NOT NULL,
  CONSTRAINT [PK_USUARIO] PRIMARY KEY CLUSTERED
  (
  [ide_usuario] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)
)
GO


CREATE TABLE [perfil] (
	ide_perfil int IDENTITY(1,1) NOT NULL,
	nome varchar(25) NOT NULL,
	descricao varchar(150) NOT NULL,
	sts_exclusao bit NOT NULL,
  CONSTRAINT [PK_PERFIL] PRIMARY KEY CLUSTERED
  (
  [ide_perfil] ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

CREATE TABLE [cliente] (
	ide_cliente bigint IDENTITY(1,1) NOT NULL,
	guuid varchar(max) NOT NULL,
	nome varchar(50) NOT NULL,
	sobrenome varchar(60) NULL,
	email varchar(150) NULL,
	telefone bigint NOT NULL,
	is_whatsapp bit NOT NULL,
	dtc_inclusao datetime NOT NULL,
	sts_exclusao bit NOT NULL,
	ide_perfil int NOT NULL,
  CONSTRAINT [PK_CLIENTE] PRIMARY KEY CLUSTERED
  (
  ide_cliente ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO


CREATE TABLE [produto] (
	ide_produto bigint IDENTITY(1,1) NOT NULL,
	guuid varchar(max) NOT NULL,
	nome varchar(50) NOT NULL,
	valor decimal(5,2) NOT NULL,
	codigo_interno bigint NOT NULL,
	codigo_barras bigint NULL,
	descricao varchar(150) NULL,
	dtc_inclusao datetime NOT NULL,
	sts_exclusao bit NOT NULL,
  CONSTRAINT [PK_PRODUTO] PRIMARY KEY CLUSTERED
  (
  ide_produto ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

CREATE TABLE [carrinho] (
	ide_carrinho bigint IDENTITY(1,1) NOT NULL,
	guuid_carrinho varchar(max) NOT NULL,
	guuid_cliente varchar(max) NOT NULL,
	guuid_produto varchar(max) NULL,
	produto_valor_unitario decimal(5,2) NULL,
	desconto int NULL,
	valor_final decimal(5,2) NULL,
	sts_carrinho bit NOT NULL
  CONSTRAINT [PK_CARRINHO] PRIMARY KEY CLUSTERED
  (
  ide_carrinho ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

CREATE TABLE [venda] (
	ide_venda bigint IDENTITY(1,1) NOT NULL,
	guuid_venda varchar(max) NOT NULL,
	guuid_carrinho varchar(max) NOT NULL,
	guuid_cliente varchar(max) NOT NULL,
	guuid_usuario_inclusao varchar(max) NOT NULL,
	valor_total decimal(5,2) NOT NULL,
	qtd_itens int NOT NULL,
	tipo_pagamento int NOT NULL,
	dtc_inclusao datetime NOT NULL,
	sts_exclusao bit NOT NULL,
	sts_venda bit NOT NULL,
  CONSTRAINT [PK_VENDA] PRIMARY KEY CLUSTERED
  (
  ide_venda ASC
  ) WITH (IGNORE_DUP_KEY = OFF)

)
GO

ALTER TABLE [usuario] WITH CHECK ADD CONSTRAINT [usuario_fk0] FOREIGN KEY ([ide_perfil]) REFERENCES [perfil]([ide_perfil])
ON UPDATE CASCADE
GO

ALTER TABLE [usuario] CHECK CONSTRAINT [usuario_fk0]
GO

INSERT INTO perfil(nome, descricao, sts_exclusao)
VALUES
('Administrador', 'Administrador Geral', 0),
('Padrão', 'Usuário com restrições de tela', 0),
('Cliente', 'Cliente', 0)

INSERT INTO usuario(nome, sobrenome, guuid, email, senha, dtc_inclusao, sts_exclusao, qtd_acessos, ide_perfil)
VALUES
('Deivisson', 'Santos', '85a7c8f5-59b5-40b5-8c04-56fe824a7799', 'deivisson.santos@detran.ba.gov.br', 'ba3253876aed6bc22d4a6ff53d8406c6ad864195ed144ab5c87621b6c233b548baeae6956df346ec8c17f5ea10f35ee3cbc514797ed7ddd3145464e2a0bab413',  GETDATE(), 0, 0, 1)

INSERT INTO cliente(guuid, nome, sobrenome, email, telefone, is_whatsapp, dtc_inclusao, sts_exclusao, ide_perfil )
VALUES
('e195fdb4-c085-4144-b53d-b19637352fef', 'Rafael', NULL, NULL, 71991867777, 1, GETDATE(), 0, 3),
('5e03f967-9d10-46ee-9ae7-5f8ecabd6476', 'Douglas', 'Santos', 'dougf@gmail.com', 71981519066, 0, GETDATE(), 0, 3)

INSERT INTO produto(guuid, nome, valor, codigo_interno, codigo_barras, descricao, dtc_inclusao, sts_exclusao)
VALUES
('c5f7ef8b-9faa-43d6-918e-cf8b2196bb4c', 'Y50 Preto e Vermelho', 45.01, 70001, 78912357899, 'Avaria na tampa', GETDATE(), 0),
('45484dfc-036e-45dc-b6d0-5c878736e048', 'Pro6 Branco', 59.99, 70002, NULL, NULL, GETDATE(), 0)





