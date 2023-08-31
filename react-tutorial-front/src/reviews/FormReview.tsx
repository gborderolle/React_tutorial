import { Form, Formik, FormikHelpers } from "formik";
import FormGroupText from "../utils/FormGroupText";
import * as Yup from 'yup';
import { reviewCreationDTO } from "../reviews/review.model";

export default function FormReview(props: formReviewProps) {
    return (

        <Formik
            initialValues={{
                name: "",
            }}

            onSubmit={props.onSubmit}

            validationSchema={Yup.object({
                name: Yup.string()
                    .required('Dato requerido.')
                    .firstCharCapitalization()
            })}
        >

            {(formikProps) => (
                <Form>
                    <FormGroupText buttonDisabled={formikProps.isSubmitting} formName="Crear review" field="name" label="Nombre" navigation="/reviews" />
                </Form>
            )}

        </Formik>

    )
}

interface formReviewProps {
    model: reviewCreationDTO;
    onSubmit(values: reviewCreationDTO, action: FormikHelpers<reviewCreationDTO>): void;

}