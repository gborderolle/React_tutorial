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
        return (<h3 style={{ color: 'green' }}>{textoGeneral}</h3>)
    } else if (props.calificacion >= 80 && props.calificacion <= 90) {
        return (<h3 style={{ color: 'yellow' }}>{textoGeneral}</h3>)
    } else {
        return (<h3 style={{ color: 'red' }}>{textoGeneral}</h3>)
    }
}