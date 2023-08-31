import { Field, Formik, Form, ErrorMessage } from "formik";
import * as Yup from 'yup';
import FormGroupText from "../utils/FormGroupText";
import FormReview from "./FormReview";

export default function CreateReview() {
  return <>
  <FormReview model={{ name: '' }}
        onSubmit={async (values) => {
          await new Promise(r => setTimeout(r, 1000))
          console.log(values);
        }}
      />
  </>;
}
