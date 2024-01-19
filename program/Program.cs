// Projeto baseado no que foi criado durante o curso de C# no freecodecamp/microsoft
// Decidi por manter o nome das variáveis em inglês, porém, traduzi os demais textos do app
// Algumas opções do app podem ainda não estar completamente prontas, mas pretendo finalizar todas

// o array ourAnimals que guarda os dados dos animais contém as seguintes informações 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

// variáveis que dão suporte à entrada de dados
int maxPets = 8;
string? readResult;
string menuSelection = "";
bool validEntry = false;
int petAge;

//array usada para guardar dados em tempo de execução, não há dados persistentes
string[,] ourAnimals = new string[maxPets, 6];

// criar entradas iniciais para o array ourAnimals
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "cachorro";
            animalID = "c1";
            animalAge = "2";
            animalPhysicalDescription = "Golden Retriever fêmea, tamanho médio com pelagem na cor creme, pesando aproximadamente 30 kilos. Adestrada e castrada";
            animalPersonalityDescription = "Ama carinhos na barriga, ter os pelos escovados e gosta de brincar de pegar coisas.";
            animalNickname = "Lolla";
            break;

        case 1:
            animalSpecies = "cachorro";
            animalID = "c2";
            animalAge = "9";
            animalPhysicalDescription = "Labrador macho, porte grande e com pelagem na cor chocolate, pesando aproximadamente 40 kilos. Adestrado, castrado e treinado para acompanhar deficientes visuais.";
            animalPersonalityDescription = "Adora carinho atrás das orelhas e passeios, bastante atencioso devido o seu treinamento.";
            animalNickname = "Julinho";
            break;

        case 2:
            animalSpecies = "gato";
            animalID = "g3";
            animalAge = "1";
            animalPhysicalDescription = "Pequena fêmea branca, pesando aproximadamente 3 kilos. Castrada e treinada para usar caixa de areia.";
            animalPersonalityDescription = "Amigável e carinhosa, ama sachês e banhos de sol pela manhã, sempre busca acompanhar as pessoas.";
            animalNickname = "Mia";
            break;

        case 3:
            animalSpecies = "gato";
            animalID = "g4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            break;

    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Espécie: " + animalSpecies;
    ourAnimals[i, 2] = "Idade: " + animalAge;
    ourAnimals[i, 3] = "Nome: " + animalNickname;
    ourAnimals[i, 4] = "Descrição física: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personalidade: " + animalPersonalityDescription;
}

