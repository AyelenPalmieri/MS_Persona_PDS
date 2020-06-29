###MicroServicio Persona

(Se puede correr, previamente, Script en SqlServer para cargar Provincias, Localidades, Generos, Estados Civiles y Nacionalidades a las tablas correspondientes)

####EndPoints creados con sus correspondientes Resquest Json y Response Json

<u>Cargar una persona al Sistema</u>

    - La Provincia en Persona se guardan por ID de Provincia
    - La Localidad en Persona se guardan por ID de Localidad
    - La Nacionalidad en Persona se guardan por ID de Nacionalidad
    - El Genero en Persona de guardan por ID de Genero
    - El Estado Civil en Persona de guardan por ID de Estado Civil
    - El campo si tiene hijos de la persona se carga inicialmente como false
    - El campo de fecha de defuncion de la persona se carga inicialmente como null


[HttpPost] URI: https://localhost:44391/api/persona/SetPersona

**Request Json**

```csharp
{
    "Dni": 42568589,
    "Nombre": "Monica",
    "Apellido": "Argento",
    "FechaNacimiento": "1987-11-05T10:48:07",
    "Genero": "Femenino",
    "EstadoCivil": "Casado/a",
    "Nacionalidad": "Argentina",
    "Provincia" : "Buenos Aires",
    "Localidad": "Berazategui",
    "Direccion": "Av melvin 589"
}
```

**Response Json**
```csharp
{
    "personaId": 1,
    "dni": 42568589,
    "nombre": "Monica",
    "apellido": "Argento",
    "fechaNacimiento": "1987-11-05T10:48:07",
    "generoId": 1,
    "estadoCivilId": 1,
    "nacionalidadId": 1,
    "provinciaId": 1,
    "localidadId": 2,
    "direccion": "Av melvin 589",
    "tieneHijos": false,
    "fechaDefuncion": null,
    "nacionalidad": {
        "nacionalidadId": 1,
        "tipoDeNacionalidad": "Argentina"
    },
    "estadoCivil": {
        "estadoCivilId": 1,
        "tipoEstadoCivil": "Casado/a"
    },
    "genero": {
        "generoId": 1,
        "tipoGenero": "Femenino"
    },
    "provincia": {
        "provinciaId": 1,
        "nombreProvincia": "Buenos Aires"
    },
    "localidad": {
        "localidadId": 2,
        "nombreLocalidad": "Berazategui"
    }
}
```
-------------------------------------------------------------------------------

<u>Traer el Listado de todas las Personas ingresadas</u>

[HttpGet] URI: https://localhost:44391/api/persona/AllPersonas

**Response Json**

```csharp
{
    "Personas": [
        {
            "dni": 42568589,
            "nombre": "Monica",
            "apellido": "Argento",
            "fechaNacimiento": "1987-11-05T10:48:07",
            "genero": "Femenino",
            "estadoCivil": "Casado/a",
            "nacionalidad": "Argentina",
            "provincia": "Buenos Aires",
            "localidad": "Berazategui",
            "direccion": "Av melvin 589",
            "tieneHijos": false,
            "fechaDefuncion": null
        },
        {
            "dni": 43xxxxxx,
            ...
        },
        {
            "dni": 40xxxxxx,
            ...
        },
        {
            ...
        }
    ]
}
```

-------------------------------------------------------------------------------

<u>Traer una Persona ingresada
(DEVOLVERA UN OBJETO COMPLEJO VINCULANDO LOS DATOS DE PERSONA CON LOS OBJETOS GENERO, ESTADO CIVIL, NACIONALIDAD, PROVINCIA, LOCALIDAD Y SI TIENE HIJOS)</u>

[HttpGet] URI: https://localhost:44391/api/persona/GetPersona{Dni}

**Response Json**

```csharp
{
    "personaId": 1,
    "dni": 45956785,
    "nombre": "Monica",
    "apellido": "Argento",
    "fechaNacimiento": "1987-11-05T10:48:07",
    "generoId": 1,
    "estadoCivilId": 1,
    "nacionalidadId": 1,
    "provinciaId": 1,
    "localidadId": 2,
    "direccion": "Av melvin 589",
    "tieneHijos": true,
    "fechaDefuncion": null,
    "nacionalidad": {
        "nacionalidadId": 1,
        "tipoDeNacionalidad": "Argentina"
    },
    "estadoCivil": {
        "estadoCivilId": 1,
        "tipoEstadoCivil": "Casado/a"
    },
    "genero": {
        "generoId": 1,
        "tipoGenero": "Femenino"
    },
    "provincia": {
        "provinciaId": 1,
        "nombreProvincia": "Buenos Aires"
    },
    "localidad": {
        "localidadId": 2,
        "nombreLocalidad": "Berazategui"
    }
}
```

