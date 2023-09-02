import { ReactElement } from "react";

export default function Anchor(props: anchorProps) {
  return (
    <>
      {/* <a href={props.url} className="btn btn-primary">
        {props.children}
      </a> */}
    </>
  );
}

interface anchorProps {
  children: ReactElement;
  url: ReactElement;
}
