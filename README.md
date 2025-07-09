# Sistema de Gestión de Vuelos - FISEI

## Descripción

Sistema de gestión de vuelos desarrollado en .NET Framework 4.7.2 utilizando arquitectura en capas y servicios WCF REST. El proyecto implementa un sistema completo para la gestión de vuelos, usuarios, reservas y autenticación.

## Arquitectura del Proyecto

El proyecto sigue una arquitectura en capas bien definida:

### Capas del Sistema

#### 1. **Capa de Dominio** (`proyecto.fisei.vuelos.dominio`)
Contiene las entidades principales del sistema:
- **Vuelo**: Gestión de vuelos con origen, destino, fechas y precios
- **Usuario**: Gestión de usuarios con autenticación
- **Reserva**: Gestión de reservas de vuelos por usuarios

#### 2. **Capa de Contratos** (`proyecto.fisei.vuelos.contrato`)
Define las interfaces de servicios WCF:
- `IVueloService`: Operaciones de vuelos
- `IUsuarioService`: Gestión de usuarios
- `IReservaService`: Gestión de reservas
- `IAuthService`: Autenticación de usuarios

#### 3. **Capa de Implementación** (`proyecto.fisei.vuelos.implementacion`)
Implementa los servicios WCF:
- `VueloService`: Implementación de operaciones de vuelos
- `UsuarioService`: Implementación de gestión de usuarios
- `ReservaService`: Implementación de gestión de reservas
- `AuthService`: Implementación de autenticación

#### 4. **Capa de Fachada** (`proyecto.fisei.vuelos.fachada`)
Proporciona una capa de abstracción entre servicios y repositorios:
- `VueloFachada`: Fachada para operaciones de vuelos
- `UsuarioFachada`: Fachada para operaciones de usuarios
- `ReservaFachada`: Fachada para operaciones de reservas
- `AuthFachada`: Fachada para operaciones de autenticación

#### 5. **Capa de Repositorios** (`proyecto.fisei.vuelos.ContratoRepositorio` y `proyecto.fisei.vuelos.sqlrepositorio`)
- **Contratos**: Define interfaces de repositorios
- **SQL Repositorio**: Implementación con SQL Server y Dapper

#### 6. **Capa de Utilidades** (`proyecto.fisei.vuelos.utils`)
- `Utils`: Funciones de utilidad como hash de contraseñas

#### 7. **Capa de Servicios WCF** (`proyecto.fisei.vuelos.wcf`)
Hospeda los servicios WCF con endpoints REST y SOAP.

## Tecnologías Utilizadas

- **.NET Framework 4.7.2**
- **WCF (Windows Communication Foundation)**
- **SQL Server** (Base de datos remota)
- **Dapper** (Micro ORM)
- **Newtonsoft.Json** (Serialización JSON)
- **SHA256** (Hash de contraseñas)

## Funcionalidades Principales

### Gestión de Vuelos
- Listar todos los vuelos disponibles
- Buscar vuelos por criterios (origen, destino, fechas)
- Información detallada de vuelos (precio, horarios, etc.)

### Gestión de Usuarios
- Registro de nuevos usuarios
- Listado de usuarios
- Autenticación segura con hash SHA256

### Gestión de Reservas
- Crear nuevas reservas
- Listar reservas por usuario
- Actualizar estado de reservas
- Seguimiento de reservas

### Autenticación
- Inicio de sesión seguro
- Validación de credenciales
- Hash de contraseñas con SHA256

## Configuración de la Base de Datos

El proyecto utiliza una base de datos SQL Server remota configurada en `Web.config`:

```xml
<connectionStrings>
    <add name="Proyecto" 
         connectionString="Data Source=DBProyectoAD.mssql.somee.com; 
                         Initial Catalog=DBProyectoAD; 
                         user id=Ariel21A_SQLLogin_1;
                         pwd=bos7eo41ed;"/>
</connectionStrings>
```

## Endpoints REST Disponibles

### Servicio de Vuelos
- `GET /VueloService/rest/ListarVuelos` - Listar todos los vuelos
- `POST /VueloService/rest/BuscarVuelos` - Buscar vuelos por criterios

### Servicio de Usuarios
- `GET /UsuarioService/rest/ListarUsuarios` - Listar todos los usuarios
- `POST /UsuarioService/rest/RegistrarUsuario` - Registrar nuevo usuario

