# GDD: Null Standing (título de trabalho)

## Escopo atual (decidido pelo autor)
- Agora o que o autor quer é um FPS de extração. A história não precisa entrar de primeira.
- Tudo o que foi desenhado além disso (a campanha de três atos, as facções com território, a A-Life, os personagens, o sistema de amigos, as camadas da Arca) são add-ons futuros, não parte do primeiro marco.
- Câmera: primeira e terceira pessoa. Proposta de implementação (a confirmar): corpo único e completo, polido na primeira pessoa no primeiro marco, e a terceira como modo de câmera sobre o mesmo corpo.
- Primeiro marco (decidido): hub simples (estoque, mercado e saída para as incursões), um ou dois mapas de incursão com entrada e ponto de extração, IA inimiga com patrulha, alerta e combate (só um tipo de inimigo no primeiro marco: soldados; saqueadores, drones e Filhos do Vazio entram depois), dano por partes do corpo, perda dos itens ao morrer com retorno ao hub, e loot, armas e munição. Regiões persistentes com transições, facções territoriais e A-Life ficam como add-ons. Sementes narrativas baratas podem entrar desde o começo (descrições de itens, terminais, barks, textos de carregamento).

## Visão de longo prazo da estrutura de mapas (add-on, proposta do autor)
- Conjunto de mapas em torno de uma Arca: 10 mapas, sendo 6 zonas cinzentas puras de extração e 4 híbridos, que são complexos de facção com "fortalezas" dentro.
- Exemplos de fortalezas do autor: um navio de guerra abandonado onde ficam os "Marines", uma mina abandonada em região montanhosa e uma base militar.
- Regra de persistência: dentro do complexo (a fortaleza), o que se mantém fica guardado entre visitas. Fora dele, tudo pode mudar de uma saída para uma volta (extração reiniciando).
- Não entra no primeiro marco. O primeiro mapa é uma das 6 zonas cinzentas puras (a Frente de Guerra urbana).
- Persistência na fortaleza (decidido): persistem o estado da fortaleza (quem manda e os danos que sofreu) e o acesso e a reputação do jogador com aquela facção. O loot e os soldados reiniciam a cada visita.
- Em aberto: quais são as quatro facções, e como chamar essas fortalezas para não confundir com o hub do jogador (nas comunidades do muro). Sugestão: hub para o do jogador e fortaleza ou bastião para as das facções.

## Visão geral
- Gênero: ficção científica distópica, jogo de tiro de extração (hub explorável + mapas instanciados). Referência de gameplay: The Division (Arca como zona segura, Zona Cinzenta como zona de tiroteio). O autor quer um jogo de tiro.
- Plataforma / engine: Unity
- Resumo em uma frase: um operador de baixo, fora do sistema que decide quem ascende, entra nas Zonas Cinzentas para cumprir contratos e conquistar o controle do próprio futuro pelo protocolo PULSO.

## Pilares do jogo
1. **Toda saída tem risco.** Entrar, saquear e voltar vivo. Se o jogador morrer antes da extração, perde o que carregava. Cada mapa é uma aposta, e voltar com o saque é a vitória.
2. **Crescer te expõe.** Poder e visibilidade sobem juntos. Quanto mais o jogador converte, acumula e compra, mais o score de caça sobe. O jogador escolhe quanto risco quer assumir para ascender.
3. **Poder raro, sentido como poder.** A tecnologia é escassa e controlada. Quando o jogador consegue equipamento melhor, principalmente a super tecnologia de ótima qualidade, ele se sente um monstro. O raro é conquista, não rotina.
4. **O mundo continua sem você.** A guerra já está em andamento nas zonas, com facções, outros operadores e ameaças que não esperam o jogador. Ele é um operador que entra no meio do conflito, não o centro dele.

