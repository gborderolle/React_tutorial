import { Field, Formik, Form, ErrorMessage } from "formik";
import * as Yup from "yup";
import FormGroupText from "../utils/FormGroupText";
import FormActor from "./FormActor";

export default function CreateActor() {
  return (
    <>
      <FormActor
        formName="Crear actor"
        model={{ name: "", born: new Date() }}
        onSubmit={async (values) => {
          console.log(values);
        }}
      />
    </>
  );
}
