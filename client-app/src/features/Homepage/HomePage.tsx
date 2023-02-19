import { Container } from "semantic-ui-react";
import Login from "../Login/Login";
import Register from "../Register/Register";

export default function HomePage() {
  return (
    <Container>
      {/* <h1>Hello, is there anybody out there?</h1>
       */}
      <Login />
      {/* <Register /> */}
    </Container>
  );
}