### Servicio de Reservas
- `POST /ReservaService/rest/ListarReservas` - Listar reservas por usuario
- `POST /ReservaService/rest/RegistrarReserva` - Crear nueva reserva
- `PUT /ReservaService/rest/ActualizarReserva` - Actualizar reserva

### Servicio de Autenticación
- `POST /AuthService/rest/IniciarSesion` - Iniciar sesión de usuario

## Estructura de la Solución

```
ProyectoVuelos/
├── proyecto.fisei.vuelos.dominio/          # Entidades del dominio
├── proyecto.fisei.vuelos.contrato/          # Interfaces de servicios
├── proyecto.fisei.vuelos.implementacion/    # Implementación de servicios
├── proyecto.fisei.vuelos.fachada/           # Capa de fachada
├── proyecto.fisei.vuelos.ContratoRepositorio/ # Interfaces de repositorios
├── proyecto.fisei.vuelos.sqlrepositorio/    # Implementación de repositorios
├── proyecto.fisei.vuelos.utils/             # Utilidades
├── proyecto.fisei.vuelos.wcf/               # Hospedaje de servicios WCF
└── ProyectoVuelos.sln                      # Solución principal
```

## Instalación y Configuración

### Prerrequisitos
- Visual Studio 2017 o superior
- .NET Framework 4.7.2
- SQL Server (para desarrollo local)

### Pasos de Instalación

1. **Clonar el repositorio**
   ```bash
   git clone [URL_DEL_REPOSITORIO]
   cd ProyectoVuelos
   ```

2. **Abrir la solución en Visual Studio**
   - Abrir `ProyectoVuelos.sln`
   - Restaurar paquetes NuGet

3. **Configurar la base de datos**
   - Modificar la cadena de conexión en `proyecto.fisei.vuelos.wcf/Web.config`
   - Ejecutar los scripts de base de datos si es necesario

4. **Compilar la solución**
   - Build → Build Solution (Ctrl+Shift+B)

5. **Ejecutar el proyecto WCF**
   - Establecer `proyecto.fisei.vuelos.wcf` como proyecto de inicio
   - Presionar F5 para ejecutar

## Uso de los Servicios

### Ejemplo de Consumo REST

```javascript
// Listar vuelos
fetch('/VueloService/rest/ListarVuelos', {
    method: 'GET',
    headers: {
        'Content-Type': 'application/json'
    }
})
.then(response => response.json())
.then(data => console.log(data));

// Buscar vuelos
fetch('/VueloService/rest/BuscarVuelos', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify({
        Origen: "Quito",
        Destino: "Guayaquil"
    })
})
.then(response => response.json())
.then(data => console.log(data));
```

## Características de Seguridad

- **Hash de contraseñas**: Utiliza SHA256 para el hash de contraseñas
- **Validación de datos**: Validación en capas de dominio y servicios
- **Manejo de errores**: Gestión centralizada de excepciones
- **CORS habilitado**: Soporte para peticiones cross-origin

## Patrones de Diseño Utilizados

- **Arquitectura en Capas**: Separación clara de responsabilidades
- **Repository Pattern**: Abstracción del acceso a datos
- **Facade Pattern**: Simplificación de interfaces complejas
- **Dependency Injection**: Inyección de dependencias en servicios
- **Service Layer Pattern**: Capa de servicios para lógica de negocio

## Mantenimiento y Desarrollo

### Agregar Nuevas Funcionalidades

1. **Nuevas entidades**: Agregar en la capa de dominio
2. **Nuevos servicios**: Crear interfaces en contratos e implementar
3. **Nuevos repositorios**: Implementar patrones existentes
4. **Configuración WCF**: Actualizar Web.config con nuevos endpoints

### Debugging

- Utilizar herramientas de debugging de Visual Studio
- Revisar logs de WCF en el Event Viewer
- Verificar conexiones de base de datos

## Contribución

1. Fork el proyecto
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## Licencia

Este proyecto está bajo la Licencia MIT. Ver el archivo `LICENSE` para más detalles.

## Contacto

- **Desarrollador**: FISEI
- **Proyecto**: Sistema de Gestión de Vuelos
- **Versión**: 1.0.0

---

**Nota**: Este proyecto es un sistema académico desarrollado para fines educativos en el contexto de la FISEI. 