export default function Button(props: buttonProps) {
  return (
    <button
      type={props.type}
      className="btn btn-sm btn-primary"
      onClick={props.onClick}
      disabled={props.buttonDisabled}
    >
      {props.children}
    </button>
  );
}

interface buttonProps {
  children: React.ReactNode;
  onClick?(): void;
  type: "button" | "submit";
  buttonDisabled?: boolean;
}

Button.defaultProps = {
  type: "button",
  disabled: false,
};