//exibir as opções do menu principal
do
{
    Console.Clear();

    Console.WriteLine("-------------------------------------------------------------------");
    Console.WriteLine("|                        ADOTE UM PET                             |");
    Console.WriteLine("-------------------------------------------------------------------");
    Console.WriteLine("\nBem-vindo ao Adote um Pet. Escolha uma das opções abaixo:");
    Console.WriteLine(" 1. Listar todas as informações dos nossos pets");
    Console.WriteLine(" 2. Adicionar um novo animal no sistema");
    Console.WriteLine(" 3. Preencher informações que faltam de idade e descrição física");
    Console.WriteLine(" 4. Preencher informações que faltam de nomes e personalidade");
    Console.WriteLine(" 5. Editar a idade de um animal");
    Console.WriteLine(" 6. Editar a personalidade de um animal");
    Console.WriteLine(" 7. Exibir todos os gatos com uma característica específica");
    Console.WriteLine(" 8. Exibir todos os cães com uma característica específica");
    Console.WriteLine("\nDigite o número selecionado ou digite 'sair' para sair do programa");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        case "1":
            // listar todas as informações atuais dos animais
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\nAperte ENTER para continuar");
            readResult = Console.ReadLine();
            break;

        case "2":
            // adicionar um novo animal ao array ourAnimals
            string anotherPet = "s";
            int petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }

            if (petCount < maxPets)
            {
                Console.WriteLine($"Nós atualmente temos {petCount} pets que precisam de um lar. Podemos cuidar de mais {(maxPets - petCount)} animais.");
            }

            while (anotherPet == "s" && petCount < maxPets)
            {
                // obter a espécie (cachorro ou gato) do animal - a string animalSpecies é um campo obrigatório
                do
                {
                    Console.WriteLine("\n\rDigite 'cachorro' ou 'gato' para iniciar");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();

                        if (animalSpecies != "cachorro" && animalSpecies != "gato")
                        {
                            validEntry = false;
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }

                } while (validEntry == false);

                // construir o código do animalId - por exemplo c1, c2, g3 (cachorro1, cachorro2, gato3)
                animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();

                // obter a idade do animal. a entrada inicial pode ser '?'
                do
                {
                    Console.WriteLine("Digite a idade do pet ou '?' se ela for desconhecida");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalAge = readResult;

                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }

                } while (validEntry == false);

                // obter a descrição física do animal em aparência e condições - pode ficar em branco
                do
                {
                    Console.WriteLine("Digite a descrição física do animal (tamanho, cor, peso, gênero, treinamento, castração)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult;

                        if (animalPhysicalDescription == "")
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                // obter a descrição de personalidade do animal - pode ficar em branco
                do
                {
                    Console.WriteLine("Digite a descrição de personalidade do animal (do que ele gosta, truques, nível de energia)");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult;

                        if (animalPersonalityDescription == "")
                        {
                            validEntry = true;
                        }
                    }

                } while (validEntry == false);

                // obter o nome do animal - pode ficar em branco
                do
                {
                    Console.WriteLine("Digite o nome do animal");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalNickname = readResult;

                        if (animalNickname == "")
                        {
                            validEntry = true;
                        }
                    }

                } while (validEntry == false);

                // guardar as informações do animal no array ourAnimals
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Espécie: " + animalSpecies;
                ourAnimals[petCount, 2] = "Idade: " + animalAge;
                ourAnimals[petCount, 3] = "Nome: " + animalNickname;
                ourAnimals[petCount, 4] = "Descrição física: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personalidade: " + animalPersonalityDescription;

                // incrementar petCount (o array é baseado em zero, então incrementamos o contador depois de adicioná-lo ao array)
                petCount = petCount + 1;

                // conferir o limite de maxPets
                if (petCount < maxPets)
                {
                    // outro animal?
                    Console.WriteLine("Deseja inserir informações sobre um outro pet? s/n");

                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "s" && anotherPet != "n");
                }
            }

            if (petCount >= maxPets)
            {
                Console.WriteLine("Nós atingimos o limite de animais sob os nossos cuidados. Tente novamente mais tarde.");
                Console.WriteLine("\nAperte ENTER para continuar");
                readResult = Console.ReadLine();
            }

            break;

        case "3":
            // certificar-se que a idade e a descrição física dos animais estão completas
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 2] == "Idade: ?" && ourAnimals[i, 0] != "ID #: ")
                {
                    do
                    {
                        Console.WriteLine($"Digite a idade para o animal {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalAge = readResult;
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                    } while (validEntry == false);
                    ourAnimals[i, 2] = "Idade: " + animalAge.ToString();
                }

                if (ourAnimals[i, 4] == "Descrição física: " && ourAnimals[i, 0] != "ID #: ")
                {
                    do
                    {
                        Console.WriteLine($"Digite a descrição física para o animal {ourAnimals[i, 0]} (tamanho, cor, gênero, peso, treinamento)");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPhysicalDescription = readResult;
                            if (animalPhysicalDescription == "")
                            {
                                validEntry = false;
                            }
                            else
                            {
                                validEntry = true;
                            }

                        }
                    } while (validEntry == false);

                    ourAnimals[i, 4] = "Descrição física: " + animalPhysicalDescription;
                } 
            }
        Console.WriteLine("\n\rAs informações de idade e descrição física estão completas para todos os nossos pets!");
        Console.WriteLine("\nAperte ENTER para continuar");
        readResult = Console.ReadLine();
        break;

        case "4":
        // certificar-se que os nomes e personalidades dos animais estão completos

        for (int i = 0; i < maxPets; i++)
        {
            if (ourAnimals[i, 3] == "Nome: " && ourAnimals[i, 0] != "ID #: ")
            {
                do
                {
                    Console.WriteLine($"Digite um nome para o animal {ourAnimals[i, 0]}");
                    readResult = Console.ReadLine();

                    if (readResult != null)
                    {
                        animalNickname = readResult;
                        if (animalNickname == "")
                        {
                            validEntry = false;
                        } 
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);
                
                ourAnimals[i, 3] = "Nome: " + animalNickname;
            }

            if (ourAnimals[i, 5] == "Personalidade: " && ourAnimals[i, 0] != "ID #: ")
            {
                do
                {
                    Console.WriteLine($"Digite uma descrição de personalidade para o animal {ourAnimals[i, 0]} (do que ele gosta, truques, nível de energia)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult;
                        if (animalPersonalityDescription == "")
                        {
                            validEntry = false;
                        } else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                ourAnimals[i, 5] = "Personalidade: " + animalPersonalityDescription;
            }
        }
        
        Console.WriteLine("\n\rAs informações de nome e personalidade estão completas para todos os nossos pets!");
        Console.WriteLine("\nAperte ENTER para continuar");
        readResult = Console.ReadLine();
        break;

        case "5":
            // editar a idade de um animal

            Console.WriteLine("Em Construção - Verifique novamente mais tarde.");
            Console.WriteLine("\nAperte ENTER para continuar");
            readResult = Console.ReadLine();
            break;

        case "6":
            // editar a descrição de personalidade de um animal
            Console.WriteLine("Em Construção - Verifique novamente mais tarde.");
            Console.WriteLine("\nAperte ENTER para continuar");
            readResult = Console.ReadLine();
            break;

        case "7":
            // exibir todos os gatos com uma característica específica

            string catCharacteristics = "";

            while (catCharacteristics == "")
            {
                Console.WriteLine($"\nDigite as características que deseja em um gato separadas por vírgulas:");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    catCharacteristics = readResult.ToLower();
                    Console.WriteLine();
                }
            }

            string[] catSearch = catCharacteristics.Split(",");
            for (int i = 0; i < catSearch.Length; i++)
            {
                catSearch[i] = catSearch[i].Trim();
            }

            Array.Sort(catSearch);
            string[] searching = {".", ".", "."};

            // loop na array ourAnimals para buscar correspondência
            bool catFound = false;
            string catDescription = "";

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("gato"))
                {
                    catDescription = ourAnimals[i, 4].ToLower() + "\n" + ourAnimals[i, 5].ToLower();
                    bool matchCurrentCat = false;

                    foreach (string term in catSearch)
                    {
                        if (term != null && term.Trim() != "")
                        {
                            for(int j = 3; j > -1; j--)
                            {
                                foreach(string icon in searching)
                                {
                                    Console.Write($"\rConferindo nosso gato {ourAnimals[i, 3]} para {term.Trim()} {icon} {j.ToString()}");
                                    Thread.Sleep(100);
                                }

                                Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                            }
                            
                            if (catDescription.Contains(" " + term.Trim() + " "))
                            {
                                Console.WriteLine($"\rNosso gato {ourAnimals[i, 3]} corresponde a sua pesquisa por {term.Trim()}!");

                                matchCurrentCat = true;
                                catFound = true;
                            }
                        }
                    }

                    //exibir informações do gato em caso de correspondência
                    if (matchCurrentCat)
                    {
                        Console.WriteLine($"\r{ourAnimals[i,3]} ({ourAnimals[i, 0]})\n{catDescription}\n");
                    }
                }
            }

            if (!catFound)
            {
                Console.WriteLine("Infelizmente nenhum dos nossos gatos corresponde a pesquisa por: " + catCharacteristics);
            }

            Console.WriteLine("\nAperte ENTER para continuar");
            readResult = Console.ReadLine();
            break;

        case "8":
            // exibir todos os cachorros com uma característica específica

            string dogCharacteristics = "";

            while (dogCharacteristics == "")
            {
                Console.WriteLine($"\nDigite as características que deseja em um cachorro separadas por vírgulas:");
                readResult = Console.ReadLine();

                if (readResult != null)
                {
                    dogCharacteristics = readResult.ToLower();
                    Console.WriteLine();
                }
            }

            string[] dogSearch = dogCharacteristics.Split(",");
            for (int i = 0; i < dogSearch.Length; i++)
            {
                dogSearch[i] = dogSearch[i].Trim();
            }

            Array.Sort(dogSearch);
            string[] searchingIcon = {".", ".", "."};

            // loop na array ourAnimals para buscar correspondência
            bool dogFound = false;
            string dogDescription = "";

            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("cachorro"))
                {
                    dogDescription = ourAnimals[i, 4].ToLower() + "\n" + ourAnimals[i, 5].ToLower();
                    bool matchCurrentDog = false;

                    foreach (string term in dogSearch)
                    {
                        if (term != null && term.Trim() != "")
                        {
                            for(int j = 3; j > -1; j--)
                            {
                                foreach(string icon in searchingIcon)
                                {
                                    Console.Write($"\rConferindo nosso cachorro {ourAnimals[i, 3]} para {term.Trim()} {icon} {j.ToString()}");
                                    Thread.Sleep(100);
                                }

                                Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                            }
                            
                            if (dogDescription.Contains(" " + term.Trim() + " "))
                            {
                                Console.WriteLine($"\rNosso cachorro {ourAnimals[i, 3]} corresponde a sua pesquisa por {term.Trim()}!");

                                matchCurrentDog = true;
                                dogFound = true;
                            }
                        }
                    }

                    //exibir informações do cachorro em caso de correspondência
                    if (matchCurrentDog)
                    {
                        Console.WriteLine($"\r{ourAnimals[i,3]} ({ourAnimals[i, 0]})\n{dogDescription}\n");
                    }
                }
            }

            if (!dogFound)
            {
                Console.WriteLine("Infelizmente nenhum dos nossos cachorros corresponde a pesquisa por: " + dogCharacteristics);
            }

            Console.WriteLine("\nAperte ENTER para continuar");
            readResult = Console.ReadLine();
            break;

        default:
            break;
    }

} while (menuSelection != "sair");