-------------------------------------------------------------------------------

<u>Cargar Hijos a una Persona ingresada
(EL CAMPO TIENEHIJOS EN PERSONA PASA A CONTENER EL VALOR TRUE SOLO CUANDO SE REALIZA LA SOLICITUD POR POST DE SETHIJOS, LUEGO LOS DNI DE LOS HIJOS DE ESA PERSONA SE CARGARAN EN LA TABLA LISTAHIJOS)</u>

[HttpPost] URI: https://localhost:44391/api/listahijos/SetHijos

**Request Json**

```csharp
{
    "PadreDNI": 45956785,
    "HijoDNI": 42545235
}
```

**Response Json**

```csharp
{
    "padreDni": 45956785,
    "hijos": [
        {
            "listaHijosId": 1,
            "hijoDni": 35456789
        },
        {
            "listaHijosId": 2,
            "hijoDni": 32478956
        },
        {
            "listaHijosId": 3,
            "hijoDni": 30478523
        }
    ]
}
```

-------------------------------------------------------------------------------

<u>Traer el Listado de todos los Hijos de una Persona ingresada
(MOSTRAR SOLO LOS ID Y DNI DE CADA UNO DE LOS HIJOS DE LA PERSONA)</u>

[HttpGet] URI: https://localhost:44391/api/listahijos/GetHijosByPadreDni{PadreDni}

**Response Json**

```csharp
{
    "padreDni": 45956785,
    "hijos": [
        {
            "listaHijosId": 1,
            "hijoDni": 35456789
        },
        {
            "listaHijosId": 2,
            "hijoDni": 32478956
        },
        {
            "listaHijosId": 3,
            "hijoDni": 30478523
        }
    ]
}
```

-------------------------------------------------------------------------------

<u>Cargar un Genero</u>

[HttpPost] URI: https://localhost:44391/api/genero/SetGenero

**Request Json**

```csharp
{
    "TipoGenero" : "Masculino"
}
```

**Response Json**

```csharp
{
    "generoId": 2,
    "tipoGenero": "Masculino"
}
```

-------------------------------------------------------------------------------
<u>Cargar lista de Localidades a una Provincia existente</u>

[HttpPost] URI: https://localhost:44391/api/provincia/SetLocalidadesByNombreProvincia


**Request Json**

```csharp
{
   "NombreProvincia": "Buenos Aires",

	"Localidades": [

    	{
      	"NombreLocalidad": "Quilmes"
        },
        {
        "NombreLocalidad": "Berazategui"
        },
        {
        "NombreLocalidad": "Fcio Varela"
        }
    ]
}
```

**Response Json**

```csharp
{
    "provinciaId": 1,
    "nombreProvincia": "Buenos Aires",
    "localidades": [
        {
            "localidadId": 1,
            "nombreLocalidad": "Quilmes"
        },
        {
            "localidadId": 2,
            "nombreLocalidad": "Berazategui"
        },
        {
            "localidadId": 3,
            "nombreLocalidad": "Fcio Varela"
        }
    ]
}
```

-------------------------------------------------------------------------------

<u>Traer el Listado de Provincias</u>

[HttpGet] URI: https://localhost:44391/api/provincia/AllProvincias

**Response Json**

```csharp
[
    {
        "provinciaId": 1,
        "nombreProvincia": "Buenos Aires"
    },
    {
        "provinciaId": 2,
        "nombreProvincia": "Tucuman"
    },
    {
        "provinciaId": 3,
        "nombreProvincia": "Cordoba"
    }
]
```

-------------------------------------------------------------------------------

<u>Cargar una Provincia</u>

[HttpPost] URI: https://localhost:44391/api/provincia/SetProvincia

**Request Json**

```csharp
{
    "nombreProvincia" : "Buenos Aires"
}
```

**Response Json**

```csharp
{
    "provinciaId": 1,
    "nombreProvincia": "Buenos Aires"
}
```

-------------------------------------------------------------------------------

<u>Traer el Listado de Localidades</u>

[HttpGet] URI: https://localhost:44391/api/localidad/AllLocalidades

**Response Json**

```csharp
[
    {
        "localidadId": 1,
        "nombreLocalidad": "Quilmes"
    },
    {
        "localidadId": 2,
        "nombreLocalidad": "Berazategui"
    },
    {
        "localidadId": 3,
        "nombreLocalidad": "Fcio Varela"
    },
    {
        "localidadId": 4,
        "nombreLocalidad": "Lanus"
    },
    {
        "localidadId": 5,
        "nombreLocalidad": "Temperley"
    },
    {
        "localidadId": 6,
        "nombreLocalidad": "Souriguez"
    }
]
```

