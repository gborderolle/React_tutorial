import FormCinema from "./FormCinema";

export default function CreateCinema() {
  return (
    <>
      <FormCinema
        formName="Crear cine"
        model={{ name: '' }}
        onSubmit={async (values) => {
          await new Promise(r => setTimeout(r, 1000))
          console.log(values);
        }}
      />
    </>
  )
}