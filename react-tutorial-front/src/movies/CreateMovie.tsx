import FormMovie from "./FormMovie";

export default function CreateMovie() {
  return (
    <>
      <FormMovie
        formName="Crear película"
        model={{ title: '', onCinema:true }}
        onSubmit={async (values) => {
          await new Promise(r => setTimeout(r, 1000))
          console.log(values);
        }}
      />
    </>
  )
}