## Pilares narrativos
1. **O mérito é uma fachada.** A MOIRA se vende como governo dos melhores, mas entrega oligarquia. A cada camada do mundo, o jogador vê quem de fato se beneficia.
2. **Ascensão tem preço.** Subir de status deixa o fantasma mais visível e mais caçado. O topo é um risco, não um prêmio.
3. **Incerteza como regra.** O score é oculto, os contratos são anônimos e o PULSO tem um criador sem rosto. O jogador nunca tem certeza de quem está do outro lado.
4. **História em pedaços que sobrevivem ao jogo.** A narrativa chega por ambiente, barks e contratos, e funciona mesmo que o jogador pule tudo o que for opcional.

## Fantasia do jogador
Alguém de baixo que viu no PULSO uma chance de ascensão e de controle sobre o próprio futuro. Origem fixa (não há escolha de backstory). Tem uma casa pequena na comunidade da base da Arca, como ponto de ligação. O hub principal fica nas comunidades do muro.

## Loop principal de gameplay
Estrutura decidida: um hub explorável (as comunidades do muro) e mapas instanciados, um por Zona Cinzenta. Cada mapa tem entrada e ponto de extração.
1. No hub (as comunidades do muro; a casa do jogador na Arca é só um ponto de ligação): escolher contrato, equipamento e zona. Vender saque, comprar no mercado negro, converter moeda.
2. Inserção no mapa por um ponto de entrada.
3. Objetivo: scavenging e contrato (recuperar, sabotar, resgatar, eliminar, hackear).
4. Pressão: guerra em andamento, outros operadores, tempo.
5. Extração: voltar com o saque. Se o jogador morrer, perde o que carregava e acorda na maca do médico.
6. Progressão: vender, subir de status, desbloquear contratos e história. Quanto mais o jogador ascende, mais o score de caça cresce e mais os caçadores de fantasmas o procuram.

## Inimigos (primeiro marco)
- Só um tipo: soldados (tropas do conflito espalhadas pelas zonas). Saqueadores, drones e Filhos do Vazio entram depois.
- IA dura e punitiva, estilo Tarkov (decidido). Proposta de como deixá-la justa: soldados que se agrupam, usam cobertura e flanqueiam, e punem a imprudência, mas legíveis: a patrulha tem rotas, o alerta dá um sinal e a fuga é possível. A morte deve parecer culpa do jogador, não do acaso.
- Loot (decidido): os soldados dropam as armas e a armadura que usam, além de munição e itens médicos. Para ter equipamento melhor é preciso derrotar quem o tem. O soldado mais bem equipado é o mais perigoso e o que mais vale.
- Escalonamento (decidido): dentro do mapa, as áreas de maior valor concentram soldados mais equipados e em maior número. A rota segura rende pouco, e a de alto valor pode custar tudo.
- Fora do primeiro marco (add-ons): saqueadores, drones, Filhos do Vazio, os caçadores de fantasmas, a IA adaptativa estilo MGS V, e as facções territoriais com A-Life.
- Modelo do mapa: extração pura (a incursão reinicia a cada visita). A persistência fica só fora do mapa, no estoque do hub.

## Combate (primeiro marco)
- Ritmo (decidido): letal para os dois lados. Poucos tiros bem colocados matam o jogador e o soldado. A diferença vem de armadura, munição e posição, não de uma barra de vida grande. A morte deve parecer justa: o jogador ouve os soldados, vê o alerta e tem como fugir.
- Balística (decidido): depende da arma. Armas de cadência rápida e curto alcance usam raycast (acerto instantâneo). Armas mais lentas e de longo alcance usam projétil físico, com velocidade finita e queda leve. Interpretação a confirmar: "rápidas" quer dizer cadência alta e "lentas" quer dizer cadência baixa e alcance maior.
- Armadura (proposta, a confirmar): cada armadura tem uma classe e cada munição tem um valor de penetração, e o resultado do tiro vem da comparação. Penetração de paredes, ricochete e balística avançada ficam fora do primeiro marco.
- Dano por partes (decidido): sete zonas. Cabeça e tórax são vitais: dano suficiente em qualquer uma delas mata. Abdômen, braços e pernas não matam sozinhos, mas causam efeitos. Pernas podem fraturar e deixar o jogador lento. Braços feridos deixam a mira instável. Sangramento leve ou pesado drena a vida até o jogador usar uma bandagem. Fratura exige uma tala.
- Ligação com o hub: o que o jogador não tratou no campo é cobrado no reparo (o Tomás, na versão com história).
- Armas (decidido: poucas, três ou quatro). Lista confirmada: 1) pistola (cadência média, curto alcance, raycast); 2) submetralhadora (cadência alta, curto alcance, raycast); 3) fuzil de assalto (cadência média, médio alcance, projétil, o que os soldados mais usam e dropam); 4) fuzil de precisão (cadência baixa, longo alcance, projétil). Duas munições bastam: uma comum e uma de maior penetração, para testar a lógica da armadura. A personalização de peças (miras, canos, coronhas) fica para depois.

