import { Form, Formik, FormikHelpers } from "formik";
import FormGroupText from "../utils/FormGroupText";
import * as Yup from "yup";
import { actorCreationDTO } from "./actor.model";
import FormGroupDate from "../utils/FormGroupDate";
import { Link } from "react-router-dom";
import Button from "../utils/Button";

export default function FormActor(props: formActorProps) {
  return (
    <Formik
      initialValues={props.model}
      onSubmit={props.onSubmit}
      validationSchema={Yup.object({
        name: Yup.string()
          .required("Dato requerido.")
          .firstCharCapitalization(),
      })}
    >
      {(formikProps) => (
        <Form>
          <FormGroupText
            buttonDisabled={formikProps.isSubmitting}
            formName="Modificar actor"
            field="name"
            label="Nombre"
            navigation="/actors"
          />
          <FormGroupDate label="Fecha de nacimiento" field="born" />

          <div className="btn-group" role="group" aria-label="First group">
            <Button type="submit" buttonDisabled={props.buttonDisabled}>
              Guardar
            </Button>
            {props.navigation ? (
              <Link className="btn btn-sm btn-secondary" to={props.navigation}>
                Cancelar
              </Link>
            ) : null}
          </div>
        </Form>
      )}
    </Formik>
  );
}

interface formActorProps {
  buttonDisabled: boolean | undefined;
  navigation: any;
  model: actorCreationDTO;
  onSubmit(
    values: actorCreationDTO,
    action: FormikHelpers<actorCreationDTO>
  ): void;
}
