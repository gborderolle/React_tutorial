// Comunicación hijo padre
// Clase 47: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25789860#overview

export default function FormularioTexto(props: formularioTextoProps) {
  return (
    <>
      <div className="form-group">
        <input
          type="text"
          className="form-control"
          onKeyUp={(e) => props.manejarKeyUpTitulo(e.currentTarget.value)}
          id="exampleInputEmail1"
          placeholder="Título"
        />
      </div>
    </>
  );
}

interface formularioTextoProps {
  manejarKeyUpTitulo(texto: string): void;
}
