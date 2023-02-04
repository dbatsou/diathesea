import { NavLink } from "react-router-dom";
import { Container, Grid, Menu, Segment } from "semantic-ui-react";
import { useStore } from "../stores/store";
import Utils from "../helpers/visibilityHelper";
import { observer } from "mobx-react-lite";
export default observer(function NavBar() {
  const { authStore } = useStore();
  const { isLoggedIn } = authStore;

  return (
    <Container>
      <Menu size="large" inverted fixed="top">
        <Menu.Item header as={NavLink} to="/">
          diathesea
        </Menu.Item>
        <Menu.Item
          header
          as={NavLink}
          to="/state/new"
          style={{ display: Utils.isVisible(isLoggedIn) }}
        >
          New
        </Menu.Item>
        <Menu.Item
          header
          as={NavLink}
          to="/history"
          style={{ display: Utils.isVisible(isLoggedIn) }}
        >
          History
        </Menu.Item>
        <Menu.Item
          header
          as={NavLink}
          style={{ display: Utils.isVisible(isLoggedIn) }}
        >
          Logout
        </Menu.Item>
        {/* <Menu.Item name="States" /> */}
        {/* <Menu.Item name="History" /> */}
        {/* <Menu.Item name="Activites" /> */}
      </Menu>
    </Container>
  );
});
