// Pasar parámetros a componentes: props
// Clase 41: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25779062#overview

// Parámetros opcionales y default
// Clase 43: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25788104#overview

export default function MostrarTexto(props: any) {
  return <div>{props.texto}</div>;
}

interface MostrarTextoProps {
  texto?: string; //opcional, se omite por defecto
}

MostrarTexto.defaultProps = {
  texto: "valor por defecto defaultsProp",
};
