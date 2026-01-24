# Analisis de Desiciones Técnicas

1. Estrategia de caché

- Se usó IMemoryCache en memoria local
- Para una aplicación que requiere simplicidad y velocidad por la cantidad de peticiones recibidas lo mejor fue aplicar está estrategia que va directamente a la RAM,
- Para la invalidación se aplicó Absolute Expiration en este caso de 1 hora y un sliding expiration de 20 minutos, lo cual es un tiempo prudente para la eliminación de la caché.

2. Solución de la Concurrencia

- la téctina usada fue con RowVersion para concurrencia optimizada
- La tabla de las Tareas contiene una columna de RowVersion en Byte[] con el atributo de TimeStamp en la base de datos
-  Cuando dos usuarios intentan editar la misma tarea, EF Core compara la versión de la fila. Si el segundo usuario intenta guardar una versión antigua, el sistem
   arroja una DbUpdateConcurrencyException, evitando el problema de "la última escritura gana" y protegiendo la integridad de los datos.

3. Escalabilidad del backgroudService

- ¿Qué pasaría si tu aplicación backend estuviera escalada horizontalmente en 3 servidores?
  ¿Tu servicio de fondo se ejecutaría 3 veces enviando correos duplicados? 
  R/ Si, se tendría un caso de duplicados ya que el background service vive dentro del proceso de la app se tendrian los servidores enviando las ejecuciones cada 2 minutos
  Solución: La solución principal puede ser un servicio de mensajeria (Colas), seria que la ejecucion envie un mensaje al broker  por ejemplo Azure serviceBus los servidores escuchan la
  cola y el broker se encarga de entregar el mensaje a un solo consumidor.