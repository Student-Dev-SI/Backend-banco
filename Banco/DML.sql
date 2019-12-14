/*DML*/

USE fastrade

INSERT INTO Tipo_Usuario (Tipo) VALUES ('Consumidor')

INSERT INTO Tipo_Usuario (Tipo) VALUES ('Fornecedor')

INSERT INTO Tipo_Usuario (Tipo) VALUES ('Administrador')

INSERT INTO Endereco (Rua_Av, Numero, Complemento,  CEP, Bairro, Estado  ) VALUES ('Rua Grafite', 223, 'cs6', '123456789', 'Jardim Romão', 'SP')

INSERT INTO Cat_Produto(Tipo) VALUES ('Conserva')

INSERT INTO Cat_Produto(Tipo) VALUES ('Bebida')

INSERT INTO Cat_Produto(Tipo) VALUES ('Graos')

INSERT INTO Cat_Produto(Tipo) VALUES ('Frios')

INSERT INTO Cat_Produto(Tipo) VALUES ('Fruta')

INSERT INTO Cat_Produto(Tipo) VALUES ('Verdura')

INSERT INTO Cat_Produto(Tipo) VALUES ('Legumes')

INSERT INTO Produto (Id_Cat_Produto) VALUES (1)

INSERT INTO Produto (Id_Cat_Produto) VALUES (1)

INSERT INTO Receita(Nome_Receita) VALUES ('Limão')

INSERT INTO Receita(Nome_Receita) VALUES ('Casca De Laranja')

INSERT INTO Produto_Receita(Id_Produto, Id_Receita) VALUES (1, 2)

INSERT INTO Usuario(Id_Endereco, Id_Tipo_Usuario, Nome_Razao_Social, CPF_CNPJ, Email, Senha, Celular_Telefone, Foto_Url_Usuario) VALUES (1, 1, 'Consumidor Do Chiquinho',  '123456789', 'Fornecedor@gmail.com', '******', '(11)9777-6666', 'Imagem bank')

INSERT INTO Usuario(Id_Endereco, Id_Tipo_Usuario, Nome_Razao_Social, CPF_CNPJ, Email, Senha, Celular_Telefone, Foto_Url_Usuario) VALUES (1, 2, 'Fornecedor Do Chiquinho',  '123456789', 'consumidor@gmail.com', '******', '(11)9777-6666', 'Imagem bank')

INSERT INTO Usuario(Id_Endereco, Id_Tipo_Usuario, Nome_Razao_Social, CPF_CNPJ, Email, Senha, Celular_Telefone, Foto_Url_Usuario) VALUES (1, 3, 'Adm', '123456789', 'adc@gmail.com', '******', '(11)9777-6666', 'Imagem bank')

INSERT INTO Pedido(Id_Produto, Id_Usuario, Quantidade) VALUES (1, 1, 20)

INSERT INTO Pedido(Id_Produto, Id_Usuario, Quantidade) VALUES (1, 1, 30)

INSERT INTO Oferta(Id_Produto, Id_Usuario, Quantidade, NomeProduto, Preco, Descricao_do_Produto, Validade, Foto_Url_Oferta) VALUES (1, 2, 'Feijão', '200', 3, 'Feijão de 1kg', '22/11/2001', 'Img_oferta')

INSERT INTO Oferta(Id_Produto, Id_Usuario, Quantidade, NomeProduto, Preco, Descricao_do_Produto, Validade, Foto_Url_Oferta) VALUES (1, 2, 'Arroz', '350', 5.00, 'Arroz de 1kg', '23/12/2020', 'Img_oferta1')

INSERT INTO Oferta(Id_Produto, Id_Usuario, Quantidade, NomeProduto, Preco, Descricao_do_Produto, Validade, Foto_Url_Oferta) VALUES (1, 2, 'Arroz Branco','400', 7.00, 'Arroz Branco de 1kg', '23/12/2020', 'Img_oferta1')