## Inventário e perda (primeiro marco)
- Perda ao morrer (decidido): o jogador perde tudo o que levou, sem espaço seguro. O que está no corpo e na mochila fica no mapa. (Antes havia a ideia de um pequeno espaço seguro, removida pelo autor.)
- Recuperação depois de morrer (decidido): o jogador compra a crédito, e o saldo pode ficar negativo (dívida). A dívida tem um teto. Ao atingi-lo, o hub ainda entrega um kit mínimo, que entra na dívida mas não a aumenta além do teto, para o jogador nunca travar. A dívida é o pilar do mérito como fachada em forma de mecânica: o sistema deixa tentar de novo, e cobra. Moeda do hub (decidido): BIT, a moeda do PULSO, como na lore. O CREDIT só entra quando houver as Arcas, como add-on. Em aberto: o valor do teto da dívida (decidir no teste).
- Estoque do hub (decidido): limitado, com um número de espaços. O jogador escolhe o que guardar, o que vender e o que descartar. Ampliar o estoque pode ser uma recompensa de progressão.
- Inventário da incursão (decidido): lista simples, sem grade. Cada item vale um número de espaços, e há um limite. A decisão de o que levar fica, e a grade do estilo Tarkov pode entrar depois como melhoria.
- Em aberto: o número de espaços inicial, e os espaços de equipamento no corpo (arma principal, pistola, armadura, itens médicos).

## Hub (primeiro marco)
- Forma (decidido): um espaço 3D para andar, em blockout simples e rápido, na comunidade do muro. A muralha gigante da Arca aparece ao fundo. Fica como base para o hub explorável da campanha, com mais trabalho de arte depois.
- Estações (decidido): quatro. 1) Estoque: guarda e retira itens, com espaços limitados, e é onde o jogador monta o que leva. 2) Mercado: compra e venda em BIT, e é onde aparecem a dívida, o teto e o kit mínimo. 3) Tratamento: cura fraturas, sangramento e ferimentos (na versão com história, é o Tomás; no primeiro marco pode ser uma estação sem personagem). 4) Saída para a incursão: o portão da muralha, onde o jogador sai para o mapa.
- Tomás no primeiro marco (decidido): a estação de tratamento já tem o Tomás, em versão mínima: um personagem parado ao lado da maca, com duas ou três falas curtas na linha da ficha dele (bronca com cuidado por baixo). É a assinatura do hub e a primeira semente da campanha. Modelo simples em blockout, sem animação complexa.
- Fora do primeiro marco: corretores e contratos, a escolha entre vários mapas, as fortalezas de facção e os personagens da história.

