import { observer } from "mobx-react-lite";
import { ChangeEvent, useState } from "react";
import { useNavigate } from "react-router-dom";
import { Button, Form, Grid, Header, Segment } from "semantic-ui-react";
import { RegisterModel } from "../../app/models/registerModel";
import { useStore } from "../../app/stores/store";

export default observer(function Register() {
  const { authStore } = useStore();
  const { register } = authStore;
  const [registerModel, setRegisterModel] = useState<RegisterModel>();
  const navigate = useNavigate();

  async function onSubmit() {
    await register(registerModel!);
    navigate("/login");
  }

  function handleInputChange(event: ChangeEvent<HTMLInputElement>) {
    const { name, value } = event.target;
    handleSetAuthModel(name, value);
  }

  function handleSetAuthModel(name: string, value: string) {
    setRegisterModel({
      ...registerModel,
      [name]: value,
    });
  }

  return (
    <Grid textAlign="center" style={{ height: "100vh" }} verticalAlign="middle">
      <Grid.Column style={{ maxWidth: 450 }}>
        <Header as="h2" textAlign="center">
          Register your account
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

            <Form.Input
              fluid
              icon="lock"
              iconPosition="left"
              placeholder="Verify Password"
              type="password"
              name="repeatpassword"
              onChange={handleInputChange}
            />

            <Button color="green" fluid size="large" disabled={false}>
              Register
            </Button>
          </Segment>
        </Form>
      </Grid.Column>
    </Grid>
  );
});
