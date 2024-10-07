Algunos desafios a los que nos enfrentamos:
Uno de los mayores desafíos fue asegurarnos de que todas las clases respetaran los principios de diseño, especialmente SRP (Single Responsibility Principle) y Expert. Al principio, había una tendencia a sobrecargar clases como Batalla con responsabilidades tanto de lógica de juego como de interacción con el usuario, lo cual iba en contra del principio de responsabilidad única. Dividir esa lógica entre clases más especializadas fue un desafío, pero resultó en un código más modular y fácil de mantener.

Otro desafío fue implementar correctamente el polimorfismo y el uso de interfaces en el sistema de tipos de Pokémon. Asegurar que los diferentes tipos pudieran interactuar de manera flexible y que la efectividad de los ataques se pudiera calcular sin romper el principio de sustitución de Liskov (LSP) también fue complicado. Fue necesario reestructurar algunas partes del código para que cada tipo de Pokémon implementara la interfaz ITipo y pudiera calcular la efectividad de los ataques de manera intercambiable.


Aprendisajes feura de la curricula: 
Un aprendizaje clave fuera de la currícula fue cómo integrar el Patrón Facade para simplificar la interacción con sistemas complejos. Aunque habíamos visto algunos patrones de diseño en clase, aplicar un Facade en un escenario práctico donde necesitábamos simplificar la interacción entre la lógica de la batalla y la interfaz con los jugadores fue algo nuevo. Implementar el patrón nos ayudó a desacoplar la lógica interna del programa de la forma en que interactuábamos con el usuario, haciendo que el sistema fuera mucho más fácil de mantener y extender.
Para la implementacion de esto utilizamos la documentacion enviada por los docentes: https://refactoring.guru/design-patterns/facade


Reflexión y comentarios adicionales sobre el trabajo en el proyecto:
Este proyecto nos dio una visión mucho más profunda de la importancia de un diseño adecuado en aplicaciones más grandes. Empezamos con una estructura de código mucho más rígida y compleja, pero a medida que fuimos aplicando los principios de diseño, nos dimos cuenta de lo mucho que mejoraba la calidad del código en términos de legibilidad, mantenibilidad y extensibilidad.

Además, entendimos que el diseño orientado a objetos va más allá de solo usar clases e interfaces. Se trata de pensar cuidadosamente en las responsabilidades de cada parte del sistema y en cómo interactúan entre sí de manera eficiente. El uso de patrones de diseño no es simplemente un ejercicio académico, sino una herramienta práctica para crear software que funcione de manera sólida y flexible, incluso en escenarios complejos.

Este proyecto también nos enseñó a planificar mejor y pensar más en las interacciones entre las clases desde el principio, en lugar de empezar a escribir código y luego refactorizar grandes partes.
