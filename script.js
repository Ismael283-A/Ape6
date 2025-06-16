const apiUrl = "https://localhost:7102/api/Producto"; 

async function cargarProductos() { 

  try { 

    const res = await fetch(apiUrl); 

    const data = await res.json(); 

    console.log("📥 Productos cargados desde API:", data); 

    const tabla = document.getElementById("tabla-productos"); 

    tabla.innerHTML = ""; 

    if (!Array.isArray(data) || data.length === 0) { 

      console.warn("📭 No hay productos para mostrar."); 

      tabla.innerHTML = ` 

        <tr> 

          <td colspan="5" style="text-align:center; font-style:italic;">No hay productos disponibles</td> 

        </tr>`; 

      return; 

    } 

    data.forEach(p => { 

      console.log("➡️ Producto en tabla:", p); 

      const fila = document.createElement("tr"); 

      fila.innerHTML = ` 

        <td>${p.IdProducto}</td> 

        <td>${p.NombreProducto}</td> 

        <td>$${p.Precio.toFixed(2)}</td> 

        <td>${p.Stock}</td> 

        <td> 

          <button onclick="cargarParaEditar(${p.IdProducto}, '${p.NombreProducto}', ${p.Precio}, ${p.Stock})">✏️ Editar</button> 

          <button onclick="eliminarProducto(${p.IdProducto})">🗑️ Eliminar</button> 

        </td> 

      `; 

      tabla.appendChild(fila); 

    }); 

  } catch (error) { 

    console.error("❌ Error al cargar productos:", error); 

  } 

} 

 
 

async function crearProducto(event) { 

  event.preventDefault(); 

 
 

  const id = document.getElementById("idProducto").value; 

  const nombre = document.getElementById("nombre").value.trim(); 

  const precio = parseFloat(document.getElementById("precio").value); 

  const stock = parseInt(document.getElementById("stock").value); 

 
 

  if (!nombre) { 

    alert("⚠️ El nombre es obligatorio."); 

    return; 

  } 

 
 

  const producto = { 

    NombreProducto: nombre, 

    Precio: precio, 

    Stock: stock 

  }; 

 
 

  console.log("📤 Producto a enviar:", producto); 

 
 

  let res; 

  if (id) { 

    producto.IdProducto = parseInt(id); 

    console.log("🛠️ Enviando PUT..."); 

    res = await fetch(apiUrl, { 

      method: "PUT", 

      headers: { "Content-Type": "application/json" }, 

      body: JSON.stringify(producto) 

    }); 

  } else { 

    console.log("🆕 Enviando POST..."); 

    res = await fetch(apiUrl, { 

      method: "POST", 

      headers: { "Content-Type": "application/json" }, 

      body: JSON.stringify(producto) 

    }); 

  } 

 
 

  const result = await res.text(); 

 
 

  if (res.ok) { 

    console.log("✅ Respuesta del servidor:", result); 

    alert(`✅ Producto ${id ? "actualizado" : "creado"} correctamente`); 

    await cargarProductos(); 

    document.getElementById("form-crear").reset(); 

    document.getElementById("idProducto").value = ""; 

  } else { 

    console.error("❌ Error en respuesta del servidor:", result); 

    alert("❌ Error al guardar el producto:\n" + result); 

  } 

} 

 
 

function cargarParaEditar(id, nombre, precio, stock) { 

  console.log("✏️ Cargando producto para editar:", { id, nombre, precio, stock }); 

  document.getElementById("idProducto").value = id; 

  document.getElementById("nombre").value = nombre; 

  document.getElementById("precio").value = precio; 

  document.getElementById("stock").value = stock; 

} 

 
 

async function eliminarProducto(id) { 

  if (confirm("¿Estás seguro de eliminar este producto?")) { 

    console.log("🗑️ Eliminando producto con ID:", id); 

    const res = await fetch(`${apiUrl}/${id}`, { 

      method: "DELETE" 

    }); 

 
 

    const result = await res.text(); 

    if (res.ok) { 

      console.log("✅ Producto eliminado:", result); 

      alert("🗑️ Producto eliminado correctamente"); 

      await cargarProductos(); 

    } else { 

      console.error("❌ Error al eliminar producto:", result); 

      alert("❌ Error al eliminar producto:\n" + result); 

    } 

  } 

} 

 
 

document.addEventListener("DOMContentLoaded", function () { 

  console.log("📄 Documento cargado. Iniciando carga de productos..."); 

  cargarProductos(); 

  document.getElementById("form-crear").addEventListener("submit", crearProducto); 

}); 