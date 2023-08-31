import { Field, Formik, Form, ErrorMessage } from "formik";
import * as Yup from 'yup';
import FormGroupText from "../utils/FormGroupText";
import FormCinema from "./FormCinema";

export default function CreateCinema() {
  return (
    <>
      <FormCinema model={{ name: '' }}
        onSubmit={async (values) => {
          await new Promise(r => setTimeout(r, 1000))
          console.log(values);
        }}
      />
    </>
  )
}