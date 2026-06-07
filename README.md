# Bomb-Arena

Protótipo de jogo em Godot com C#, pensado para uma experiência mobile.

O projeto usa Godot 4.6, C# e renderização configurada para mobile. Pela estrutura atual, o jogo possui cena principal, arena, HUD, controles mobile, menu de pausa e tela de game over.

## Objetivo

Desenvolver um jogo em arena com foco em estruturação de cenas, controles para mobile e organização inicial de sistemas de jogo em Godot.

## Tecnologias e conceitos utilizados

- Godot 4.6
- C#
- .NET
- Estrutura de cenas (`.tscn`)
- Interface/HUD
- Controles mobile
- Organização de scripts por responsabilidade
- Jolt Physics
- Renderização mobile

## Estrutura geral

Arquivos e cenas identificados no projeto:

```text
project.godot
Bomb-Arena.csproj
scenes/
  main/
  arena/
  ui/
scripts/
  managers/
```

A cena principal configurada no `project.godot` é:

```text
res://scenes/main/Main.tscn
```

A cena `Main` instancia elementos centrais como arena, câmera, HUD, controles mobile, menu de pausa, tela de game over e `GameManager`.

## Como executar

Pré-requisitos:

- Godot 4.6 com suporte a C#/.NET;
- SDK .NET compatível com o projeto.

Passos:

```text
1. Clone o repositório.
2. Abra o projeto pelo Godot usando o arquivo project.godot.
3. Aguarde a restauração/compilação dos scripts C#.
4. Execute a cena principal configurada no projeto.
```

## Status atual

Projeto em desenvolvimento inicial.

A estrutura base do projeto Godot já existe, mas o `GameManager` ainda está sem lógica implementada. A documentação foi escrita de forma conservadora para não afirmar mecânicas que ainda não estejam claras no código.

## Evolução do projeto

- Criação do projeto Godot com C#.
- Configuração da cena principal.
- Inclusão de arena, HUD, controles mobile, menu de pausa e tela de game over.
- Configuração de renderização mobile.
- Fase atual: base estrutural criada; lógica de gameplay ainda em evolução.

## Próximos passos sugeridos

- Implementar a lógica principal no `GameManager`.
- Documentar controles e mecânicas quando estiverem consolidados.
- Definir fluxo de início, pausa, game over e reinício.
- Adicionar instruções de build/exportação mobile quando o projeto estiver pronto para isso.

## Aprendizados principais

- Estruturação de projetos em Godot.
- Uso de C# com Godot.
- Organização de cenas e scripts.
- Preparação de interface e controles para mobile.
- Separação entre cena principal, UI e gerenciadores.

## Autor

Desenvolvido por [vinionix](https://github.com/vinionix).
