# Desafio de Projeto Backend para Site de Compras

Bem-vindo ao repositório do meu projeto de backend para um site de compras. Este repositório contém o código-fonte, a documentação e os testes para a implementação de um sistema backend robusto e escalável, desenvolvido como parte de um desafio de projeto. A seguir, você encontrará uma visão geral dos requisitos funcionais e não-funcionais, a arquitetura planejada, os modelos e diagramas, os cenários de validação e os pontos de atenção para este projeto.

## Requisitos Funcionais

### Realizar Compra:
- **Buscar Produto:** O usuário procura um produto específico.
- **Visualizar Detalhes:** O usuário visualiza os detalhes do produto, incluindo descrição, preço e disponibilidade.
- **Adicionar ao Carrinho:** O usuário adiciona o produto desejado ao carrinho de compras.
- **Escolher Quantidade:** O usuário escolhe a quantidade desejada de cada produto.
- **Realizar Pagamento:** O usuário finaliza a compra realizando o pagamento.

### Visualizar Extrato de Venda:
- **Lista de Pedidos:** O proprietário da loja visualiza a lista de todos os pedidos realizados.
- **Detalhes dos Produtos:** Visualiza os produtos vendidos, suas quantidades, o comprador e a data da compra.

## Requisitos Não-Funcionais
- **Disponibilidade:** Suporte para múltiplos usuários realizarem compras e consultas simultaneamente.
- **Consistência de Dados:** Garantia de atualização correta do estoque para evitar inconsistências e erros de vendas.
- **Validação de Cenários:** Utilização de testes automatizados para validar a compra em diferentes cenários.

## Arquitetura

### Arquitetura em Camadas:
- **Boundary:** Interface com o usuário.
- **Control:** Lógica de aplicação.
- **Entity:** Modelos de dados.

### Arquitetura Cliente/Servidor ou Distribuída com MPI:
- Garantia de funcionamento em múltiplos computadores ou máquinas virtuais.

## Modelos e Diagramas

- **Modelo de Casos de Uso:** Descrição das interações entre os usuários (clientes e proprietários) e o sistema.
- **Modelo de Domínio:** Representação das entidades do sistema (ex.: Produto, Carrinho, Pedido, Usuário).

### Diagramas de Sequência:
- **Realizar Compra:** Sequência de interações para a realização de uma compra.
- **Visualizar Extrato de Venda:** Sequência de interações para visualizar os extratos de venda.

## Cenários de Validação

- **Cenário 1:** 2 clientes comprando aleatoriamente de 2 a 4 produtos dos 5 produtos existentes, com 1 item disponível de cada produto.
- **Cenário 2:** 10 clientes comprando aleatoriamente de 2 a 4 produtos dos 10 produtos existentes, com 5 itens disponíveis de cada produto.
- **Cenário 3:** 1000 clientes comprando aleatoriamente 1 dos 10 produtos existentes, com 100 itens disponíveis de cada produto.

## Implementação

O sistema será desenvolvido em C#. Será testado em ambientes reais utilizando diferentes computadores ou máquinas virtuais para validar a funcionalidade e a consistência do sistema.

## Relatório Final

O relatório final incluirá:
- **Modelo de Casos de Uso:** Diagrama e descrição detalhada.
- **Modelo de Domínio:** Diagrama e explicação das entidades.
- **Diagramas de Sequência:** Fluxos principais dos casos de uso.
- **Cenários de Validação:** Descrição dos cenários, resultados dos testes e análise de consistência dos dados.

## Pontos de Atenção

- Garantir a atualização correta dos saldos dos itens em estoque.
- Utilizar diferentes computadores ou máquinas virtuais para testar o sistema em ambientes reais.

---

Este repositório será atualizado continuamente com o progresso do projeto, incluindo código-fonte, documentação e resultados de testes. Fique à vontade para clonar o repositório, contribuir com sugestões ou relatar quaisquer problemas encontrados.

**Autor:** João Victor Fernandes Martins  
**Contato:** jfmartinsvred@gmail.com  
**Data de Início:** 12 de julho de 2024
