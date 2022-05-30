Console.WriteLine("Cada jogador possui as seguintes embarcações:\nPorta - Aviões(5 quadrantes)\nNavio - Tanque(4 quadrantes)\nDestroyers(3 quadrantes)\nSubmarinos(2 quadrantes)\n");
Console.WriteLine("As embarcações são identificadas por siglas, então quando for solicitado tipo, utilize as siglas:\nPA - Porta - Aviões(5 quadrantes)\nNT - Navio - Tanque(4 quadrantes)\nDS - Destroyers(3 quadrantes)\nSB - Submarinos(2 quadrantes)\nEx: SB\nLocal: A1A2(sempre informe coluna e linha inicial e final apenas)\n");
Console.WriteLine("Quando for efetuar o disparo cheque para ver se o quadrante existe e se não é repetido, caso isso ocorra você perderá sua vez.\nAperte Enter apenas quando entender o jogo\n");
Console.ReadLine();
Console.Clear();

Console.WriteLine("Quantas pessoas vão jogar 1 ou 2?");
var numJog = Console.ReadLine();
if (numJog == "2")
{
    Console.WriteLine("Qual o nome do primeiro jogador?");
    var nome1 = Console.ReadLine();
    Console.WriteLine("Qual o nome do segundo jogador?");
    var nome2 = Console.ReadLine();
    Console.Clear();

    //Dicionario para converter str para int para encontrar as linhas na matriz
    var dicLinha = new Dictionary<string, int>() { { "A", 1 }, { "B", 2 }, { "C", 3 }, { "D", 4 }, { "E", 5 }, { "F", 6 }, { "G", 7 }, { "H", 8 }, { "I", 9 }, { "J", 10 } };
    var dicLinha2 = new Dictionary<int, string>() { { 1, "A" }, { 2, "B" }, { 3, "C" }, { 4, "D" }, { 5, "E" }, { 6, "F" }, { 7, "G" }, { 8, "H" }, { 9, "I" }, { 10, "J" } };
    var dicEmbarcações = new Dictionary<string, int>() { { "SB", 2 }, { "PA", 5 }, { "NT", 4 }, { "DS", 3 } };
    var listaEmbarcações = new List<string>() { { "SB0" }, { "SB1" }, { "SB2" }, { "SB3" }, { "NT0" }, { "NT1" }, { "DS0" }, { "DS1" }, { "DS2" }, { "PA0" } };
    string[,] mapaJog1 = new string[11, 11];
    string[,] jogadasJog1 = new string[11, 11];
    var tente = ", tente novamente";
    int qtdSB = 0, qtdPA = 0, qtdNT = 0, qtdDS = 0;
    List<int> listaLinha = new List<int>();
    List<int> listaColuna = new List<int>();
    int numLinha = 0, numColuna = 0;
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Qual o tipo da embarcação {i + 1} {nome1}?");
        var embarcação = (Console.ReadLine()).ToUpper();
        var verificaEmbarc = dicEmbarcações.ContainsKey(embarcação);
        var embarcaçãoAux = "";
        switch (embarcação)
        {
            case "SB":
                embarcaçãoAux = embarcação + qtdSB;
                break;
            case "PA":
                embarcaçãoAux = embarcação + qtdPA;
                break;
            case "DS":
                embarcaçãoAux = embarcação + qtdDS;
                break;
            case "NT":
                embarcaçãoAux = embarcação + qtdNT;
                break;
            default:
                Console.WriteLine($"Tipo de embarcação não encontrado{tente}");
                i--;
                continue;
        }
        if (!(listaEmbarcações.Contains(embarcaçãoAux)))
        {
            Console.WriteLine($"Tipo de embarcação já escolhido{tente}");
            i--;
            continue;
        }

        Console.WriteLine("Qual a sua posição?");
        var local = (Console.ReadLine()).ToUpper();
        var ocupado = false;
        var zero = false;
        int contador = 0;
        if (local.Contains("10"))
        {
            local = local.Replace("10", "-");
        }
        var tamanho = local.Length;



        var local1 = "";
        if (!(String.IsNullOrWhiteSpace(local)) && tamanho == 4)
        {

            if (local.Contains("0"))
            {
                zero = true;
            }

            if (local.Contains("-"))
            {
                local = local.Replace("-", "0");
            }
            if (zero == false)
            {
                var primeiraLin = local.Substring(0, 1);
                var ultimaLin = local.Substring(2, 1);
                var primeiraCol = local.Substring(1, 1);
                var ultimaCol = local.Substring(3, 1);
                var primeiraColu = int.TryParse(primeiraCol, out var primeiraColuna);
                var ultimaColu = int.TryParse(ultimaCol, out var ultimaColuna);
                if (primeiraColuna == 0)
                    primeiraColuna = 10;
                if (ultimaColuna == 0)
                    ultimaColuna = 10;
                var contemLin1 = dicLinha.ContainsKey(primeiraLin);
                var contemLin2 = dicLinha.ContainsKey(ultimaLin);


                if (primeiraColu && ultimaColu)
                {
                    if (primeiraLin == ultimaLin && primeiraColuna != ultimaColuna)
                    {
                        for (int p = primeiraColuna; p <= ultimaColuna; p++)
                        {
                            local1 = local1 + primeiraLin + p;

                        }
                        local = local1;
                        Console.WriteLine(local);
                    }
                    else
                    {
                        if (contemLin1 && contemLin2 && primeiraLin != ultimaLin && primeiraColuna == ultimaColuna)
                        {


                            for (int p = dicLinha[primeiraLin]; p <= dicLinha[ultimaLin]; p++)
                            {
                                local1 = local1 + dicLinha2[p] + primeiraColuna;
                                contador++;

                            }
                            local = local1;
                            Console.WriteLine(local);
                        }
                        else
                        {

                            if (contador == 0)
                                Console.WriteLine(local);
                        }
                    }
                }

            }
        }
        else
        {

            Console.WriteLine(local);
        }

        var zero1 = false;
        if (local.Contains("10"))
        {
            local = local.Replace("10", "-");
        }
        var tamanho1 = local.Length;

        if (local.Contains("0"))
        {
            zero1 = true;
        }
        if (zero1 || tamanho1 != dicEmbarcações[embarcação] * 2)
        {
            Console.WriteLine($"Alocação da embarcação incorreta{tente}");
            i--;
            continue;
        }


        if (zero == false)
        {
            if (local.Contains("-"))
            {
                local = local.Replace("-", "0");
            }
        }
        for (int o = 0; o < local.Length; o++)
        {
            string l = local.Substring(o, 1);
            numLinha = dicLinha[l];
            listaLinha.Add(numLinha);
            o++;
            l = local.Substring(o, 1);
            numColuna = int.Parse(l);
            if (numColuna == 0)
                numColuna = 10;
            listaColuna.Add(numColuna);
        }
        var verificaLinhaSequencia = Sequencia(listaLinha);
        var verificaLinhaIgual = igual(listaLinha);
        var verificaColunaSequencia = Sequencia(listaColuna);
        var verificaColunaIgual = igual(listaColuna);
        var diagonal = 1;
        if ((verificaLinhaSequencia && verificaColunaIgual) || (verificaLinhaIgual && verificaColunaSequencia))
        {
            diagonal = 0;
        }
        listaColuna.Clear();
        listaLinha.Clear();
        if (diagonal == 1)
        {
            Console.WriteLine($"Alocação da embarcação incorreta{tente}");
            i--;
            continue;
        }

        var verificaLocal = local.Length == dicEmbarcações[embarcação] * 2;
        if (!verificaLocal)
        {
            Console.WriteLine($"Quantidade de quadrante incompativel com o tipo de embarcação escolhida{tente}");
            i--;
            continue;
        }

        for (int j = 0; j < local.Length; j++)
        {
            var linha = local.Substring(j, 1);
            var coluna = local.Substring(j + 1, 1);
            var verificaColuna = int.TryParse(coluna, out int colunaM);
            if (colunaM == 0)
            {
                colunaM = 10;
            }
            if (dicLinha.ContainsKey(linha) && verificaColuna)
            {
                var linhaM = dicLinha[linha];
                if (String.IsNullOrEmpty(mapaJog1[linhaM, colunaM]))
                {
                    mapaJog1[linhaM, colunaM] = embarcação;
                    j++;
                }
                else
                {
                    Console.WriteLine($"Um ou mais espaços já estão ocupados{tente} em outra posição");
                    i--;
                    ocupado = true;
                    break;
                }
            }
            else
            {
                Console.WriteLine($"Local da embarcação invalido{tente} com uma entrada valida");
                i--;
                break;
            }
        }
        if (ocupado)
            continue;
        switch (embarcação)
        {
            case "SB":
                qtdSB++;
                break;
            case "PA":
                qtdPA++;
                break;
            case "DS":
                qtdDS++;
                break;
            case "NT":
                qtdNT++;
                break;
        }


    }
    Console.Clear();
    Console.WriteLine("Jogador 2 sua vez de preencher o mapa");
    qtdSB = 0; qtdPA = 0; qtdNT = 0; qtdDS = 0;
    string[,] mapaJog2 = new string[11, 11];
    string[,] jogadasJog2 = new string[11, 11];



    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Qual o tipo da embarcação {i + 1} {nome2}?");
        var embarcação = (Console.ReadLine()).ToUpper();
        var verificaEmbarc = dicEmbarcações.ContainsKey(embarcação);
        var embarcaçãoAux = "";
        switch (embarcação)
        {
            case "SB":
                embarcaçãoAux = embarcação + qtdSB;
                break;
            case "PA":
                embarcaçãoAux = embarcação + qtdPA;
                break;
            case "DS":
                embarcaçãoAux = embarcação + qtdDS;
                break;
            case "NT":
                embarcaçãoAux = embarcação + qtdNT;
                break;
            default:
                Console.WriteLine($"Tipo de embarcação não encontrado{tente}");
                i--;
                continue;
        }
        if (!(listaEmbarcações.Contains(embarcaçãoAux)))
        {
            Console.WriteLine($"Tipo de embarcação já escolhido{tente}");
            i--;
            continue;
        }

        Console.WriteLine("Qual a sua posição?");
        var local = (Console.ReadLine()).ToUpper();
        var ocupado = false;
        var zero = false;
        int contador = 0;
        if (local.Contains("10"))
        {
            local = local.Replace("10", "-");
        }
        var tamanho = local.Length;



        var local1 = "";
        if (!(String.IsNullOrWhiteSpace(local)) && zero == false && tamanho == 4)
        {

            if (local.Contains("0"))
            {
                zero = true;
            }
            if (zero == false)
            {
                if (local.Contains("-"))
                {
                    local = local.Replace("-", "0");
                }
                var primeiraLin = local.Substring(0, 1);
                var ultimaLin = local.Substring(2, 1);
                var primeiraCol = local.Substring(1, 1);
                var ultimaCol = local.Substring(3, 1);
                var primeiraColu = int.TryParse(primeiraCol, out var primeiraColuna);
                var ultimaColu = int.TryParse(ultimaCol, out var ultimaColuna);
                if (primeiraColuna == 0)
                    primeiraColuna = 10;
                if (ultimaColuna == 0)
                    ultimaColuna = 10;
                var contemLin1 = dicLinha.ContainsKey(primeiraLin);
                var contemLin2 = dicLinha.ContainsKey(ultimaLin);


                if (primeiraColu && ultimaColu)
                {
                    if (primeiraLin == ultimaLin && primeiraColuna != ultimaColuna)
                    {
                        for (int p = primeiraColuna; p <= ultimaColuna; p++)
                        {
                            local1 = local1 + primeiraLin + p;

                        }
                        local = local1;
                        Console.WriteLine(local);
                    }
                    else
                    {
                        if (contemLin1 && contemLin2 && primeiraLin != ultimaLin && primeiraColuna == ultimaColuna)
                        {

                            for (int p = dicLinha[primeiraLin]; p <= dicLinha[ultimaLin]; p++)
                            {
                                local1 = local1 + dicLinha2[p] + primeiraColuna;
                                contador++;

                            }
                            local = local1;
                            Console.WriteLine(local);
                        }
                        else
                        {

                            if (contador == 0)
                                Console.WriteLine(local);
                        }
                    }
                }
            }

        }
        else
        {

            Console.WriteLine(local);
        }
        var zero1 = false;
        if (local.Contains("10"))
        {
            local = local.Replace("10", "-");
        }
        var tamanho1 = local.Length;

        if (local.Contains("0"))
        {
            zero1 = true;
        }
        if (zero1 || tamanho1 != dicEmbarcações[embarcação] * 2)
        {
            Console.WriteLine($"Alocação da embarcação incorreta{tente}");
            i--;
            continue;
        }


        if (zero == false)
        {
            if (local.Contains("-"))
            {
                local = local.Replace("-", "0");
            }
        }
        for (int o = 0; o < local.Length; o++)
        {
            string l = local.Substring(o, 1);
            numLinha = dicLinha[l];
            listaLinha.Add(numLinha);
            o++;
            l = local.Substring(o, 1);
            numColuna = int.Parse(l);
            if (numColuna == 0)
                numColuna = 10;
            listaColuna.Add(numColuna);
        }
        var verificaLinhaSequencia = Sequencia(listaLinha);
        var verificaLinhaIgual = igual(listaLinha);
        var verificaColunaSequencia = Sequencia(listaColuna);
        var verificaColunaIgual = igual(listaColuna);
        var diagonal = 1;
        if ((verificaLinhaSequencia && verificaColunaIgual) || (verificaLinhaIgual && verificaColunaSequencia))
        {
            diagonal = 0;
        }
        listaColuna.Clear();
        listaLinha.Clear();
        if (diagonal == 1)
        {
            Console.WriteLine($"Alocação da embarcação incorreta{tente}");
            i--;
            continue;
        }

        var verificaLocal = local.Length == dicEmbarcações[embarcação] * 2;
        if (!verificaLocal)
        {
            Console.WriteLine($"Quantidade de quadrante incompativel com o tipo de embarcação escolhida{tente}");
            i--;
            continue;
        }

        for (int j = 0; j < local.Length; j++)
        {
            var linha = local.Substring(j, 1);
            var coluna = local.Substring(j + 1, 1);
            var verificaColuna = int.TryParse(coluna, out int colunaM);
            if (colunaM == 0)
            {
                colunaM = 10;
            }
            if (dicLinha.ContainsKey(linha) && verificaColuna)
            {
                var linhaM = dicLinha[linha];
                if (String.IsNullOrEmpty(mapaJog2[linhaM, colunaM]))
                {
                    mapaJog2[linhaM, colunaM] = embarcação;
                    j++;
                }
                else
                {
                    Console.WriteLine($"Um ou mais espaços já estão ocupados{tente} em outra posição");
                    ocupado = true;
                    i--;
                    break;
                }
            }
            else
            {
                Console.WriteLine($"Local da embarcação invalido{tente} com uma entrada valida");
                i--;
                break;
            }
        }
        if (ocupado)
            continue;
        switch (embarcação)
        {
            case "SB":
                qtdSB++;
                break;
            case "PA":
                qtdPA++;
                break;
            case "DS":
                qtdDS++;
                break;
            case "NT":
                qtdNT++;
                break;
        }


    }



    for (int i = 0; i < 11; i++)
    {
        for (int j = 0; j < 11; j++)
        {
            if (i == 0)
            {
                jogadasJog1[i, j] = j + "|";
            }
            if (i > 0)
            {
                if (j == 0)
                {
                    jogadasJog1[i, j] = dicLinha2[i] + "|";
                }
                else
                    jogadasJog1[i, j] = " |";
            }
        }
    }

    for (int i = 0; i < 11; i++)
    {
        for (int j = 0; j < 11; j++)
        {
            if (i == 0)
            {
                jogadasJog2[i, j] = j + "|";
            }
            if (i > 0)
            {
                if (j == 0)
                {
                    jogadasJog2[i, j] = dicLinha2[i] + "|";
                }
                else
                    jogadasJog2[i, j] = " |";
            }
        }
    }
    Console.Clear();
    int qtd = 30;
    bool semvencedor = true;
    var tentativasjog1 = new List<string>();
    var tentativasjog2 = new List<string>();
    var acertosJog1 = 0;
    var acertosJog2 = 0;
    Console.WriteLine("Começou o jogo");
    while (semvencedor)
    {
        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                Console.Write(jogadasJog1[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Qual o local da tentativa {nome1}?");
        var tentativa = (Console.ReadLine()).ToUpper();
        if (!(String.IsNullOrWhiteSpace(tentativa)))
        {
            var repetido = false;
            if (tentativasjog1.Contains(tentativa))
                repetido = true;
            var zero = true;
            if (tentativa.Contains("0"))
                zero = false;
            if (tentativa.Contains("10"))
                tentativa = tentativa.Replace("10", "0");
            var tamanhoTentativa = tentativa.Length;
            var tentLinha = tentativa.Substring(0, 1);
            var tentCol = tentativa.Substring(1, 1);
            var tentColu = int.TryParse(tentCol, out var tentColuna);
            if (tentColuna == 0)
                tentColuna = 10;
            if (dicLinha.ContainsKey(tentLinha) && tentColu && dicLinha.ContainsValue(tentColuna) && zero && !repetido)
            {
                var linhaJog = dicLinha[tentLinha];
                var ColunaJog = tentColuna;
                if (!(String.IsNullOrEmpty(mapaJog2[linhaJog, ColunaJog])))
                {
                    jogadasJog1[linhaJog, ColunaJog] = "A|";
                    Console.WriteLine("Você acertou");
                    acertosJog1++;
                }
                else
                {
                    jogadasJog1[linhaJog, ColunaJog] = "X|";
                    Console.WriteLine("Você errou");
                }

            }
            else
                Console.WriteLine("Entrada invalida ou repetida, perdeu a vez");
        }
        else
            Console.WriteLine("Entrada invalida ou repetida, perdeu a vez");

        if (!tentativasjog1.Contains(tentativa))
            tentativasjog1.Add(tentativa);
        Console.WriteLine("Aperte ENTER para a proxima jogada");
        Console.ReadLine();
        Console.Clear();



        for (int i = 0; i < 11; i++)
        {
            for (int j = 0; j < 11; j++)
            {
                Console.Write(jogadasJog2[i, j]);
            }
            Console.WriteLine();
        }
        Console.WriteLine($"Qual o local da tentativa {nome2}?");
        tentativa = (Console.ReadLine()).ToUpper();
        if (!(String.IsNullOrWhiteSpace(tentativa)))
        {
            var repetido = false;
            if (tentativasjog2.Contains(tentativa))
                repetido = true;
            var zero = true;
            if (tentativa.Contains("0"))
                zero = false;
            if (tentativa.Contains("10"))
                tentativa = tentativa.Replace("10", "0");
            var tamanhoTentativa = tentativa.Length;
            var tentLinha = tentativa.Substring(0, 1);
            var tentCol = tentativa.Substring(1, 1);
            var tentColu = int.TryParse(tentCol, out var tentColuna);
            if (tentColuna == 0)
                tentColuna = 10;
            if (dicLinha.ContainsKey(tentLinha) && tentColu && dicLinha.ContainsValue(tentColuna) && zero && !repetido)
            {
                var linhaJog = dicLinha[tentLinha];
                var ColunaJog = tentColuna;
                if (!(String.IsNullOrEmpty(mapaJog2[linhaJog, ColunaJog])))
                {
                    jogadasJog2[linhaJog, ColunaJog] = "A|";
                    Console.WriteLine("Você acertou");
                    acertosJog2++;
                }
                else
                {
                    jogadasJog2[linhaJog, ColunaJog] = "X|";
                    Console.WriteLine("Você errou");
                }

            }
            else
                Console.WriteLine("Entrada invalida ou repetida, perdeu a vez");
        }
        else
            Console.WriteLine("Entrada invalida ou repetida, perdeu a vez");

        if (!tentativasjog2.Contains(tentativa))
            tentativasjog2.Add(tentativa);
        Console.WriteLine("Aperte ENTER para a proxima jogada");
        Console.ReadLine();
        Console.Clear();
        if (acertosJog1 == qtd || acertosJog2 == qtd)
            semvencedor = false;

    }
    if (acertosJog1 == qtd && acertosJog2 != qtd)
        Console.WriteLine($"{nome1} ganhou, parabéns");

    if (acertosJog2 == qtd && acertosJog1 != qtd)
        Console.WriteLine($"{nome2} ganhou, parabéns");

    if (acertosJog1 == qtd && acertosJog2 == qtd)
        Console.WriteLine("Empatou, parabéns");
}
else
{
    if (numJog == "1")
    {
        Console.WriteLine("Opção de jogador contra o computador ainda esta em desenvolvimento\nDesculpe\nVersão Player vs Player disponível");
    }
    else
        Console.WriteLine("Entrada não reconhecida");

}



static bool igual(List<int> entrada)
{
    int checador = 0;
    for (int i = 0; i < entrada.Count; i++)
        if (i < entrada.Count - 1)
        {
            if (entrada[i] != entrada[i + 1])
            {
                checador++;
            }
        }
    if (checador == 0)
    {
        return true;
    }
    else
        return false;
}
static bool Sequencia(List<int> entrada)
{
    int checadorSe = 0;
    for (int i = 0; i < entrada.Count; i++)
    {
        if (i < entrada.Count - 1)
        {
            if (entrada[i] + 1 == entrada[i + 1])
            {
                checadorSe++;
            }
        }
    }
    if (checadorSe == entrada.Count - 1)
    {
        return true;
    }
    else
        return false;
}