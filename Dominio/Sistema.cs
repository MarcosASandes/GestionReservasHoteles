using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sistema
    {
        #region Listas (Actividad, Agenda, Usuario, Proveedor) - Ya inicializadas
        private List<Actividad> listaActividades = new List<Actividad>();
        private List<Agenda> listaAgendas = new List<Agenda>();
        private List<Usuario> listaUsuarios = new List<Usuario>();
        private List<Proveedor> listaProveedores = new List<Proveedor>();
        #endregion

        #region Singleton
        private static Sistema _instancia;
        public static Sistema Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new Sistema();
                }
                return _instancia;
            }
        }
        #endregion

        #region Precarga de datos requeridos.
        public Sistema()
        {
            PrecargarDatos();
        }

        private void PrecargarDatos()
        {
            try 
            {
                //Proveedor dreamworks = new Proveedor("DreamWorks S.R.L.", "23048549", "Suarez 3380 Apto 304", 10);
                AltaProveedor(new Proveedor("DreamWorks S.R.L.", "23048549", "Suarez 3380 Apto 304", 10));
                //Proveedor umpierrez = new Proveedor("Estela Umpierrez S.A.", "33459678", "Lima 2456", 7);
                AltaProveedor(new Proveedor("Estela Umpierrez S.A.", "33459678", "Lima 2456", 7));
                //Proveedor travelFun = new Proveedor("TravelFun", "29152020", "Misiones 1140", 9);
                AltaProveedor(new Proveedor("TravelFun", "29152020", "Misiones 1140", 9));
                //Proveedor rekreation = new Proveedor("Rekreation S.A.", "29162019", "Bacacay 1211", 11);
                AltaProveedor(new Proveedor("Rekreation S.A.", "29162019", "Bacacay 1211", 11));
                //Proveedor alonso = new Proveedor("Alonso & Umpierrez", "24051920", "18 de Julio 1956 Apto 4", 10);
                AltaProveedor(new Proveedor("Alonso & Umpierrez", "24051920", "18 de Julio 1956 Apto 4", 10));
                //Proveedor electricBlue = new Proveedor("Electric Blue", "26018945", "Cooper 678", 5);
                AltaProveedor(new Proveedor("Electric Blue", "26018945", "Cooper 678", 5));
                //Proveedor ludica = new Proveedor("Lúdica S.A.", "26142967", "Dublin 560", 4);
                AltaProveedor(new Proveedor("Lúdica S.A.", "26142967", "Dublin 560", 4));
                //Proveedor gimenez = new Proveedor("Gimenez S.R.L.", "29001010", "Andes 1190", 7);
                AltaProveedor(new Proveedor("Gimenez S.R.L.", "29001010", "Andes 1190", 7));
                //Proveedor aProveedor = new Proveedor("Parallax", "22041120", "Agraciada 2512 Apto. 1", 8);
                AltaProveedor(new Proveedor("Parallax", "22041120", "Agraciada 2512 Apto. 1", 8));
                //Proveedor norberto = new Proveedor("Norberto Molina", "22001189", "Paraguay 2100", 9);
                AltaProveedor(new Proveedor("Norberto Molina", "22001189", "Paraguay 2100", 9));


                AltaActividadPropia(new ActividadPropia("Eduardo", "Recepcion", false, "Tour del Hotel", "Tour para conocer el hotel.", DateTime.Parse("23-06-2023"), 50, 1, 0));
                AltaActividadPropia(new ActividadPropia("Manuel", "Piscina", true, "Fiesta Electronica", "Fiesta electronica con DJ.", DateTime.Parse("25-06-2023"), 100, 18, 150));
                AltaActividadPropia(new ActividadPropia("Susana", "Azotea", true, "Meditacion guiada", "Espacio de meditacion guiada por la experta Susana M.", DateTime.Parse("24-06-2023"), 35, 5, 100));
                AltaActividadPropia(new ActividadPropia("Manuel", "Piscina interior", false, "Nado sincronizado", "Clases de nado sincronizado en la piscina climatizada del hotel.", DateTime.Parse("30-06-2023"), 40, 12, 0));
                AltaActividadPropia(new ActividadPropia("Nicolas", "Sala de eventos", false, "Torneo de MTG", "Torneo con premio del aclamado juego de cartas: Magic The Gathering.", DateTime.Parse("02-07-2023"), 50, 18, 200));
                AltaActividadPropia(new ActividadPropia("Eduardo", "Sala de eventos", false, "Maraton de peliculas", "Espacio para disfrutar de un maraton de peliculas junto a los demas huespedes.", DateTime.Parse("05-07-2023"), 60, 5, 0));
                AltaActividadPropia(new ActividadPropia("Susana", "Patio interior", false, "Espiritualidad", "Taller impartido por Susana M que busca dar mas claridad a las emociones.", DateTime.Parse("07-07-2023"), 60, 18, 500));
                AltaActividadPropia(new ActividadPropia("Ana", "Espacio exterior", true, "Running", "Running por las inmediaciones del hotel.", DateTime.Parse("10-07-2023"), 80, 18, 0));
                AltaActividadPropia(new ActividadPropia("Eduardo", "Piscina", true, "Fiesta Hawaiana", "Fiesta con tematica Hawaiana.", DateTime.Parse("15-07-2023"), 150, 1, 100));
                AltaActividadPropia(new ActividadPropia("Ana", "Patio", true, "Aerobicos", "Espacio de entrenamiento de ejercicios aerobicos.", DateTime.Parse("16-07-2023"), 50, 18, 0));
                AltaActividadPropia(new ActividadPropia("Susana", "Azotea", true, "Conexion mente-cuerpo", "Espacio de meditacion y restrospectiva.", DateTime.Parse("16-06-2023"), 50, 18, 0));
                AltaActividadPropia(new ActividadPropia("Lucia", "Recepcion", false, "Spa", "Recorrido de spa en distintas partes del hotel.", DateTime.Parse("24-06-2023"), 30, 18, 245));
                AltaActividadPropia(new ActividadPropia("Lucia", "Piscina", true, "Dia de piscina y musica", "Dia dedicado a distintas actividades en la piscina del hotel.", DateTime.Parse("24-06-2023"), 100, 18, 0));
                AltaActividadPropia(new ActividadPropia("Lucia", "Sala de eventos", false, "Charla de aromaterapia", "Charla impartida por profesionales sobre los beneficios de los aceites esenciales.", DateTime.Parse("24-06-2023"), 60, 15, 135));
                AltaActividadPropia(new ActividadPropia("Lucia", "Sala de eventos", false, "Charla de introspeccion", "Charla impartida por profesionales sobre la importancia de la meditacion auto sugestionada.", DateTime.Parse("24-06-2023"), 100, 18, 155));
                AltaActividadPropia(new ActividadPropia("Pepe", "Cancha de baloncesto", true, "Torneo de basquetbol", "Durante las proxima semana se desarrollara un torneo de basquetbol entre los hoteles de la zona: Cada hotel crea su equipo entre los huespedes que deseen participar.", DateTime.Parse("25-06-2023"), 200, 18, 0));
                AltaActividadPropia(new ActividadPropia("Eduardo", "Piscina", true, "Fiesta Hawaiana Vol2", "Fiesta con tematica Hawaiana Vol2.", DateTime.Parse("25-06-2023"), 150, 1, 100));
                AltaActividadPropia(new ActividadPropia("Lucia", "Sala de eventos", false, "Charla sobre relaciones", "Charla impartida por profesionales sobre las relaciones amorosas-afectivas.", DateTime.Parse("25-06-2023"), 60, 15, 115));
                AltaActividadPropia(new ActividadPropia("Susana", "Patio", true, "Meditacion diaria 1", "Encuentro de meditacion diario.", DateTime.Parse("25-06-2023"), 20, 18, 0));
                AltaActividadPropia(new ActividadPropia("Pepe", "Cancha de baloncesto", true, "THB: Jornada 1", "Primer partido del torneo.", DateTime.Parse("26-06-2023"), 200, 18, 0));
                AltaActividadPropia(new ActividadPropia("Eduardo", "Piscina", true, "Fiesta de luces", "Fiesta con luces fluorescentes en la piscina.", DateTime.Parse("26-06-2023"), 150, 1, 100));
                AltaActividadPropia(new ActividadPropia("Lucia", "Sala de eventos", false, "Las mujeres en negocios", "Charla impartida por profesionales sobre el rol en constante evolucion de la mujer en entornos de emprendimiento.", DateTime.Parse("26-06-2023"), 60, 15, 150));
                AltaActividadPropia(new ActividadPropia("Susana", "Patio", true, "Meditacion diaria 2", "Encuentro de meditacion diario.", DateTime.Parse("26-06-2023"), 20, 18, 0));
                AltaActividadPropia(new ActividadPropia("Pepe", "Cancha de baloncesto", true, "THB: Jornada 2", "Segundo partido del torneo.", DateTime.Parse("27-06-2023"), 200, 18, 0));
                AltaActividadPropia(new ActividadPropia("Ana", "Piscina", true, "Encuentro deportivo", "Entrenamientos en piscina y alrededores.", DateTime.Parse("27-06-2023"), 50, 16, 0));
                AltaActividadPropia(new ActividadPropia("Lucia", "Sala de eventos", false, "Sobre negocios Vol1", "Charla impartida por profesionales sobre el emprendimiento Volumen 1.", DateTime.Parse("27-06-2023"), 60, 15, 150));
                AltaActividadPropia(new ActividadPropia("Susana", "Patio", true, "Meditacion diaria 3", "Encuentro de meditacion diario.", DateTime.Parse("27-06-2023"), 20, 18, 0));
                AltaActividadPropia(new ActividadPropia("Pepe", "Cancha de baloncesto", true, "THB: Jornada 3", "Tercer partido del torneo.", DateTime.Parse("29-06-2023"), 200, 18, 0));
                AltaActividadPropia(new ActividadPropia("Ana", "Piscina", true, "Entrenamiento cardio", "Entrenamientos cardiovasculares para adultos mayores.", DateTime.Parse("29-06-2023"), 50, 50, 0));
                AltaActividadPropia(new ActividadPropia("Lucia", "Sala de eventos", false, "Sobre negocios Vol2", "Charla impartida por profesionales sobre el emprendimiento Volumen 2.", DateTime.Parse("29-06-2023"), 60, 15, 150));
                AltaActividadPropia(new ActividadPropia("Susana", "Patio", true, "Meditacion diaria 4", "Encuentro de meditacion diario.", DateTime.Parse("29-06-2023"), 20, 18, 0));

                
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("DreamWorks S.R.L."), true, "Recorrido infantil", "Espacio para disfrutar de obras infantiles", DateTime.Parse("28-06-23"), 45, 5, 200));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("DreamWorks S.R.L."), false, "Fiesta de disfraces", "Evento de disfraces, premio al mejor disfraz", DateTime.Parse("30-06-23"), 100, 5, 350));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("DreamWorks S.R.L."), false, "Torneo de juegos", "Torneo de maquinas arcade", DateTime.Parse("04-07-23"), 150, 10, 100));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("TravelFun"), false, "Safari virtual", "Espacio hecho en realidad virtual dedicado a completar recorridos de safari y mas.", DateTime.Parse("30-06-23"), 70, 15, 150));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("TravelFun"), true, "Recorrida de acuario", "Recorrida del acuario donde aprenderemos sobre diversas especies marinas.", DateTime.Parse("08-07-23"), 50, 10, 200));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("TravelFun"), true, "Dia de playa", "Diversas actividades para realizar en la playa", DateTime.Parse("10-07-23"), 150, 5, 0));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Electric Blue"), false, "Noche de stand up", "Noche de stand up donde participaran diversos artistas", DateTime.Parse("23-07-23"), 150, 18, 400));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Electric Blue"), true, "Recorrido gastronomico", "Feria de gastronomia nacional", DateTime.Parse("15-07-23"), 300, 12, 50));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Electric Blue"), false, "Encuentro cultural", "Charla sobre eventos culturales", DateTime.Parse("20-07-23"), 100, 18, 0));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Norberto Molina"), true, "Torneo de futbol", "Torneo organizado para promover el deporte del futbol", DateTime.Parse("23-07-23"), 100, 18, 140));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Norberto Molina"), false, "Torneo de volley", "Torneo organizado para promover el deporte del volley", DateTime.Parse("24-07-23"), 100, 18, 140));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Norberto Molina"), true, "Torneo de basquet", "Torneo organizado para promover el deporte del basquet", DateTime.Parse("25-07-23"), 100, 18, 140));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Lúdica S.A."), false, "Cirque Du Soleil", "Cirque Du Soleil evento especial", DateTime.Parse("29-07-23"), 200, 18, 700));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Lúdica S.A."), true, "Evento de musica", "Se presentaran diversos artistas de muchos generos distintos.", DateTime.Parse("24-07-23"), 400, 18, 100));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Lúdica S.A."), false, "Feria tecnologica", "Evento para promover la tecnologia y exponer avances", DateTime.Parse("22-07-23"), 500, 15, 0));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Lúdica S.A."), true, "Cirque Du Soleil 2", "Cirque Du Soleil fin de la gira", DateTime.Parse("02-07-23"), 400, 18, 1100));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Norberto Molina"), true, "Torneo de handball", "Torneo organizado para promover el deporte del Handball", DateTime.Parse("03-07-23"), 100, 18, 130));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Electric Blue"), true, "Gastronomia india", "Feria de gastronomia de comida india.", DateTime.Parse("04-07-23"), 300, 12, 50));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("TravelFun"), true, "Recorrida acuario VOL2", "Recorrida del acuario donde aprenderemos sobre diversas especies marinas - Segunda edicion.", DateTime.Parse("05-07-23"), 50, 10, 200));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("DreamWorks S.R.L."), true, "Juegos de mesa", "Torneo de juegos de mesa: Magic, carcasonne, catan, etc", DateTime.Parse("06-07-23"), 150, 10, 100));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Estela Umpierrez S.A."), true, "Torneo de taekwondo", "Torneo de taekwondo profesional", DateTime.Parse("07-07-23"), 150, 10, 100));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Rekreation S.A."), true, "Curso de salvavidas", "Curso introductorio de salvavidas costero.", DateTime.Parse("08-07-23"), 150, 10, 100));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Alonso & Umpierrez"), true, "Sobre tecnologias", "Charla donde profesionales del area de la tecnologia contaran sus experiencias y tips.", DateTime.Parse("09-07-23"), 150, 10, 100));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Parallax"), true, "Peliculas de BollyWood", "A modo de evento cultural, se exhibiran peliculas de la india.", DateTime.Parse("10-07-23"), 150, 10, 300));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Gimenez S.R.L."), true, "Retrato y expresion", "Espacio de expresion artistica", DateTime.Parse("11-07-23"), 150, 10, 120));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Lúdica S.A."), true, "Relatos poeticos", "Evento para promover la poesia", DateTime.Parse("26-06-23"), 100, 14, 50));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Norberto Molina"), true, "Debate politico", "Debate politico entre entendidos del tema", DateTime.Parse("27-06-23"), 100, 18, 0));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Electric Blue"), true, "Gastronomia peruana", "Feria de gastronomia de comida peruana.", DateTime.Parse("28-06-23"), 300, 12, 50));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("TravelFun"), true, "Recorrida de zoologico", "Recorrida del zoologico nacional.", DateTime.Parse("29-06-23"), 50, 10, 100));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("DreamWorks S.R.L."), true, "Juegos de mesa VOL2", "Torneo de juegos de mesa: Magic, carcasonne, catan, etc VOL2", DateTime.Parse("30-06-23"), 150, 10, 110));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Estela Umpierrez S.A."), true, "Torneo de jiu jitsu", "Torneo de jiu jitsu profesional", DateTime.Parse("01-07-23"), 150, 10, 100));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Rekreation S.A."), true, "Primeros auxilios", "Curso introductorio de primeros auxilios.", DateTime.Parse("02-07-23"), 150, 10, 100));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Alonso & Umpierrez"), true, "Sobre IA", "Charla donde profesionales del area de la tecnologia contaran sus experiencias y tips.", DateTime.Parse("03-07-23"), 150, 10, 100));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Parallax"), true, "Peliculas de America", "A modo de evento cultural, se exhibiran peliculas de Latinoamerica.", DateTime.Parse("03-07-23"), 150, 10, 300));
                AltaActividadTercerizada(new ActividadTercerizada(GetProvPorNombre("Gimenez S.R.L."), true, "Escultura digital", "Espacio de expresion artistica", DateTime.Parse("04-07-23"), 150, 10, 120));


                AltaHuesped(new Huesped(TipoDoc.CI, 76860391, "Manuel", "Hernandez", "5", DateTime.Parse("01-01-98"), 2, "manuel@gmail.com", "manuel123"));
                AltaHuesped(new Huesped(TipoDoc.PASAPORTE, 12345678, "Luis", "Perez", "2", DateTime.Parse("06-11-01"), 3, "luis@gmail.com", "luis1234"));
                AltaHuesped(new Huesped(TipoDoc.OTROS, 87654321, "Matias", "Lopez", "12", DateTime.Parse("11-06-91"), 4, "matias@gmail.com", "matias123"));
                AltaHuesped(new Huesped(TipoDoc.PASAPORTE, 11223344, "Ezequiel", "Gonzalez", "18", DateTime.Parse("11-08-94"), 2, "ezequiel@gmail.com", "ezequiel123"));
                AltaHuesped(new Huesped(TipoDoc.OTROS, 99887766, "Cristina", "Matheos", "11", DateTime.Parse("18-01-99"), 3, "cristina@gmail.com", "cristina123"));
                AltaHuesped(new Huesped(TipoDoc.CI, 99544526, "Alexa", "Deloise", "3", DateTime.Parse("01-11-78"), 4, "alexa@gmail.com", "alexa123"));


                AltaOperador(new Operador("Camila", "Martinez", DateTime.Parse("12-05-23"), "camila@operador.com", "camila123"));
                AltaOperador(new Operador("Lucas", "Martinez", DateTime.Parse("19-02-22"), "lucas@operador.com", "lucas123"));
                AltaOperador(new Operador("Vanessa", "Pelaez", DateTime.Parse("20-03-23"), "vanessa@operador.com", "vanessa123"));


                AltaAgenda(new Agenda(GetHuespedPorNombre("Manuel", "Hernandez"), GetActividadPorNombre("Tour del Hotel")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Luis", "Perez"), GetActividadPorNombre("Dia de playa")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Luis", "Perez"), GetActividadPorNombre("Fiesta Electronica")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Luis", "Perez"), GetActividadPorNombre("Escultura digital")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Luis", "Perez"), GetActividadPorNombre("Peliculas de America")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Manuel", "Hernandez"), GetActividadPorNombre("Sobre IA")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Manuel", "Hernandez"), GetActividadPorNombre("Juegos de mesa VOL2")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Manuel", "Hernandez"), GetActividadPorNombre("Recorrida de zoologico")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Matias", "Lopez"), GetActividadPorNombre("Relatos poeticos")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Matias", "Lopez"), GetActividadPorNombre("Torneo de jiu jitsu")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Matias", "Lopez"), GetActividadPorNombre("Escultura digital")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Ezequiel", "Gonzalez"), GetActividadPorNombre("Primeros auxilios")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Ezequiel", "Gonzalez"), GetActividadPorNombre("Recorrida de acuario")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Ezequiel", "Gonzalez"), GetActividadPorNombre("Recorrido gastronomico")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Alexa", "Deloise"), GetActividadPorNombre("Primeros auxilios")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Alexa", "Deloise"), GetActividadPorNombre("Evento de musica")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Alexa", "Deloise"), GetActividadPorNombre("Peliculas de BollyWood")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Cristina", "Matheos"), GetActividadPorNombre("Debate politico")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Cristina", "Matheos"), GetActividadPorNombre("Evento de musica")));
                AltaAgenda(new Agenda(GetHuespedPorNombre("Cristina", "Matheos"), GetActividadPorNombre("Torneo de basquet")));
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion




        #region Metodos para facilitar MVC

        public List<Agenda> GetAgendasPorDocumentoHuespedYFecha(int numero, TipoDoc tipo, DateTime fechaAct)
        {
            List<Agenda> agendasAux = new List<Agenda>();
            foreach (Agenda a in listaAgendas)
            {
                if (a.HuespedAgenda.NumeroDocumento == numero && a.HuespedAgenda.TipoDocumento == tipo && a.ActAgenda.Fecha == fechaAct)
                {
                    agendasAux.Add(a);
                }
            }
            return agendasAux;
        }

        public List<Agenda> GetAgendasPorDocumentoHuesped(int numero, TipoDoc tipo)
        {
            List<Agenda> agendasAux = new List<Agenda>();
            foreach(Agenda a in listaAgendas)
            {
                if (a.HuespedAgenda.NumeroDocumento == numero && a.HuespedAgenda.TipoDocumento == tipo)
                {
                    agendasAux.Add(a);
                }
            }
            return agendasAux;
        }

        public List<Agenda> GetAgendasPorFecha(DateTime fechaAct)
        {
            List<Agenda> agendasAux = new List<Agenda>();
            foreach(Agenda a in listaAgendas)
            {
                if(a.ActAgenda.Fecha == fechaAct)
                {
                    agendasAux.Add(a);
                }
            }
            return agendasAux;
        }

        public string GetNombreProvPorId(int? idProv)
        {
            string ret = "";
            foreach(Proveedor p in listaProveedores)
            {
                if(p.Id == idProv)
                {
                    ret = p.Nombre;
                }
            }
            return ret;
        }

        public Agenda GetAgendaPorId(int? idAgenda)
        {
            Agenda agendaRet = null;
            foreach(Agenda a in listaAgendas)
            {
                if(a.Id == idAgenda)
                {
                    agendaRet = a;
                }
            }
            return agendaRet;
        }

        public List<Agenda> GetAgendasDeHuesped(int? idHuesped)
        {
            Huesped huespedBuscado = GetHuespedPorId(idHuesped);
            List<Agenda> agendasHuesped = new List<Agenda>();
            foreach(Agenda a in listaAgendas)
            {
                if(a.HuespedAgenda == huespedBuscado)
                {
                    agendasHuesped.Add(a);
                }
            }
            return agendasHuesped;
        }

        public Usuario Login(string email, string pass)
        {
            foreach (Usuario p in listaUsuarios)
            {
                if (p.Email.Equals(email) && p.Contrasenia.Equals(pass))
                {
                    return p;
                }
            }
            return null;
        }

        public List<Actividad> GetActividadesConFltroDate(DateTime filtro)
        {
            List<Actividad> actividadesRet = new List<Actividad>();
            foreach(Actividad a in listaActividades)
            {
                if(a.Fecha == filtro)
                {
                    actividadesRet.Add(a);
                }
            }
            return actividadesRet;
        }

        public List<Actividad> GetActividadesDeHoy()
        {
            List<Actividad> actividadesRet = new List<Actividad>();
            foreach (Actividad a in listaActividades)
            {
                if (a.Fecha == DateTime.Now)
                {
                    actividadesRet.Add(a);
                }
            }
            return actividadesRet;
        }
        #endregion


        /// <summary>
        /// Metodo para devolver un proveedor teniendo su ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>Proveedor</returns>
        public Proveedor GetProvForID(int? ID)
        {
            Proveedor unProv = null;
            foreach (Proveedor prov in listaProveedores)
            {
                if (prov.Id == ID)
                {
                    unProv = prov;
                }
            }
            return unProv;
        }

        /// <summary>
        /// Metodo para obtener el nombre de un proveedor que organice una actividad que se llame como la que pasamos por parametro.
        /// </summary>
        /// <param name="unNombreActividad"></param>
        /// <returns>String</returns>
        public string GetNombreProvPorActividad(string unNombreActividad)
        {
            string retorno = "";
            foreach (Actividad act in listaActividades)
            {
                if (act.GetTipo() == "Tercerizada")
                {
                    ActividadTercerizada aux = act as ActividadTercerizada;
                    if (aux.Nombre == unNombreActividad)
                    {
                        retorno = aux.ProveedorActividad.Nombre;
                    }
                }
            }
            return retorno;
        }


        /// <summary>
        /// Metodo para obtener todas las actividades del proveedor que pasemos por parametro.
        /// </summary>
        /// <param name="unProv"></param>
        /// <returns>Lista de actividades tercerizadas</returns>
        public List<ActividadTercerizada> GetActividadesPorProveedor(Proveedor unProv)
        {
            List<ActividadTercerizada> auxAct = new List<ActividadTercerizada>();
            foreach (Actividad act in listaActividades)
            {
                if (act.GetTipo() == "Tercerizada")
                {
                    ActividadTercerizada unaActTercerizada = act as ActividadTercerizada;
                    if (unaActTercerizada.ProveedorActividad == unProv)
                    {
                        auxAct.Add(unaActTercerizada);
                    }
                }
            }
            return auxAct;
        }


        /// <summary>
        /// Metodo que devuelve el objeto de actividad tercerizada a partir del nombre de esta.
        /// </summary>
        /// <param name="nombreAct"></param>
        /// <returns>Actividad Tercerizada</returns>
        public ActividadTercerizada GetActividadTercPorNombre(string nombreAct)
        {
            ActividadTercerizada retorno = null;
            foreach (Actividad act in listaActividades)
            {
                if (act.GetTipo() == "Tercerizada")
                {
                    ActividadTercerizada unaActTerc = act as ActividadTercerizada;
                    if (nombreAct == unaActTerc.Nombre)
                    {
                        retorno = unaActTerc;
                    }
                }
            }
            return retorno;
        }


        /// <summary>
        /// Metodo que funciona como union entre la clase proveedor y la fachada para transportar el valor de descuento.
        /// </summary>
        /// <param name="prov"></param>
        /// <param name="valorPromocion"></param>
        public void SetValorPromocion(Proveedor prov, double valorPromocion)
        {
            if (listaProveedores.Contains(prov))
            {
                prov.EstablecerPromocion(valorPromocion);
            }
            else
            {
                throw new Exception("El proveedor no existe.");
            }
        }


        /// <summary>
        /// Metodo que devuelve el objeto huesped (si existe) dando el nombre y el apellido del mismo. Usado principalmente para crear agendas.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <returns>Huesped</returns>
        public Huesped GetHuespedPorNombre(string nombre, string apellido)
        {
            Huesped objHuesped = null;
            foreach(Usuario user in listaUsuarios)
            {
                if(user.GetTipo() == "Huesped")
                {
                    Huesped unHuesped = user as Huesped;
                    if(unHuesped.Nombre == nombre && unHuesped.Apellido == apellido)
                    {
                        objHuesped = unHuesped;
                    }
                }
            }
            return objHuesped;
        }


        public Proveedor GetProvPorNombre(string nombre)
        {
            Proveedor objProv = null;
            foreach (Proveedor prov in listaProveedores)
            {
                if (prov.Nombre == nombre)
                {
                    objProv = prov;
                }
            }
            return objProv;
        }

        public Huesped GetHuespedPorId(int? id)
        {
            Huesped? ret = null;
            foreach(Usuario us in listaUsuarios)
            {
                if(id == us.Id)
                {
                    ret = us as Huesped;
                }
            }
            return ret;
        }


        public Operador GetOperadorPorId(int? id)
        {
            Operador? ret = null;
            foreach (Usuario us in listaUsuarios)
            {
                if (id == us.Id)
                {
                    ret = us as Operador;
                }
            }
            return ret;
        }


        /// <summary>
        /// Metodo que devuelve un objeto Actividad (si existe) pasandole el nombre de la misma.
        /// </summary>
        /// <param name="nombreAct"></param>
        /// <returns>Actividad</returns>
        public Actividad GetActividadPorNombre(string nombreAct)
        {
            Actividad objActividad = null;
            foreach(Actividad act in listaActividades)
            {
                if(act.Nombre == nombreAct)
                {
                    objActividad = act;
                }
            }
            return objActividad;
        }

        /// <summary>
        /// Metodo usado en el punto tres del menu de consola para mostrar actividades que cumplan cierto costo y este entre ciertas fechas.
        /// </summary>
        /// <param name="costoBase"></param>
        /// <param name="fechaBase"></param>
        /// <param name="fechaMaxima"></param>
        /// <returns>Lista de actividades</returns>
        public List<Actividad> GetActividadesSegunFechaYCosto(int costoBase, DateTime fechaBase, DateTime fechaMaxima)
        {
            List<Actividad> retorno = new List<Actividad>();
            foreach (Actividad unaActividad in listaActividades)
            {
                if (unaActividad.Fecha > fechaBase && unaActividad.Fecha < fechaMaxima && unaActividad.Costo > costoBase)
                {
                    retorno.Add(unaActividad);
                }
            }
            return retorno;
        }

        public Actividad GetActPorId(int? idAct)
        {
            Actividad actRet = null;
            foreach(Actividad a in listaActividades)
            {
                if(idAct == a.Id)
                {
                    actRet = a;
                }
            }
            return actRet;
        }

        #region Geters de las listas.
        public IEnumerable<Actividad> GetActividades()
        {
            listaActividades.Sort();
            return listaActividades;
        }
        public IEnumerable<Agenda> GetAgendas()
        {
            return listaAgendas;
        }
        public IEnumerable<Usuario> GetUsuarios()
        {
            return listaUsuarios;
        }
        public IEnumerable<Proveedor> GetProveedores()
        {
            listaProveedores.Sort();
            return listaProveedores;
        }
        #endregion


        #region Seters de las listas.
        public void AltaActividadPropia(ActividadPropia unaActividad)
        {
            if (unaActividad == null)
            {
                throw new Exception("La actividad no puede ser nula.");
            }
            if (listaActividades.Contains(unaActividad))
            {
                throw new Exception("Esa actividad ya existe.");
            }

            try
            {
                unaActividad.Validar();
                listaActividades.Add(unaActividad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaActividadTercerizada(ActividadTercerizada unaActividad)
        {
            if (unaActividad == null)
            {
                throw new Exception("La actividad no puede ser nula.");
            }
            if (listaActividades.Contains(unaActividad))
            {
                throw new Exception("Esa actividad ya existe.");
            }

            try
            {
                unaActividad.Validar();
                listaActividades.Add(unaActividad);
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Agenda.
        public void AltaAgenda(Agenda unaAgenda)
        {

            if (unaAgenda == null)
            {
                throw new Exception("La agenda no puede ser nula.");
            }
            if (listaAgendas.Contains(unaAgenda))
            {
                throw new Exception("Esa agenda ya existe.");
            }


            try
            {
                unaAgenda.Validar();
                listaAgendas.Add(unaAgenda);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void AltaHuesped(Huesped unHuesped)
        {
            if (unHuesped == null)
            {
                throw new Exception("El huesped no puede ser nulo.");
            }
            if (listaUsuarios.Contains(unHuesped))
            {
                throw new Exception("El huesped ya existe.");
            }


            try
            {
                unHuesped.Validar();
                listaUsuarios.Add(unHuesped);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaOperador(Operador unOperador)
        {
            if (unOperador == null)
            {
                throw new Exception("El operador no puede ser nulo.");
            }

            try
            {
                if (!listaUsuarios.Contains(unOperador))
                {
                    unOperador.Validar();
                    listaUsuarios.Add(unOperador);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //Proveedores.
        public void AltaProveedor(Proveedor unProveedor)
        {
            if (unProveedor == null)
            {
                throw new Exception("El proveedor no puede ser nulo.");
            }
            if (listaProveedores.Contains(unProveedor))
            {
                throw new Exception("Ese proveedor ya existe.");
            }

            try
            {
                unProveedor.Validar();
                listaProveedores.Add(unProveedor);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
