CREATE DATABASE IF NOT EXISTS nookdb;
#drop database nookdb;
USE nookdb;

-- ==========================
-- TABELA CLIENTES
-- ==========================

CREATE TABLE clientes (
    id INT AUTO_INCREMENT,
    nome VARCHAR(150) NOT NULL,
    cpf VARCHAR(14) NOT NULL UNIQUE,
    email VARCHAR(150) NOT NULL UNIQUE,
    telefone VARCHAR(20),
    endereco VARCHAR(255),

    PRIMARY KEY(id)
);

-- ==========================
-- TABELA FUNCIONARIOS
-- ==========================

CREATE TABLE funcionarios (
    id INT AUTO_INCREMENT,
    nome VARCHAR(150) NOT NULL,
    cpf VARCHAR(14) NOT NULL UNIQUE,
    email VARCHAR(150) NOT NULL UNIQUE,
    telefone VARCHAR(20),
    funcao VARCHAR(100),
    senha VARCHAR(255) NOT NULL,

    PRIMARY KEY(id)
);

-- ==========================
-- TABELA LIVROS
-- ==========================

CREATE TABLE livros (
    id INT AUTO_INCREMENT,
    titulo VARCHAR(200) NOT NULL,
    autor VARCHAR(150) NOT NULL,
    ano INT NOT NULL,
    quantidade_estoque INT NOT NULL DEFAULT 0,
    imagem_capa VARCHAR(255),

    PRIMARY KEY(id)
);

-- ==========================
-- TABELA EVENTOS
-- ==========================

CREATE TABLE eventos (
    id INT AUTO_INCREMENT,
    titulo VARCHAR(200) NOT NULL,
    descricao TEXT,
    data_evento DATETIME NOT NULL,
    local_evento VARCHAR(200),
    vagas INT NOT NULL,
    banner VARCHAR(255),

    PRIMARY KEY(id)
);

-- ==========================
-- TABELA RESERVA LIVROS
-- ==========================

CREATE TABLE reservas_livros (
    id INT AUTO_INCREMENT,

    cliente_id INT NOT NULL,
    livro_id INT NOT NULL,

    data_reserva DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    status_reserva ENUM(
        'PENDENTE',
        'RETIRADO',
        'CANCELADO'
    ) DEFAULT 'PENDENTE',

    PRIMARY KEY(id),

    CONSTRAINT fk_reserva_cliente
        FOREIGN KEY(cliente_id)
        REFERENCES clientes(id),

    CONSTRAINT fk_reserva_livro
        FOREIGN KEY(livro_id)
        REFERENCES livros(id)
);

-- ==========================
-- TABELA PARTICIPACAO EVENTOS
-- ==========================

CREATE TABLE participacoes_eventos (
    id INT AUTO_INCREMENT,

    cliente_id INT NOT NULL,
    evento_id INT NOT NULL,

    data_inscricao DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,

    PRIMARY KEY(id),

    CONSTRAINT fk_participacao_cliente
        FOREIGN KEY(cliente_id)
        REFERENCES clientes(id),

    CONSTRAINT fk_participacao_evento
        FOREIGN KEY(evento_id)
        REFERENCES eventos(id)
);

#SELECT * FROM clientes;
#SELECT * FROM eventos;


DESCRIBE clientes;
DESCRIBE funcionarios;
DESCRIBE livros;
DESCRIBE eventos;
DESCRIBE reservas_livros;
DESCRIBE participacoes_eventos;

