import { Field, Formik, Form, ErrorMessage } from "formik";
import * as Yup from 'yup';
import FormGroupText from "../utils/FormGroupText";
import FormMovie from "./FormMovie";

export default function CreateMovie() {
  return <>
    <FormMovie model={{ title: '' }}
        onSubmit={async (values) => {
          await new Promise(r => setTimeout(r, 1000))
          console.log(values);
        }}
      />
  </>;
}
