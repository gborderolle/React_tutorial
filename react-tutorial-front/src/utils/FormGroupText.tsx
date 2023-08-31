import { Field, ErrorMessage } from "formik";
import { Link } from "react-router-dom";
import Button from "./Button";
import ShowErrorField from "./ShowErrorField";

export default function FormGroupText(props: formGroupTextProps) {
    return (

        <div className="mt-4">
            <div className="card text-white bg-secondary mb-3" style={{ maxWidth: "18rem" }}>
                <div className="card-header"><h3>{props.formName}</h3></div>
                <div className="card-body">
                    {props.label ? <h5 className="card-title">{props.label}</h5> : null}
                    <Field name={props.field} className="form-control" />
                    <ErrorMessage name={props.field}>{(msg: string) =>
                        <ShowErrorField message={msg} />
                    }
                    </ErrorMessage>
                    <br />

                    <div className="btn-group" role="group" aria-label="First group">
                        <Button type="submit" buttonDisabled={props.buttonDisabled}>Guardar</Button>
                        {props.navigation ? (
                            <Link className="btn btn-sm btn-secondary" to={props.navigation}>
                                Cancelar
                            </Link>
                        ) : null}
                    </div>
                </div>
            </div>
        </div>

    )
}

// define los parámetros de entrada del componente
interface formGroupTextProps {
    formName: string;
    field: string;
    label?: string;
    placeholder?: string;
    navigation?: string;
    buttonDisabled?: boolean;
}