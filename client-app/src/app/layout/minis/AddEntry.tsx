import { Button, Segment } from "semantic-ui-react";

export default function AddEntry() {
  return (
    <Segment basic textAlign="center">
      <Button circular color="green">
        Add new entry
      </Button>
    </Segment>
  );
}
