import { NavLink, useNavigate } from "react-router-dom";
import { Container, Menu } from "semantic-ui-react";
import { useStore } from "../stores/store";
import Utils from "../helpers/visibilityHelper";
import { observer } from "mobx-react-lite";
export default observer(function NavBar() {
  const { authStore } = useStore();
  const { isLoggedIn, logout } = authStore;
  const navigate = useNavigate();

  function handleLogout() {
    logout();
    navigate("/");
  }
  return (
    <Container>
      <Menu size="large" inverted fixed="top">
        <Menu.Item header as={NavLink} to={isLoggedIn ? "/history" : "/"}>
          diathesea
        </Menu.Item>

        <Menu.Item
          as={NavLink}
          to="/register"
          style={{ display: Utils.isVisible(!isLoggedIn) }}
        >
          Register
        </Menu.Item>
        <Menu.Item
          as={NavLink}
          to="/state/new"
          style={{ display: Utils.isVisible(isLoggedIn) }}
        >
          New
        </Menu.Item>
        <Menu.Item
          as={NavLink}
          to="/history"
          style={{ display: Utils.isVisible(isLoggedIn) }}
        >
          History
        </Menu.Item>
        <Menu.Item
          // as={NavLink}
          onClick={handleLogout}
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
