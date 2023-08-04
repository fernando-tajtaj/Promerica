--A. Escriba la consulta en SQL que devuelva el nombre del proyecto y sus productos del proyecto Premia cuyo código es 1.
SELECT 
	b.ProyectoNombre [Proyecto]
	, a.* [Producto]
FROM Producto_Proyecto a INNER JOIN Proyecto b
ON a.IdProyecto = b.ProyectoId
WHERE b.ProyectoId = 1
AND b.ProyectoNombre = ‘PREMIA’

--B. Escriba una consulta SQL que devuelva los distintos mensajes que hay, indicando a qué proyecto y producto pertenecen.
SELECT
	d.Nombre [TipoMensaje]
	, c.Nombre [TipoInformacion]
	, b.Asunto [Mensaje]
	, e.Nombre [Proyecto]
	, f.Descripcion [Producto]
FROM Mensaje a INNER JOIN Formato_Mensaje b
ON a.FormatoMensaje = b.FormatoMensaje
INNER JOIN Tipo_Informacion c
ON b.TipoInformacion = c.TipoInformacion
INNER JOIN Tipo d
ON b.Tipo = d.Tipo
INNER JOIN Proyecto e
ON a.Proyecto = e.Proyecto
INNER JOIN Producto f
ON a.Producto = f.Producto

--C. Escriba una consulta SQL que devuelva los distintos mensajes que hay, indicando a qué proyecto y producto pertenecen. 
--Pero si el mensaje está en todos los productos de un proyecto, en lugar de mostrar cada producto, debe mostrar el nombre del proyecto y un solo producto que diga “TODOS”.
SELECT
    b.Proyecto [Proyecto]
    , ISNULL(a.Producto, 'TODOS') [Producto]
FROM (
    SELECT DISTINCT 
	d.Proyecto
	, d.Producto
    FROM Mensajes d
) a
LEFT JOIN Proyecto b 
ON a.Proyecto = b.Proyecto
LEFT JOIN Producto c 
ON a.Producto = c.Producto;
