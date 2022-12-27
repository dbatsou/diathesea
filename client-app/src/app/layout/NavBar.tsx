import { NavLink } from "react-router-dom";
import { Container, Menu } from "semantic-ui-react";

export default function NavBar() {
  return (
    <Container>
      <Menu size="large" inverted fixed="top">
        <Menu.Item header as={NavLink} to="/">
          diathesea
        </Menu.Item>
        <Menu.Item header as={NavLink} to="/state/new">
          New
        </Menu.Item>
        <Menu.Item header as={NavLink} to="/history">
          History
        </Menu.Item>
        <Menu.Item header as={NavLink} to="/buggy">
          Buggy
        </Menu.Item>
        {/* <Menu.Item name="States" /> */}
        {/* <Menu.Item name="History" /> */}
        {/* <Menu.Item name="Activites" /> */}
      </Menu>
    </Container>
  );
}
