import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { useEffect, useState } from "react";

export default function Rating(props: ratingProps) {
    const [maxValueArr, setMaxValueArr] = useState<number[]>([]);

    useEffect(() => {
        setMaxValueArr(Array(props.maxValue).fill(0));
    }, [props.maxValue])

    return (
        <>
            {
                maxValueArr.map((value, index) =>
                    <FontAwesomeIcon
                        icon="star"
                        key={index}
                        className={'fa-lg pointer'}
                    />
                )
            }
        </>
    )

}
interface ratingProps {
    maxValue: number;
    selectedValue: number;
    onChange(vote: number): void;
}