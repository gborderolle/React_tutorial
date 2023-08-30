// Contenido dinámico con las calificaciones
// Clase 46: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25789636#overview

export default function ContenidoDinamico(props: any) {
  //Ejemplo 1: operador ternario (:)
  // return (
  //     <div>
  //         {props.mostrarMensajeSecreto ? <span>Mensaje secreto: 42</span> : null}
  //     </div>
  // )

  //Ejemplo 2: ifs
  let textoGeneral = `La calificación de ${props.nombre} es ${props.calificacion}`;
  if (props.calificacion > 90) {
    return <h3 style={{ color: "green" }}>{textoGeneral}</h3>;
  } else if (props.calificacion >= 80 && props.calificacion <= 90) {
    return <h3 style={{ color: "yellow" }}>{textoGeneral}</h3>;
  } else if (props.calificacion >= 0 && props.calificacion <= 80) {
    return <h3 style={{ color: "red" }}>{textoGeneral}</h3>;
  } else {
    throw `** Hubo un error con la calificación de ${props.nombre}`;
  }
}
