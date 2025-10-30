# ⚖️ Certe.Result

**Certe.Result** es una implementación moderna, extensible y strongly-typed del patrón **Result**, diseñada para separar con claridad los flujos de éxito y error dentro de una aplicación.  
Su enfoque permite expresar resultados de dominio, errores y datos complejos (como sets o paginados) sin depender de frameworks externos.

---

## 🚀 Características principales

- ✅ Implementación simple y pura de `Result` y `Result<T>`
- 🔁 Soporte para estructuras tipadas mediante `IResultSet`
- ⚙️ Estructuras de datos listas: `SimpleResultSet`, `PagedResultSet`
- 🧱 Extensiones `Match()` y `Match<T>()` para flujos funcionales
- 💬 Modelo de errores enriquecido (`Error` con código, mensaje y detalle)
- 🔒 Independiente de HTTP, ASP.NET o cualquier framework web
- 🧩 Fácilmente integrable con una futura capa `Certe.Result.AspNet`

---

## 📦 Instalación

bash
dotnet add package Certe.Result