export default function MostrarTexto(props: any) {
    return (
        <div>
            {props.texto}
        </div>
    )
}

interface MostrarTextoProps{
    texto?: string; //opcional, se omite por defecto
}

MostrarTexto.defaultProps ={
    texto: 'valor por defecto defaultsProp'
}