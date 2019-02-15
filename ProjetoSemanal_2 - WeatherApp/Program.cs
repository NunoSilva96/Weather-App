using Newtonsoft.Json;
using System;
using System.Net.Http;

namespace ProjetoSemanal_2___WeatherApp
{
    class Program
    {
        const string jsonPrevisoes0_url = "http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/hp-daily-forecast-day0.json";
        const string jsonPrevisoes1_url = "http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/hp-daily-forecast-day1.json";
        const string jsonPrevisoes2_url = "http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/hp-daily-forecast-day2.json";
        const string distritos_url = "http://api.ipma.pt/open-data/distrits-islands.json";

        static int Option3_day = 0;
        static int Option3_country;
        static int Option3_country_globalid = 0;

        static void Main(string[] args)
        {
            WelcomeScreen();
            FirstOptionsScreen();
            Console.ReadLine();
        }

        static void WelcomeScreen()
        {
            Console.WriteLine("                     #################################################################################");
            Console.WriteLine("                     #                ________               __   __                                 #");
            Console.WriteLine("                     #               |  |  |  |.-----.---.-.|  |_|  |--.-----.----.                  #");
            Console.WriteLine("                     #               |  |  |  ||  -__|  _  ||   _|     |  -__|   _|                  #");
            Console.WriteLine("                     #               |________||_____|___._||____|__|__|_____|__|                    #");
            Console.WriteLine("                     #                                                                               #");
            Console.WriteLine("                     #           _______         __ __              __   __                          #");
            Console.WriteLine("                     #          |   _   |.-----.|  |__|.----.---.-.|  |_|__|.-----.-----.            #");
            Console.WriteLine("                     #          |       ||  _  ||  |  ||  __|  _  ||   _|  ||  _  |     |            #");
            Console.WriteLine("                     #          |___|___||   __||__|__||____|___._||____|__||_____|__|__|            #");
            Console.WriteLine("                     #                   |__|                                                        #");
            Console.WriteLine("                     #################################################################################\n\n");
        }

        static void FirstOptionsScreen()
        {
            int opcao;
                Console.WriteLine("                      _______________________________________________________________________________");
                Console.WriteLine("                     |                                                                               |");
                Console.WriteLine("                     |                    Escolha uma das Opções Disponíveis                         |");
                Console.WriteLine("                     |                                                                               |");
                Console.WriteLine("                     |                    1 - Temperatura para Todas as Regiões                      |");
                Console.WriteLine("                     |                    2 - Temperatura e Precipitação Média do País               |");
                Console.WriteLine("                     |                    3 - Informações por Região e Data                          |");
                Console.WriteLine("                     |                    4 - Sair da Aplicação                                      |");
                Console.WriteLine("                     |_______________________________________________________________________________|");

                Console.Write("\n\nOpção: ");
                opcao = Int32.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Option1();
                        break;

                    case 2:
                        Console.Clear();
                        Option2();
                        break;

                    case 3:
                    Console.Clear();
                    Option3();

                        break;

                    case 4:
                    Environment.Exit(0);
                        break;

                    default:
                    Console.Clear();
                    Console.WriteLine("Escolha uma opção entre 1 e 4!");
                    Console.WriteLine("Pressione qualquer tecla para continuar");
                    Console.ReadLine();
                    Console.Clear();
                    WelcomeScreen();
                    FirstOptionsScreen();
                    break;
                }
                Console.Read();
        }