-------------------------------------------------------------------------------

<u>Traer el Listado de Localidades por Provincia</u>

[HttpGet] URI: https://localhost:44391/api/provincia/GetLocalidadesByProvincia/{NombreProvincia}

**Response Json**

```csharp
{
    "provinciaId": 1,
    "nombreProvincia": "Buenos Aires",
    "localidades": [
        {
            "localidadId": 1,
            "nombreLocalidad": "Quilmes"
        },
        {
            "localidadId": 2,
            "nombreLocalidad": "Berazategui"
        },
        {
            "localidadId": 3,
            "nombreLocalidad": "Fcio Varela"
        },
        {
            "localidadId": 4,
            "nombreLocalidad": "Lanus"
        },
        {
            "localidadId": 5,
            "nombreLocalidad": "Temperley"
        }
    ]
}
```

-------------------------------------------------------------------------------

<u>Traer el Listado de Generos</u>

[HttpGet] URI: https://localhost:44391/api/genero/AllGeneros

**Response Json**

```csharp
[
    {
        "generoId": 1,
        "tipoGenero": "Femenino"
    },
    {
        "generoId": 2,
        "tipoGenero": "Masculino"
    }
]
```

-------------------------------------------------------------------------------

<u>Traer el Listado de Estados Civiles</u>

[HttpGet] URI: https://localhost:44391/api/estadocivil/AllEstadosCiviles

**Response Json**

```csharp
[
    {
        "estadoCivilId": 1,
        "tipoEstadoCivil": "Casado/a"
    },
    {
        "estadoCivilId": 2,
        "tipoEstadoCivil": "Divorciado/a"
    },
    {
        "estadoCivilId": 3,
        "tipoEstadoCivil": "Separado/a Legalmente"
    },
    {
        "estadoCivilId": 4,
        "tipoEstadoCivil": "Soltero/a"
    },
    {
        "estadoCivilId": 5,
        "tipoEstadoCivil": "Viudo/a"
    }
]
```

-------------------------------------------------------------------------------

<u>Agregar Fecha de Defuncion a una Persona (Modificar campo en Persona)</u>

[HttpPut] URI: https://localhost:44391/api/persona/ModifyFechaDefuncion

**Request Json**

```csharp
{
	"Dni" : 45956785,
	"fechaDefuncion" : "2020-05-05T10:48:07"
}
```

**Response Json**

```csharp
(return numero de filas afectadas)
```

-------------------------------------------------------------------------------

<u>Modificar datos de una Persona 
(NO SE PODRA MODIFICA EL DATO DE PERSONAID, DNI, FECHA DE NACIMIENTO Y NACIONALIDAD)</u>

[HttpPut] URI: https://localhost:44391/api/persona/ModifyPersonaByDNI

**Request Json**

```csharp
{
    "Dni": 45956785,
    "Nombre": "Carlos",
    "Apellido": "Perez",
    "Genero": "Masculino",
    "EstadoCivil": "Casado/a",
    "Localidad": "Fcio Varela",
    "Direccion": "Av San Martin 456"
}
```

**Response Json**

```csharp
(return numero de filas afectadas)
```

--------------------------------------------------------------------------------

<u>Cargar una Nacionalidad</u>

[HttpPost] URI: https://localhost:44391/api/nacionalidad/SetNacionalidad

**Request Json**

```csharp
{
    "tipoDeNacionalidad" : "Argentina"
}
```

**Response Json**

```csharp
{
    "nacionalidadId": 1,
    "tipoDeNacionalidad": "Argentina"
}
```

--------------------------------------------------------------------------------

<u>Traer el Listado de Nacionalidades</u>

[HttpGet] URI: https://localhost:44391/api/nacionalidad/AllNacionalidades

**Response Json**

```csharp
[
    {
        "nacionalidadId": 1,
        "tipoDeNacionalidad": "Argentina"
    },
    {
        "nacionalidadId": 2,
        "tipoDeNacionalidad": "Paraguay"
    },
    {
        "nacionalidadId": 3,
        "tipoDeNacionalidad": "Uruguay"
    },
    {
        "nacionalidadId": 4,
        "tipoDeNacionalidad": "Chile"
    },
    {
        "nacionalidadId": 6,
        "tipoDeNacionalidad": "Brasil"
    },
    {
        "nacionalidadId": 7,
        "tipoDeNacionalidad": "Ecuador"
    },
    {
        "nacionalidadId": 8,
        "tipoDeNacionalidad": "Bolivia"
    }
]
```