## Mapa do primeiro marco
- Tema (decidido): Frente de Guerra urbana. Um bairro em ruínas, com trincheiras e ruas bloqueadas, junto à muralha de uma Arca. É onde as tropas (os soldados) estão.
- A muralha gigante da Arca é sempre visível no horizonte, como assinatura visual: a cidade segura ali, a guerra aqui.
- Tom visual (decidido): realista e sujo, estilo Tarkov. Concreto gasto, ruas bloqueadas e restos de guerra. Paleta de cinza, ferrugem e poeira, com um contraste: a luz limpa da Arca ao fundo, na muralha gigante. A cidade segura é clara, e a guerra é suja.
- Duração e tamanho (decidido): incursão de cerca de 20 minutos, em um mapa pequeno a médio.
- Estrutura (decidido): duas ou três entradas em lados opostos, dois ou três pontos de extração na muralha e duas ou três áreas de alto valor.
- Os pontos de extração ficam ao pé da muralha, em portões improvisados que levam ao hub, nas comunidades do muro (decidido). Ideia ainda sem decisão: cada ponto com uma condição de uso diferente (um aberto, outro com chave ou tempo de espera), para o jogador escolher.

## Estrutura da história

### Abertura (decidida)
- O jogador acorda numa maca médica. A amnésia não é mistério do jogo: é só um dispositivo do tutorial, sem peso na história.
- Um médico conduz a cena com falas curtas, sem explicar as siglas em bloco. O significado completo de MOIRA e PULSO aparece no ambiente (terminal, tela, etiqueta).
- A fala deve dizer que a MOIRA entrou em modo fantasma (não que foi encerrado) e que o PULSO está ativo. Gancho: o jogador pergunta "ativo pra quê?" e o médico responde que é pra trabalhar.
- Esboço de ritmo (não é texto final):
  - Médico: "Pronto. Seu perfil na MOIRA entrou em modo fantasma. O PULSO já está ativo."
  - Jogador: "Ativo pra quê?"
  - Médico: "Pra trabalhar. O resto você aprende no caminho."
- Depois da cena, vem uma intro simples que mostra o resto do mundo.

### Atos e finais (rascunho, em construção)
Espinha dos atos: três alavancas de controle, descobertas uma por ato. O conforto (Huxley, *Admirável Mundo Novo*), o medo (Orwell, *1984*) e o conhecimento negado (Bradbury, *Fahrenheit 451*).

Esqueleto proposto, ainda sem texto de cena:
- Ato 1, a base: o jogador acorda, vira scavenger, conhece o hub e os corretores e cumpre os primeiros contratos. Termina no primeiro bloqueio vertical: ao tentar subir ao Meio, um terminal o lê e mostra algo como "MOIRA: fantasma. Oportunidade: nenhuma". O sistema o vê e o considera sem valor.
  - (A rever: o autor quer um jogo de tiro, e este tutorial foi desenhado em torno de evitar o combate. Ver a decisão sobre o equilíbrio entre tiro e furtividade.)
  - Primeiro mapa (tutorial de scavenging): uma terra de ninguém logo depois da muralha, com ruínas de um combate recente. O objetivo é coletar poucos recursos e chegar ao ponto de extração. O jogador vê soldados ou máquinas lutando ao longe e aprende a evitar o combate: esconder, esperar, contornar e fugir (estilo The Forever Winter). Ensina o loop, o risco de perder o que carrega e que o mundo segue sem ele.
  - O médico é também o mentor e o vínculo do jogador, e o ponto de retorno: sempre que o jogador morre, acorda na maca dele. Ele cobra a lição em voz de bronca, com cuidado por baixo (ideia de fala: "Cara, você tem que saber o que faz. Uma hora eles vão cobrar pra te consertar. Dessa vez só tomaram teus itens, na próxima quem sabe."). A morte, no lore, é um resgate: a rede das comunidades do muro traz o corpo e o médico o remenda (sem ressurreição). Quem acha o corpo toma os itens, e o custo de ser consertado pode escalar. Como o jogador morre e volta, o médico é quem a invasão do hub pode ameaçar no Ato 2.
  - O médico da abertura (clínica clandestina do PULSO) manda o jogador, sem muita explicação, a um corretor que precisa de um scavenger. O primeiro corretor é o primeiro rosto do hub e dá o contrato do tutorial. Tom: transacional e ambíguo, sem acolhimento. Fala de contrato e de preço e de quase nada além. A humanidade do ato vem de outras pessoas, não dele.
  - Alavanca de controle revelada: o conforto (Huxley). O jogador vê quem fica dentro das Arcas, quem fica de fora e por que as pessoas aceitam o sistema.