        static void Option1()
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                WelcomeScreen();
                Console.WriteLine("                                            Temperatura para Todas as Regiões                        ");
                Console.WriteLine("\n\n-- Escolha uma das Opções: ");
                Console.WriteLine("1 - Ver tempo para Hoje");
                Console.WriteLine("2 - Ver tempo para Amanhã");
                Console.WriteLine("3 - Ver tempo para Depois de Amanhã");
                Console.WriteLine("4 - Voltar ao Ecrã Anterior");
                opcao = Int32.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        GetPrevisao_Dia0();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        GetPrevisao_Dia1();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        GetPrevisao_Dia2();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("--------------------------------------------------------\n");
                        Console.WriteLine("Escolha uma opção de 1 a 4!");
                        Console.WriteLine("\n--------------------------------------------------------\n\n");
                        break;
                }

            } while (opcao != 4);
            Console.Clear();
            WelcomeScreen();
            FirstOptionsScreen();


        }

        static void Option2()
        {

            int opcao = 0;
            do
            {
                Console.Clear();
                WelcomeScreen();
                Console.WriteLine("                                          Temperatura e Precipitação Média do País                 ");
                Console.WriteLine("\n\n-- Escolha uma das Opções: ");
                Console.WriteLine("1 - Ver Média para Hoje");
                Console.WriteLine("2 - Ver Média para Amanhã");
                Console.WriteLine("3 - Ver Média para Depois de Amanhã");
                Console.WriteLine("4 - Voltar ao Ecrã Anterior");
                opcao = Int32.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        GetMedia_Dia0();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        GetMedia_Dia1();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                        
                    case 3:
                        GetMedia_Dia2();
                        Console.ReadLine();
                        Console.Clear(); 
                        break;

                    default:
                        Console.WriteLine("--------------------------------------------------------\n");
                        Console.WriteLine("Escolha uma opção de 1 a 4!");
                        Console.WriteLine("\n--------------------------------------------------------\n\n");
                        break;
                }
            } while (opcao != 4);
            Console.Clear();
            WelcomeScreen();
            FirstOptionsScreen();


        }

        static void Option3()
        {
            do
            {
                Option3_ReadDay();
                if(Option3_day == 4)
                {
                    Console.Clear();
                    WelcomeScreen();
                    FirstOptionsScreen();
                }
                else
                {
                    Option3_ShowCountry();
                    Option3_ReadCountry();
                    Regiao_Data();
                    Console.ReadLine();
                }
            } while (Option3_day != 4);

        }

        static void Option3_ReadDay()
        {
            Console.Clear();
            WelcomeScreen();

            Console.WriteLine("                                             Informações por Região e Data                 ");
            Console.WriteLine("\n\n-- Escolha uma data para Consulta: ");
            Console.WriteLine("1 - Ver Tempo para Hoje");
            Console.WriteLine("2 - Ver Tempo para Amanhã");
            Console.WriteLine("3 - Ver Tempo para Depois de Amanhã");
            Console.WriteLine("4 - Voltar ao Ecrã Anterior");
            Option3_day = int.Parse(Console.ReadLine());
        }

        static async void Option3_ShowCountry()
        {
            Console.Clear();
            WelcomeScreen();
            Console.WriteLine("                                             Informações por Região e Data                 ");
            HttpClient httpClient = new HttpClient();
            var json_distrito = await httpClient.GetStringAsync(distritos_url);
            Distritos.RootObject distritos = JsonConvert.DeserializeObject<Distritos.RootObject>(json_distrito);

            int contador = 0;
            foreach (var res in distritos.data)
            {
                 Console.WriteLine("[" + contador + "] " + res.local);
                 contador++;
            }
        }

        static void Option3_ReadCountry()
        {
            Option3_country = int.Parse(Console.ReadLine());
        }
        
        static async void Regiao_Data()
        {
            Console.Clear();
            WelcomeScreen();
            Console.WriteLine("                                             Informações por Região e Data                 ");
            HttpClient httpClient = new HttpClient();
            var json_distrito = await httpClient.GetStringAsync(distritos_url);
            var json_regiao="";
            Distritos.RootObject distritos = JsonConvert.DeserializeObject<Distritos.RootObject>(json_distrito);
            if(Option3_day == 1)
            {
                json_regiao = await httpClient.GetStringAsync(jsonPrevisoes0_url);
            }
            else if(Option3_day == 2)
            {
                json_regiao = await httpClient.GetStringAsync(jsonPrevisoes1_url);
            }
            else if(Option3_day == 3)
            {
                json_regiao = await httpClient.GetStringAsync(jsonPrevisoes2_url);
            }

            Previsoes.RootObject regioes = JsonConvert.DeserializeObject<Previsoes.RootObject>(json_regiao);

            Option3_country_globalid = distritos.data[Option3_country].globalIdLocal;

            foreach(var res in regioes.data)
            {
                if(res.globalIdLocal == Option3_country_globalid)
                {
                    Console.WriteLine("Distrito: " + distritos.data[Option3_country].local);
                    Console.WriteLine("Data: " + regioes.forecastDate);
                    Console.WriteLine("Última Atualização: " + regioes.dataUpdate);
                    Console.WriteLine("Temperatura Max: " + res.tMax);
                    Console.WriteLine("Temperatura Min: " + res.tMin);
                    Console.WriteLine("Intensidade do Vento: " + res.classWindSpeed);
                    Console.WriteLine("Direção do Vento: " + res.predWindDir);
                    Console.WriteLine("Probabilidade de Precipitação: " + res.precipitaProb + "%");
                    Console.WriteLine("Latitude: " + res.latitude);
                    Console.WriteLine("Longitude: " + res.longitude);
                }

            }
            Console.WriteLine("Pressione uma tecla para voltar ao Menu Anterior");

        }

        static async void GetMedia_Dia0()
        {
            int contador = 0;
            int contador2 = 0;
            double precipitacao=0;
            double probPrecipitacao = 0;

            double tmpMax = 0;
            double tmpMin = 0;
            double mediaTemp = 0;
            HttpClient httpClient = new HttpClient();
            var json_previsoes = await httpClient.GetStringAsync(jsonPrevisoes0_url);
            Previsoes.RootObject previsoes = JsonConvert.DeserializeObject<Previsoes.RootObject>(json_previsoes);

            foreach (var res in previsoes.data)
            {
                precipitacao += previsoes.data[contador].precipitaProb;
                contador++;

            }
            probPrecipitacao = precipitacao / contador;

            foreach (var res in previsoes.data)
            {
                tmpMin += previsoes.data[contador2].tMin;
                tmpMax += previsoes.data[contador2].tMax;
                contador2++;
            }
            mediaTemp = (tmpMin + tmpMax) / (contador2 * 2);

            Console.WriteLine("\n\n--------------------------------------------------------");
            Console.WriteLine("\nTemperatura Média do País: " + Math.Round(mediaTemp, 2) + " ºC");
            Console.WriteLine("\nProbabilidade de Precipitação do País: " + Math.Round(probPrecipitacao,2));
            Console.WriteLine("\n--------------------------------------------------------\n\n");
            Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu anterior");
        }

        static async void GetMedia_Dia1()
        {
            int contador = 0;
            int contador2 = 0;

            double precipitacao = 0;
            double probPrecipitacao = 0;

            double tmpMax = 0;
            double tmpMin = 0;
            double mediaTemp = 0;
            HttpClient httpClient = new HttpClient();
            var json_previsoes1 = await httpClient.GetStringAsync(jsonPrevisoes1_url);
            Previsoes.RootObject previsoes1 = JsonConvert.DeserializeObject<Previsoes.RootObject>(json_previsoes1);

            foreach (var res in previsoes1.data)
            {
                precipitacao += previsoes1.data[contador].precipitaProb;
                contador++;

            }
            probPrecipitacao = precipitacao / contador;

            foreach (var res in previsoes1.data)
            {
                tmpMin += previsoes1.data[contador2].tMin;
                tmpMax += previsoes1.data[contador2].tMax;
                contador2++;
            }
            mediaTemp = (tmpMin + tmpMax) / (contador2 * 2);

            Console.WriteLine("\n\n--------------------------------------------------------");
            Console.WriteLine("\nTemperatura Média do País: " + Math.Round(mediaTemp, 2) + " ºC");
            Console.WriteLine("\nProbabilidade de Precipitação do País: " + Math.Round(probPrecipitacao,2));
            Console.WriteLine("\n--------------------------------------------------------\n\n");
            Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu anterior");
        }

        static async void GetMedia_Dia2()
        {
            int contador = 0;
            int contador2 = 0;

            double tmpMax = 0;
            double tmpMin = 0;
            double mediaTemp = 0;

            double precipitacao = 0;
            double probPrecipitacao = 0;
            HttpClient httpClient = new HttpClient();
            var json_previsoes2 = await httpClient.GetStringAsync(jsonPrevisoes2_url);
            Previsoes.RootObject previsoes2 = JsonConvert.DeserializeObject<Previsoes.RootObject>(json_previsoes2);

            foreach (var res in previsoes2.data)
            {
                precipitacao += previsoes2.data[contador].precipitaProb;
                contador++;

            }
            probPrecipitacao = precipitacao / contador;

            foreach (var res in previsoes2.data)
            {
                tmpMin += previsoes2.data[contador2].tMin;
                tmpMax += previsoes2.data[contador2].tMax;
                contador2++;
            }
            mediaTemp = (tmpMin + tmpMax) / (contador2 * 2);

            Console.WriteLine("\n\n--------------------------------------------------------");
            Console.WriteLine("\nTemperatura Média do País: " + Math.Round(mediaTemp, 2) + " ºC");
            Console.WriteLine("\nProbabilidade de Precipitação do País: " + Math.Round(probPrecipitacao, 2));
            Console.WriteLine("\n--------------------------------------------------------\n\n");
            Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu anterior");
        }

        static async void GetPrevisao_Dia0()
        {
            int contador = 0;
            HttpClient httpClient = new HttpClient();
            var json_previsoes = await httpClient.GetStringAsync(jsonPrevisoes0_url);
            Previsoes.RootObject previsoes = JsonConvert.DeserializeObject<Previsoes.RootObject>(json_previsoes);

            var json_distritos = await httpClient.GetStringAsync(distritos_url);
            Distritos.RootObject distritos = JsonConvert.DeserializeObject<Distritos.RootObject>(json_distritos);

            foreach(var res in previsoes.data)
            {
                
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Distrito: " + distritos.data[contador].local);
                Console.WriteLine("Temperatura Mínima: " + previsoes.data[contador].tMin);
                Console.WriteLine("Temperatura Máxima: " + previsoes.data[contador].tMax);
                Console.WriteLine("--------------------------------------------------------\n\n");
                contador++;

            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior");
        }

        static async void GetPrevisao_Dia1()
        {
            int contador = 0;
            HttpClient httpClient = new HttpClient();
            var json_previsoes1 = await httpClient.GetStringAsync(jsonPrevisoes1_url);
            Previsoes.RootObject previsoes1 = JsonConvert.DeserializeObject<Previsoes.RootObject>(json_previsoes1);

            var json_distritos = await httpClient.GetStringAsync(distritos_url);
            Distritos.RootObject distritos = JsonConvert.DeserializeObject<Distritos.RootObject>(json_distritos);

            foreach (var res in previsoes1.data)
            {

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Distrito: " + distritos.data[contador].local);
                Console.WriteLine("Temperatura Mínima: " + previsoes1.data[contador].tMin);
                Console.WriteLine("Temperatura Máxima: " + previsoes1.data[contador].tMax);
                Console.WriteLine("--------------------------------------------------------\n\n");
                contador++;

            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior");
        }

        static async void GetPrevisao_Dia2()
        {
            int contador = 0;
            HttpClient httpClient = new HttpClient();
            var json_previsoes2 = await httpClient.GetStringAsync(jsonPrevisoes2_url);
            Previsoes.RootObject previsoes2 = JsonConvert.DeserializeObject<Previsoes.RootObject>(json_previsoes2);

            var json_distritos = await httpClient.GetStringAsync(distritos_url);
            Distritos.RootObject distritos = JsonConvert.DeserializeObject<Distritos.RootObject>(json_distritos);

            foreach (var res in previsoes2.data)
            {

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Distrito: " + distritos.data[contador].local);
                Console.WriteLine("Temperatura Mínima: " + previsoes2.data[contador].tMin);
                Console.WriteLine("Temperatura Máxima: " + previsoes2.data[contador].tMax);
                Console.WriteLine("--------------------------------------------------------\n\n");
                contador++;

            }
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu anterior");
        }

    }
}
