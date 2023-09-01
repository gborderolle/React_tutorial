import { Field, ErrorMessage } from "formik";
import { Link } from "react-router-dom";
import Button from "./Button";
import ShowErrorField from "./ShowErrorField";

export default function FormGroupText(props: formGroupTextProps) {
    return (

        <>
            {props.label ? <h5 className="card-title">{props.label}</h5> : null}
            <Field name={props.field} className="form-control" />
            <ErrorMessage name={props.field}>{(msg: string) =>
                <ShowErrorField message={msg} />
            }
            </ErrorMessage>
            <br />
        </>

    )
}

// define los parámetros de entrada del componente
interface formGroupTextProps {
    formName: string;
    field: string;
    label?: string;
    placeholder?: string;
}