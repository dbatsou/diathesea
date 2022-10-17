import SemanticDatepicker from "react-semantic-ui-datepickers";
import { Button, Container, Form, TextArea } from "semantic-ui-react";
import { StateFormFormatted } from "../../app/models/state";

interface Props {
  states: StateFormFormatted[];
}

const StateEntryInput = ({ states }: Props) => (
  <Container>
    <Form>
      <SemanticDatepicker />

      <Form.Select options={states} placeholder="State" />
      <TextArea placeholder="Tell us more" />
      <Button
        floated="right"
        content="Save"
        color="green"
        style={{ marginTop: "1em" }}
      />
    </Form>
  </Container>
);

export default StateEntryInput;
