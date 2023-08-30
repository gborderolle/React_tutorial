// Proyectar contenido ("RenderBody()")
// Clase 42: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25779486#overview
import { ReactElement } from "react";

export default function ProyectarContenido2(props: proyectarContenido2Prop) {
  return (
    <>
      La parte 1: {props.parte1 ? props.parte1 : <h3>Contenido por defecto</h3>}
      <hr />
      {props.parte2}
      <hr />
      {props.parte3}
    </>
  );
}

interface proyectarContenido2Prop {
  parte1?: ReactElement;
  parte2?: ReactElement;
  parte3?: ReactElement;
}
