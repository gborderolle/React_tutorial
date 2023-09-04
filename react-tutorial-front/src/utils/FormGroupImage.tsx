import { error } from "console";
import { useFormikContext } from "formik";
import { ChangeEvent, useState } from "react";

export default function FormGroupImage(props: formGroupImageProps) {

    const [imageURL, setImageURL] = useState('');
    const [imageBase64, setImageBase64] = useState(props.imageURL);

    const { values } = useFormikContext<any>();

    const onChangeEvent = (e: ChangeEvent<HTMLInputElement>) => {
        if (e.currentTarget.files) {
            const file = e.currentTarget.files[0];
            toBase64(file)
                .then((base64: string) => setImageBase64(base64))
                .catch(error => console.error(error))

            values[props.field] = file;
            setImageURL('');
        }
    }

    const toBase64 = (file: File) => {
        return new Promise<string>((resolve, reject) => {
            const reader = new FileReader();
            reader.readAsDataURL(file);
            reader.onload = () => resolve(reader.result as string);
            reader.onerror = (error) => reject(error);
        })
    }

    return (
        <>
            <div className="form-group">
                <label htmlFor={props.label}></label>
                <div>
                    <input type="file" accept=".jpg, .jpeg, .png" onChange={onChangeEvent} className="form-control" />
                </div>
                {imageBase64 ? (
                    <div className="mt-3">
                        <img src={imageBase64} className="img-fluid rounded" alt="Imagen seleccionada" />
                    </div>
                ) : null}

                {imageURL ? (
                    <div className="mt-3">
                        <img src={imageURL} className="img-fluid rounded" alt="Imagen seleccionada" />
                    </div>
                ) : null}
            </div>
        </>
    )
}

interface formGroupImageProps {
    field: string;
    label: string;
    imageURL?: string;
}

FormGroupImage.defaultProps = {
    imageURL: ''
}
