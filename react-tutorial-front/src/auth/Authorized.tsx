// Clase 152: https://www.udemy.com/course/desarrollando-aplicaciones-en-react-y-aspnet-core/learn/lecture/26118756#notes

import { useContext, useEffect, useState } from "react";
import { ReactElement } from "react-markdown/lib/react-markdown";
import AuthenticationContext from "./AuthenticationContext";

export default function Authorized(props: authorizedProps) {
  const [isAuthorized, setIsAuthorized] = useState(false);
  const { claims } = useContext(AuthenticationContext);

  useEffect(() => {
    if (props.role) {
      const index = claims.findIndex(
        (claim) => claim.name === "role" && claim.value === props.role
      );
      setIsAuthorized(index > -1);
    } else {
      setIsAuthorized(claims.length > 0);
    }
  }, [claims, props.role]);

  return <>{isAuthorized ? props.authorized : props.unauthorized}</>;
}

interface authorizedProps {
  authorized: ReactElement;
  unauthorized?: ReactElement;
  role?: string;
}
