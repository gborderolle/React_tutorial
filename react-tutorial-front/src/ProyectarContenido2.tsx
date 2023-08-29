import { ReactElement } from "react";

export default function ProyectarContenido2(props: proyectarContenido2Prop) {
    return (
        <>
            La parte 1: {props.parte1 ? props.parte1:<h3>Contenido por defecto</h3>}
            <hr/>
            {props.parte2}
            <hr/>
            {props.parte3}
        </>
    )
}

interface proyectarContenido2Prop {
    parte1?: ReactElement;
    parte2?: ReactElement;
    parte3?: ReactElement;
}