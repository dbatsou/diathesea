import { observer } from "mobx-react-lite";
import { ChangeEvent, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Form, Grid, Header, Segment } from "semantic-ui-react";
import { AuthenticationModel } from "../../app/models/authenticationModel";
import { useStore } from "../../app/stores/store";

export default observer(function Login() {
  const { authStore } = useStore();
  const { login } = authStore;
  const [authModel, setAuthModel] = useState<AuthenticationModel>();
  const navigate = useNavigate();

  async function onSubmit() {
    await login(authModel!);
    navigate("/history");
  }

  function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
    const { name, value } = event.target;
    handleSetAuthModel(name, value);
  }

  function handleSetAuthModel(name: string, value: string) {
    setAuthModel({
      ...authModel,
      [name]: value,
    });
  }

  return (
    <Grid textAlign="center" style={{ height: "100vh" }} verticalAlign="middle">
      <Grid.Column style={{ maxWidth: 450 }}>
        <Header as="h2" textAlign="center">
          Log-in to your account
        </Header>
        <Form size="large" onSubmit={onSubmit}>
          <Segment stacked>
            <Form.Input
              fluid
              icon="user"
              iconPosition="left"
              placeholder="Username"
              name="username"
              onChange={handleInputChange}
            />
            <Form.Input
              fluid
              icon="lock"
              iconPosition="left"
              placeholder="Password"
              type="password"
              name="password"
              onChange={handleInputChange}
            />

            <Button color="green" fluid size="large" type="submit">
              Login
            </Button>
          </Segment>
        </Form>
      </Grid.Column>
    </Grid>
  );
});
