# Introducción
Entity Framework Core (EF Core) con el enfoque de Code First, soporta herencia para modelar entidades en una base de datos. 

Los tipos de herencia soportados son:
- Table per Hierarchy (TPH)   
- Table per Type (TPT)    
- Table per Concrete Class (TPC)


> [!info] 
> https://learn.microsoft.com/en-us/ef/core/modeling/inheritance 

# Table per Hierarchy (TPH)   
- Es el enfoque por defecto en EF Core.
- Todas las clases derivadas se almacenan en una sola tabla, y una columna discriminadora se usa para diferenciar entre las diferentes subclases.
- Ventajas: Simplicidad y rendimiento, ya que todo está en una tabla.
- Desventajas: Puede resultar en tablas grandes y con muchas columnas nulas si las subclases tienen propiedades muy diferentes.

# Table per Type (TPT)
- Cada clase en la jerarquía tiene su propia tabla, donde existe una tabla “general” que contiene las propiedades comunes, y tablas que contienen las propiedades específicas de cada subclase. Ventajas: Mejora la normalización y evita la proliferación de columnas nulas.
- Desventajas: Puede afectar el rendimiento debido a los `JOIN` necesarios para reconstruir las entidades completas.

# Table per Concrete Class (TPC)
- Cada clase concreta (no abstracta) tiene su propia tabla, incluyendo todas las propiedades heredadas.
- Ventajas: Sencillez y evita los `JOIN`.
- Desventajas: Puede causar duplicación de datos y problemas de normalización.

