// Clase 115: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25991890#overview
export default function ShowErrors(props: showErrorsProps) {
  const style = { color: "red" };

  if (!Array.isArray(props.errors)) {
    console.error('ShowErrors component received a non-array prop:', props.errors);
    return null;
  }

  return (
    <>
      {props.errors.length > 0 ? (
        <ul style={style}>
          {props.errors.map((error, index) => (
            <li key={index}>{error}</li>
          ))}
        </ul>
      ) : null}
    </>
  );
}

interface showErrorsProps {
  errors: string[];
}
