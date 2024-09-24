Dados do banco de dados, armazenado no site freesqldatabase.com

CREATE TABLE Produto (
    ProdutoID INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    PartNumber VARCHAR(50) NOT NULL UNIQUE,
    PrecoMedioCusto DECIMAL(10, 2) NOT NULL
);

CREATE TABLE Estoque (
    EstoqueID INT AUTO_INCREMENT PRIMARY KEY,
    ProdutoID INT NOT NULL,
    QuantidadeDisponivel INT NOT NULL DEFAULT 0,
    FOREIGN KEY (ProdutoID) REFERENCES Produto(ProdutoID) ON DELETE CASCADE
);

CREATE TABLE MovimentacaoEstoque (
    MovimentacaoID INT AUTO_INCREMENT PRIMARY KEY,
    ProdutoID INT NOT NULL,
    DataMovimentacao DATE NOT NULL,
    QuantidadeMovimentada INT NOT NULL,
    TipoMovimentacao ENUM('entrada', 'saida') NOT NULL,
    CustoMovimentacao DECIMAL(10, 2),
    FOREIGN KEY (ProdutoID) REFERENCES Produto(ProdutoID) ON DELETE CASCADE
);

CREATE TABLE LogErro (
    LogID INT AUTO_INCREMENT PRIMARY KEY,
    Texto VARCHAR(1000) NOT NULL,
    Endpoint VARCHAR(50) NOT NULL
);
