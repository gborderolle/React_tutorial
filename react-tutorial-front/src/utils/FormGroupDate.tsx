// Manejando fechas
// Clase 79: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/25918556#overview

import { useFormikContext } from "formik";
import ShowErrorField from "./ShowErrorField";

export default function FormGroupDate(props: formGroupDateProps) {
  const { values, validateForm, touched, errors } = useFormikContext<any>();
  return (
    <div className="form-group">
      <label htmlFor={props.field}>{props.label}</label>
      <input
        type="date"
        className="form-control"
        id={props.field}
        name={props.field}
        // defaultValue={values[props.field]?.toLocaleDateString("en-CA")}
        defaultValue={
          values[props.field]
            ? values[props.field].toLocaleDateString("en-CA")
            : ""
        }
        onChange={(e) => {
          const date = new Date(e.currentTarget.value + "T00:00:00");
          values[props.field] = date;
          validateForm();
        }}
      />
      {touched[props.field] && errors[props.field] ? (
        <ShowErrorField message={errors[props.field]?.toString()} />
      ) : null}
    </div>
  );
}

interface formGroupDateProps {
  field: string;
  label: string;
}