- Ato 2, a ascensão: contratos melhores, pistas de quem está por trás deles, o score subindo. Termina na primeira invasão do hub (a virada): a MOIRA passa da indiferença ao interesse.
  - Sequência do fim do Ato 2 (proposta do autor, em ajuste):
    1. O médico fica no muro, num hub das comunidades do muro. Depois que o vendedor do hub some (a segunda perda), perto do fim do ato, ele dá ao jogador uma missão: pegar um item, o pendente da filha dele. É a primeira vez que ele pede algo, no pior momento, e o jogador já ouviu o aviso duas vezes.
    2. Na volta, os caçadores aparecem e pegam os itens do jogador, incluindo o pendente. O pendente guarda uma foto e tem gravado o nome Erika Maverton.
       - A MOIRA, que é um sistema inteligente, analisa o nome e avisa Samara Maverton (esposa do médico, de uma família oligarca ou de alto nível) sobre o achado. Ela solicita a caçada do jogador.
    3. Mais tarde, os caçadores voltam a tentar achar o jogador e o levam a uma das grandes mansões (camada alta). Lá ele encontra a esposa do médico, que pergunta por que ele roubou aquilo. A palavra "roubou" tem o foco de "encontrou": para ela, que é elite, um comum só pode ter roubado. É o preconceito de classe numa palavra. O jogador diz que encontrou.
    4. Depois disso, os caçadores encontram o médico, seguindo os passos do jogador. A descoberta acontece por culpa do jogador, por acúmulo do rastro e não por escolha avisada. O médico é levado vivo.
  - O médico (decidido): anos atrás desenvolveu uma tecnologia de longevidade, o que lhe deu status de elite. Ao ver no que ela se tornou, a manutenção do poder sobre a humanidade, ele sumiu. Hoje se dedica a salvar a vida daqueles que o mundo destruiu de verdade. Isso é o que o sistema quer de volta. A culpa é compartilhada: o médico pediu, o jogador levou, a MOIRA leu o nome. O pendente é sentimental, sem chave de dados. Erika (decidido): depois de um acidente na casa da família na zona, ficou gravemente ferida. O médico, já descrente de tudo, aceitou a eutanásia da filha. A mãe, Samara, confirmou, mas deixou Erika em coma até hoje, num hospital da Arca sob o controle da família. Oficialmente Erika está morta, e o médico acredita nisso. Depois da perda ele abandonou tudo e foi para os muros. Samara, com isso, tem poder sobre a história: ela mentiu ao marido. A longevidade que ele criou é a tecnologia que mantém a filha viva.
  - Fatos mantidos: o médico é um ex-membro da elite da MOIRA que saiu por escolha e sabe algo que o sistema quer de volta (a ligação com o PULSO fica de fora por ora). O jogador descobre que ele é uma pessoa influente ou importante. O resgate do médico leva o jogador às camadas altas no Ato 3. Parte dos amigos cai pela pressão dos caçadores.
  - Contratos e status (meio do Ato 2, decidido): escada de três degraus. 1) Coleta: scavenging simples, como o tutorial. 2) Objetivo: recuperar, escoltar, sabotar, resgatar, em mapas maiores (Porto Franco, Cinturão Industrial). 3) Alto risco: infiltração em instalações de megacorps ou em locais como o Deserto de Dados, com pagamento alto e mais peso no score. O status sobe por dois eixos: a reputação com os corretores abre contratos melhores, e o dinheiro (BIT e CREDIT) compra equipamento, casas e itens, o que chama a atenção da MOIRA.
  - Pistas sobre quem contrata (meio do Ato 2, decidido): aparecem pelo próprio trabalho, sem diálogo longo. Em objetos (etiqueta, símbolo, código no saque), nos objetivos (o que o contrato pede sugere a origem: roubar dados de pesquisa aponta para os Rebeldes, limpar arquivos para uma megacorp) e no ambiente e nos barks. Depois de descobrir a origem de um tipo de contrato, o jogador pode recusar contratos dessa origem, e isso custa reputação com o corretor, que só repassa. A pista pode ser falsa, então recusar é sempre uma aposta.
  - Escada de perdas dos amigos (meio do Ato 2, decidida): 1) o resgatador do início, de rosto, sai por medo e para de atender (perde-se a proteção dos itens); 2) um vendedor ou corretor do hub some; 3) o médico é levado, a perda que o jogador causa por uma ação concreta (o pendente).
  - Resolvido: a clínica e o hub ficam no muro. A casa do jogador, pequena, fica na comunidade dentro da Arca e é um ponto de ligação. Comprar casas, veículos e itens na Arca chama a atenção da MOIRA. Decidido: o jogador pega o pendente numa casa abandonada na zona, que era propriedade da família do médico e da esposa. A casa vira um mapa de extração: uma ruína que era confortável e hoje é destroço, contando o conforto pelo cenário. A esposa diz que foi roubo porque a casa e tudo nela ainda são dela. Pontos em aberto: o nome do médico, o que Samara quer (o marido, a filha ou outra coisa), e o que é o pendente e onde o jogador o pega; por que o pendente pertence à esposa; por que os caçadores agem fora dos muros se a MOIRA não vê ali (hipótese: eles seguem o jogador pelo rastro físico).
  - Alavanca de controle revelada: o medo e a vigilância (Orwell). O score, os caçadores, a invasão do hub.
