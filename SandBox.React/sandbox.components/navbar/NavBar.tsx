import {Alignment, Button, Navbar} from "@blueprintjs/core";

import "normalize.css/normalize.css";
import "@blueprintjs/icons/lib/css/blueprint-icons.css";
import "@blueprintjs/core/lib/css/blueprint.css";

interface NavBarProps {
  heading: string,
}

export const NavBar = (
  {
    heading = '',
    ...props
  }: NavBarProps
) => {
  return (
    <Navbar
      {...props}
    >
      <Navbar.Group align={Alignment.LEFT}>
        <Navbar.Heading>{heading}</Navbar.Heading>
        <Navbar.Divider/>
        <Button className="bp4-minimal" icon="home" text="Home"/>
        <Button className="bp4-minimal" icon="document" text="Files"/>
      </Navbar.Group>
    </Navbar>
  );
}
