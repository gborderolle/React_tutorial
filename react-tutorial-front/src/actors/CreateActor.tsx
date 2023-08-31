import { Field, Formik, Form, ErrorMessage } from "formik";
import * as Yup from "yup";
import FormGroupText from "../utils/FormGroupText";
import FormActor from "./FormActor";

export default function CreateActor() {
  return (
    <>
      <FormActor
        model={{ name: "", born: new Date() }}
        buttonDisabled
        onSubmit={async (values) => {
          console.log(values);
        }}
      />
    </>
  );
}
