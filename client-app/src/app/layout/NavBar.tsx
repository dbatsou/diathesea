import React from "react";
import { Container, Dropdown, Menu } from "semantic-ui-react";

export default function NavBar() {
  return (
    <Menu size="large" inverted fixed="top">
      <Container>
        <Menu.Item header>diathesea</Menu.Item>
        <Menu.Item name="States" />
        <Menu.Item name="History" />
        <Menu.Item name="Activites" />
      </Container>
    </Menu>
    // <Menu size="large" inverted fixed="top">
    //   <Dropdown item text="Categories">
    //     <Dropdown.Menu>
    //       <Dropdown.Item>Electronics</Dropdown.Item>
    //       <Dropdown.Item>Automotive</Dropdown.Item>
    //       <Dropdown.Item>Home</Dropdown.Item>
    //     </Dropdown.Menu>
    //   </Dropdown>
    // </Menu>
  );
}