- Ato 3, o preço: super tecnologia ao alcance, caçadores mais perto e a decisão final.
  - Alavanca de controle revelada: o conhecimento negado (Bradbury). O que é guardado e o que acontece perto do topo.
  - As Arcas viram área de jogo no meio e no fim, com camadas liberadas pelo status.
  - Revelação do conhecimento negado: as guerras da Tríade são geridas pelos três super oligarcas ligados dentro da MOIRA. A guerra que deu rumo ao jogador nunca foi pensada para ser vencida.
  - Samara (decidido): o que ela quer, acima de tudo, é Erika acordada. Ela usa a MOIRA e os caçadores porque é o jeito mais rápido de trazer o médico, mas não é leal aos três: o amor pela filha pode fazê-la trair a elite. É uma aliada instável. Precisa do jogador, porque o médico confia nele e não nela, e pode oferecer algo em troca (acesso, um lugar na elite, proteção). É a rachadura humana do sistema.
  - A subida (decidido): o resgate é uma subida em etapas. Cada camada da Arca é um trecho, liberada pelo status, com tom próprio. Base: o terreno familiar, onde o jogador deixa a casa pequena. Meio: o conforto da renda básica e das "experiências"; o score pesa mais porque a MOIRA vê tudo. Alto: a mansão, o hospital da família e as casas de luxo, onde Erika está e onde o médico é mantido. Cada trecho pode pedir algo diferente (furtividade no meio, negociação no alto). O jogador sobe porque o status permite, ou porque Samara o deixa passar.
  - Ordem das revelações no Ato 3 (decidida, da menor escala para a maior): 1) Erika está viva, em coma, num hospital da família (no Alto); 2) as guerras da Tríade são geridas pelos três; 3) os três cérebros são super oligarcas, um de cada potência, ligados na MOIRA (no topo da Arca). O jogador sobe a escada junto com as revelações: o Meio mostra o conforto, o Alto mostra Erika, e o topo mostra os três.
  - Resgate do médico (decidido): o jogador sobe às camadas altas para resgatá-lo e, ali, descobre que Erika está viva, em coma, num hospital da família. Na cena da mansão, no Ato 2, Samara só pergunta e esconde o segredo.
  - Por que Samara e os oligarcas querem o médico de volta: ele é uma das mentes mais brilhantes que já existiram, e só ele talvez tenha a capacidade de tirar Erika do coma (\"quem sabe\"). Para os oligarcas, ele significaria uma capacidade maior de melhorar a medicina e a tecnologia.

Finais (decididos, três direções; cada um cobra um custo diferente):
1. Entrar no sistema (decidido): Samara oferece um lugar na elite em troca do que ela precisa, que o jogador leve o médico até Erika. Aceitar significa usar a confiança que o médico tem nele e ganhar o que o sistema nega a quem vem de baixo. O jogador sobe por uma troca, não por mérito, e isso fecha o pilar do mérito como fachada. A dúvida moral: entregar o médico é trair o médico, mesmo que seja pelo que ele mais quer, ver a filha viva.
2. Derrubar a MOIRA e deixar o PULSO no lugar (decidido): o jogador chega aos três e, aproveitando a rachadura de Samara (a única do sistema: os três ficam unidos e frios), o sistema cai. A guerra gerida também acaba. O PULSO não é um final bom de graça. Custos possíveis:
   - Sem centro, ninguém corrige o sistema. Quem controla mais nós manda de fato, e as organizações criminosas já estão lá.
   - A transição deixa um período sem renda básica para quem depende dela (a renda está ligada à MOIRA).
   - A Liga perde a base de poder, o que pode gerar um conflito novo.
3. Manter a MOIRA como está e proteger o PULSO como refúgio (decidido): o jogador resgata o médico e sai da escada, sem subir nem derrubar. Fica fantasma e protege a rede. O médico fica livre, mas Erika continua em coma e a guerra continua.
Fio comum aos três: o médico e Erika são a peça central. Em todos, o jogador decide o que fazer com eles: entregar, usar ou proteger.

## Notas
- Direção do autor para as Zonas Cinzentas (inspirada em S.T.A.L.K.E.R.): não precisa ser um mundo linear fixo, mas pode ter pontos de transição entre áreas. Facções controlam, de forma geral, áreas específicas. O autor gosta da reputação e da guerra de facções do S.T.A.L.K.E.R. e do mundo vivo (A-Life). Como isso convive com o hub, os mapas instanciados e o anonimato dos contratos está em decisão.
- Referências de gameplay do autor (em avaliação, ainda sem decisão do que adotar): Metal Gear Solid V (infiltração semi-aberta, escolha de abordagem, IA adaptativa, gestão de base), Escape from Tarkov e Road to Vostok (extração, dano por partes do corpo, personalização de armas, versão solo PvE), Helldivers (cooperativo, stratagems), Foxhole (guerra massiva e logística de jogadores) e Beta Decay (RPG cyberpunk de simulação, implantes, facções) e S.T.A.L.K.E.R. (A-Life, facções e reputação, anomalias, sobrevivência).
- Altered Carbon como referência só para a longevidade como casta da elite (sem troca de corpo ou transferência de consciência).
- Resgate: no começo é narrativo (tela da maca, com um resgatador de rosto na cena de despertar). Resgate dentro do mapa, com risco para o resgatador (inspiração: Far Cry 2), fica como ideia futura. No decorrer do jogo o jogador faz amigos, e amigos evitam a perda dos itens ao morrer. Os amigos podem ser perdidos: os caçadores os pressionam quando o score sobe, e eles podem morrer ou sair.
- Referências de tom: Admirável Mundo Novo, 1984 e Fahrenheit 451 (três alavancas de controle). Metropolis e Tempos Modernos para a estrutura vertical das Arcas.
- Caixa de texto como forma de entrega. Sem dublagem e sem localização planejadas.
- Os caçadores de fantasmas são o braço da MOIRA contra quem ganha poder demais.
- Tipo do jogo: ação (extração). As pastas de barks e lore de ambiente já existem em `narrativa/`.
