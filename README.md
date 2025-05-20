# Pokédex Web MVC

## Instrucciones:

- Arrancar la API i la web (ara tot és .NET) obrint una terminal a la carpeta arrel del projecte i executant:

  ```bash
  dotnet run
  ```

- Obrir Swagger per veure i provar els endpoints de l'API:

  [http://localhost:5064/swagger](http://localhost:5064/swagger)

- La web MVC també s'arrenca amb el mateix `dotnet run`. Per exemple, pots accedir a l'endpoint de pokémons aquí:

  [http://localhost:5064/pokemons](http://localhost:5064/pokemons)

## Motivación
Los videojuegos de Pokémon es algo que nos a acompañado en nuestras infancias, por eso hemos decidido hacer una página tipo "pokédex" (como una bd de pokémons)

## Esquema de arquitectura
El proyecto sigue la arquitectura MVC (Modelo-Vista-Controlador) de .NET Core:
- **Modelos:** Representan los datos de Pokémon, tipos, regiones y favoritos. Incluyen modelos para la integración con la PokéAPI y para la base de datos local (SQLite).
- **Vistas:** Archivos `.cshtml` Razor que muestran información de Pokémon, tipos, regiones y favoritos, con maquetación cuidada y estilos personalizados en CSS.
- **Controladores:** Gestionan las rutas principales, coordinan la obtención de datos de la PokéAPI y la base de datos, y pasan los datos a las vistas.

## Explicación detallada del código y la arquitectura MVC
- **Controladores:**
  - `PokemonController`: Gestiona las rutas para buscar Pokémon por nombre, tipo y región, mostrar detalles y gestionar favoritos. Llama a servicios para consumir la PokéAPI y la base de datos SQLite.
  - `HomeController`: Página principal y rutas genéricas.
- **Modelos:**
  - Modelos para deserializar la respuesta de la PokéAPI (`PokemonApiModel`, `PokemonTypeApiModel`, `PokemonRegionApiModel`, etc.).
  - Modelos para la base de datos local (`PokemonFavorite`, etc.).
- **Vistas:**
  - Páginas Razor para mostrar listas, búsquedas, detalles y favoritos.
  - Uso de partials para reutilizar componentes (por ejemplo, detalles de Pokémon).
- **Servicios:**
  - `PokemonService`: Encapsula la lógica de consumo de la PokéAPI y el mapeo de datos.
  - `PokemonCacheService`: Gestiona la caché de datos para mejorar el rendimiento.
- **Base de datos:**
  - SQLite gestionada mediante Entity Framework Core.
- **Serialización:**
  - Uso de la librería Newtonsoft.Json para la serialización y deserialización de datos JSON.

## Propuestas de mejora y nuevas funcionalidades

- Implementar autenticación de usuarios para favoritos personalizados.
- Añadir gráficos y estadísticas de Pokémon.
- Mejorar la experiencia móvil